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
    public partial class Page_PremiereConnexion : UserControl
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

        public Page_PremiereConnexion()
        {
            InitializeComponent();
            this.MinimumSize = new Size(810, 476);
        }

        private void buttonConfirmer_Click(object sender, EventArgs e)
        {            
            Employe NouvelEmploye = new Employe();
            NouvelEmploye.ModificationSansMotDePasse = true;
            NouvelEmploye.SurErreur += NouvelEmploye_SurErreur;
            NouvelEmploye.AvantChangement += NouvelEmploye_AvantChangement;
            NouvelEmploye.Nom = textBoxNom.Text;
            NouvelEmploye.Prenom = TextBoxPrenom.Text;
            NouvelEmploye.Email = TextBoxEmail.Text;
            NouvelEmploye.Civilite = listeDeroulanteCivilite.CiviliteSelectionne;
            NouvelEmploye.Adresse = listeDeroulanteCodePostalLoc.CodePostalSelectionne;
            NouvelEmploye.DateNaissance = dateTimePickerDateNaissance.Value;
            NouvelEmploye.Rue = TextBoxNomRue.Text;
            NouvelEmploye.NumeroTelephone = TextBoxNumTel.Text;
            NouvelEmploye.NumeroHabitation = TextBoxNumHabitation.Text;
            NouvelEmploye.MotDePasse = TextBoxMdp.Text;
            NouvelEmploye.CompteActif = 1;
            NouvelEmploye.Statut = Program.GMBD.EnumererStatutEmploye(null, null, new PDSGBD.MyDB.CodeSql("WHERE nom_statut = \"Administrateur\""), null).FirstOrDefault();
            if ((NouvelEmploye.EstValide) && (Program.GMBD.AjouterEmploye(NouvelEmploye)))
            {
                Form_Principal.Instance.CreerPageCourante<Page_Connexion>(
                                    (Page) =>
                                    {
                                        return true;
                                    });
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
                case Employe.Champs.Adresse:
                    errorProvider.SetError(listeDeroulanteCodePostalLoc, MessageErreur);
                    break;
            }
        }

        private void buttonQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Page_PremiereConnexion_Load(object sender, EventArgs e)
        {
            ChargerDonneesListView();
        }        

        public void ChargerDonneesListView()
        {
            listeDeroulanteCodePostalLoc.CodePostal = Program.GMBD.EnumererAdresse(null, null, null, null);
            listeDeroulanteCivilite.Civilite = Program.GMBD.EnumererCivilite(null, null, null, null);
        }
    }    
}
