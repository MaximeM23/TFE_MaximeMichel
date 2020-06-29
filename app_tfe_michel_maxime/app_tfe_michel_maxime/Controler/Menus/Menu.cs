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
    public partial class Menu : UserControl
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


        public Menu()
        {
            InitializeComponent();
        }

        private void AfficherButtonsMenu()
        {
            switch (Form_Principal.Employe.Statut.NomStatut)
            {
                case "Mécanicien":
                    {
                        buttonPlanning.Visible = true;
                        buttonPlanning.Location = new Point(0, 200);
                        buttonDeconnexion.Visible = true;
                        buttonDeconnexion.Location = new Point(0, ParentForm.Height - 100);
                        break;
                    }
                case "Vendeur":
                    {
                        buttonNosVoitures.Visible = true;
                        buttonNosMotos.Visible = true;
                        buttonEntretiensReparations.Visible = true;
                        buttonFactures.Visible = true;
                        buttonStockMarchandise.Location = new Point(0, buttonFactures.Location.Y + 39);
                        buttonStockMarchandise.Visible = true;
                        buttonDeconnexion.Visible = true;
                        buttonDeconnexion.Location = new Point(0, ParentForm.Height - 100);
                        nouvelleVoitureToolStripMenuItem.Visible = false;
                        nouvelleMotoToolStripMenuItem.Visible = false;
                        break;
                    }
                case "Administrateur":
                    {
                        buttonNosVoitures.Visible = true;
                        buttonNosMotos.Visible = true;
                        buttonEntretiensReparations.Visible = true;
                        buttonFactures.Visible = true;
                        buttonOptions.Visible = true;
                        buttonStockMarchandise.Location = new Point(0, buttonOptions.Location.Y + 39);
                        buttonStockMarchandise.Visible = true;
                        buttonEmployes.Visible = true;
                        buttonDeconnexion.Visible = true;
                        buttonDeconnexion.Location = new Point(0, ParentForm.Height - 100);

                        break;
                    }
                default:
                    {
                        throw new Exception("L'utilisateur n'a pas pu être identifié");
                    }
            }
        }

        private void buttonNosVoitures_Click(object sender, EventArgs e)
        {
            Point screenPoint = buttonNosVoitures.PointToScreen(new Point(buttonNosVoitures.Left, buttonNosVoitures.Bottom));
            if (screenPoint.Y + contextMenuStripV.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStripV.Show(buttonNosVoitures, new Point(0, -contextMenuStripV.Size.Height));
            }
            else
            {
                contextMenuStripV.Show(buttonNosVoitures, new Point(0, buttonNosVoitures.Height));
            }
        }

        private void buttonNosMotos_Click(object sender, EventArgs e)
        {
            Point screenPoint = buttonNosMotos.PointToScreen(new Point(buttonNosMotos.Left, buttonNosMotos.Bottom));
            if (screenPoint.Y + contextMenuStripM.Size.Height > Screen.PrimaryScreen.WorkingArea.Height)
            {
                contextMenuStripM.Show(buttonNosMotos, new Point(0, -contextMenuStripM.Size.Height));
            }
            else
            {
                contextMenuStripM.Show(buttonNosMotos, new Point(0, buttonNosMotos.Height));
            }
        }

        private void buttonDeconnexion_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Connexion>(
                                (Page) =>
                                {
                                    Form_Principal.Employe = null;
                                    return true;
                                });
        }        

        private void catalogueDeVoituresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_CatalogueVoiture>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            if (Form_Principal.Employe != null)
            {
                labelNomUser.Text = string.Format("{0}\n{1}", Form_Principal.Employe.Prenom, Form_Principal.Employe.Nom);
                AfficherButtonsMenu();
            }
        }

        private void buttonEntretiensReparations_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Rdv_Mecanicien>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void catalogueDeMotosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_CatalogueMoto>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void lesCommandesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Commandes>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void lesCommandesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Commandes>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void buttonOptions_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Options>(
                                (Page) =>
                                {
                                    return true;
                                });
        }

        private void nouveauVehiculeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_NouveauVehicule>(
                                (Page) =>
                                {
                                    Page.EstVoiture = true;
                                    Page.EstMoto = false;
                                    return true;
                                });
        }

        private void nouvelleMotoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_NouveauVehicule>(
                                (Page) =>
                                {
                                    Page.EstMoto = true;
                                    Page.EstVoiture = false;
                                    return true;
                                });
        }

        private void buttonFactures_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Facture>(
                               (Page) =>
                               {
                                   return true;
                               });
        }

        private void buttonEmployes_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Employe>(
                               (Page) =>
                               {
                                   return true;
                               });
        }

        private void buttonStockMarchandise_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_StockMarchandise>(
                               (Page) =>
                               {
                                   return true;
                               });
        }

        private void nouvelleDisponibilitéToolStripMenuItemM_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_NouvelleDisponibilite>(
                               (Page) =>
                               {
                                   Page.EstVoiture = false;
                                   return true;
                               });
        }

        private void nouvelleDisponibilitéToolStripMenuItemV_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_NouvelleDisponibilite>(
                               (Page) =>
                               {
                                   Page.EstVoiture = true;
                                   return true;
                               });
        }
    }
}
