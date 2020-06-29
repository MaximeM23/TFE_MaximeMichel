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
    public partial class Formulaire_Employe : UserControl
    {        

        /// <summary>
        /// Permet l'activation ou la désactivation du bouton d'ajout
        /// </summary>
        public bool EnableButtonAjouter
        {
            set
            {
                buttonAjouter.Enabled = value;
            }
        }

        /// <summary>
        /// Permet l'activation ou la désactivation du bouton de modification
        /// </summary>
        public bool EnableButtonModifier
        {
            set
            {
                buttonModifier.Enabled = value;
            }
        }

        /// <summary>
        /// Permet l'activation ou la désactivation du bouton d'annulation
        /// </summary>
        public bool EnableButtonAnnuler
        {
            set
            {
                buttonAnnuler.Enabled = value;
            }
        }

        //Correspond à l'employé actif dans le formulaire
        private Employe EmployeActif;

        /// <summary>
        /// Donne l'accès à l'employé actif dans ce formulaire et permet la modification de celui-ci après une possible sélection dans un autre controler
        /// </summary>
        public Employe EmployeSelectionne
        {
            get
            {
                return EmployeActif;
            }
            set
            {
                if ((value != null) && (value is Employe))
                {
                    EmployeActif = value;
                    errorProvider.Clear();
                    ValidationProvider.Clear();
                    RemplirFormulaire();
                }
            }
        }

        public Formulaire_Employe()
        {
            InitializeComponent();
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
        }        

        public void ChargerDonneesListView()
        {
            listeDeroulanteLocaliteCP.Adresse = Program.GMBD.EnumererAdresse(null, null, null, null);
            listeDeroulanteCivilite.Civilite = Program.GMBD.EnumererCivilite(null, null, null, null);
            listeDeroulanteStatutEmploye1.StatutEmploye = Program.GMBD.EnumererStatutEmploye(null, null, new PDSGBD.MyDB.CodeSql("WHERE nom_statut != \"Administrateur\""), null);
        }        

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            Employe NouvelEmploye = new Employe();
            NouvelEmploye.SurErreur += NouvelEmploye_SurErreur;
            NouvelEmploye.AvantChangement += NouvelEmploye_AvantChangement;
            NouvelEmploye.ModificationSansMotDePasse = true;
            NouvelEmploye.Nom = textBoxNom.Text;
            NouvelEmploye.Prenom = TextBoxPrenom.Text;
            NouvelEmploye.Email = TextBoxEmail.Text;
            NouvelEmploye.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
            NouvelEmploye.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
            NouvelEmploye.DateNaissance = dateTimePickerDateNaissance.Value;
            NouvelEmploye.Rue = TextBoxNomRue.Text;
            NouvelEmploye.NumeroTelephone = TextBoxNumTel.Text;
            NouvelEmploye.NumeroHabitation = TextBoxNumHabitation.Text;
            NouvelEmploye.MotDePasse = TextBoxMdp.Text;
            NouvelEmploye.CompteActif = 1;
            NouvelEmploye.Statut = listeDeroulanteStatutEmploye1.StatutEmployeSelectionne;
            if ((NouvelEmploye.EstValide) && (Program.GMBD.AjouterEmploye(NouvelEmploye)))
            {
                RefreshFormulaire();
                ValidationProvider.SetError(buttonAjouter, "Employé correctement ajouté");
                if (SActiveLorsDunAjoutOuModification != null)
                {
                    SActiveLorsDunAjoutOuModification(this, EventArgs.Empty);
                }
            }
        }

        private void NouvelEmploye_AvantChangement(Employe Entite, Employe.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Employe.Champs.MotDePasse:
                    {
                        if (TextBoxMdp.Text != TextBoxConfMdp.Text)
                        {
                            AccumulateurErreur.NotifierErreur("Les mots de passe ne correspondent pas");
                        }
                    }
                    break;
                case Employe.Champs.Email:
                    {
                        Employe EmailExiste = Program.GMBD.EnumererEmploye(null, null, new PDSGBD.MyDB.CodeSql("WHERE email = {0}", NouvelleValeur), null).FirstOrDefault();
                        if (EmailExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("L'email existe déjà, veuillez en choisir une autre");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void NouvelEmploye_SurErreur(Employe Entite, Employe.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case Employe.Champs.Nom:
                    errorProvider.SetError(textBoxNom, MessageErreur);
                    break;
                case Employe.Champs.Prenom:
                    errorProvider.SetError(TextBoxPrenom, MessageErreur);
                    break;
                case Employe.Champs.Civilite:
                    errorProvider.SetError(listeDeroulanteCivilite, MessageErreur);
                    break;
                case Employe.Champs.NumeroTelephone:
                    errorProvider.SetError(TextBoxNumTel, MessageErreur);
                    break;
                case Employe.Champs.Email:
                    errorProvider.SetError(TextBoxEmail, MessageErreur);
                    break;
                case Employe.Champs.DateNaissance:
                    errorProvider.SetError(dateTimePickerDateNaissance, MessageErreur);
                    break;
                case Employe.Champs.NomDeRue:
                    errorProvider.SetError(TextBoxNomRue, MessageErreur);
                    break;
                case Employe.Champs.NumeroHabitation:
                    errorProvider.SetError(TextBoxNumHabitation, MessageErreur);
                    break;
                case Employe.Champs.MotDePasse:
                    errorProvider.SetError(TextBoxMdp, MessageErreur);
                    break;
                case Employe.Champs.Statut:
                    errorProvider.SetError(listeDeroulanteStatutEmploye1, MessageErreur);
                    break;
                case Employe.Champs.Adresse:
                    if (listeDeroulanteLocaliteCP.AdresseSelectionne == null) errorProvider.SetError(listeDeroulanteLocaliteCP, MessageErreur);
                    break;
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (TextBoxMdp.Text == "")
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                Employe EmployeAModifier = EmployeSelectionne;
                EmployeAModifier.SurErreur += NouvelEmploye_SurErreur;
                EmployeAModifier.AvantChangement += EmployeAModifier_AvantChangement;
                EmployeAModifier.ModificationSansMotDePasse = false;
                EmployeAModifier.Nom = textBoxNom.Text;
                EmployeAModifier.Prenom = TextBoxPrenom.Text;
                EmployeAModifier.Email = TextBoxEmail.Text;
                EmployeAModifier.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
                EmployeAModifier.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
                EmployeAModifier.DateNaissance = dateTimePickerDateNaissance.Value;
                EmployeAModifier.Rue = TextBoxNomRue.Text;
                EmployeAModifier.NumeroTelephone = TextBoxNumTel.Text;
                EmployeAModifier.NumeroHabitation = TextBoxNumHabitation.Text;
                EmployeAModifier.MotDePasse = EmployeSelectionne.MotDePasse; // On garde le même mot de passe
                if (EmployeSelectionne.Statut.NomStatut != "Administrateur") EmployeAModifier.Statut = listeDeroulanteStatutEmploye1.StatutEmployeSelectionne;
                else EmployeAModifier.Statut = EmployeSelectionne.Statut;
                if ((EmployeAModifier.EstValide) && (Program.GMBD.ModifierEmploye(EmployeAModifier)))
                {
                    RefreshFormulaire();
                    ValidationProvider.SetError(buttonModifier, "Employé correctement modifié");
                    if (SActiveLorsDunAjoutOuModification != null)
                    {
                        SActiveLorsDunAjoutOuModification(this, EventArgs.Empty);
                    }
                }
            }
            else
            {
                Employe EmployeAModifier = EmployeSelectionne;
                EmployeAModifier.SurErreur += NouvelEmploye_SurErreur;
                EmployeAModifier.AvantChangement += EmployeAModifier_AvantChangement;
                EmployeAModifier.ModificationSansMotDePasse = true;
                EmployeAModifier.Nom = textBoxNom.Text;
                EmployeAModifier.Prenom = TextBoxPrenom.Text;
                EmployeAModifier.Email = TextBoxEmail.Text;
                EmployeAModifier.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
                EmployeAModifier.Adresse = listeDeroulanteLocaliteCP.AdresseSelectionne;
                EmployeAModifier.DateNaissance = dateTimePickerDateNaissance.Value;
                EmployeAModifier.Rue = TextBoxNomRue.Text;
                EmployeAModifier.NumeroTelephone = TextBoxNumTel.Text;                
                EmployeAModifier.NumeroHabitation = TextBoxNumHabitation.Text;
                EmployeAModifier.MotDePasse = TextBoxMdp.Text;
                EmployeAModifier.Statut = listeDeroulanteStatutEmploye1.StatutEmployeSelectionne;
                if ((EmployeAModifier.EstValide) && (Program.GMBD.ModifierEmploye(EmployeAModifier)))
                {
                    RefreshFormulaire();
                    ValidationProvider.SetError(buttonModifier, "Employé correctement modifié");
                    if (SActiveLorsDunAjoutOuModification != null)
                    {
                        SActiveLorsDunAjoutOuModification(this, EventArgs.Empty);
                    }
                }
            }
        }

        private void EmployeAModifier_AvantChangement(Employe Entite, Employe.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Employe.Champs.MotDePasse:
                    {
                        if (TextBoxMdp.Text != TextBoxConfMdp.Text)
                        {
                            AccumulateurErreur.NotifierErreur("Les mots de passe ne correspondent pas");
                        }
                    }
                    break;
                case Employe.Champs.Email:
                    {
                        Employe EmailExiste = Program.GMBD.EnumererEmploye(null, null, new PDSGBD.MyDB.CodeSql("WHERE email = {0} AND id_employe != {1}", NouvelleValeur, EmployeSelectionne.Id), null).FirstOrDefault();
                        if (EmailExiste != null)
                        {
                            AccumulateurErreur.NotifierErreur("L'email existe déjà, veuillez en choisir une autre");
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            RefreshFormulaire();
        }

        private void RefreshFormulaire()
        {
            errorProvider.Clear();
            ValidationProvider.Clear();
            textBoxNom.Text = "";
            TextBoxPrenom.Text = "";
            TextBoxEmail.Text = "";
            listeDeroulanteCivilite.CiviliteSelectionne = null;
            listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            dateTimePickerDateNaissance.Value = DateTime.Now;
            TextBoxNomRue.Text = "";
            TextBoxNumTel.Text = "";
            TextBoxNumHabitation.Text = "";
            TextBoxMdp.Text = "";
            TextBoxConfMdp.Text = "";
            buttonModifier.Enabled = false;
            buttonAjouter.Enabled = true;
            listeDeroulanteStatutEmploye1.StatutEmployeSelectionne = null;
            listeDeroulanteStatutEmploye1.Enabled = true;
            listeDeroulanteStatutEmploye1.ResetText();
            if(RefreshSurAnnulation != null)
            {
                RefreshSurAnnulation(this, null);
            }
        }

        public EventHandler RefreshSurAnnulation;

        public EventHandler SActiveLorsDunAjoutOuModification;

        private void RemplirFormulaire()
        {
            textBoxNom.Text = EmployeSelectionne.Nom;
            TextBoxPrenom.Text = EmployeSelectionne.Prenom;
            TextBoxEmail.Text = EmployeSelectionne.Email;
            listeDeroulanteCivilite.CiviliteSelectionne = EmployeSelectionne.Civilite;
            listeDeroulanteLocaliteCP.AdresseSelectionne = EmployeSelectionne.Adresse;
            dateTimePickerDateNaissance.Value = EmployeSelectionne.DateNaissance;
            TextBoxNomRue.Text = EmployeSelectionne.Rue;
            TextBoxNumTel.Text = EmployeSelectionne.NumeroTelephone;
            TextBoxNumHabitation.Text = EmployeSelectionne.NumeroHabitation;
            listeDeroulanteStatutEmploye1.StatutEmployeSelectionne = EmployeSelectionne.Statut;
            if(EmployeSelectionne.Statut.NomStatut == "Administrateur")
            {
                listeDeroulanteStatutEmploye1.Enabled = false;
            }
            else
            {
                listeDeroulanteStatutEmploye1.Enabled = true;
            }
        }
    }
}
