using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tfe_michel_maxime
{
    public partial class Page_Options : UserControl
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

        public Page_Options()
        {
            InitializeComponent();
            ficheOptionsAjouter.SurChangementSelection += FicheOptionsAjouter_SurChangementSelection;
            listeDeroulantePackOptions1.SurChangementSelection += ListeDeroulantePackOptions_SurChangementSelection;
            numericUpDownPrixOption.Minimum = 0;
            numericUpDownPrixOption.Maximum = int.MaxValue;
            numericUpDownPrixPack.Minimum = 0;
            numericUpDownPrixPack.Maximum = int.MaxValue;

            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());

            this.MinimumSize = new Size(1300, 748);
           
        }

        private void ListeDeroulantePackOptions_SurChangementSelection(object sender, EventArgs e)
        {
            if(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne != null)
            {
                buttonAjouterP.Enabled = false;
                buttonSupprimerPack.Enabled = true;

                #region Requêtes pour les packs d'options
                //////////////////////////////////////
                // Requêtes pour les pack d'options //
                //////////////////////////////////////
                ficheOptionsPackActuel.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN pack_option ON option_vehicule.id_option_vehicule = pack_option.fk_id_option_vehicule
                                                                                                                     JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), 
                                                                                           new PDSGBD.MyDB.CodeSql("WHERE pack_option.fk_id_popv = {0}", listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null);

                ficheOptionsPackActuel.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptionsPackActuel.TexteFiltreOptions != "")
                    {
                        ficheOptionsPackActuel.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN pack_option ON option_vehicule.id_option_vehicule = pack_option.fk_id_option_vehicule
                                                                                                     JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE nom_option LIKE {0} AND pack_option.fk_id_popv = {1}", string.Format(c_FiltreAvecLike, ficheOptionsPackActuel.TexteFiltreOptions, listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id),listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id),
                                                                            null);
                    }
                    else
                    {
                        ficheOptionsPackActuel.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN pack_option ON option_vehicule.id_option_vehicule = pack_option.fk_id_option_vehicule
                                                                                                                             JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), 
                                                                                                   new PDSGBD.MyDB.CodeSql("WHERE pack_option.fk_id_popv = {0}", listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null);
                    }
                };
                #endregion

                textBoxNomPack.Text = listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.NomPack;
                numericUpDownPrixPack.Value = decimal.Parse(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.PrixPack.ToString());

                ChoixPackVehicule LiaisonExistante = Program.GMBD.EnumererChoixPackVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_popv = {0}",listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null).FirstOrDefault();
                if(LiaisonExistante != null)
                {
                    numericUpDownPrixPack.Enabled = false;
                    pictureBoxPackA.Enabled = false;
                    pictureBoxPackR.Enabled = false;
                    buttonModifierP.Enabled = false;
                    textBoxNomPack.Enabled = false;
                }
                else
                {
                    numericUpDownPrixPack.Enabled = true;
                    pictureBoxPackA.Enabled = true;
                    pictureBoxPackR.Enabled = true;
                    buttonModifierP.Enabled = true;
                    textBoxNomPack.Enabled = true;
                }

            }
            else
            {
                numericUpDownPrixPack.Enabled = true;
            }
        }
        
        private void FicheOptionsAjouter_SurChangementSelection(object sender, EventArgs e)
        {
            if (ficheOptionsAjouter.OptionsSelectionnee != null)
            {
                ChoixOptionVehicule LiaisonExistante = Program.GMBD.EnumererChoixOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_option_vehicule = {0}",ficheOptionsAjouter.OptionsSelectionnee.Id), null).FirstOrDefault();

                if (LiaisonExistante != null)
                {
                    numericUpDownPrixOption.Enabled = false;
                    textBoxNomOption.Enabled = false;
                    buttonModifierO.Enabled = false;

                }
                else
                {
                    numericUpDownPrixOption.Enabled = true;
                    buttonModifierO.Enabled = true;
                    textBoxNomOption.Enabled = true;

                }

                buttonAjouterO.Enabled = false;
                buttonSupprimerOptions.Enabled = true;
                textBoxNomOption.Text = ficheOptionsAjouter.OptionsSelectionnee.NomOption;
                listeDeroulanteTypeOptions1.TypeOptionsSelectionne = ficheOptionsAjouter.OptionsSelectionnee.TypeOption;
                numericUpDownPrixOption.Value = decimal.Parse(ficheOptionsAjouter.OptionsSelectionnee.Prix.ToString());
                ValidationProvider.Clear();
                errorProvider.Clear();
            }
            else
            {
                numericUpDownPrixOption.Enabled = true;
            }
        }
        
        private void Page_Options_Load(object sender, EventArgs e)
        {
            #region Requêtes pour les options à ajouter
            ///////////////////////////////
            // Requêtes pour les options //
            ///////////////////////////////
            ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null,new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"),null);

            ficheOptionsAjouter.SurChangementFiltre += (s, ev) =>
            {
                // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                if (ficheOptionsAjouter.TexteFiltreOptions != "")
                {
                    ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE nom_option LIKE {0} AND disponible = 1", string.Format(c_FiltreAvecLike, ficheOptionsAjouter.TexteFiltreOptions)),
                                                                        null);
                }
                else
                {
                    ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                }
            };
            #endregion

            #region Requêtes pour les options à choisir
            ///////////////////////////////
            // Requêtes pour les options //
            ///////////////////////////////
            ficheOptionsPackRecherche.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);

            ficheOptionsPackRecherche.SurChangementFiltre += (s, ev) =>
            {
                // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                if (ficheOptionsPackRecherche.TexteFiltreOptions != "")
                {
                    ficheOptionsPackRecherche.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE nom_option LIKE {0} AND disponible = 1", string.Format(c_FiltreAvecLike, ficheOptionsPackRecherche.TexteFiltreOptions)),
                                                                        null);
                }
                else
                {
                    ficheOptionsPackRecherche.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                }
            };
            #endregion

            listeDeroulantePackOptions1.PackOptionPackVehicule = Program.GMBD.EnumererPackOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
            listeDeroulanteTypeOptions1.TypeOptions = Program.GMBD.EnumererTypeOptions(null,null, null, null);

        }

        private void buttonAjouterO_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            OptionVehicule NouvelleOption = new OptionVehicule();
            NouvelleOption.SurErreur += NouvelleOption_SurErreur;
            NouvelleOption.AvantChangement += NouvelleOption_AvantChangement;
            NouvelleOption.NomOption = textBoxNomOption.Text;
            NouvelleOption.Disponible = 1;
            int Prix = -1;
            if(int.TryParse(numericUpDownPrixOption.Value.ToString(),out Prix))
            {
                NouvelleOption.Prix = int.Parse(numericUpDownPrixOption.Value.ToString());
            }
            NouvelleOption.TypeOption = listeDeroulanteTypeOptions1.TypeOptionsSelectionne;

            if((NouvelleOption.EstValide) && (Program.GMBD.AjouterOptionVehicule(NouvelleOption)))
            {
                ValidationProvider.SetError(buttonAjouterO, "Option correctement ajoutée");
                ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                ficheOptionsPackRecherche.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                ClearOptions();
            }
        }

        private void NouvelleOption_AvantChangement(OptionVehicule Entite, OptionVehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            AccumulateurErreur.ClearAccumulateur();
            switch(Champ)
            {
                case OptionVehicule.Champs.NomOption:
                    {
                        OptionVehicule OptionExiste = Program.GMBD.EnumererOptionVehicule(new PDSGBD.MyDB.CodeSql("nom_option"), null, new PDSGBD.MyDB.CodeSql("where nom_option = {0} AND disponible = 1", NouvelleValeur), null).FirstOrDefault();
                        if (OptionExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("Cette option existe déjà, veuillez revérifier par une recherche de l'enregistrement désiré");
                        }
                        break;
                    }
            }
        }

        private void NouvelleOption_SurErreur(OptionVehicule Entite, OptionVehicule.Champs Champ, string MessageErreur)
        {
            switch(Champ)
            {
                case OptionVehicule.Champs.NomOption:
                    errorProvider.SetError(textBoxNomOption, MessageErreur);
                    break;
                case OptionVehicule.Champs.Prix:
                    errorProvider.SetError(numericUpDownPrixOption, MessageErreur);
                    break;
                case OptionVehicule.Champs.TypeOption:
                    errorProvider.SetError(listeDeroulanteTypeOptions1, MessageErreur);
                    break;
                    

            }
        }

        private void buttonAnnulerO_Click(object sender, EventArgs e)
        {
            ClearOptions();
            ficheOptionsAjouter.OptionsSelectionnee = null;
            buttonAjouterO.Enabled = true;
            buttonModifierO.Enabled = false;
            buttonSupprimerOptions.Enabled = false;
            numericUpDownPrixOption.Enabled = true;
        }
        
        private void ClearOptions()
        {
            textBoxNomOption.Text = "";
            listeDeroulanteTypeOptions1.TypeOptionsSelectionne = null;
            numericUpDownPrixOption.Value = 0;
        }

        private void buttonModifierO_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if(ficheOptionsAjouter.OptionsSelectionnee != null)
            {
                OptionVehicule OptionAModifier = ficheOptionsAjouter.OptionsSelectionnee;
                OptionAModifier.SurErreur += NouvelleOption_SurErreur;
                OptionAModifier.AvantChangement += NouvelleOption_AvantChangement;
                OptionAModifier.NomOption = textBoxNomOption.Text;
                OptionAModifier.Prix = int.Parse(numericUpDownPrixOption.Value.ToString());
                OptionAModifier.TypeOption = listeDeroulanteTypeOptions1.TypeOptionsSelectionne;

                if ((OptionAModifier.EstValide) && (Program.GMBD.ModifierOptionVehicule(OptionAModifier)))
                {
                    buttonAjouterO.Enabled = true;
                    buttonModifierO.Enabled = false;
                    ValidationProvider.SetError(buttonModifierO, "Option correctement modifiée");
                    ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);                    
                    ClearOptions();
                }
            }
        }

        private void RefreshFichePack(int IdPack)
        {
            ficheOptionsPackActuel.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN pack_option ON option_vehicule.id_option_vehicule = pack_option.fk_id_option_vehicule
                                                                                                                 JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                           new PDSGBD.MyDB.CodeSql("WHERE pack_option.fk_id_popv = {0}", IdPack), null);

        }

        private void pictureBoxPackA_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if (ficheOptionsPackRecherche.OptionsSelectionnee != null)
            {
                // Si un pack a été choisi, alors on rajoute directement la valeur
                if (listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne != null)
                {
                    bool DoublonsSurOption = false;
                    foreach(OptionVehicule OV in ficheOptionsPackActuel.Options)
                    {
                        if((ficheOptionsPackRecherche.OptionsSelectionnee.TypeOption.NomType == OV.TypeOption.NomType) && (ficheOptionsPackRecherche.OptionsSelectionnee.TypeOption.NomType != "Autres"))
                        {
                            DoublonsSurOption = true;
                        }
                    }
                    if (!DoublonsSurOption)
                    {
                        PackOption PackChoisi = new PackOption();
                        PackChoisi.AvantChangement += NouvelleOptionLiee_AvantChangement;
                        PackChoisi.SurErreur += NouvelleOptionLie_SurErreur;
                        PackChoisi.OptionVehicule = ficheOptionsPackRecherche.OptionsSelectionnee;
                        PackChoisi.PackOptionPackVehicule = listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne;                        
                        if ((PackChoisi.EstValide) && (Program.GMBD.AjouterPackOption(PackChoisi)))
                        {
                            ValidationProvider.SetError(pictureBoxPackA, "Option correctement ajoutée");
                            RefreshFichePack(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id);
                        }
                    }
                    else
                    {
                        errorProvider.SetError(pictureBoxPackA, "Ce type d'option a déjà été choisi");
                    }
                }
                // Sinon on crée le pack avec les valeurs de nom et de prix encodés, si elles ne le sont pas, on retourne un message d'erreur
                else
                {
                    PackOptionPackVehicule NouveauPack = new PackOptionPackVehicule();
                    NouveauPack.SurErreur += Pack_SurErreur;
                    NouveauPack.AvantChangement += AjouterNouveauPack_AvantChangement;
                    NouveauPack.NomPack = textBoxNomPack.Text;
                    NouveauPack.PrixPack = double.Parse(numericUpDownPrixPack.Value.ToString());
                    NouveauPack.Disponible = 1;
                    if ((NouveauPack.EstValide) && (Program.GMBD.AjouterPackOptionPackVehicule(NouveauPack)))
                    {
                        PackOption NouvelleOptionDeCePack = new PackOption();
                        NouvelleOptionDeCePack.OptionVehicule = ficheOptionsPackRecherche.OptionsSelectionnee;
                        NouvelleOptionDeCePack.PackOptionPackVehicule = NouveauPack;
                        if ((NouvelleOptionDeCePack.EstValide) && (Program.GMBD.AjouterPackOption(NouvelleOptionDeCePack)))
                        {
                            ValidationProvider.SetError(pictureBoxPackA, "Ce pack et cette option ont bien été ajoutés");
                            RefreshFichePack(NouveauPack.Id);
                        }
                        else
                        {
                            Program.GMBD.SupprimerPackOptionPackVehicule(NouveauPack);
                            errorProvider.SetError(pictureBoxPackA, "L'ajout semble impossible, veuillez revérifier vos valeurs");
                        }
                    }
                }
            }
        }

        private void pictureBoxPackR_Click(object sender, EventArgs e)
        {

            ValidationProvider.Clear();
            errorProvider.Clear();
            // Si un pack a été choisi, alors on retire directement la valeur
            if (ficheOptionsPackActuel.OptionsSelectionnee != null)
            {
                if (listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne != null)
                {
                    PackOption PackChoisi = Program.GMBD.EnumererPackOption(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_option_vehicule = {0} AND fk_id_popv = {1}", ficheOptionsPackActuel.OptionsSelectionnee.Id, listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null).FirstOrDefault();

                    if ((PackChoisi.EstValide) && (Program.GMBD.SupprimerPackOption(PackChoisi)))
                    {
                        ValidationProvider.SetError(pictureBoxPackR, "Option correctement supprimée");
                        RefreshFichePack(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id);
                    }
                }
            }
        }


        private void AjouterNouveauPack_AvantChangement(PackOptionPackVehicule Entite, PackOptionPackVehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case PackOptionPackVehicule.Champs.NomPack:
                    {
                        PackOptionPackVehicule PackExiste = Program.GMBD.EnumererPackOptionVehicule(new PDSGBD.MyDB.CodeSql("nom_pack"), null, new PDSGBD.MyDB.CodeSql("where nom_pack = {0} AND disponible = 1",NouvelleValeur), null).FirstOrDefault();
                        if (PackExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("Ce pack existe déjà, veuillez rajouter cette option au pack existant ou recréer un nouveau pack");
                        }
                        break;
                    }
            }
        }

        private void NouvelleOptionLiee_AvantChangement(PackOption Entite, PackOption.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case PackOption.Champs.OptionVehicule:
                    {
                        PackOption OptionExistePourCePack = Program.GMBD.EnumererPackOption(null, null, new PDSGBD.MyDB.CodeSql("where fk_id_option_vehicule = {0} AND fk_id_popv = {1}", ficheOptionsPackRecherche.OptionsSelectionnee.Id,listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null).FirstOrDefault();
                        if (OptionExistePourCePack != null)
                        {
                            AccumulateurErreur.NotifierErreur("Cette option est déjà existante dans ce pack");
                        }
                        break;
                    }
            }
        }

        private void NouvelleOptionLie_SurErreur(PackOption Entite, PackOption.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case PackOption.Champs.OptionVehicule:
                    errorProvider.SetError(pictureBoxPackA, MessageErreur);
                    break;
                case PackOption.Champs.PackOptionPackVehicule:
                    errorProvider.SetError(pictureBoxPackA, MessageErreur);
                    break;
                default:
                    break;
            }
        }

        private void Pack_SurErreur(PackOptionPackVehicule Entite, PackOptionPackVehicule.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case PackOptionPackVehicule.Champs.NomPack:
                    errorProvider.SetError(textBoxNomPack, MessageErreur);
                    break;
                case PackOptionPackVehicule.Champs.PrixPack:
                    errorProvider.SetError(numericUpDownPrixPack, MessageErreur);
                    break;
            }
        }

        private void buttonAjouterP_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            PackOptionPackVehicule NouveauPack = new PackOptionPackVehicule();
            NouveauPack.SurErreur += Pack_SurErreur;
            NouveauPack.AvantChangement += AjouterNouveauPack_AvantChangement;
            NouveauPack.NomPack = textBoxNomPack.Text;
            NouveauPack.PrixPack = double.Parse(numericUpDownPrixPack.Value.ToString());
            NouveauPack.Disponible = 1;
            if ((NouveauPack.EstValide) && (Program.GMBD.AjouterPackOptionPackVehicule(NouveauPack)))
            {
                ValidationProvider.SetError(buttonAjouterP, "Pack correctement ajouté");
                RefreshListeDeroulantePack(NouveauPack);
                listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne = NouveauPack;
                RefreshFichePack(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id);                
            }
        }

        private void RefreshListeDeroulantePack(PackOptionPackVehicule PackASelectionner = null)
        {
            listeDeroulantePackOptions1.PackOptionPackVehicule = Program.GMBD.EnumererPackOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
            if (PackASelectionner != null)
            {
                listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne = PackASelectionner;
            }
        }

        private void buttonModifierP_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            if (listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne != null)
            {
                PackOptionPackVehicule PackAModifier = listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne;
                PackAModifier.SurErreur += Pack_SurErreur;
                PackAModifier.AvantChangement += ModifierPack_AvantChangement;
                PackAModifier.NomPack = textBoxNomPack.Text;
                PackAModifier.PrixPack = int.Parse(numericUpDownPrixPack.Value.ToString());

                if ((PackAModifier.EstValide) && (Program.GMBD.ModifierPackOptionPackVehicule(PackAModifier)))
                {
                    buttonAjouterP.Enabled = true;
                    buttonModifierP.Enabled = false;
                    ValidationProvider.SetError(buttonModifierP, "Pack correctement modifié");
                    RefreshListeDeroulantePack(PackAModifier);
                    ClearOptions();
                }
            }
        }

        private void ModifierPack_AvantChangement(PackOptionPackVehicule Entite, PackOptionPackVehicule.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            AccumulateurErreur.ClearAccumulateur();
            switch (Champ)
            {
                case PackOptionPackVehicule.Champs.NomPack:
                    {
                        PackOptionPackVehicule PackExiste = Program.GMBD.EnumererPackOptionVehicule(new PDSGBD.MyDB.CodeSql("nom_pack"), null, new PDSGBD.MyDB.CodeSql("WHERE nom_pack = {0} AND id_pack_option_pack_vehicule != {1} AND disponible = 1", NouvelleValeur,listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne.Id), null).FirstOrDefault();
                        if (PackExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("Ce pack existe déjà, veuillez rajouter cette option au pack existant ou recréer un nouveau pack");
                        }
                        break;
                    }
            }
        }

        private void buttonAnnulerP_Click(object sender, EventArgs e)
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            buttonAjouterP.Enabled = true;
            buttonModifierP.Enabled = false;
            ficheOptionsPackActuel.Options = null;
            listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne = null;
            buttonSupprimerPack.Enabled = false;
            numericUpDownPrixPack.Enabled = true;
            textBoxNomPack.Enabled = true;
            textBoxNomPack.Text = "";
            numericUpDownPrixPack.Value = 0;
        }

        private void buttonSupprimerOptions_Click(object sender, EventArgs e)
        {
            if(ficheOptionsAjouter.OptionsSelectionnee != null)
            {
                OptionVehicule OptionASupprimer = ficheOptionsAjouter.OptionsSelectionnee;
                OptionASupprimer.Disponible = 0;
                if(Program.GMBD.ModifierOptionVehicule(OptionASupprimer))
                {
                    textBoxNomOption.Text = "";
                    numericUpDownPrixOption.Value = 0;
                    buttonAjouterO.Enabled = true;
                    buttonModifierO.Enabled = false;
                    buttonSupprimerOptions.Enabled = false;
                    listeDeroulanteTypeOptions1.TypeOptionsSelectionne = null;
                    ficheOptionsAjouter.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);                   
                    ValidationProvider.SetError(buttonSupprimerOptions, "Suppression de l'option correctement effectuée");

                    #region Requêtes pour les options à choisir
                    ///////////////////////////////
                    // Requêtes pour les options //
                    ///////////////////////////////
                    ficheOptionsPackRecherche.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                    
                    #endregion
                }
            }
        }
        
        private void buttonSupprimerPack_Click(object sender, EventArgs e)
        {
            if(listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne != null)
            {
                PackOptionPackVehicule PackASupprimer = listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne;
                PackASupprimer.Disponible = 0;
                if(Program.GMBD.ModifierPackOptionPackVehicule(PackASupprimer))
                {
                    textBoxNomPack.Text = "";
                    numericUpDownPrixPack.Value = 0;
                    RefreshListeDeroulantePack();
                    listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne = null;
                    ficheOptionsPackActuel.Options = null;
                    ValidationProvider.SetError(buttonSupprimerPack, "Suppression du pack correctement effectuée");
                }                
            }
        }
    }
}
