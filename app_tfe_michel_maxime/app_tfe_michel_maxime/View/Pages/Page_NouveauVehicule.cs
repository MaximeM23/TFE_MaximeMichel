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
    public partial class Page_NouveauVehicule : UserControl
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


        public bool EstMoto = false;
        public bool EstVoiture = false;
        private bool ImageChangee = false;
        private bool CaractSelectionnee = false;
        private int IndicateurDAjout = 0;

        public Page_NouveauVehicule()
        {
            InitializeComponent();
            listeDeroulanteVehicule1.SurChangementSelection += ListeDeroulanteVehicule_SurChangementSelection;
            ficheTechnique1.SurChangementSelection += FicheTechnique1_SurChangementSelection;
            listeDeroulanteCaracteristique1.SurChangementSelection += ListeDeroulanteCaracteristique_SurChangementSelection;
            listeDeroulanteCaracteristiqueAjouter.SurChangementSelection += listeDeroulanteCaracteristiqueAjouter_SurChangementSelection;
            listeDeroulanteTypeVehiculeFiltre.SurChangementSelection += ListeDeroulanteTypeVehiculeFiltre_SurChangementSelection;

            numericUpDownPrix.Maximum = int.MaxValue;
            numericUpDownPrix.Minimum = 0;
            numericUpDownTempsLivraison.Maximum = 100;
            numericUpDownTempsLivraison.Minimum = 1;

            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());

            panelAjouterCaract.BringToFront();

            this.MinimumSize = new Size(1300, 672);
        }

        private void ListeDeroulanteTypeVehiculeFiltre_SurChangementSelection(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if ((listeDeroulanteTypeVehiculeFiltre.TypeVehiculeSelectionne != null) && (CaractSelectionnee == false))
            {
                listeDeroulanteCaracteristique1.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE fk_id_type = {0} AND disponible = 1", listeDeroulanteTypeVehiculeFiltre.TypeVehiculeSelectionne.Id), null);
            }
        }

        private void listeDeroulanteCaracteristiqueAjouter_SurChangementSelection(object sender, EventArgs e)
        {
            if(listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne != null)
            {
                // Si la caractéristique est déjà référencée sur une facture, sa modification n'est plus possible
                Caracteristique CaracteristiqueExistante = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql(@"JOIN type ON caracteristique.fk_id_type = type.id_type 
                                                                                                                                JOIN vehicule_caracteristique ON vehicule_caracteristique.fk_id_caracteristique = caracteristique.id_caracteristique 
                                                                                                                                JOIN vehicule ON vehicule_caracteristique.fk_id_vehicule = vehicule.id_vehicule")
                                                                                                    , new PDSGBD.MyDB.CodeSql(@"WHERE ((vehicule.id_vehicule IN(SELECT client_vehicule.fk_id_vehicule FROM client_vehicule)) OR (vehicule.id_vehicule IN(SELECT vehicule_vente.fk_id_vehicule FROM vehicule_vente))) AND id_caracteristique = {0}", listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.Id), null).FirstOrDefault();

                if(CaracteristiqueExistante != null)
                {
                    buttonAjouterCaract.Enabled = false;
                    buttonModifierCaract.Enabled = false;
                    buttonSupprimerCaract.Enabled = true;
                }
                else
                {
                    buttonAjouterCaract.Enabled = false;
                    buttonModifierCaract.Enabled = true;
                    buttonSupprimerCaract.Enabled = true;
                }
                textBoxNomCaract.Text = listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.NomCaracteristique;
                listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne = listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.TypeVehicule;
                
            }
        }

        /// <summary>
        /// Se produit lors d'un changement de sélection dans la liste déroulante
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeDeroulanteVehicule_SurChangementSelection(object sender, EventArgs e)
        {
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                errorProvider.Clear();
                ValidationProvider.Clear();
                // Permet de charger l'outils comprenant l'interface de liaison entre les packs et le véhicule choisi
                lierPack.Vehicule = listeDeroulanteVehicule1.VehiculeSelectionne;
                lierPack.ChargerPanelPack();

                // Permet de charger l'outils comprenant l'interface de liaison entre les options et le véhicule choisi
                lierOptions.Vehicule = listeDeroulanteVehicule1.VehiculeSelectionne;
                lierOptions.ChargerPanelOptions();

                Vehicule VehiculeReference = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type")
                                                                              , new PDSGBD.MyDB.CodeSql(@"WHERE (vehicule.id_vehicule IN(SELECT client_vehicule.fk_id_vehicule FROM client_vehicule WHERE fk_id_vehicule = {0})
                                                                                                           OR vehicule.id_vehicule IN(SELECT vehicule_vente.fk_id_vehicule FROM vehicule_vente WHERE fk_id_vehicule = {0})) AND id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null).FirstOrDefault();

                if(VehiculeReference == null)
                {
                    buttonModifier.Enabled = true;
                    panelLier.Enabled = true;
                }
                else
                {
                    buttonModifier.Enabled = false;
                    panelLier.Enabled = false;
                }
                buttonLierOptions.Enabled = true;
                buttonAjouter.Enabled = false;
                buttonSupprimer.Enabled = true;
                buttonLierPack.Enabled = true;
                lierPack.Enabled = true;              
                buttonPanelLierCaract.Enabled = true;
                ficheTechnique1.Caracteristique = listeDeroulanteVehicule1.VehiculeSelectionne.EnumVehiculeCaracteristique;
                textBoxModele.Text = listeDeroulanteVehicule1.VehiculeSelectionne.Modele;
                numericUpDownPrix.Value = decimal.Parse(listeDeroulanteVehicule1.VehiculeSelectionne.PrixVehicule.ToString());
                numericUpDownTempsLivraison.Value = decimal.Parse(listeDeroulanteVehicule1.VehiculeSelectionne.TempsLivraison.ToString());
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + ""))
                {
                    pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + "");
                }
            }
            else if(listeDeroulanteVehicule1.VehiculeSelectionne == null)
            {
                buttonLierOptions.Enabled = false;
                buttonPanelLierCaract.Enabled = false;
                panelLier.Enabled = false;
                buttonLierPack.Enabled = false;
                lierPack.Enabled = false;               
            }
        }

        /// <summary>
        /// Se produit lors du clic sur le bouton correspondant à l'ajout d'une image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAjouterImage_Click(object sender, EventArgs e)
        {
            //Création du répertoire
            if (!Directory.Exists(string.Format("{0}\\ImagesVehicule", Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString())))
            {
                Directory.CreateDirectory(string.Format("{0}\\ImagesVehicule", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            }

            using (OpenFileDialog openFileDialog1 = new OpenFileDialog())
            {
                openFileDialog1.Filter = "Image files (*.jpg,*.jpeg,*.png)|*.jpg;*.jpeg;*.png";
                openFileDialog1.Multiselect = false;
                openFileDialog1.ShowDialog();
                string FilePath = openFileDialog1.FileName;
                
                if (openFileDialog1.FileName != "")
                {
                    bool TailleCorrecte = true;
                    using (Image img = Image.FromFile(openFileDialog1.FileName))
                    {
                        if ((img.Height != 192) && (img.Width != 320))
                        {
                            TailleCorrecte = false;
                        }
                    }
                    if (TailleCorrecte)
                    {
                        if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/ImagesVehicule/" + openFileDialog1.SafeFileName))
                        {
                            File.Copy(openFileDialog1.FileName, Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "\\ImagesVehicule\\" + openFileDialog1.SafeFileName);
                            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/ImagesVehicule/" + openFileDialog1.SafeFileName))
                            {
                                pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString() + "/ImagesVehicule/" + openFileDialog1.SafeFileName);
                                pictureBox1.Tag = openFileDialog1.SafeFileName;
                            }
                            ImageChangee = true;
                        }
                        else
                        {
                            errorProvider.SetError(buttonAjouterImage, "Le nom du fichier existe déjà, veuillez le renommer avant son enregistrement");
                            openFileDialog1.Dispose();
                                
                        }
                    }
                    else
                    {
                        errorProvider.SetError(buttonAjouterImage, "L'image doit correspondre au format 320x192");
                        openFileDialog1.Dispose();
                    }
                }                
            }
        }
        
        /// <summary>
        /// Se produit avant le changement dans la base de données
        /// </summary>
        private void NouveauVehicule_AvantChangement(Vehicule Entite, Vehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch(Champ)
            {
                case Vehicule.Champs.Modele:
                    Vehicule ModeleExiste = Program.GMBD.EnumererVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE modele = {0} AND disponible = 1", NouvelleValeur)
                                                                                    , null).FirstOrDefault();
                    if(ModeleExiste != null)
                    {
                        AccumulateurErreur.NotifierErreur("Ce nom de modèle existe déjà");
                    }
                    break;
            }
        }

        /// <summary>
        /// Indique sur quel UserControl mettre le message d'erreur pour chacune des valeurs modifiables
        /// </summary>
        private void NouveauVehicule_SurErreur(Vehicule Entite, Vehicule.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case Vehicule.Champs.Modele:
                    errorProvider.SetError(textBoxModele, MessageErreur);
                    break;
                case Vehicule.Champs.PrixVehicule:
                    errorProvider.SetError(numericUpDownTempsLivraison, MessageErreur);
                    break;
                case Vehicule.Champs.NomImage:
                    errorProvider.SetError(buttonAjouterImage, MessageErreur);
                    break;
                case Vehicule.Champs.TempsLivraison:
                    errorProvider.SetError(numericUpDownTempsLivraison, MessageErreur);
                    break;
                default:
                    break;
            }
        }


        /// <summary>
        /// Se produit lors du chargement de la page "NouveauVehicule"
        /// </summary>
        private void Page_NouveauVehicule_Load(object sender, EventArgs e)
        {
            if (EstVoiture)
            {
                labelTitre.Text = "Les voitures";
                labelFicheTechnique.Text = "Fiche technique de la voiture";
                labelRechercheVehicule.Text = "Rechercher une voiture";
            }
            else if (EstMoto)
            {
                labelTitre.Text = "Les motos";
                labelFicheTechnique.Text = "Fiche technique de la moto";
                labelRechercheVehicule.Text = "Rechercher une moto";
            }
            listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type != {0} AND disponible = 1", (EstVoiture) ? "Moto" : "Voiture"), null);
        }

        /// <summary>
        /// Se produit lors du clic sur le bouton d'ajout des informations propres du véhicule
        /// </summary>
        private void buttonAjouter_Click(object sender, EventArgs e)
        {

            errorProvider.Clear();
            ValidationProvider.Clear();
            Vehicule NouveauVehicule = new Vehicule();
            NouveauVehicule.SurErreur += NouveauVehicule_SurErreur;
            NouveauVehicule.AvantChangement += NouveauVehicule_AvantChangement;
            NouveauVehicule.Modele = textBoxModele.Text;
            NouveauVehicule.PrixVehicule = double.Parse(numericUpDownPrix.Value.ToString());
            NouveauVehicule.TempsLivraison = int.Parse(numericUpDownTempsLivraison.Value.ToString());
            NouveauVehicule.TypeVehicule = Program.GMBD.EnumererTypeVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE type = {0}", (EstMoto) ? "Moto" : "Voiture"), null).FirstOrDefault();
            NouveauVehicule.Disponible = 1;
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                NouveauVehicule.NomImage = (ImageChangee) ? pictureBox1.Tag.ToString() : listeDeroulanteVehicule1.VehiculeSelectionne.NomImage;
            }
            else
            {
                NouveauVehicule.NomImage = (ImageChangee) ? pictureBox1.Tag.ToString() : null;
            }
            if ((NouveauVehicule.EstValide) && (Program.GMBD.AjouterVehicule(NouveauVehicule)))
            {               
                listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type = {0} AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
                listeDeroulanteVehicule1.VehiculeSelectionne = NouveauVehicule;
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + ""))
                {
                    pictureBox1.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + "");
                }
                ImageChangee = false;
                ValidationProvider.SetError(buttonAjouter, (EstMoto) ? "Moto correctement sauvegardée" : "Voiture correctement sauvegardée");
            }
        }
        
        /// <summary>
        /// Se produit lors du clic sur le bouton de modification des données du véhicule
        /// </summary>
        private void buttonModifier_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                Vehicule VehiculeAModifier = listeDeroulanteVehicule1.VehiculeSelectionne;
                VehiculeAModifier.SurErreur += NouveauVehicule_SurErreur;
                VehiculeAModifier.AvantChangement += VehiculeAModifier_AvantChangement; ;
                VehiculeAModifier.Modele = textBoxModele.Text;
                VehiculeAModifier.PrixVehicule = double.Parse(numericUpDownPrix.Value.ToString());
                VehiculeAModifier.TempsLivraison = int.Parse(numericUpDownTempsLivraison.Value.ToString());
                VehiculeAModifier.Disponible = listeDeroulanteVehicule1.VehiculeSelectionne.Disponible;
                VehiculeAModifier.NomImage = (ImageChangee) ? openFileDialog1.SafeFileName : listeDeroulanteVehicule1.VehiculeSelectionne.NomImage;
                VehiculeAModifier.TypeVehicule = Program.GMBD.EnumererTypeVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE type = {0}", (EstMoto) ? "Moto" : "Voiture"), null).FirstOrDefault();
                if((VehiculeAModifier.EstValide) && (Program.GMBD.ModifierVehicule(VehiculeAModifier)))
                {
                    ValidationProvider.SetError(buttonModifier, "Modification correctement effectuée");
                    listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND type = {0}",(EstMoto) ? "Moto" : "Voiture"), null);
                    listeDeroulanteVehicule1.VehiculeSelectionne = VehiculeAModifier;
                    ImageChangee = false;
                }
            }
        }

        /// <summary>
        /// Se produit avant la modification en base de données
        /// </summary>
        private void VehiculeAModifier_AvantChangement(Vehicule Entite, Vehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Vehicule.Champs.Modele:
                    Vehicule ModeleExiste = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_vehicule ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE modele = {0} AND id_vehicule != {1} AND type = {2} AND disponible = 1", NouvelleValeur,Entite.Id,(EstMoto) ? "Moto" : "Voiture"), null).FirstOrDefault();
                    if (ModeleExiste != null)
                    {
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("Ce modèle existe déjà");
                    }
                    break;
            }
        }

        /// <summary>
        /// Se produit lors du changement de sélection dans la fiche technique du véhicule
        /// </summary>
        private void FicheTechnique1_SurChangementSelection(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (ficheTechnique1.CaracteristiqueSelectionnee != null)
            {
                listeDeroulanteCaracteristique1.CaracteristiqueSelectionne = ficheTechnique1.CaracteristiqueSelectionnee.Caracteristique;
                textBoxNomCaract.Text = ficheTechnique1.CaracteristiqueSelectionnee.Caracteristique.NomCaracteristique;
                textBoxInfo.Text = ficheTechnique1.CaracteristiqueSelectionnee.Valeur;
                buttonModifierLier.Enabled = true;
            }
        }

        /// <summary>
        /// Se produit lors du changement dans la liste déroulante qui correspond aux caractéristiques déjà existantes dans la base de données
        /// </summary>
        private void ListeDeroulanteCaracteristique_SurChangementSelection(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (listeDeroulanteCaracteristique1.CaracteristiqueSelectionne != null)
            {
                CaractSelectionnee = true;
                listeDeroulanteTypeVehiculeFiltre.TypeVehiculeSelectionne = listeDeroulanteCaracteristique1.CaracteristiqueSelectionne.TypeVehicule;
            }
           
        }

        /// <summary>
        /// Se produit lors du clic sur le bouton d'ajout d'une caractéristique
        /// </summary>
        private void buttonAjouterCaract_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();            
            Caracteristique CaracteristiqueExiste = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE caracteristique = {0}", textBoxNomCaract.Text.Trim()), null).FirstOrDefault();

            if((CaracteristiqueExiste != null)&&(CaracteristiqueExiste.Disponible == 1) && ((CaracteristiqueExiste.TypeVehicule.NomDuType == listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne.NomDuType)))
            {
                errorProvider.SetError(buttonAjouterCaract, "Cette caractéristique existe déjà");
            }
            else if((CaracteristiqueExiste != null) && ( CaracteristiqueExiste.TypeVehicule.NomDuType == ((EstVoiture) ? "Voiture" : "Moto")))
            {
                // Permet de vérifier si l'utilisateur souhaite modifié l'enregistrement existant sous l'autre type de véhicule en générique afin de garder 1 seul enregsitrement pour les 2 véhicules
                if (IndicateurDAjout == 0)
                {
                    errorProvider.SetError(buttonAjouterCaract, "Cette option existe pour les voitures. Pour la passer en générique, veuillez recliquer une deuxième fois sur ajouter. Sinon, cliquez sur annuler");
                    IndicateurDAjout++;
                }
                else if (IndicateurDAjout == 1)
                {
                    CaracteristiqueExiste.TypeVehicule = Program.GMBD.EnumererTypeVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE type = \"Générique\""), null).FirstOrDefault();
                    if (CaracteristiqueExiste.Disponible == 0) CaracteristiqueExiste.Disponible = 1;
                    if (CaracteristiqueExiste.EstValide && Program.GMBD.ModifierCaracteristique(CaracteristiqueExiste))
                    {
                        RefreshListeCaract();
                        listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = CaracteristiqueExiste;
                        ValidationProvider.SetError(buttonAjouterCaract, "L'option a bien été modifiée et son type est passé à générique");
                    }
                    IndicateurDAjout = 0;
                }
            }
            else if((CaracteristiqueExiste != null) && (CaracteristiqueExiste.Disponible == 0) && (listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne.NomDuType == CaracteristiqueExiste.TypeVehicule.NomDuType))
            {
                CaracteristiqueExiste.Disponible = 1;
                if((CaracteristiqueExiste.EstValide)&&(Program.GMBD.ModifierCaracteristique(CaracteristiqueExiste)))
                {
                    RefreshListeCaract();
                    ValidationProvider.SetError(buttonAjouterCaract, "La caractéristique a bien été ajoutée");
                    listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = CaracteristiqueExiste;
                }
            }
            else if((CaracteristiqueExiste != null) && (CaracteristiqueExiste.Disponible == 0) && (listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne.NomDuType != CaracteristiqueExiste.TypeVehicule.NomDuType))
            {
                VehiculeCaracteristique CaracteristiqueReferencee = Program.GMBD.EnumererVehiculeCaracteristique(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_caracteristique = {0}", listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.Id), null).FirstOrDefault();

                if(CaracteristiqueReferencee != null)
                {
                    CaracteristiqueExiste.Disponible = 1;
                    CaracteristiqueExiste.TypeVehicule = listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne;
                    if ((CaracteristiqueExiste.EstValide) && (Program.GMBD.ModifierCaracteristique(CaracteristiqueExiste)))
                    {
                        RefreshListeCaract();  
                        ClearCaract();
                        ValidationProvider.SetError(buttonAjouterCaract, "La caractéristique a bien été ajoutée");
                        listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = CaracteristiqueExiste;

                    }
                }
                else
                {
                    CaracteristiqueExiste.TypeVehicule = listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne;
                    if((CaracteristiqueExiste.EstValide)&&(Program.GMBD.ModifierCaracteristique(CaracteristiqueExiste)))
                    {
                        RefreshListeCaract();
                        ClearCaract();
                        ValidationProvider.SetError(buttonAjouterCaract, "La caractéristique a bien été ajoutée");
                        listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = CaracteristiqueExiste;

                    }
                }

            }
            else
            {
                Caracteristique NouvelleCaracteristique = new Caracteristique();
                NouvelleCaracteristique.SurErreur += NouvelleCaracteristique_SurErreur;
                NouvelleCaracteristique.NomCaracteristique = textBoxNomCaract.Text;
                NouvelleCaracteristique.TypeVehicule = listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne;
                NouvelleCaracteristique.Disponible = 1;
                if ((NouvelleCaracteristique.EstValide) && (Program.GMBD.AjouterCaracteristique(NouvelleCaracteristique)))
                {
                    RefreshListeCaract();
                    ValidationProvider.SetError(buttonAjouterCaract, "La caractéristique a bien été ajoutée");
                    listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = NouvelleCaracteristique;
                }
            }
                
        }

        private void NouvelleValeurCaracteristique_SurErreur(VehiculeCaracteristique Entite, VehiculeCaracteristique.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case VehiculeCaracteristique.Champs.Valeur:
                    errorProvider.SetError(textBoxInfo, MessageErreur);
                    break;
            }
        }

        private void NouvelleCaracteristique_AvantChangement(Caracteristique Entite, Caracteristique.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch(Champ)
            {
                case Caracteristique.Champs.Type:
                    if (listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne == null)
                    {
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("Veuillez choisir un type pour la caractéristique");
                    }
                    break;
            }
        }
        

        private void NouvelleCaracteristique_SurErreur(Caracteristique Entite, Caracteristique.Champs Champ, string MessageErreur)
        {
            switch(Champ)
            {
                case Caracteristique.Champs.Caracteristique:
                    errorProvider.SetError(textBoxNomCaract, MessageErreur);
                    break;
                case Caracteristique.Champs.Type:
                    errorProvider.SetError(listeDeroulanteTypeVehicule1, MessageErreur);
                    break;
            }
        }

        private void RefreshFicheTechnique()
        {
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                ficheTechnique1.Caracteristique = listeDeroulanteVehicule1.VehiculeSelectionne.EnumVehiculeCaracteristique;
            }
        }

        private void RefreshListeCaract()
        {
            if(listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne != null) listeDeroulanteCaracteristique1.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type = {0} AND disponible = 1", listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne.NomDuType), null);
            listeDeroulanteCaracteristiqueAjouter.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type = {0} OR type = \"Générique\" AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
        }

        private void buttonAnnulerModele_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            listeDeroulanteVehicule1.VehiculeSelectionne = null;
            pictureBox1.Image = null;
            textBoxModele.Text = "";
            numericUpDownPrix.Value = 0;
            numericUpDownTempsLivraison.Value = 1;
            buttonAjouter.Enabled = true;
            buttonModifier.Enabled = false;
            buttonSupprimer.Enabled = false;  
        }

        private void ClearCaract()
        {        
            listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne = null;
            listeDeroulanteCaracteristique1.CaracteristiqueSelectionne = null;
            listeDeroulanteTypeVehiculeFiltre.TypeVehiculeSelectionne = null;
            listeDeroulanteCaracteristique1.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE (type = {0} OR type = \"Générique\") AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
            textBoxInfo.Text = "";
            textBoxNomCaract.Text = "";
        }

        private void buttonAnnulerCaract_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            ClearCaract();
            CaractSelectionnee = false;
            buttonModifierLier.Enabled = false;
        }

        private void buttonModifierCaract_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if(listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne != null)
            {
                VehiculeCaracteristique CaracteristiqueReferencee = Program.GMBD.EnumererVehiculeCaracteristique(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_caracteristique = {0}", listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.Id), null).FirstOrDefault();
                Caracteristique CaracteristiqueExiste = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE caracteristique = {0} AND type = {1} AND id_caracteristique != {2}", textBoxNomCaract.Text.Trim(), listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne.NomDuType, listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.Id), null).FirstOrDefault();

                if ((CaracteristiqueExiste != null) && (CaracteristiqueExiste.Disponible == 1))
                {
                    errorProvider.SetError(buttonModifierCaract, "Cette caractéristique existe déjà");
                    listeDeroulanteCaracteristique1.CaracteristiqueSelectionne = CaracteristiqueExiste;
                }
                else if ((CaracteristiqueExiste != null) && (CaracteristiqueExiste.Disponible == 0) && (CaracteristiqueReferencee == null))
                {
                    CaracteristiqueExiste.SurErreur += NouvelleCaracteristique_SurErreur;
                    CaracteristiqueExiste.Disponible = 1;
                    if ((CaracteristiqueExiste.EstValide) && (Program.GMBD.ModifierCaracteristique(CaracteristiqueExiste)))
                    {
                        ValidationProvider.SetError(buttonModifier, "La caractéristique a bien été modifiée");
                        RefreshListeCaract();
                        listeDeroulanteCaracteristique1.CaracteristiqueSelectionne = CaracteristiqueExiste;
                    }
                }
                else
                {
                    Caracteristique CaracteristiqueAModifier = listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne;
                    CaracteristiqueAModifier.SurErreur += NouvelleCaracteristique_SurErreur;
                    CaracteristiqueAModifier.NomCaracteristique = textBoxNomCaract.Text;
                    CaracteristiqueAModifier.TypeVehicule = listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne;
                    if ((CaracteristiqueAModifier.EstValide) && (Program.GMBD.ModifierCaracteristique(CaracteristiqueAModifier)))
                    {
                        errorProvider.Clear();
                        ValidationProvider.SetError(buttonModifierCaract, "Caractéristique correctement modifiée");
                        textBoxNomCaract.Text = "";
                        listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne = null;
                        RefreshFicheTechnique();
                        RefreshListeCaract();
                        listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = CaracteristiqueAModifier;
                    }
                }
            }            
        }

        private void buttonSupprimerCaract_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne != null)
            {
                VehiculeCaracteristique VehiculeCaractUtilise = Program.GMBD.EnumererVehiculeCaracteristique(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_caracteristique = {0}", listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne.Id), null).FirstOrDefault();
                if(VehiculeCaractUtilise == null)
                {
                    if (Program.GMBD.SupprimerCaracteristique(listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne))
                    {
                        ClearCaract();
                        errorProvider.Clear();
                        ValidationProvider.Clear();
                        ValidationProvider.SetError(buttonSupprimerCaract, "La caractéristique a bien été supprimée");
                        RefreshNouvelleCaract();
                        RefreshListeCaract();
                    }
                }
                else
                {
                    errorProvider.Clear();
                    ValidationProvider.Clear();
                    Caracteristique CaracteristiqueASupprimer = listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne;
                    CaracteristiqueASupprimer.Disponible = 0;
                    if((CaracteristiqueASupprimer.EstValide)&&(Program.GMBD.ModifierCaracteristique(CaracteristiqueASupprimer)))
                    {
                        ValidationProvider.SetError(buttonSupprimerCaract, "La caractéristique a bien été supprimée");
                        RefreshNouvelleCaract();
                        RefreshListeCaract();
                    }
                }
            }
        }

        private void pictureBoxCaractA_Click(object sender, EventArgs e)
        {            
            VehiculeCaracteristique NouvelleValeurCaracteristique = new VehiculeCaracteristique();
            NouvelleValeurCaracteristique.SurErreur += NouvelleValeurCaracteristique_SurErreur1; ;
            NouvelleValeurCaracteristique.AvantChangement += NouvelleValeurCaracteristique_AvantChangement;
            NouvelleValeurCaracteristique.Valeur = textBoxInfo.Text;
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null) NouvelleValeurCaracteristique.Vehicule = listeDeroulanteVehicule1.VehiculeSelectionne;
            else errorProvider.SetError(listeDeroulanteVehicule1, "Veuillez sélectionner un véhicule");
            NouvelleValeurCaracteristique.Caracteristique = listeDeroulanteCaracteristique1.CaracteristiqueSelectionne;
            if ((NouvelleValeurCaracteristique.EstValide) && (Program.GMBD.AjouterVehiculeCaracteristique(NouvelleValeurCaracteristique)))
            {
                errorProvider.Clear();
                ValidationProvider.Clear();
                ValidationProvider.SetError(pictureBoxCaractA, "Caractéristique correctement ajoutée");
                RefreshFicheTechnique();
            }
            
        }

        private void NouvelleValeurCaracteristique_SurErreur1(VehiculeCaracteristique Entite, VehiculeCaracteristique.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case VehiculeCaracteristique.Champs.Caracteristique:
                    errorProvider.SetError(pictureBoxCaractA, MessageErreur);
                    break;
                case VehiculeCaracteristique.Champs.Valeur:
                    errorProvider.SetError(textBoxInfo, MessageErreur);
                    break;
            }
        }

        private void NouvelleValeurCaracteristique_AvantChangement(VehiculeCaracteristique Entite, VehiculeCaracteristique.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch(Champ)
            {
                case VehiculeCaracteristique.Champs.Caracteristique:
                    VehiculeCaracteristique CaracteristiqueExiste = Program.GMBD.EnumererVehiculeCaracteristique(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_caracteristique = {0} AND fk_id_vehicule = {1}", listeDeroulanteCaracteristique1.CaracteristiqueSelectionne.Id, listeDeroulanteVehicule1.VehiculeSelectionne.Id), null).FirstOrDefault();
                    if(CaracteristiqueExiste != null)
                    {
                        errorProvider.Clear();
                        ValidationProvider.Clear();
                        AccumulateurErreur.NotifierErreur("Cette caractéristique existe déjà pour ce véhicule");
                    } 
                    break;
            }
        }

        private void pictureBoxCaractR_Click(object sender, EventArgs e)
        {
            if (ficheTechnique1.CaracteristiqueSelectionnee != null)
            {
                if (Program.GMBD.SupprimerVehiculeCaracteristique(ficheTechnique1.CaracteristiqueSelectionnee))
                {
                    ClearCaract();
                    errorProvider.Clear();
                    ValidationProvider.Clear();
                    ValidationProvider.SetError(pictureBoxCaractR, "La caractéristique a bien été retirée");
                    RefreshFicheTechnique();
                }
            }
        }
        

        private void buttonPanelLierCaract_Click(object sender, EventArgs e)
        {
            panelLier.BringToFront();
            
        }

        private void buttonAnnulerCaractAjout_Click(object sender, EventArgs e)
        {
            RefreshNouvelleCaract();
        }

        private void RefreshNouvelleCaract()
        {
            listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne = null;
            listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = null;
            textBoxNomCaract.Text = "";
            buttonAjouterCaract.Enabled = true;
            buttonModifierCaract.Enabled = false;
            buttonSupprimerCaract.Enabled = false;
        }

        private void buttonPanelAjouterCaract_Click(object sender, EventArgs e)
        {
            panelAjouterCaract.BringToFront();
        }

        private void listeDeroulanteCaracteristiqueAjouter_Load(object sender, EventArgs e)
        {
            listeDeroulanteCaracteristique1.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE (type = {0} OR type = \"Générique\") AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
        }

        private void listeDeroulanteCaracteristique1_Load(object sender, EventArgs e)
        {
            listeDeroulanteCaracteristiqueAjouter.Caracteristique = Program.GMBD.EnumererCaracteristique(null, new PDSGBD.MyDB.CodeSql("JOIN type ON caracteristique.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE (type = {0} OR type = \"Générique\") AND disponible = 1", (EstVoiture) ? "Voiture" : "Moto"), null);
        }

        private void buttonModifierLier_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (ficheTechnique1.CaracteristiqueSelectionnee != null)
            {
                VehiculeCaracteristique CaracteristiqueAModifier = ficheTechnique1.CaracteristiqueSelectionnee;
                CaracteristiqueAModifier.SurErreur += NouvelleValeurCaracteristique_SurErreur;
                CaracteristiqueAModifier.Valeur = textBoxInfo.Text;
                if (listeDeroulanteVehicule1.VehiculeSelectionne != null) CaracteristiqueAModifier.Vehicule = listeDeroulanteVehicule1.VehiculeSelectionne;
                else errorProvider.SetError(listeDeroulanteVehicule1, "Veuillez sélectionner un véhicule");
                CaracteristiqueAModifier.Caracteristique = listeDeroulanteCaracteristique1.CaracteristiqueSelectionne;
                if ((CaracteristiqueAModifier.EstValide) && (Program.GMBD.ModifierVehiculeCaracteristique(CaracteristiqueAModifier)))
                {
                    errorProvider.Clear();
                    ValidationProvider.SetError(buttonModifierLier, "Caractéristique correctement modifiée");
                    RefreshFicheTechnique();
                }
            }

        }

        private void listeDeroulanteTypeVehicule1_Load(object sender, EventArgs e)
        {
            listeDeroulanteTypeVehicule1.TypeVehicule = Program.GMBD.EnumererTypeVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE type != {0}", (EstVoiture) ? "Moto" : "Voiture"), null);
        }

        private void listeDeroulanteTypeVehiculeFiltre_Load(object sender, EventArgs e)
        {
            listeDeroulanteTypeVehiculeFiltre.TypeVehicule = Program.GMBD.EnumererTypeVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE type != {0}", (EstVoiture) ? "Moto" : "Voiture"), null);
        }

        private void buttonLierPack_Click(object sender, EventArgs e)
        {
            lierPack.BringToFront();
        }

        private void buttonLierOptions_Click(object sender, EventArgs e)
        {
            lierOptions.BringToFront();
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                Vehicule VehiculeReference = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type")
                                                                               , new PDSGBD.MyDB.CodeSql(@"WHERE (vehicule.id_vehicule IN(SELECT client_vehicule.fk_id_vehicule FROM client_vehicule WHERE fk_id_vehicule = {0})
                                                                                                           OR vehicule.id_vehicule IN(SELECT vehicule_vente.fk_id_vehicule FROM vehicule_vente WHERE fk_id_vehicule = {0})) AND id_vehicule = {0}",listeDeroulanteVehicule1.VehiculeSelectionne.Id), null).FirstOrDefault();
                // Si le véhicule est référencé au moins une fois dans les tables désignées au dessus on ne supprime que fictivement
                if (VehiculeReference != null)
                {
                    VehiculeReference.Disponible = 0;
                    if((VehiculeReference.EstValide)&&(Program.GMBD.ModifierVehicule(VehiculeReference)))
                    {
                        ValidationProvider.SetError(buttonSupprimer, "Ce véhicule a été correctement supprimé");
                        textBoxModele.Text = "";
                        numericUpDownPrix.Value = 0;
                        numericUpDownTempsLivraison.Value = 1;
                        pictureBox1.Image = null;
                        listeDeroulanteVehicule1.VehiculeSelectionne = null;
                        listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND type = {0}", (EstMoto) ? "Moto" : "Voiture"), null);
                        ficheTechnique1.Caracteristique = null;
                        panelAjouterCaract.BringToFront();
                        buttonAjouter.Enabled = true;
                        buttonModifier.Enabled = false;
                        buttonSupprimer.Enabled = false;
                        buttonAnnulerModele.Enabled = true;
                    }
                }
                // Sinon aucun problème pour une suppression en cascade des packs, options et caractéristiques
                else
                {
                    if(Program.GMBD.SupprimerVehicule(listeDeroulanteVehicule1.VehiculeSelectionne))
                    {
                        ValidationProvider.SetError(buttonSupprimer, "Ce véhicule a été correctement supprimé");
                        textBoxModele.Text = "";
                        numericUpDownPrix.Value = 0;
                        numericUpDownTempsLivraison.Value = 1;
                        pictureBox1.Image = null;
                        listeDeroulanteVehicule1.VehiculeSelectionne = null;
                        listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1 AND type = {0}", (EstMoto) ? "Moto" : "Voiture"), null);
                        ficheTechnique1.Caracteristique = null;
                        panelAjouterCaract.BringToFront();
                        buttonAjouter.Enabled = true;
                        buttonModifier.Enabled = false;
                        buttonSupprimer.Enabled = false;
                        buttonAnnulerModele.Enabled = true;
                    }
                }
            }
        }
    }
}
