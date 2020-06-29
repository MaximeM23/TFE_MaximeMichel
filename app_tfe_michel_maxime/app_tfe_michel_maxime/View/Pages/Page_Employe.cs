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
    public partial class Page_Employe : UserControl
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


        public Page_Employe()
        {
            InitializeComponent();
            listeDeroulanteEmploye1.SurChangementSelection += listeDeroulanteEmploye_SurChangementSelection;
            ficheEmploye1.SurChangementSelection += FicheEmploye1_SurChangementSelection;
            formulaire_Employe.SActiveLorsDunAjoutOuModification += RafraichirDonneesEmployes;
            formulaire_Employe.RefreshSurAnnulation += RefreshSurAnnulation;
            this.MinimumSize = new Size(1100, 797);
        }

        private void FicheEmploye1_SurChangementSelection(object sender, EventArgs e)
        {            
            if (ficheEmploye1.EmployeSelectionnee != null)
            {
                formulaire_Employe.EmployeSelectionne = ficheEmploye1.EmployeSelectionnee;
                formulaire_Employe.EnableButtonModifier = true;
                formulaire_Employe.EnableButtonAjouter = false;

                if (ficheEmploye1.EmployeSelectionnee.Statut.NomStatut == "Administrateur")
                {
                    buttonActiver.Enabled = false;
                    buttonDesactiver.Enabled = false;
                }
                else if (ficheEmploye1.EmployeSelectionnee.CompteActif == 1)
                {
                    buttonDesactiver.Enabled = true;
                    buttonActiver.Enabled = false;
                }
                else if (ficheEmploye1.EmployeSelectionnee.CompteActif == 0)
                {
                    buttonActiver.Enabled = true;
                    buttonDesactiver.Enabled = false;
                }
            }
        }

        private void RafraichirDonneesEmployes(object sender, EventArgs e)
        {
            ficheEmploye1_Load(sender, e);
        }

        private void listeDeroulanteEmploye_SurChangementSelection(object sender, EventArgs e)
        {
            if(listeDeroulanteEmploye1.EmployeSelectionne != null)
            {
                ficheEmploye1.Employe = Program.GMBD.EnumererEmploye(null, new PDSGBD.MyDB.CodeSql(@"JOIN statut_employe ON employe.fk_id_statut_employe = statut_employe.id_statut_employe
                                                                                                 JOIN adresse ON employe.fk_id_adresse = adresse.id_adresse
                                                                                                 JOIN civilite ON employe.fk_id_civilite = civilite.id_civilite"), 
                                                                                                 new PDSGBD.MyDB.CodeSql("WHERE employe.id_employe = {0}",listeDeroulanteEmploye1.EmployeSelectionne.Id), null);
                
            }
        }

        private void ficheEmploye1_Load(object sender, EventArgs e)
        {
            ficheEmploye1.HideFiltre();

            ficheEmploye1.Employe = Program.GMBD.EnumererEmploye(null, new PDSGBD.MyDB.CodeSql(@"JOIN statut_employe ON employe.fk_id_statut_employe = statut_employe.id_statut_employe
                                                                                                 JOIN adresse ON employe.fk_id_adresse = adresse.id_adresse
                                                                                                 JOIN civilite ON employe.fk_id_civilite = civilite.id_civilite"), null, null);
            listeDeroulanteEmploye1.Employe = ficheEmploye1.Employe;

        }

        private void formulaire_Employe_Load(object sender, EventArgs e)
        {
            formulaire_Employe.ChargerDonneesListView();
        }

        private void buttonActiver_Click(object sender, EventArgs e)
        {
            Employe EmployeAModifier = ficheEmploye1.EmployeSelectionnee;
            EmployeAModifier.CompteActif = 1;
            if ((EmployeAModifier.EstValide) && (Program.GMBD.ModifierEmploye(EmployeAModifier)))
            {
                ficheEmploye1.Employe = null;
                ficheEmploye1.Employe = Program.GMBD.EnumererEmploye(null, new PDSGBD.MyDB.CodeSql(@"JOIN statut_employe ON employe.fk_id_statut_employe = statut_employe.id_statut_employe
                                                                                                 JOIN adresse ON employe.fk_id_adresse = adresse.id_adresse
                                                                                                 JOIN civilite ON employe.fk_id_civilite = civilite.id_civilite"), null, null);

                buttonActiver.Enabled = false;
                buttonDesactiver.Enabled = false;
            }
        }

        private void buttonDesactiver_Click(object sender, EventArgs e)
        {
            Employe EmployeAModifier = ficheEmploye1.EmployeSelectionnee;
            EmployeAModifier.CompteActif = 0;
            if ((EmployeAModifier.EstValide) && (Program.GMBD.ModifierEmploye(EmployeAModifier)))
            {
                ficheEmploye1.Employe = null;
                ficheEmploye1.Employe = Program.GMBD.EnumererEmploye(null, new PDSGBD.MyDB.CodeSql(@"JOIN statut_employe ON employe.fk_id_statut_employe = statut_employe.id_statut_employe
                                                                                                 JOIN adresse ON employe.fk_id_adresse = adresse.id_adresse
                                                                                                 JOIN civilite ON employe.fk_id_civilite = civilite.id_civilite"), null, null);

                buttonActiver.Enabled = false;
                buttonDesactiver.Enabled = false;
            }
        }

        private void ficheEmploye1_SizeChanged(object sender, EventArgs e)
        {
            ficheEmploye1_Load(sender, e);
        }

        private void RefreshSurAnnulation(object sender, EventArgs e)
        {
            ficheEmploye1.EmployeSelectionnee = null;
        }
    }
}
