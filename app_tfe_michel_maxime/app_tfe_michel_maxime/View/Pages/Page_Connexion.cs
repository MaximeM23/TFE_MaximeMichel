using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace app_tfe_michel_maxime
{
    public partial class Page_Connexion : UserControl
    {
        GMBD s_GMBD = new GMBD();

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


        public Page_Connexion()
        {
            InitializeComponent();
            this.MinimumSize = new Size(1200, 400);
            textBoxAvecTextInvisibleEmail.EnterPress += new KeyEventHandler(textBoxAvecTextInvisibleMdp_KeyDown);
            textBoxAvecTextInvisibleMdp.EnterPress += new KeyEventHandler(textBoxAvecTextInvisibleMdp_KeyDown);
        }

        private void textBoxAvecTextInvisibleMdp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSeConnecter_Click(sender, e);
            }
        }

        private void pictureBoxMinimize_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }


        private void buttonSeConnecter_Click(object sender, EventArgs e)
        {
            if ((textBoxAvecTextInvisibleEmail != null) && (textBoxAvecTextInvisibleMdp != null))
            {
                s_GMBD.Initialiser();
                Employe Employe = s_GMBD.ConnexionApplication(textBoxAvecTextInvisibleEmail.Text, textBoxAvecTextInvisibleMdp.Text);
                if (Employe == null)
                {
                    errorProviderConnexion.SetError(textBoxAvecTextInvisibleEmail, "L'email ou le mot de passe est incorrect");
                    errorProviderConnexion.SetIconPadding(textBoxAvecTextInvisibleEmail, 4);
                }
                else
                {
                    if (Employe.CompteActif == 1)
                    {
                        if (Employe.Statut.NomStatut == "Mécanicien")
                        {
                            Form_Principal.Instance.CreerPageCourante<Page_Mecanicien>(
                                (Page) =>
                                {
                                    Form_Principal.Employe = Employe;
                                    return true;
                                });
                        }
                        else if ((Employe.Statut.NomStatut == "Administrateur")||(Employe.Statut.NomStatut == "Vendeur"))
                        {
                            Form_Principal.Instance.CreerPageCourante<Page_Rdv_Mecanicien>(
                                (Page) =>
                                {
                                    Form_Principal.Employe = Employe;
                                    return true;
                                });
                        }
                    }
                    else
                    {
                        errorProviderConnexion.SetError(buttonSeConnecter, "Ce compte est inactif, veuillez contacter l'administateur afin qu'il réactive votre compte");
                    }
                }

            }
        }

        private void pictureBoxClose_Click_1(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }

    }
}
