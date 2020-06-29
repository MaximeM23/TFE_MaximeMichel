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
    public partial class Page_Personnalisation : UserControl
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


        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";

        private Vehicule m_VehiculeChoisi;

        private double PrixEstimeApresChoix = 0.0;

        private List<OptionVehicule> OptionsChoisies;

        private List<PackOptionPackVehicule> PackChoisis;

        public Vehicule VehiculeChoisi
        {
            get
            {
                return m_VehiculeChoisi;
            }
            set
            {
                if ((value.GetType() == typeof(Vehicule)))
                {
                    m_VehiculeChoisi = value;
                }
            }
        }

        public Page_Personnalisation()
        {
            InitializeComponent();
            OptionsChoisies = new List<OptionVehicule>();
            PackChoisis = new List<PackOptionPackVehicule>();
            listeDeroulanteTypeOptions1.TypeOptions = Program.GMBD.EnumererTypeOptions(null, null, null, null);
            listeDeroulanteTypeOptions1.SurChangementSelection += TypeOption_SurChangementSelection;
            formulaire_Client1.AccesALaListeClient.SurChangementSelectionDeuxiemeMethode += FormulaireClient_SurChangementSelection;
            formulaire_Client1.ChargerDonneesListView();
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
            this.MinimumSize = new Size(1489, 699);
            fichePackOptionsChoisis.CacheTextBoxFiltre();
            ficheOptionsChoisies.CacheTextBoxFiltre();
        }
        

        private void FormulaireClient_SurChangementSelection(object sender, EventArgs e)
        {
            if (formulaire_Client1.AccesALaListeClient.ClientSelectionne != null)
            {
                buttonCommander.Enabled = true;
            }
        }

        private void TypeOption_SurChangementSelection(object sender, EventArgs e)
        {
            if (listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null)
            {
                #region Requêtes pour les options
                ///////////////////////////////
                // Requêtes pour les options //
                ///////////////////////////////
                ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                              JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND option_vehicule.fk_id_type_option = {1}", VehiculeChoisi.Id, listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                                    null);
                ficheOptionsGeneral.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if ((ficheOptionsGeneral.TexteFiltreOptions != "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne == null))
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND nom_option LIKE {1}", VehiculeChoisi.Id, string.Format(c_FiltreAvecLike, ficheOptionsGeneral.TexteFiltreOptions)),
                                                                            null);
                    }
                    else if ((ficheOptionsGeneral.TexteFiltreOptions == "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null))
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND option_vehicule.fk_id_type_option = {1}", VehiculeChoisi.Id, listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                            null);

                    }
                    else if ((ficheOptionsGeneral.TexteFiltreOptions != "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null))
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND nom_option LIKE {1} AND option_vehicule.fk_id_type_option = {2}", VehiculeChoisi.Id, string.Format(c_FiltreAvecLike, ficheOptionsGeneral.TexteFiltreOptions), listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                            null);
                    }
                    else if ((ficheOptionsGeneral.TexteFiltreOptions == "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne == null))
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0}", VehiculeChoisi.Id),
                                                                            null);
                    }
                };

                #endregion
            }
        }

        /// <summary>
        /// Rajoute l'élément choisi à la liste des options désirés
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxAjouterO_Click(object sender, EventArgs e)
        {
            if (ficheOptionsGeneral.OptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                if (OptionsChoisies != null)
                {
                    if (!ficheOptionsChoisies.Options.Contains(ficheOptionsGeneral.OptionsSelectionnee))
                    {
                        OptionVehicule OptionExiste = OptionsChoisies.Find(item => (item.Id == ficheOptionsGeneral.OptionsSelectionnee.Id) || (item.TypeOption.NomType == listeDeroulanteTypeOptions1.TypeOptionsSelectionne.NomType));
                        if ((OptionExiste == null) || ((ficheOptionsGeneral.OptionsSelectionnee.TypeOption.NomType == "Autres")))
                        {
                            bool OptionDispoDansPack = false;
                            if (PackChoisis.Count > 0)
                            {

                                foreach (PackOptionPackVehicule POPV in PackChoisis)
                                {
                                    foreach (PackOption PO in POPV.EnumPackOption)
                                    {
                                        if (PO.OptionVehicule.Id == ficheOptionsGeneral.OptionsSelectionnee.Id)
                                        {
                                            errorProvider.SetError(pictureBoxAjouterO, "Cette option est déjà disponible avec le pack : " + POPV.NomPack);
                                            OptionDispoDansPack = true;
                                        }
                                    }
                                }
                            }
                            if (OptionDispoDansPack == false)
                            {
                                PrixEstimeApresChoix += ficheOptionsGeneral.OptionsSelectionnee.Prix;
                                textBoxPrixTotal.Text = string.Format("{0} €", PrixEstimeApresChoix);
                                OptionsChoisies.Add(ficheOptionsGeneral.OptionsSelectionnee);
                                ficheOptionsChoisies.Options = OptionsChoisies;
                                ValidationProvider.SetError(pictureBoxAjouterO, "L'option a bien été ajoutée");
                            }
                        }
                        else
                        {
                            errorProvider.SetError(pictureBoxAjouterO, "Ce type d'option a déjà été choisi");
                        }
                    }
                    else
                    {
                        errorProvider.SetError(pictureBoxAjouterO, "Cette option a déjà été choisie");
                    }                
                }
            }
        }

        /// <summary>
        /// Retire l'élément choisi de la liste des options désirées
        /// </summary>
        private void pictureBoxRetirerO_Click(object sender, EventArgs e)
        {
            if (ficheOptionsChoisies.OptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();                
                PrixEstimeApresChoix -= ficheOptionsGeneral.OptionsSelectionnee.Prix;
                textBoxPrixTotal.Text = string.Format("{0} €", PrixEstimeApresChoix);
                OptionsChoisies.Remove(ficheOptionsChoisies.OptionsSelectionnee);
                ficheOptionsChoisies.Options = OptionsChoisies;
                ValidationProvider.SetError(pictureBoxRetirerO, "L'option a bien été retirée");
            }
        }

        /// <summary>
        /// Rajoute l'élément choisi à la liste des options désirées
        /// </summary>
        private void pictureBoxAjouterP_Click(object sender, EventArgs e)
        {
            if (fichePackOptionsGeneral.PackOptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                if (PackChoisis != null)
                {
                    PackOptionPackVehicule PackExiste = PackChoisis.Find(item => (item.Id == fichePackOptionsGeneral.PackOptionsSelectionnee.Id));
                    if (PackExiste == null)
                    {

                        bool ValidationIndiquee = false;
                        foreach (PackOption PO in fichePackOptionsGeneral.PackOptionsSelectionnee.EnumPackOption)
                        {
                            foreach (OptionVehicule OV in ficheOptionsChoisies.Options)
                            {
                                if ((PO.OptionVehicule.Id == OV.Id) || ((PO.OptionVehicule.TypeOption.Id == OV.TypeOption.Id) && (OV.TypeOption.NomType != "Autres")))
                                {
                                    PrixEstimeApresChoix -= OV.Prix;
                                    OptionsChoisies.Remove(OV);
                                    ficheOptionsChoisies.Options = OptionsChoisies;
                                }
                            }


                            if (PackChoisis.Count > 0)
                            {
                                foreach (PackOptionPackVehicule POPV in fichePackOptionsGeneral.PackOptions)
                                {
                                    foreach (PackOption PO2 in POPV.EnumPackOption)
                                    {
                                        if ((PO.OptionVehicule.Id == PO2.OptionVehicule.Id) && (PO2.PackOptionPackVehicule.Id != fichePackOptionsGeneral.PackOptionsSelectionnee.Id))
                                        {

                                            PackChoisis.Remove(PackChoisis.Find(item => item.Id == PO2.PackOptionPackVehicule.Id));
                                            PrixEstimeApresChoix -= PO2.PackOptionPackVehicule.PrixPack;
                                            ValidationProvider.SetError(pictureBoxAjouterP, "Un ou plusieurs packs comprenant des duplications d'options ont été retirés");
                                            ValidationIndiquee = true;
                                        }
                                    }
                                }
                            }
                        }
                        if(!ValidationIndiquee) ValidationProvider.SetError(pictureBoxAjouterP, "Le pack a bien été ajouté");
                        PrixEstimeApresChoix += fichePackOptionsGeneral.PackOptionsSelectionnee.PrixPack;
                        textBoxPrixTotal.Text = string.Format("{0} €", PrixEstimeApresChoix);
                        PackChoisis.Add(fichePackOptionsGeneral.PackOptionsSelectionnee);
                        fichePackOptionsChoisis.PackOptions = PackChoisis;
                    }
                    else
                    {
                        errorProvider.SetError(pictureBoxAjouterP, "Ce pack a déjà été choisi");
                    }
                }
            }
        }

        /// <summary>
        /// Retire l'élément choisi de la liste des packs désirés
        /// </summary>
        private void pictureBoxRetirerP_Click(object sender, EventArgs e)
        {
            if (fichePackOptionsGeneral.PackOptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                if (PackChoisis.Count > 0)
                {
                    PrixEstimeApresChoix -= fichePackOptionsChoisis.PackOptionsSelectionnee.PrixPack;
                    textBoxPrixTotal.Text = string.Format("{0} €", PrixEstimeApresChoix);
                    PackChoisis.Remove(fichePackOptionsGeneral.PackOptionsSelectionnee);
                    fichePackOptionsChoisis.PackOptions = PackChoisis;
                    ValidationProvider.SetError(pictureBoxRetirerP, "Le pack a bien été retiré");

                }
            }
        }

        private void fichePackOptionsGeneral_Load(object sender, EventArgs e)
        {
            #region Requêtes pour les packs d'options
            ////////////////////////////////////////
            // Requêtes pour les packs d'options //
            ///////////////////////////////////////

            fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0}", VehiculeChoisi.Id), null);
            fichePackOptionsGeneral.SurChangementFiltre += (s, ev) =>
            {
                // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                if (fichePackOptionsGeneral.TexteFiltrePackOptions != "")
                {
                    fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                    new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                    new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND nom_pack LIKE {1}", VehiculeChoisi.Id, string.Format(c_FiltreAvecLike, fichePackOptionsGeneral.TexteFiltrePackOptions)),
                                                                    null);
                }
                else
                {
                    fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0}", VehiculeChoisi.Id), null);
                }
            };
            #endregion
        }

        private void Page_Personnalisation_Load(object sender, EventArgs e)
        {
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + VehiculeChoisi.NomImage + ""))
            {
                pictureBoxVoiture.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + VehiculeChoisi.NomImage + "");
            }
            if (VehiculeChoisi.TempsLivraison > 1)
            {
                textBoxEstimationLivraison.Text = string.Format("{0} {1}", VehiculeChoisi.TempsLivraison.ToString(), "jours");
            }
            else
            {
                textBoxEstimationLivraison.Text = string.Format("{0} {1}", VehiculeChoisi.TempsLivraison.ToString(), "jour");
            }
            textBoxPrix.Text = string.Format("{0} €", VehiculeChoisi.PrixVehicule.ToString());
            textBoxPrixTotal.Text = string.Format("{0} €", VehiculeChoisi.PrixVehicule.ToString());
            PrixEstimeApresChoix = VehiculeChoisi.PrixVehicule;

        }

        private void buttonCommander_Click(object sender, EventArgs e)
        {
            if (formulaire_Client1.AccesALaListeClient.ClientSelectionne != null)
            {
                bool CreationOptionSucces = true;
                bool CreationPackOptionSucces = true;
                VehiculeVente VehiculeCommande = new VehiculeVente();
                VehiculeCommande.AnneeConstruction = 0;
                VehiculeCommande.DateArrivee = DateTime.MinValue;
                VehiculeCommande.DateCommande = DateTime.Now;
                VehiculeCommande.DateMiseEnCirculation = DateTime.MinValue;
                VehiculeCommande.Kilometrage = 0;
                VehiculeCommande.NumeroChassis = "";
                VehiculeCommande.PrixTotal = PrixEstimeApresChoix;
                VehiculeCommande.Vehicule = VehiculeChoisi;
                VehiculeCommande.StatutLivraison = Program.GMBD.EnumererStatut(null, null, new PDSGBD.MyDB.CodeSql("WHERE statut = \"En livraison\""), null).FirstOrDefault();

                if ((VehiculeCommande.EstValide) && (Program.GMBD.AjouterVehiculeVente(VehiculeCommande)))
                {
                    for (int i = 0; i < OptionsChoisies.Count; i++)
                    {
                        ChoixOptionVehicule OV = new ChoixOptionVehicule();
                        OV.VehiculeVente = VehiculeCommande;
                        OV.OptionVehicule = OptionsChoisies[i];
                        if ((OV.EstValide) && (Program.GMBD.AjouterChoixOptionVehicule(OV)))
                        {
                            //ne rien faire vu que la création a été validée
                        }
                        else
                        {
                            CreationOptionSucces = false;
                        }
                    }
                    if (CreationOptionSucces)
                    {
                        for (int i = 0; i < PackChoisis.Count; i++)
                        {
                            ChoixPackVehicule CPV = new ChoixPackVehicule();
                            CPV.VehiculeVente = VehiculeCommande;
                            CPV.PackOptionPackVehicule = PackChoisis[i];
                            if ((CPV.EstValide) && (Program.GMBD.AjouterChoixPackVehicule(CPV)))
                            {
                                //ne rien faire vu que la création a été validée
                            }
                            else
                            {
                                CreationPackOptionSucces = false;
                            }
                        }
                    }
                    // Si un problème est déjà survenu à cet endroit, il n'y a aucun intérêt de poursuivre la création
                    if ((!CreationOptionSucces) && (!CreationPackOptionSucces))
                    {
                        Program.GMBD.SupprimerVehiculeVente(VehiculeCommande);
                        errorProvider.SetError(buttonCommander, "Une erreur interne s'est produite, veuillez recommencer");
                    }
                    else
                    {
                        FactureVente DernierId = Program.GMBD.EnumererFactureVente(null, null, null, null).LastOrDefault();
                        FactureVente NouvelleFactureDeCommande = new FactureVente();
                        NouvelleFactureDeCommande.Client = formulaire_Client1.ClientEnCoursDeTraitement;
                        NouvelleFactureDeCommande.Employe = Form_Principal.Employe;
                        NouvelleFactureDeCommande.VehiculeVente = VehiculeCommande;
                        NouvelleFactureDeCommande.PourcentageTva = 1;
                        NouvelleFactureDeCommande.RemiseSurReprise = 1000;
                        NouvelleFactureDeCommande.DateVente = DateTime.MinValue;
                        if(DernierId == null)
                        {
                            NouvelleFactureDeCommande.NumeroFacture = string.Format("{0}-1",DateTime.Now.Year);
                        }
                        else
                        {
                            NouvelleFactureDeCommande.NumeroFacture = string.Format("{0}-{1}", DateTime.Now.Year, DernierId.Id + 1);
                        }

                        if ((NouvelleFactureDeCommande.EstValide) && (Program.GMBD.AjouterNouvelleFactureVente(NouvelleFactureDeCommande)))
                        {
                            GenerationFacturePDF NouveauBonDeCommande = new GenerationFacturePDF();
                            NouveauBonDeCommande.GenerationBonDeCommande(NouvelleFactureDeCommande);
                            ValidationProvider.Clear();
                            formulaire_Client1.ViderFormulaire();
                            ficheOptionsChoisies.Options = null;
                            fichePackOptionsChoisis.PackOptions = null;
                        }
                        else
                        {
                            Program.GMBD.SupprimerVehiculeVente(VehiculeCommande);
                            errorProvider.SetError(buttonCommander, "Une erreur interne s'est produite, veuillez recommencer");
                        }
                    }
                }
            }
        }
    }
}
