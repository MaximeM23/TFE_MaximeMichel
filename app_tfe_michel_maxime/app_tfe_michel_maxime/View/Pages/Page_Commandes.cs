using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace app_tfe_michel_maxime
{
    public partial class Page_Commandes : UserControl
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

        public Page_Commandes()
        {
            InitializeComponent();
            numericUpDownKilometrage.Minimum = 0;
            numericUpDownKilometrage.Maximum = int.MaxValue;
            numericUpDownTVA.Minimum = 1;
            numericUpDownTVA.Maximum = 100;
            numericUpDownAnneeConstruction.Minimum = 2010;
            numericUpDownAnneeConstruction.Maximum = 2999;
            numericUpDownKilometrage.Minimum = 0;
            numericUpDownKilometrage.Maximum = int.MaxValue;
            listeDeroulanteFactureVente1.SurChangementSelection += BonCommandeSurChangementSelection;
            ficheOptions1.CacheTextBoxFiltre();
            fichePackOptions1.CacheTextBoxFiltre();
            ficheTechnique1.CacheTextBoxFiltre();
            listeDeroulanteClientVehicule1.SurChangementSelection += ClientVehiculeSurChangementSelection;
            this.MinimumSize = new Size(1479, 657);  
        }

        /// <summary>
        /// Se produit lors du chargement de la liste déroulante des bons de commandes
        /// </summary>
        private void listeDeroulanteBonCommande1_Load(object sender, EventArgs e)
        {
            listeDeroulanteFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                              new PDSGBD.MyDB.CodeSql("WHERE statut.statut = \"En livraison\""), null);
        }

        /// <summary>
        /// Se produit lors d'un changement de sélection sur la liste des véhicules du client
        /// </summary>
        private void ClientVehiculeSurChangementSelection(object sender, EventArgs e)
        {
            textBoxRemise.Enabled = true;
        }

        /// <summary>
        /// Se produit lors d'un changement de sélection sur un bon de commande
        /// </summary>
        private void BonCommandeSurChangementSelection(object sender,EventArgs e)
        {
            if(listeDeroulanteFactureVente1.FactureVenteSelectionne != null)
            {
                buttonImprimerFacture.Enabled = true;
                listeDeroulanteClientVehicule1.Enabled = true;
                buttonImprimerFacture.Enabled = true;
                dateTimePickerDateReception.Enabled = true;
                textBoxNumChassis.Enabled = true;
                numericUpDownTVA.Enabled = true;
                numericUpDownAnneeConstruction.Enabled = true;
                numericUpDownKilometrage.Enabled = true;
                listeDeroulanteClientVehicule1.ClientVehicule = Program.GMBD.EnumererClientVehicule(null,new PDSGBD.MyDB.CodeSql("JOIN client ON client_vehicule.fk_id_client = client.id_client JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),new PDSGBD.MyDB.CodeSql("where fk_id_client = {0} AND vehicule_actif = 1",listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Id),null);
                textBoxLoc.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Adresse.Localite.ToString();
                textBoxCP.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Adresse.CodePostal.ToString();
                textBoxAdresse.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Rue;
                textBoxDateCommande.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.DateCommande.ToString("d/M/yyyy");
                textBoxDateNaissance.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.DateNaissance.ToString("d/M/yyyy");
                textBoxEmail.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Email;
                textBoxCivilite.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Civilite.CiviliteDeLaPersonne;
                textBoxNom.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Nom;
                textBoxPrenom.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.Prenom;
                textBoxNumHabitation.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.NumeroHabitation;
                textBoxNumTel.Text = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client.NumeroTelephone.ToString();
                textBoxPrix.Text = string.Format("{0} €",listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Vehicule.PrixVehicule.ToString());
                textBoxPrixTotal.Text = string.Format("{0} €", listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.PrixTotal.ToString());

                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Vehicule.NomImage + ""))
                {
                    pictureBoxVehicule.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Vehicule.NomImage + "");
                }
                
                ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON choix_option_vehicule.fk_id_option_vehicule = option_vehicule.id_option_vehicule
                                                                                                                JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Id),
                                                                                    null);
                
                
                fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN choix_pack_vehicule ON choix_pack_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE choix_pack_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Id), null);

                ficheTechnique1.Caracteristique = listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Vehicule.EnumVehiculeCaracteristique;
            }
        }

        /// <summary>
        /// Se produit lors du click sur le bouton d'impression d'une facture
        /// </summary>
        private void buttonImprimerFacture_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();            
            FactureVente FactureAModifier = listeDeroulanteFactureVente1.FactureVenteSelectionne;
            FactureAModifier.SurErreur += FactureVenteEnEdition_SurErreur;
            FactureAModifier.AvantChangement += FactureEnEdition_AvantChangement;
            int Remise = 0;
            if (listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null)
            {
                if (string.IsNullOrWhiteSpace(textBoxRemise.Text))
                {
                    FactureAModifier.RemiseSurReprise = 0;
                }
                else if(int.TryParse(textBoxRemise.Text,out Remise))
                {
                    if (Remise > 0) FactureAModifier.RemiseSurReprise = Remise;
                }
                else
                {
                    FactureAModifier.RemiseSurReprise = double.MaxValue;
                }
            }
            else
            {
                FactureAModifier.RemiseSurReprise = 0;
            }
            FactureAModifier.Client = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client;
            FactureAModifier.DateVente = DateTime.Now;
            FactureAModifier.PourcentageTva = int.Parse(numericUpDownTVA.Value.ToString());

            if(FactureAModifier.EstValide && Program.GMBD.ModifierFactureVente(FactureAModifier))
            {
                VehiculeVente VehiculeVenteAModifier = listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente;
                VehiculeVenteAModifier.SurErreur += VehiculeVenteEnEdition_SurErreur;
                VehiculeVenteAModifier.AvantChangement += VehiculeVenteEnEdition_AvantChangement;
                VehiculeVenteAModifier.DateArrivee = dateTimePickerDateReception.Value;
                VehiculeVenteAModifier.DateMiseEnCirculation = DateTime.Now;
                VehiculeVenteAModifier.Kilometrage = int.Parse(numericUpDownKilometrage.Value.ToString());
                VehiculeVenteAModifier.NumeroChassis = textBoxNumChassis.Text;
                VehiculeVenteAModifier.AnneeConstruction = int.Parse(numericUpDownAnneeConstruction.Value.ToString());
                VehiculeVenteAModifier.StatutLivraison = Program.GMBD.EnumererStatut(null, null, new PDSGBD.MyDB.CodeSql("WHERE statut = \"Vendu\""), null).FirstOrDefault();

                if (VehiculeVenteAModifier.EstValide && Program.GMBD.ModifierVehiculeVente(VehiculeVenteAModifier))
                {
                    ClientVehicule NouveauClientVehicule = new ClientVehicule();
                    NouveauClientVehicule.Client = listeDeroulanteFactureVente1.FactureVenteSelectionne.Client;
                    NouveauClientVehicule.VehiculeActif = 1;
                    NouveauClientVehicule.Vehicule = listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.Vehicule;
                    NouveauClientVehicule.NumeroChassis = listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.NumeroChassis;
                    NouveauClientVehicule.Immatriculation = "";
                    if(NouveauClientVehicule.EstValide && Program.GMBD.AjouterClientVehicule(NouveauClientVehicule))
                    {
                        if(listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null)
                        {
                            ClientVehicule VehiculeReprisParLaConcession = listeDeroulanteClientVehicule1.ClientVehiculeSelectionne;
                            VehiculeReprisParLaConcession.VehiculeActif = 0;
                            if((VehiculeReprisParLaConcession.EstValide)&&(Program.GMBD.ModifierClientVehicule(VehiculeReprisParLaConcession)))
                            {
                                RefreshPage();
                                GenerationFacturePDF FacturationPDF = new GenerationFacturePDF();
                                FacturationPDF.GenerationFactureVente(FactureAModifier);
                                listeDeroulanteFactureVente1.FactureVenteSelectionne = null;
                            }
                        }
                        else
                        {
                            RefreshPage();
                            GenerationFacturePDF FacturationPDF = new GenerationFacturePDF();
                            FacturationPDF.GenerationFactureVente(FactureAModifier);
                            listeDeroulanteFactureVente1.FactureVenteSelectionne = null;
                        }
                    }
                }

            }

        }

        /// <summary>
        /// Permet de réinitialiser la page de commande
        /// </summary>
        private void RefreshPage()
        {
            listeDeroulanteClientVehicule1.ClientVehicule = null;
            listeDeroulanteFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                                new PDSGBD.MyDB.CodeSql("WHERE statut.statut = \"En livraison\""), null);
            textBoxRemise.Text = "";
            listeDeroulanteClientVehicule1.ClientVehicule = null;
            dateTimePickerDateReception.Value = DateTime.Now;
            numericUpDownTVA.Value = 1;
            textBoxDateCommande.Text = "";
            numericUpDownKilometrage.Value = 0;
            textBoxNumChassis.Text = "";
            numericUpDownAnneeConstruction.Value = 2010;
            textBoxAdresse.Text = "";
            textBoxCP.Text = "";
            textBoxEmail.Text = "";
            textBoxCivilite.Text = "";
            textBoxLoc.Text = "";
            textBoxNom.Text = "";
            textBoxNumHabitation.Text = "";
            textBoxNumTel.Text = "";
            textBoxPrenom.Text = "";
            textBoxNom.Text = "";
            textBoxPrix.Text = "";
            textBoxPrixTotal.Text = "";
            buttonImprimerFacture.Enabled = false;
            pictureBoxVehicule.Image = null;
            ficheOptions1.Options = null;
            fichePackOptions1.PackOptions = null;
            ficheTechnique1.Caracteristique = null;                      
        }


        /// <summary>
        /// Methode permettant de vérifier si les champs sont bien remplis avant la modification de la facture
        /// </summary>
        private void FactureEnEdition_AvantChangement(FactureVente Entite, FactureVente.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case FactureVente.Champs.RemiseSurReprise:
                    int Remise = 0;
                    if ((listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null) && (NouvelleValeur.ToString() != ""))
                    {
                        if (int.TryParse(textBoxRemise.Text, out Remise))
                        {
                            if ((listeDeroulanteClientVehicule1.ClientVehiculeSelectionne != null) && (int.Parse(textBoxRemise.Text) < 0) || (int.Parse(textBoxRemise.Text) > listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.PrixTotal))
                            {
                                AccumulateurErreur.NotifierErreur(string.Format("La remise doit être comprise entre 1 € et {0} €", listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.PrixTotal));
                            }
                        }
                        else
                        {
                            AccumulateurErreur.NotifierErreur(string.Format("La remise doit être comprise entre 1 € et {0} €", listeDeroulanteFactureVente1.FactureVenteSelectionne.VehiculeVente.PrixTotal));
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Methode permettant de vérifier si les champs sont bien remplis avant la modification du véhicule
        /// </summary>
        private void VehiculeVenteEnEdition_AvantChangement(VehiculeVente Entite, VehiculeVente.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case VehiculeVente.Champs.DateArrivee:
                    if (DateTime.Parse(NouvelleValeur.ToString()) < Entite.DateCommande)
                    {
                        AccumulateurErreur.NotifierErreur(string.Format("La date de réception ne peut pas être inférieure à la date de commande"));
                    }
                    break;                    
                case VehiculeVente.Champs.NumeroChassis: // Dans ce cas particulier, le véhicule étant un nouveau véhicule, l'unicité de ce numéro doit être respecté
                    VehiculeVente UniciteNumChassis = Program.GMBD.EnumererVehiculeVente(new PDSGBD.MyDB.CodeSql("numero_chassis"), null, new PDSGBD.MyDB.CodeSql("WHERE numero_chassis = {0}", NouvelleValeur), null).FirstOrDefault();                    
                    if (string.IsNullOrWhiteSpace(NouvelleValeur.ToString()))
                    {
                        AccumulateurErreur.NotifierErreur("Le numéro de châssis doit être indiqué afin de finaliser la vente");
                    }
                    else if (UniciteNumChassis != null)
                    {
                        AccumulateurErreur.NotifierErreur("Ce numéro de châssis existe déjà pour un autre véhicule");
                    }
                    break;
                case VehiculeVente.Champs.AnneeConstruction:
                    int AnneeTemp = 0;
                    if (int.TryParse(NouvelleValeur.ToString(),out AnneeTemp) && (AnneeTemp < 1) || (AnneeTemp > 9999))
                    {
                        AccumulateurErreur.NotifierErreur(string.Format("L'année de construction doit comprendre 4 chiffres"));
                    }
                    break;
            }
        }


        /// <summary>
        /// Methode permettant de réagir sur l'erreur d'une édition d'une facture
        /// </summary>
        private void FactureVenteEnEdition_SurErreur(FactureVente Entite, FactureVente.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case FactureVente.Champs.PourcentageTva:
                    errorProvider.SetError(numericUpDownTVA, MessageErreur);
                    break;
                case FactureVente.Champs.RemiseSurReprise:
                    errorProvider.SetError(textBoxRemise, MessageErreur);
                    break;
            }
        }


        /// <summary>
        /// Methode permettant de réagir sur l'erreur d'une édition d'un véhicule en vente
        /// </summary>
        private void VehiculeVenteEnEdition_SurErreur(VehiculeVente Entite, VehiculeVente.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case VehiculeVente.Champs.Kilometrage:
                    errorProvider.SetError(numericUpDownKilometrage, MessageErreur);
                    
                    break;
                case VehiculeVente.Champs.NumeroChassis:
                    errorProvider.SetError(textBoxNumChassis, MessageErreur);
                    break;
                case VehiculeVente.Champs.DateArrivee:
                    errorProvider.SetError(dateTimePickerDateReception, MessageErreur);
                    break;
            }
        }
        
    }
}
