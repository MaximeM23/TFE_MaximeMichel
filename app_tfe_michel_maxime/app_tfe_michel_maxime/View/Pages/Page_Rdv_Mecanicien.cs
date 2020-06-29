using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public partial class Page_Rdv_Mecanicien : UserControl
    {
        #region Event de déplacement de l'application
        Point DernierClic;
        bool dragging;
        private void Page_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            DernierClic = e.Location;
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ParentForm.Left += e.X - DernierClic.X;
                    ParentForm.Top += e.Y - DernierClic.Y;
                }
            }
        }

        private void Page_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion

        bool RechargementApresModification = false;

        private GenerationFacturePDF GenerationDocumentsPDF = new GenerationFacturePDF();

        public Page_Rdv_Mecanicien()
        {
            InitializeComponent();
            CalendrierRdv.Facture = Program.GMBD.EnumererFacture(
            null,
            new MyDB.CodeSql(@" JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut
                                JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                JOIN adresse ON client.fk_id_adresse = adresse.id_adresse 
                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
            new MyDB.CodeSql("WHERE date_debut BETWEEN {0} AND {1} OR date_fin BETWEEN {0} AND {1}", DateTime.Today, DateTime.Today.AddHours(24)),
            new MyDB.CodeSql("ORDER BY facture.id_facture"));

            CalendrierRdv.SurChangementSelection += FormCalendrier_ChangementSelectionClient;
            ClientVehicule.ActivationButtonSurChangementSelection += ClientVehicule_SurChangementVehiculeActif;
            ClientVehicule.RafraichirApresModification += ClientVehicule_RafraichirApresModification;          

            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
            dateTimePickerArrivee.Format = DateTimePickerFormat.Custom;
            dateTimePickerArrivee.CustomFormat = "yyyy/MM/dd HH:mm:ss";
            dateTimePickerFin.Format = DateTimePickerFormat.Custom;
            dateTimePickerFin.CustomFormat = "yyyy/MM/dd HH:mm:ss";

            entretiens.Visible = false;
            entretiens.RefreshApresAction += RefreshListeEntretiens;
            listeDeroulanteEntretien.SurChangementSelection += ListeDeroulanteEntretien_SurChangementSelection;

            this.MinimumSize = new Size(1300, 750);

        }

        private void ListeDeroulanteEntretien_SurChangementSelection(object sender, EventArgs e)
        {
            if (listeDeroulanteEntretien.EntretienSelectionne != null)
            {
                FactureEntretien EntretienReference = Program.GMBD.EnumererFactureEntretien(null, null, new MyDB.CodeSql("WHERE fk_id_entretien = {0}", listeDeroulanteEntretien.EntretienSelectionne.Id), null).FirstOrDefault();
                if (EntretienReference != null)
                {
                    pictureBoxModifierEntretien.Enabled = false;
                }
                else
                {
                    pictureBoxModifierEntretien.Enabled = true;
                }
            }
        }

        /// <summary>
        /// S'active au moment d'une nouvelle sélection ou d'une première sélection sur mon userControl de calendrier
        /// </summary>
        private void FormCalendrier_ChangementSelectionClient(object sender, EventArgs e)
        {
            if (CalendrierRdv.FactureSelectionnee != null)
            {
                if (!RechargementApresModification)
                {
                    errorProvider.Clear();
                    ValidationProvider.Clear();
                }
                ClientVehicule.DesactiverListeClient = false;
                buttonReactualiser.Enabled = true;
                ClientVehicule.ClientSelectionneCalendrier = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule;
                ClientVehicule.ListeDeroulante_ChangementClient(sender,e);
                dateTimePickerArrivee.Value = CalendrierRdv.FactureSelectionnee.RendezVous.DateDebut;
                dateTimePickerFin.Value = CalendrierRdv.FactureSelectionnee.RendezVous.DateFin;
                listeDeroulanteEntretien.EntretienSelectionne = Program.GMBD.EnumererEntretien(null, new MyDB.CodeSql("JOIN facture_entretien ON entretien.id_entretien = facture_entretien.fk_id_entretien"), new MyDB.CodeSql("WHERE fk_id_facture = {0}", CalendrierRdv.FactureSelectionnee.Id), null).FirstOrDefault();
                
               // Si mon statut correspond à "En attente" et est différent de "Terminé" et que la date de début du rendez-vous est supérieure à la date du jour
                if((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "En attente")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé") 
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.DateDebut > DateTime.Now))
                {
                    buttonReactiveRdv.Enabled = false;
                    buttonAnnulationRendezvous.Enabled = true;
                    buttonAjouter.Enabled = false;
                    buttonModifier.Enabled = true;
                    buttonImprimerLaFacture.Enabled = false;
                }
                // Si mon statut correspond à "Annuler" et est différent de "Terminé" et que la date de début du rendez-vous est supérieure à la date du jour
                else if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "Annuler")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé") 
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.DateDebut > DateTime.Now))
                {
                    buttonReactiveRdv.Enabled = true;
                    buttonAnnulationRendezvous.Enabled = false;
                    buttonAjouter.Enabled = false;
                    buttonModifier.Enabled = true;
                    buttonImprimerLaFacture.Enabled = false;
                }
                // Si mon statut correspond à "Annuler" et que la date de début du rendez-vous est inférieure à la date du jour
                else if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "Annuler") && (CalendrierRdv.FactureSelectionnee.RendezVous.DateDebut < DateTime.Now))
                {
                    ClientVehicule.ButtonModifier = false;
                    ClientVehicule.ButtonAjouter = false;
                    buttonModifier.Enabled = false;
                    buttonAjouter.Enabled = false;
                    buttonAnnulationRendezvous.Enabled = false;
                    buttonImprimerLaFacture.Enabled = false;
                }
                // Si la réparation et/ou l'entretien sont terminés
                else if (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "Terminé")
                {
                    ClientVehicule.ButtonModifier = false;
                    ClientVehicule.ButtonAjouter = false;
                    buttonModifier.Enabled = false;
                    buttonAjouter.Enabled = false;
                    buttonAnnulationRendezvous.Enabled = false;
                    buttonImprimerLaFacture.Enabled = true;
                }
                else
                {
                    buttonImprimerLaFacture.Enabled = false;
                }
                if (CalendrierRdv.FactureSelectionnee.Informations != "")
                {
                    textBoxInfoReparation.Enabled = true;
                    checkBoxReparation.Checked = true;
                    textBoxInfoReparation.Text = CalendrierRdv.FactureSelectionnee.Informations;
                }
                else
                {
                    textBoxInfoReparation.Enabled = false;
                    checkBoxReparation.Checked = false;
                    textBoxInfoReparation.Text = "";
                }

                Facture ClientDejaReference = Program.GMBD.EnumererFacture(null, new MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                    JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut"),
                                                                                new MyDB.CodeSql("WHERE rendez_vous_entretien_reparation.fk_id_client_vehicule = {0} AND (statut.statut = \"Terminé\" OR statut.statut != \"Annuler\")", ClientVehicule.ClientVehiculeEnCoursDeTraitement.Id),null).FirstOrDefault();
                if(ClientDejaReference != null)
                {
                    ClientVehicule.DesactiverTextBoxImmatriculation = false;
                    ClientVehicule.DesactiverTextBoxNumChassis = false;
                    ClientVehicule.DesactiverListeModele = false;
                }
                else
                {
                    ClientVehicule.DesactiverTextBoxImmatriculation = true;
                    ClientVehicule.DesactiverTextBoxNumChassis = true;
                    ClientVehicule.DesactiverListeModele = true;
                }

                RechargementApresModification = false;
            }
        }

        private void PageRdvMecanicien_Load(object sender, EventArgs e)
        {
            listeDeroulanteEntretien.Entretien = Program.GMBD.EnumererEntretien(null, null, new MyDB.CodeSql("WHERE disponible = 1"), null);
            if (Form_Principal.Employe.Statut.NomStatut == "Administrateur")
            {
                pictureBoxAjouterEntretien.Visible = true;
                pictureBoxModifierEntretien.Visible = true;
                pictureBoxSupprimerEntretien.Visible = true;
            }
            else
            {
                pictureBoxAjouterEntretien.Visible = false;
                pictureBoxModifierEntretien.Visible = false;
                pictureBoxSupprimerEntretien.Visible = false;
                listeDeroulanteEntretien.Width = dateTimePickerArrivee.Width;
            }

        }

        private void formulaire_ClientVehicule1_Load(object sender, EventArgs e)
        {
            ClientVehicule.ChargerDonneesListView();
        }

        private void checkBoxReparation_Click(object sender, EventArgs e)
        {
            if (checkBoxReparation.Checked == true) textBoxInfoReparation.Enabled = true;
            else textBoxInfoReparation.Enabled = false;
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if ((ClientVehicule.ClientVehiculeEnCoursDeTraitement != null) && (ClientVehicule.ClientVehiculeEnCoursDeTraitement.Immatriculation != ""))
            {
                Facture NouvelleFacture = new Facture();
                NouvelleFacture.RendezVous = new RendezVousEntretienReparation();
                NouvelleFacture.SurErreur += FactureEnEdition_SurErreur;

                Facture DerniereFacture = Program.GMBD.EnumererFacture(null, null, null, new MyDB.CodeSql("ORDER BY id_facture DESC")).FirstOrDefault();

                if (DerniereFacture != null)
                {
                    NouvelleFacture.NumeroFacture = string.Format("er{0}-{1}", DateTime.Now.Year, DerniereFacture.Id);
                }
                else
                {
                    NouvelleFacture.NumeroFacture = string.Format("er{0}-1", DateTime.Now.Year);
                }

                if (checkBoxReparation.Checked == true)
                {
                    NouvelleFacture.Informations = textBoxInfoReparation.Text;
                    NouvelleFacture.m_ReparationCoche = true;
                }
                else
                {
                    NouvelleFacture.Informations = "";
                    NouvelleFacture.m_ReparationCoche = false;
                }
                if ((NouvelleFacture.m_ReparationCoche == true) || (listeDeroulanteEntretien.EntretienSelectionne != null))
                {
                    NouvelleFacture.Commentaire = string.Empty;
                    NouvelleFacture.HeurePrestation = 0;
                    if (listeDeroulanteEntretien.EntretienSelectionne != null) NouvelleFacture.PrixTotal = listeDeroulanteEntretien.EntretienSelectionne.Prix;
                    else NouvelleFacture.PrixTotal = 0;
                    NouvelleFacture.RendezVous.DateDebut = dateTimePickerArrivee.Value;
                    NouvelleFacture.RendezVous.DateFin = dateTimePickerFin.Value;
                    if (ClientVehicule.ClientSelectionneCalendrier != null)
                    {
                        NouvelleFacture.RendezVous.ClientVehicule = ClientVehicule.ClientSelectionneCalendrier;
                    }
                    else if (ClientVehicule.ClientVehiculeEnCoursDeTraitement != null)
                    {
                        NouvelleFacture.RendezVous.ClientVehicule = ClientVehicule.ClientVehiculeEnCoursDeTraitement;
                    }
                    NouvelleFacture.RendezVous.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = {0}", "En attente"), null).FirstOrDefault();
                    if (dateTimePickerArrivee.Value < dateTimePickerFin.Value)
                    {
                        if ((NouvelleFacture.EstValide) && (NouvelleFacture.RendezVous.EstValide) && (Program.GMBD.AjouterRendezvous(NouvelleFacture.RendezVous)))
                        {
                            if (Program.GMBD.AjouterNouvelleFacture(NouvelleFacture))
                            {
                                if (listeDeroulanteEntretien.EntretienSelectionne != null)
                                {
                                    FactureEntretien EntretienLiee = new FactureEntretien(NouvelleFacture, listeDeroulanteEntretien.EntretienSelectionne);

                                    if (Program.GMBD.AjouterFactureEntretien(EntretienLiee))
                                    {
                                        CalendrierRdv.ChargerListViewRdv();
                                        ValidationProvider.Clear();
                                        ValidationProvider.SetError(buttonAjouter, "Le rendez-vous a été correctement ajouté");
                                    }
                                }
                                else if (checkBoxReparation.Checked == true)
                                {
                                    ValidationProvider.Clear();
                                    ValidationProvider.SetError(buttonAjouter, "Le rendez-vous a été correctement ajouté");
                                }
                            }

                            else
                            {
                                Program.GMBD.SupprimerRendezvous(NouvelleFacture.RendezVous);
                            }
                        }
                    }
                    else
                    {
                        errorProvider.SetError(dateTimePickerFin, "La date de fin ne peut pas être inférieure ou égale à la date d'arrivée");
                    }
                }
                else
                {
                    errorProvider.SetError(buttonAjouter, "Vous devez choisir un entretien ou une réparation à effectuer");
                }
            }
            else
            {
                errorProvider.SetError(buttonAjouter, "L'immatriculation doit être indiquée et validée");
            }                    
        }
        
        /// <summary>
        /// Méthode permettant de réagir sur l'erreur d'une édition de la partie "information" d'un rendez-vous
        /// </summary>
        private void FactureEnEdition_SurErreur(Facture Entite, Facture.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case Facture.Champs.Informations:
                    errorProvider.SetError(textBoxInfoReparation, MessageErreur);
                    break;
            }
        }

        /// <summary>
        /// Méthode permettant de réagir sur l'erreur d'une édition de la partie "dates" d'un rendez-vous
        /// </summary>
        private void RendezVousEnEdition_SurErreur(RendezVousEntretienReparation Entite, RendezVousEntretienReparation.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case RendezVousEntretienReparation.Champs.DateDebut:
                    errorProvider.SetError(textBoxInfoReparation, MessageErreur);
                    break;
                case RendezVousEntretienReparation.Champs.DateFin:
                    errorProvider.SetError(textBoxInfoReparation, MessageErreur);
                    break;
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (CalendrierRdv.FactureSelectionnee != null)
            {
                bool SuppressionEntretienLier = false;
                Entretien EntretienIndisponibleExiste = null;
                Facture FactureEnEdition = CalendrierRdv.FactureSelectionnee;
                FactureEnEdition.SurErreur += FactureEnEdition_SurErreur;
                FactureEnEdition.NumeroFacture = CalendrierRdv.FactureSelectionnee.NumeroFacture;
                if (checkBoxReparation.Checked == true) { FactureEnEdition.m_ReparationCoche = true; }
                else { textBoxInfoReparation.Text = ""; FactureEnEdition.m_ReparationCoche = false; }

                if ((checkBoxReparation.Checked == true) || (listeDeroulanteEntretien.EntretienSelectionne != null))
                {
                    FactureEnEdition.Commentaire = "";
                    FactureEnEdition.HeurePrestation = 0;
                    FactureEnEdition.Informations = textBoxInfoReparation.Text;
                    if (listeDeroulanteEntretien.EntretienSelectionne != null)
                    {
                        FactureEnEdition.PrixTotal = listeDeroulanteEntretien.EntretienSelectionne.Prix;
                    }
                    else if (listeDeroulanteEntretien.TextBoxNomEntretien.Length > 1)
                    {
                        int IndexDuTiretSeparateur = 0;
                        for (int i = listeDeroulanteEntretien.TextBoxNomEntretien.Length - 1; i > 0; i--)
                        {
                            if (listeDeroulanteEntretien.TextBoxNomEntretien[i] == ('-'))
                            {
                                IndexDuTiretSeparateur = i;
                                break;
                            }
                        }
                        int PrixEntretien = int.Parse(listeDeroulanteEntretien.TextBoxNomEntretien.Substring(IndexDuTiretSeparateur + 1, (listeDeroulanteEntretien.TextBoxNomEntretien.Length - 3) - IndexDuTiretSeparateur));
                        string NomEntretien = listeDeroulanteEntretien.TextBoxNomEntretien.Substring(0, IndexDuTiretSeparateur - 1);
                        EntretienIndisponibleExiste = Program.GMBD.EnumererEntretien(null, null, new MyDB.CodeSql("WHERE disponible = 0 AND type_entretien = {0} AND prix = {1}", NomEntretien.Trim(), PrixEntretien), null).FirstOrDefault();
                        FactureEnEdition.PrixTotal = 0;
                    }
                    else
                    {
                        SuppressionEntretienLier = true;
                        FactureEnEdition.PrixTotal = 0;
                    }
                    FactureEnEdition.RendezVous.DateDebut = dateTimePickerArrivee.Value;
                    FactureEnEdition.RendezVous.DateFin = dateTimePickerFin.Value;

                    if(ClientVehicule.ClientVehiculeEnCoursDeTraitement != CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule)
                    {
                        FactureEnEdition.RendezVous.ClientVehicule = ClientVehicule.ClientVehiculeEnCoursDeTraitement;
                    }
                    else
                    {
                        FactureEnEdition.RendezVous.ClientVehicule = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule;
                    }

                    FactureEnEdition.RendezVous.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = {0}", "En attente"), null).FirstOrDefault();
                    if (((listeDeroulanteEntretien.EntretienSelectionne != null) || (EntretienIndisponibleExiste != null) || (SuppressionEntretienLier == true)) || (textBoxInfoReparation.Text != ""))
                    {
                        // Test de validation sur les 2 objets pour ne pas faire une requête si un des 2 n'est pas valide
                        if ((FactureEnEdition.EstValide) && (FactureEnEdition.RendezVous.EstValide) && (Program.GMBD.ModifierFacture(FactureEnEdition)))
                        {
                            if (Program.GMBD.ModifierRendezvous(FactureEnEdition.RendezVous))
                            {
                                if ((listeDeroulanteEntretien.EntretienSelectionne != null) && (CalendrierRdv.FactureSelectionnee.EnumFactureEntretien.ElementAt(0) == null))
                                {
                                    FactureEntretien NouvelEntretien = new FactureEntretien(FactureEnEdition, listeDeroulanteEntretien.EntretienSelectionne);

                                    if (Program.GMBD.AjouterFactureEntretien(NouvelEntretien))
                                    {
                                        ValidationProvider.SetError(buttonModifier, "Le rendez-vous a été correctement modifié");
                                        CalendrierRdv.ChargerListViewRdv();
                                        RechargementApresModification = true;
                                        CalendrierRdv.FactureSelectionnee = FactureEnEdition;
                                    }
                                }
                                else if ((listeDeroulanteEntretien.EntretienSelectionne != null) && (listeDeroulanteEntretien.EntretienSelectionne.Id != CalendrierRdv.FactureSelectionnee.EnumFactureEntretien.ElementAt(0).Entretien.Id))
                                {
                                    FactureEntretien EntretienLie = FactureEnEdition.EnumFactureEntretien.ElementAt(0);
                                    EntretienLie.Entretien = listeDeroulanteEntretien.EntretienSelectionne;
                                    EntretienLie.FactureLiee = FactureEnEdition;
                                    // Si il modifie l'entretien
                                    if (Program.GMBD.ModifierFactureEntretien(EntretienLie))
                                    {
                                        CalendrierRdv.ChargerListViewRdv();
                                        ValidationProvider.SetError(buttonModifier, "Le rendez-vous a été correctement modifié");
                                        RechargementApresModification = true;
                                        CalendrierRdv.FactureSelectionnee = FactureEnEdition;
                                    }
                                }
                                else if ((listeDeroulanteEntretien.EntretienSelectionne == null) && (EntretienIndisponibleExiste == null))
                                {
                                    FactureEntretien EntretienLier = FactureEnEdition.EnumFactureEntretien.FirstOrDefault();
                                    if (EntretienLier != null)
                                    {
                                        // Si il y a une réparation alors la suppresion de l'entretien est autorisée
                                        if ((SuppressionEntretienLier == true) && (checkBoxReparation.Checked == true))
                                        {
                                            // S'il retire l'entretien de la sélection
                                            Program.GMBD.SupprimerFactureEntretien(EntretienLier);
                                            ValidationProvider.SetError(buttonModifier, "Le rendez-vous a été correctement modifié");
                                            CalendrierRdv.ChargerListViewRdv();
                                            RechargementApresModification = true;
                                            CalendrierRdv.FactureSelectionnee = FactureEnEdition;

                                        }
                                        else
                                        {
                                            errorProvider.SetError(buttonModifier, "Vous devez choisir un entretien ou une réparation");
                                            listeDeroulanteEntretien.EntretienSelectionne = CalendrierRdv.FactureSelectionnee.EnumFactureEntretien.FirstOrDefault().Entretien;
                                        }
                                    }
                                    else
                                    {
                                        ValidationProvider.SetError(buttonModifier, "Le rendez-vous a été correctement modifié");
                                        CalendrierRdv.ChargerListViewRdv();
                                        RechargementApresModification = true;
                                        CalendrierRdv.FactureSelectionnee = FactureEnEdition;
                                    }
                                }
                                else
                                {
                                    ValidationProvider.SetError(buttonModifier, "Le rendez-vous a été correctement modifié");
                                    CalendrierRdv.ChargerListViewRdv();
                                    RechargementApresModification = true;
                                    CalendrierRdv.FactureSelectionnee = FactureEnEdition;
                                }
                            }
                        }
                    }
                }
                else
                {
                    errorProvider.SetError(buttonModifier, "Vous devez choisir un entretien ou une réparation à effectuer");
                }
            }        
        }

        private void buttonAnnulationRendezvous_Click(object sender, EventArgs e)
        {
            if(CalendrierRdv.FactureSelectionnee != null)
            {
                RendezVousEntretienReparation RdvEnEdition = CalendrierRdv.FactureSelectionnee.RendezVous;
                RdvEnEdition.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = \"Annuler\""), null).FirstOrDefault();
                if (Program.GMBD.ModifierRendezvous(RdvEnEdition))
                {
                    ValidationProvider.SetError(buttonAnnulationRendezvous, "Le rendez-vous a été annulé");
                    CalendrierRdv.ChargerListViewRdv();
                    ClearFormulaire();
                }
            }
        }

        private void ClearFormulaire()
        {
            ClientVehicule.ViderFormulaire();
            dateTimePickerArrivee.Value = DateTime.Now;
            dateTimePickerFin.Value = DateTime.Now;
            listeDeroulanteEntretien.EntretienSelectionne = null;
            checkBoxReparation.Checked = false;
            textBoxInfoReparation.Text = "";
            buttonAnnulationRendezvous.Enabled = false;
            buttonReactiveRdv.Enabled = false;
            buttonAjouter.Enabled = false;
            buttonModifier.Enabled = false;
            ClientVehicule.ButtonAjouter = true;
            ClientVehicule.ButtonModifier = false;
            ClientVehicule.DesactiverListeClient = true;
        }

        private void buttonReactiveRdv_Click(object sender, EventArgs e)
        {
            if (CalendrierRdv.FactureSelectionnee != null)
            {
                if (CalendrierRdv.FactureSelectionnee.RendezVous.DateDebut > DateTime.Now)
                {
                    RendezVousEntretienReparation RdvEnEdition = CalendrierRdv.FactureSelectionnee.RendezVous;
                    RdvEnEdition.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = {0}", "En attente"), null).FirstOrDefault();
                    if (Program.GMBD.ModifierRendezvous(RdvEnEdition))
                    {
                        ValidationProvider.SetError(buttonReactiveRdv, "Le rendez-vous a été remis en attente");
                        CalendrierRdv.ChargerListViewRdv();
                        ClearFormulaire();
                    }
                }                
            }
        }

        private void buttonReactualiser_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            ClearFormulaire();
            buttonReactualiser.Enabled = false;
            buttonModifier.Enabled = false;
            buttonAjouter.Enabled = false;
            ClientVehicule.ButtonAjouter = true;
            ClientVehicule.ButtonModifier = false;
            CalendrierRdv.RetirerSelection();
            textBoxInfoReparation.Enabled = false;
            ClientVehicule.DesactiverListeClient = true;
            buttonImprimerLaFacture.Enabled = false;
            ClientVehicule.DesactiverTextBoxImmatriculation = true;
            ClientVehicule.DesactiverTextBoxNumChassis = true;
            ClientVehicule.DesactiverListeModele = true;
        }
        
        private void ClientVehicule_SurChangementVehiculeActif(object sender,EventArgs e)
        {
            ClientVehicule.ButtonAjouter = true;
            ClientVehicule.ButtonModifier = true;
            if (CalendrierRdv.FactureSelectionnee != null)
            {
                buttonAjouter.Enabled = false;
                buttonModifier.Enabled = true;
            }
            else
            {
                buttonModifier.Enabled = false;
                buttonAjouter.Enabled = true;
            }
            buttonReactualiser.Enabled = true;
        }

        private void pictureBoxAjouterEntretien_Click(object sender, EventArgs e)
        {
            entretiens.EstAjouter = true;
            entretiens.EstModification = false;
            entretiens.Show();
        }

        private void pictureBoxModifierEntretien_Click(object sender, EventArgs e)
        {
            entretiens.EstModification = true;
            entretiens.EstAjouter = false;
            entretiens.EntretienSelectionner = listeDeroulanteEntretien.EntretienSelectionne;   
            entretiens.Show();
        }

        private void pictureBoxSupprimerEntretien_Click(object sender, EventArgs e)
        {
            if(listeDeroulanteEntretien.EntretienSelectionne != null)
            {
                FactureEntretien LienExistant = Program.GMBD.EnumererFactureEntretien(null, new MyDB.CodeSql("JOIN entretien ON facture_entretien.fk_id_entretien = entretien.id_entretien"), new MyDB.CodeSql("WHERE fk_id_entretien = {0}", listeDeroulanteEntretien.EntretienSelectionne.Id), null).FirstOrDefault();
                if(LienExistant != null)
                {
                    Entretien EntretienIndisponible = LienExistant.Entretien;
                    EntretienIndisponible.Disponible = 0;
                    // Si l'entretien est référencé, suppression fictive afin de garder la trace de celui-ci
                    if((EntretienIndisponible.EstValide)&&(Program.GMBD.ModifierEntretien(EntretienIndisponible)))
                    {
                        ValidationProvider.SetError(pictureBoxSupprimerEntretien, "Entretien correctement supprimé");
                        entretiens.EntretienSelectionner = null;
                        listeDeroulanteEntretien.EntretienSelectionne = null;
                    }
                }
                // Si l'entretien n'a aucune référence, la suppresion définitive peut être effectuée
                else if((LienExistant == null) && (Program.GMBD.SupprimerEntretien(listeDeroulanteEntretien.EntretienSelectionne)) )             
                {
                    listeDeroulanteEntretien.Entretien = Program.GMBD.EnumererEntretien(null, null, new MyDB.CodeSql("WHERE disponible = 1"), null);
                    ValidationProvider.SetError(pictureBoxSupprimerEntretien, "Entretien correctement supprimé");
                    entretiens.EntretienSelectionner = null;
                    listeDeroulanteEntretien.EntretienSelectionne = null;
                }
            }
        }

        private void RefreshListeEntretiens(object sender, EventArgs e)
        {
            listeDeroulanteEntretien.Entretien = Program.GMBD.EnumererEntretien(null, null, new MyDB.CodeSql("WHERE disponible = 1"), null);
            listeDeroulanteEntretien.EntretienSelectionne = entretiens.EntretienSelectionner;
        }

        private void buttonImprimerLaFacture_Click(object sender, EventArgs e)
        {
            if(CalendrierRdv.FactureSelectionnee != null)
            {
                GenerationDocumentsPDF.GenerationFactureEntretienReparation(CalendrierRdv.FactureSelectionnee, false);
            }
        }

        private void ClientVehicule_RafraichirApresModification(object sender, EventArgs e)
        {
            ClearFormulaire();
            CalendrierRdv.ChargerListViewRdv();
        }
    }
}
