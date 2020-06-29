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
    public partial class Page_NouvelleDisponibilite : UserControl
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


        public bool EstVoiture;

        private List<OptionVehicule> OptionsChoisies;

        private List<PackOptionPackVehicule> PackChoisis;
        
        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";

        private double PrixTotal = 0.0;

        public Page_NouvelleDisponibilite()
        {
            EstVoiture = false;
            InitializeComponent();
            OptionsChoisies = new List<OptionVehicule>();
            PackChoisis = new List<PackOptionPackVehicule>();
            listeDeroulanteTypeOptions1.TypeOptions = Program.GMBD.EnumererTypeOptions(null, null, null, null);
            listeDeroulanteTypeOptions1.SurChangementSelection += TypeOption_SurChangementSelection;
            listeDeroulanteVehicule1.SurChangementSelection += ListeDeroulanteVehicule_SurChangementSelection;
            listeDeroulanteVehiculeVente1.SurChangementSelection += ListeDeroulanteVehiculeVente_SurChangementSelection;
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());

            numericUpDownAnneeConstruction.Minimum = int.Parse((DateTime.Now.Year - 10).ToString());
            numericUpDownAnneeConstruction.Maximum = int.Parse((DateTime.Now.Year + 2).ToString());
            numericUpDownAnneeConstruction.Value = DateTime.Now.Year;

            numericUpDownKilometrage.Minimum = 0;
            numericUpDownKilometrage.Maximum = 1000;

            fichePackOptionsChoisis.CacheTextBoxFiltre();
            ficheOptionsChoisies.CacheTextBoxFiltre();
        }

        /// <summary>
        /// Se produit lors d'un changement de séléction sur la liste déroulante comprenant les véhicules de concession
        /// </summary>
        private void ListeDeroulanteVehiculeVente_SurChangementSelection(object sender, EventArgs e)
        {
            if(listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
            {
                listeDeroulanteVehicule1.Enabled = false;
                listeDeroulanteVehicule1.VehiculeSelectionne = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Vehicule;
                RefreshPackGeneral();
                numericUpDownKilometrage.Value = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Kilometrage;
                numericUpDownAnneeConstruction.Value = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.AnneeConstruction;
                textBoxPrix.Text = string.Format("{0} €",listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Vehicule.PrixVehicule.ToString());
                textBoxPrixTotal.Text = textBoxPrixTotal.Text = string.Format("{0} €", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.PrixTotal.ToString());
                PrixTotal = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.PrixTotal;
                textBoxNumChassis.Text = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.NumeroChassis;
                dateTimePickerDateArrivee.Value = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.DateArrivee;
                dateTimePickerDateCommande.Value = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.DateCommande;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/ImagesVehicule/" + listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Vehicule.NomImage))
                {
                    pictureBoxVoiture.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage);
                }
                buttonAjouter.Enabled = false;
                buttonModifier.Enabled = true;
                buttonSupprimer.Enabled = true;



                #region Requêtes pour les options
                ///////////////////////////////
                // Requêtes pour les options //
                ///////////////////////////////
                ficheOptionsChoisies.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                              JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id),
                                                                                    null);
                ficheOptionsChoisies.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptionsChoisies.TexteFiltreOptions != "")
                    {
                        ficheOptionsChoisies.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                  JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0} AND nom_option LIKE {1}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id, string.Format(c_FiltreAvecLike, ficheOptionsChoisies.TexteFiltreOptions)),
                                                                        null);
                    }
                    else
                    {
                        ficheOptionsChoisies.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                new PDSGBD.MyDB.CodeSql(@"JOIN choix_option_vehicule ON option_vehicule.id_option_vehicule = choix_option_vehicule.fk_id_option_vehicule
                                                                                                          JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                new PDSGBD.MyDB.CodeSql("WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id),
                                                                                null);
                    }
                };

                #endregion                

                #region Requêtes pour les packs d'options
                ////////////////////////////////////////
                // Requêtes pour les packs d'options //
                ///////////////////////////////////////

                fichePackOptionsChoisis.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN choix_pack_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = choix_pack_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE choix_pack_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null);
                fichePackOptionsChoisis.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptionsChoisis.TexteFiltrePackOptions != "")
                    {
                        fichePackOptionsChoisis.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule_vente = {0} AND nom_pack LIKE {1}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id, string.Format(c_FiltreAvecLike, fichePackOptionsChoisis.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptionsChoisis.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule_vente = {0}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null);
                    }
                };
                #endregion

                #region Requêtes pour les packs d'options
                ////////////////////////////////////////
                // Requêtes pour les packs d'options //
                ///////////////////////////////////////

                fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
                fichePackOptionsGeneral.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptionsGeneral.TexteFiltrePackOptions != "")
                    {
                        fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0} AND nom_pack LIKE {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, fichePackOptionsGeneral.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
                    }
                };
                #endregion

                PackChoisis = fichePackOptionsChoisis.PackOptions.ToList();
                OptionsChoisies = ficheOptionsChoisies.Options.ToList();
            }
        }

        /// <summary>
        /// Se produit lors d'un changement de sélection sur la liste déroulante des véhicules
        /// </summary>
        private void ListeDeroulanteVehicule_SurChangementSelection(object sender, EventArgs e)
        {
            if((listeDeroulanteVehicule1.VehiculeSelectionne != null)&&(listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne == null))
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                ficheOptionsChoisies.Options = null;
                ficheOptionsGeneral.Options = null;
                fichePackOptionsChoisis.PackOptions = null;
                fichePackOptionsGeneral.PackOptions = null;
                listeDeroulanteTypeOptions1.TypeOptions = null;
                buttonAjouter.Enabled = true;
                listeDeroulanteTypeOptions1.Enabled = true;
                textBoxPrix.Text = string.Format("{0} €", listeDeroulanteVehicule1.VehiculeSelectionne.PrixVehicule.ToString());
                textBoxPrixTotal.Text = textBoxPrixTotal.Text = string.Format("{0} €", listeDeroulanteVehicule1.VehiculeSelectionne.PrixVehicule.ToString());
                PrixTotal = listeDeroulanteVehicule1.VehiculeSelectionne.PrixVehicule;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + ""))
                {
                    pictureBoxVoiture.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + "");
                }

                #region Requêtes pour les packs d'options
                ////////////////////////////////////////
                // Requêtes pour les packs d'options //
                ///////////////////////////////////////

                fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
                fichePackOptionsGeneral.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptionsGeneral.TexteFiltrePackOptions != "")
                    {
                        fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0} AND nom_pack LIKE {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, fichePackOptionsGeneral.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND popv_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
                    }
                };
                #endregion
                
            }
        }

        /// <summary>
        /// Se produit lors d'un changement des différents types d'options
        /// </summary>
        private void TypeOption_SurChangementSelection(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if ((listeDeroulanteVehicule1.VehiculeSelectionne != null)&&(listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null))
            {
                #region Requêtes pour les options
                ///////////////////////////////
                // Requêtes pour les options //
                ///////////////////////////////
                ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                              JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND vehicule_option_vehicule.fk_id_vehicule = {0} AND option_vehicule.fk_id_type_option = {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                                    null);
                ficheOptionsGeneral.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptionsGeneral.TexteFiltreOptions != "")
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                  JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND vehicule_option_vehicule.fk_id_vehicule = {0} AND nom_option LIKE {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, ficheOptionsGeneral.TexteFiltreOptions)),
                                                                        null);
                    }
                    else
                    {
                        ficheOptionsGeneral.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                          JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND vehicule_option_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id),
                                                                                null);
                    }
                };

                #endregion
            }
        }

        /// <summary>
        /// Rajoute l'élément choisi à la liste des options désirées
        /// </summary>
        private void pictureBoxAjouterO_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (ficheOptionsGeneral.OptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();

                if (OptionsChoisies != null)
                {
                    if (!ficheOptionsChoisies.Options.Contains(ficheOptionsGeneral.OptionsSelectionnee))
                    {
                        OptionVehicule OptionExiste = OptionsChoisies.Find(item => (item.Id == ficheOptionsGeneral.OptionsSelectionnee.Id) || (item.TypeOption.NomType == listeDeroulanteTypeOptions1.TypeOptionsSelectionne.NomType));
                        if ((OptionExiste == null) || (ficheOptionsGeneral.OptionsSelectionnee.TypeOption.NomType == "Autres"))
                        {
                            bool OptionDispoDansPack = false;
                            if (PackChoisis.Count > 0)
                            {

                                foreach (PackOptionPackVehicule POPV in PackChoisis)
                                {
                                    foreach (PackOption PO in POPV.EnumPackOption)
                                    {
                                        if ((PO.OptionVehicule.Id == ficheOptionsGeneral.OptionsSelectionnee.Id))
                                        {
                                            errorProvider.SetError(pictureBoxAjouterO, "Cet option est déjà disponible avec le pack : " + POPV.NomPack);
                                            OptionDispoDansPack = true;
                                        }
                                    }
                                }
                            }
                            if (OptionDispoDansPack == false)
                            {

                                if (listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne == null)
                                {
                                    PrixTotal += ficheOptionsGeneral.OptionsSelectionnee.Prix;
                                    textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                                    OptionsChoisies.Add(ficheOptionsGeneral.OptionsSelectionnee);
                                    ficheOptionsChoisies.Options = OptionsChoisies;
                                    ValidationProvider.SetError(pictureBoxAjouterO, "L'option a bien été ajoutée");
                                }
                                else
                                {
                                    ChoixOptionVehicule NouvelleOption = new ChoixOptionVehicule();
                                    NouvelleOption.VehiculeVente = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne;
                                    NouvelleOption.OptionVehicule = ficheOptionsGeneral.OptionsSelectionnee;
                                    if((NouvelleOption.EstValide)&& (Program.GMBD.AjouterChoixOptionVehicule(NouvelleOption)))
                                    {
                                        PrixTotal += ficheOptionsGeneral.OptionsSelectionnee.Prix;
                                        textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                                        OptionsChoisies.Add(ficheOptionsGeneral.OptionsSelectionnee);
                                        ficheOptionsChoisies.Options = OptionsChoisies;
                                        ValidationProvider.SetError(pictureBoxAjouterO, "L'option a bien été ajoutée");
                                    }
                                    else
                                    {
                                        errorProvider.SetError(pictureBoxAjouterO, "Une erreur interne est survenue");
                                    }
                                }
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
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (ficheOptionsChoisies.OptionsSelectionnee != null)
            {
                // Si le véhicule existe (lors d'une modification)
                if (listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
                {
                    ChoixOptionVehicule OptionExisteEnDB = Program.GMBD.EnumererChoixOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_option_vehicule = {0} AND fk_id_vehicule_vente = {1}", ficheOptionsChoisies.OptionsSelectionnee.Id, listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                    PackOptionPackVehicule OptionExiste = PackChoisis.Find(item => (item.Id == fichePackOptionsGeneral.PackOptionsSelectionnee.Id));

                    if (OptionExisteEnDB == null)
                    {
                        errorProvider.SetError(pictureBoxRetirerO, "Cette option n'existe pas pour ce véhicule");
                    }
                    else if(OptionExisteEnDB != null)
                    {                        
                        if ((OptionExisteEnDB.EstValide) && (Program.GMBD.SupprimerChoixOptionVehicule(OptionExisteEnDB)))
                        {
                            PrixTotal -= ficheOptionsChoisies.OptionsSelectionnee.Prix;
                            textBoxPrixTotal.Text = string.Format("{0} €",PrixTotal);
                            // On rajoute le pack et on actualise
                            OptionsChoisies.Remove(ficheOptionsChoisies.OptionsSelectionnee);
                            ficheOptionsChoisies.Options = OptionsChoisies;
                            ValidationProvider.SetError(pictureBoxRetirerO, "L'option a bien été retirée");
                        }
                    }
                    else if((OptionExiste != null)&&(OptionsChoisies.Count > 0))
                    {
                        ValidationProvider.Clear();
                        errorProvider.Clear();
                        PrixTotal -= ficheOptionsGeneral.OptionsSelectionnee.Prix;
                        textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                        OptionsChoisies.Remove(ficheOptionsChoisies.OptionsSelectionnee);
                        ficheOptionsChoisies.Options = OptionsChoisies;
                        ValidationProvider.SetError(pictureBoxRetirerO, "L'option a bien été retirée");
                    }
                }
                // Si le véhicule n'existe pas encore
                else if(OptionsChoisies.Count > 0)
                {
                    PrixTotal -= ficheOptionsGeneral.OptionsSelectionnee.Prix;
                    textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                    OptionsChoisies.Remove(ficheOptionsChoisies.OptionsSelectionnee);
                    ficheOptionsChoisies.Options = OptionsChoisies;
                    ValidationProvider.SetError(pictureBoxRetirerO, "L'option a bien été retirée");
                }
            }
        }

        /// <summary>
        /// Rajoute l'élément choisi à la liste des options désirées
        /// </summary>
        private void pictureBoxAjouterP_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (fichePackOptionsGeneral.PackOptionsSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                if (listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
                {
                    PackOptionPackVehicule PackExiste = PackChoisis.Find(item => (item.Id == fichePackOptionsGeneral.PackOptionsSelectionnee.Id));
                    if (PackExiste == null)
                    {
                        bool ValidationIndiquee = true;
                        foreach (PackOption PO in fichePackOptionsGeneral.PackOptionsSelectionnee.EnumPackOption)
                        {
                            foreach (OptionVehicule OV in ficheOptionsChoisies.Options)
                            {
                                if ((PO.OptionVehicule.Id == OV.Id) || ((PO.OptionVehicule.TypeOption.Id == OV.TypeOption.Id) && (OV.TypeOption.NomType != "Autres")))
                                {
                                    PrixTotal -= OV.Prix;
                                    ChoixOptionVehicule OptionExisteEnDBDuplication = Program.GMBD.EnumererChoixOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_option_vehicule = {0} AND fk_id_vehicule_vente = {1}", OV.Id, listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                                    if (OptionExisteEnDBDuplication != null)
                                    {
                                        Program.GMBD.SupprimerChoixOptionVehicule(OptionExisteEnDBDuplication);
                                        OptionsChoisies.Remove(OV);
                                    }
                                    else OptionsChoisies.Remove(OV);
                                    ficheOptionsChoisies.Options = OptionsChoisies;
                                }
                            }
                            foreach (PackOptionPackVehicule POPV in fichePackOptionsGeneral.PackOptions)
                            {
                                foreach (PackOption PO2 in POPV.EnumPackOption)
                                {
                                    if ((PO.OptionVehicule.Id == PO2.OptionVehicule.Id) && (PO2.PackOptionPackVehicule.Id != fichePackOptionsGeneral.PackOptionsSelectionnee.Id))
                                    {
                                        ChoixPackVehicule PackExisteEnDBDuplication = Program.GMBD.EnumererChoixPackVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_popv = {0} AND fk_id_vehicule_vente = {1}", PO2.PackOptionPackVehicule.Id, listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                                        if (PackExisteEnDBDuplication != null)
                                        {
                                            if (Program.GMBD.SupprimerChoixPackVehicule(PackExisteEnDBDuplication))
                                            {
                                                // On retire le pack et on actualise
                                                PackChoisis.Remove(PackChoisis.Find(item => item.Id == PO2.PackOptionPackVehicule.Id));
                                                PrixTotal -= PO2.PackOptionPackVehicule.PrixPack;
                                                ValidationIndiquee = true;
                                            }
                                        }
                                        else
                                        {
                                            PackChoisis.Remove(PackChoisis.Find(item => item.Id == PO2.PackOptionPackVehicule.Id));
                                            PrixTotal -= PO2.PackOptionPackVehicule.PrixPack;
                                            ValidationIndiquee = true;
                                        }
                                    }
                                }
                            }
                        }
                        ChoixPackVehicule NouveauPack = new ChoixPackVehicule();
                        NouveauPack.PackOptionPackVehicule = fichePackOptionsGeneral.PackOptionsSelectionnee;
                        NouveauPack.VehiculeVente = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne;
                        if (NouveauPack.EstValide)
                        {
                            Program.GMBD.AjouterChoixPackVehicule(NouveauPack);

                            if (!ValidationIndiquee)
                            {
                                ValidationProvider.SetError(pictureBoxAjouterP, "Le pack a bien été ajouté");
                            }
                            else
                            {
                                ValidationProvider.SetError(pictureBoxAjouterP, "Un ou plusieurs packs comprenant des duplications d'options ont été retirés");
                            }
                            PrixTotal += fichePackOptionsGeneral.PackOptionsSelectionnee.PrixPack;
                            textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                            PackChoisis.Add(fichePackOptionsGeneral.PackOptionsSelectionnee);
                            fichePackOptionsChoisis.PackOptions = PackChoisis;
                        }
                        else
                        {
                            errorProvider.SetError(pictureBoxAjouterP, "Une erreur interne est survenue");
                        }
                    }
                    else
                    {
                        errorProvider.SetError(pictureBoxAjouterP, "Ce pack a déjà été choisi");
                    }
                }
                else
                {
                    if (PackChoisis != null)
                    {
                        PackOptionPackVehicule PackExiste = PackChoisis.Find(item => (item.Id == fichePackOptionsGeneral.PackOptionsSelectionnee.Id));
                        if ((PackExiste == null)||(PackChoisis.Count == 0))
                        {

                            bool ValidationIndiquee = false;
                            foreach (PackOption PO in fichePackOptionsGeneral.PackOptionsSelectionnee.EnumPackOption)
                            {
                                foreach (OptionVehicule OV in ficheOptionsChoisies.Options)
                                {
                                    if ((PO.OptionVehicule.Id == OV.Id) || ((PO.OptionVehicule.TypeOption.Id == OV.TypeOption.Id) && (OV.TypeOption.NomType != "Autres")))
                                    {
                                        PrixTotal -= OV.Prix;
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
                                                PrixTotal -= PO2.PackOptionPackVehicule.PrixPack;
                                                ValidationProvider.SetError(pictureBoxAjouterP, "Un ou plusieurs packs comprenant des duplications d'options ont été retirés");
                                                ValidationIndiquee = true;
                                            }
                                        }
                                    }
                                }
                            }
                            if (!ValidationIndiquee) ValidationProvider.SetError(pictureBoxAjouterP, "Le pack a bien été ajouté");
                            PrixTotal += fichePackOptionsGeneral.PackOptionsSelectionnee.PrixPack;
                            textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
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
        }

        /// <summary>
        /// Retire l'élément choisi de la liste des packs désirés
        /// </summary>
        private void pictureBoxRetirerP_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (fichePackOptionsChoisis.PackOptionsSelectionnee != null)
            {
                // Si le véhicule existe (lors d'une modification)
                if (listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
                {
                    ChoixPackVehicule PackExisteEnDB = Program.GMBD.EnumererChoixPackVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_popv = {0} AND fk_id_vehicule_vente = {1}", fichePackOptionsChoisis.PackOptionsSelectionnee.Id, listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                    PackOptionPackVehicule PackExiste = PackChoisis.Find(item => (item.Id == fichePackOptionsChoisis.PackOptionsSelectionnee.Id));

                    if (PackExisteEnDB != null)
                    {
                        if ((PackExisteEnDB.EstValide) && (Program.GMBD.SupprimerChoixPackVehicule(PackExisteEnDB)))
                        {
                            PrixTotal -= fichePackOptionsChoisis.PackOptionsSelectionnee.PrixPack;
                            textBoxPrixTotal.Text = string.Format("{0} €",PrixTotal);
                            // On retire le pack et on actualise
                            PackChoisis.Remove(fichePackOptionsChoisis.PackOptionsSelectionnee);
                            fichePackOptionsChoisis.PackOptions = PackChoisis;
                            ValidationProvider.SetError(pictureBoxRetirerP, "Le pack a bien été retiré");
                        }
                    }
                    else if ((PackExiste != null)&&(PackChoisis.Count > 0))
                    {
                        ValidationProvider.Clear();
                        errorProvider.Clear();
                        if (PackChoisis.Count > 0)
                        {
                            PrixTotal -= fichePackOptionsChoisis.PackOptionsSelectionnee.PrixPack;
                            textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                            PackChoisis.Remove(fichePackOptionsGeneral.PackOptionsSelectionnee);
                            fichePackOptionsChoisis.PackOptions = PackChoisis;
                            ValidationProvider.SetError(pictureBoxRetirerP, "Le pack a bien été retiré");
                        }
                    }
                    else
                    {
                        errorProvider.SetError(pictureBoxRetirerP, "Ce pack n'existe pas pour ce véhicule");
                    }
                }
                else if (PackChoisis.Count > 0)
                {
                    PrixTotal -= fichePackOptionsChoisis.PackOptionsSelectionnee.PrixPack;
                    textBoxPrixTotal.Text = string.Format("{0} €", PrixTotal);
                    PackChoisis.Remove(fichePackOptionsGeneral.PackOptionsSelectionnee);
                    fichePackOptionsChoisis.PackOptions = PackChoisis;
                    ValidationProvider.SetError(pictureBoxRetirerP, "Le pack a bien été retiré");

                }
            }
        }
        
        /// <summary>
        /// Se produit lors du chargement de la liste de véhicule 
        /// </summary>
        private void listeDeroulanteVehicule1_Load(object sender, EventArgs e)
        {
            listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type = {0} AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
        }

        /// <summary>
        /// Se produit lors du chargement de la liste des véhicules disponibles
        /// </summary>
        private void listeDeroulanteVehiculeVente1_Load(object sender, EventArgs e)
        {
            ChargerVehiculeVente();
        }

        /// <summary>
        /// Charge la listview contenant les véhicules disponibles
        /// </summary>
        private void ChargerVehiculeVente()
        {
            listeDeroulanteVehiculeVente1.VehiculeVente = Program.GMBD.EnumererVehiculeVente(null,
                                                                                             new PDSGBD.MyDB.CodeSql("JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule"),
                                                                                             new PDSGBD.MyDB.CodeSql("WHERE vehicule_vente.id_vehicule_vente NOT IN ( SELECT facture_vente.fk_id_vehicule_vente from facture_vente) AND statut.statut = \"En stock\""),
                                                                                             null);        
        }

        /// <summary>
        /// Se produit lors du l'action du click sur le bouton d'ajout
        /// </summary>
        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            bool ErreurSurPacks = false;
            bool ErreurSurOptions = false;
            errorProvider.Clear();
            ValidationProvider.Clear();
            VehiculeVente NouveauVehiculeDispo = new VehiculeVente();
            NouveauVehiculeDispo.SurErreur += VehiculeVente_SurErreur;
            NouveauVehiculeDispo.AvantChangement += NouveauVehiculeDispo_AvantChangement;
            NouveauVehiculeDispo.DateArrivee = dateTimePickerDateArrivee.Value;
            NouveauVehiculeDispo.DateCommande = dateTimePickerDateCommande.Value;
            NouveauVehiculeDispo.DateMiseEnCirculation = DateTime.MinValue;
            NouveauVehiculeDispo.Kilometrage = int.Parse(numericUpDownKilometrage.Value.ToString());
            NouveauVehiculeDispo.NumeroChassis = textBoxNumChassis.Text;
            NouveauVehiculeDispo.Vehicule = listeDeroulanteVehicule1.VehiculeSelectionne;
            NouveauVehiculeDispo.PrixTotal = PrixTotal;
            NouveauVehiculeDispo.StatutLivraison = Program.GMBD.EnumererStatut(null, null, new PDSGBD.MyDB.CodeSql("WHERE statut = \"En stock\""), null).FirstOrDefault();
            NouveauVehiculeDispo.AnneeConstruction = int.Parse(numericUpDownAnneeConstruction.Value.ToString());
            if((NouveauVehiculeDispo.EstValide)&&(Program.GMBD.AjouterVehiculeVente(NouveauVehiculeDispo)))
            {                
                for (int i = 0; i < OptionsChoisies.Count; i++)
                {
                    ChoixOptionVehicule OV = new ChoixOptionVehicule();
                    OV.VehiculeVente = NouveauVehiculeDispo;
                    OV.OptionVehicule = OptionsChoisies[i];
                    if ((OV.EstValide) && (Program.GMBD.AjouterChoixOptionVehicule(OV)))
                    {
                        //ne rien faire vu que la création a été validée
                    }
                    else
                    {
                        ErreurSurOptions = true;
                    }
                }
                for (int i = 0; i < PackChoisis.Count; i++)
                {
                    ChoixPackVehicule CPV = new ChoixPackVehicule();
                    CPV.VehiculeVente = NouveauVehiculeDispo;
                    CPV.PackOptionPackVehicule = PackChoisis[i];
                    if ((CPV.EstValide) && (Program.GMBD.AjouterChoixPackVehicule(CPV)))
                    {
                        //ne rien faire vu que la création a été validée
                    }
                    else
                    {
                        ErreurSurPacks = true;
                    }                    
                }

                if((ErreurSurOptions == true)&&(ErreurSurPacks == true))
                {
                    errorProvider.SetError(buttonAjouter, string.Format("{0} correctement ajouté mais un problème sur les options et les packs s'est produit, veuillez revérifier", (EstVoiture) ? "Voiture" : "Moto"));
                    listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne = NouveauVehiculeDispo;
                }
                else if((ErreurSurOptions == false)&&(ErreurSurPacks == true))
                {
                    ValidationProvider.SetError(buttonAjouter, string.Format("{0} correctement ajouté mais un problème sur les packs s'est produit, veuillez revérifier", (EstVoiture) ? "Voiture" : "Moto"));
                    listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne = NouveauVehiculeDispo;
                }
                else if((ErreurSurOptions == true)&&(ErreurSurPacks == false))
                {
                    ValidationProvider.SetError(buttonAjouter, string.Format("{0} correctement ajouté mais un problème sur les options s'est produit, veuillez revérifier", (EstVoiture) ? "Voiture" : "Moto"));
                    listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne = NouveauVehiculeDispo;
                }
                else
                {
                    ChargerVehiculeVente();
                    ClearFormulaire();
                    ValidationProvider.SetError(buttonAjouter, string.Format("{0} correctement ajouté", (EstVoiture) ? "Voiture" : "Moto"));
                }
            }
            
        }

        /// <summary>
        /// Nettoie le formulaire des données affichées
        /// </summary>
        private void ClearFormulaire()
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            dateTimePickerDateArrivee.Value = DateTime.Now;
            dateTimePickerDateCommande.Value = DateTime.Now;
            numericUpDownKilometrage.Value = 0;
            textBoxNumChassis.Text = "";
            ChargerVehiculeVente();
            listeDeroulanteVehicule1.VehiculeSelectionne = null;
            fichePackOptionsChoisis.NettoyerListView();
            ficheOptionsChoisies.NettoyerListView();
            OptionsChoisies = new List<OptionVehicule>();
            PackChoisis = new List<PackOptionPackVehicule>();
            listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne = null;
            buttonAjouter.Enabled = true;
            buttonModifier.Enabled = false;
            buttonSupprimer.Enabled = false;
            this.MinimumSize = new Size(1489, 699);
            ficheOptionsGeneral.Options = null;
            textBoxPrix.Text = "0 €";
            textBoxPrixTotal.Text = "0 €";
            listeDeroulanteVehicule1.VehiculeSelectionne = null;
            listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne = null;
            pictureBoxVoiture.Image = null;
            listeDeroulanteVehicule1.Enabled = true;
        }

        /// <summary>
        /// Se produit avant le changement d'un nouveau véhicule disponible
        /// </summary>
        private void NouveauVehiculeDispo_AvantChangement(VehiculeVente Entite, VehiculeVente.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case VehiculeVente.Champs.DateArrivee:
                    if(dateTimePickerDateArrivee.Value < dateTimePickerDateCommande.Value)
                    {
                        AccumulateurErreur.NotifierErreur("La date d'arrivée ne peut pas être inférieure à la date de commande");
                    }
                    break;
                case VehiculeVente.Champs.DateCommande:
                    if(dateTimePickerDateCommande.Value > dateTimePickerDateArrivee.Value)
                    {
                        AccumulateurErreur.NotifierErreur("La date de commande ne peut pas être inférieure à la date d'arrivée");
                    }
                    break;
                case VehiculeVente.Champs.NumeroChassis:
                    if(NouvelleValeur.ToString().Length < 1)
                    {
                        AccumulateurErreur.NotifierErreur("Le numéro de châssis doit être supérieur ou égal à 1 caractères");
                    }
                    else
                    {
                        VehiculeVente NumeroChassisExiste = Program.GMBD.EnumererVehiculeVente(null, new PDSGBD.MyDB.CodeSql("JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut "),
                                                                                                    new PDSGBD.MyDB.CodeSql("WHERE numero_chassis = {0} AND statut = \"En stock\"", textBoxNumChassis.Text), null).FirstOrDefault();
                        if (NumeroChassisExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("Ce numéro de châssis existe pour un véhicule disponible dans cette concession");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sert à indiquer sur quel "controler" afficher les messages d'erreur indiqués par le modèle de VehiculeVente
        /// </summary>
        private void VehiculeVente_SurErreur(VehiculeVente Entite, VehiculeVente.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case VehiculeVente.Champs.AnneeConstruction:
                    errorProvider.SetError(numericUpDownAnneeConstruction, MessageErreur);
                    break;
                case VehiculeVente.Champs.DateArrivee:
                    errorProvider.SetError(dateTimePickerDateArrivee, MessageErreur);
                    break;
                case VehiculeVente.Champs.DateCommande:
                    errorProvider.SetError(dateTimePickerDateCommande, MessageErreur);
                    break;
                case VehiculeVente.Champs.Kilometrage:
                    errorProvider.SetError(numericUpDownKilometrage, MessageErreur);
                    break;
                case VehiculeVente.Champs.NumeroChassis:
                    errorProvider.SetError(textBoxNumChassis, MessageErreur);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Se produit lors de l'action du click sur le bouton de modification
        /// </summary>
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if(listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
            {
                VehiculeVente VehiculeAModifier = listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne;
                VehiculeAModifier.SurErreur += VehiculeVente_SurErreur;
                VehiculeAModifier.AvantChangement += VehiculeAModifier_AvantChangement;
                VehiculeAModifier.DateArrivee = dateTimePickerDateArrivee.Value;
                VehiculeAModifier.DateCommande = dateTimePickerDateCommande.Value;
                VehiculeAModifier.DateMiseEnCirculation = DateTime.MaxValue;
                VehiculeAModifier.Kilometrage = int.Parse(numericUpDownKilometrage.Value.ToString());
                VehiculeAModifier.NumeroChassis = textBoxNumChassis.Text;
                VehiculeAModifier.PrixTotal = PrixTotal;
                VehiculeAModifier.AnneeConstruction = int.Parse(numericUpDownAnneeConstruction.Value.ToString());
                if ((VehiculeAModifier.EstValide) && (Program.GMBD.ModifierVehiculeVente(VehiculeAModifier)))
                {
                        ChargerVehiculeVente();
                        ClearFormulaire();
                        ValidationProvider.SetError(buttonModifier, string.Format("{0} correctement modifié", (EstVoiture) ? "Voiture" : "Moto"));                       
                }


            }
        }       

        /// <summary>
        /// Sert à faire des vérications supplémentaires avant une modification d'un véhicule de concession
        /// </summary>
        private void VehiculeAModifier_AvantChangement(VehiculeVente Entite, VehiculeVente.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case VehiculeVente.Champs.DateArrivee:
                    if (dateTimePickerDateArrivee.Value < dateTimePickerDateCommande.Value)
                    {
                        AccumulateurErreur.NotifierErreur("La date d'arrivée ne peut pas être inférieure à la date de commande");
                    }
                    break;
                case VehiculeVente.Champs.DateCommande:
                    if (dateTimePickerDateCommande.Value < dateTimePickerDateArrivee.Value)
                    {
                        AccumulateurErreur.NotifierErreur("La date de commande ne peut pas être inférieure à la date d'arrivée");
                    }
                    break;
                case VehiculeVente.Champs.NumeroChassis:
                    VehiculeVente NumeroChassisExiste = Program.GMBD.EnumererVehiculeVente(null, new PDSGBD.MyDB.CodeSql("JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut "),
                                                                                                new PDSGBD.MyDB.CodeSql("WHERE numero_chassis = {0} AND statut = \"En stock\" AND id_vehicule_vente != {1}", textBoxNumChassis.Text,listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                    if (NumeroChassisExiste != null)
                    {
                        AccumulateurErreur.NotifierErreur("Ce numéro de châssis existe pour un véhicule disponible dans cette concession");
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Se produit lors du click sur le bouton d'annulation
        /// </summary>
        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            ClearFormulaire();
        }

        /// <summary>
        /// Se produit lors du la suppresion d'un véhicule de concession
        /// </summary>
        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if(listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne != null)
            {
                VehiculeVente VehiculeExiste = Program.GMBD.EnumererVehiculeVente(null, null,
                                                                                       new PDSGBD.MyDB.CodeSql("WHERE id_vehicule_vente = {0}", listeDeroulanteVehiculeVente1.VehiculeVenteSelectionne.Id), null).FirstOrDefault();
                if (VehiculeExiste != null)
                {
                    Program.GMBD.SupprimerVehiculeVente(VehiculeExiste);
                    ClearFormulaire();
                    ValidationProvider.SetError(buttonSupprimer, "Suppression du véhicule terminée");
                }
            }
        }


        private void RefreshPackGeneral()
        {
            fichePackOptionsGeneral.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE pack_option_pack_vehicule.id_pack_option_pack_vehicule NOT IN (select popv_vehicule.fk_id_popv from popv_vehicule) AND disponible = 1 AND popv_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
            fichePackOptionsGeneral.TexteFiltrePackOptions = "";
           
        }
    }

}
