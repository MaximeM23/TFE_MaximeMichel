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
    public partial class Page_CatalogueVoiture : UserControl
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

        public Page_CatalogueVoiture()
        {
            InitializeComponent();
            ficheOptions1.Enabled = false;
            fichePackOptions1.Enabled = false;
            listeDeroulanteTypeOptions1.Enabled = false;
            listeDeroulanteVehicule1.Vehicule = Program.GMBD.EnumererVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type ON vehicule.fk_id_type = type.id_type"), new PDSGBD.MyDB.CodeSql("WHERE type.type = {0} AND disponible = 1",string.Format("Voiture")), null);
            listeDeroulanteVehicule1.SurChangementSelection += ListeDeroulanteVehicule_SurChangementSelection;
            listeDeroulanteTypeOptions1.SurChangementSelection += ListeDeroulanteTypeOption_SurChangementSelection;

            this.MinimumSize = new Size(1100, 750);
        }

        /// <summary>
        /// S'active au moment du changement de sélection sur la liste déroulante des véhicules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeDeroulanteVehicule_SurChangementSelection(object sender, EventArgs e)
        {
            if (listeDeroulanteVehicule1.VehiculeSelectionne != null)
            {
                buttonPasserCommande.Enabled = true;
                buttonDisponibilites.Enabled = true;
                ficheOptions1.Enabled = true;
                fichePackOptions1.Enabled = true;
                listeDeroulanteTypeOptions1.Enabled = true;
                listeDeroulanteTypeOptions1.TypeOptions = Program.GMBD.EnumererTypeOptions(null, null, null, null);
                #region Requêtes pour les caractéristique
                ///////////////////////////////////////
                // Requêtes pour les caractéristique //
                ///////////////////////////////////////
                ficheTechnique1.Caracteristique = listeDeroulanteVehicule1.VehiculeSelectionne.EnumVehiculeCaracteristique;
                ficheTechnique1.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (ficheTechnique1.TexteFiltreTechnique != "")
                        {
                            ficheTechnique1.Caracteristique = Program.GMBD.EnumererVehiculeCaracteristique(null,
                                                                            new PDSGBD.MyDB.CodeSql("JOIN caracteristique ON vehicule_caracteristique.fk_id_caracteristique = caracteristique.id_caracteristique"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_caracteristique.fk_id_vehicule = {0} AND caracteristique LIKE {1} ", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, ficheTechnique1.TexteFiltreTechnique)),
                                                                            null);
                        }
                        else
                        {
                            ficheTechnique1.Caracteristique = listeDeroulanteVehicule1.VehiculeSelectionne.EnumVehiculeCaracteristique;
                        }
                    };
                #endregion

                #region Requêtes pour les options
                ///////////////////////////////
                // Requêtes pour les options //
                ///////////////////////////////
                ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                    new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                            JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND disponible = 1", listeDeroulanteVehicule1.VehiculeSelectionne.Id),
                                                                                    null);
                ficheOptions1.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if ((ficheOptions1.TexteFiltreOptions != "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne == null))
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND nom_option LIKE {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, ficheOptions1.TexteFiltreOptions)),
                                                                            null);
                    }
                    else if ((ficheOptions1.TexteFiltreOptions == "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null))
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND option_vehicule.fk_id_type_option = {1}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                            null);

                    }
                    else if ((ficheOptions1.TexteFiltreOptions != "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null))
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND nom_option LIKE {1} AND option_vehicule.fk_id_type_option = {2}", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike, ficheOptions1.TexteFiltreOptions), listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                            null);
                    }
                    else if ((ficheOptions1.TexteFiltreOptions == "") && (listeDeroulanteTypeOptions1.TypeOptionsSelectionne == null))
                    {
                        ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                            new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule
                                                                                                      JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0}", listeDeroulanteVehicule1.VehiculeSelectionne.Id),
                                                                            null);
                    }
                };
                #endregion

                #region Requêtes pour les packs d'options
                ////////////////////////////////////////
                // Requêtes pour les packs d'options //
                ///////////////////////////////////////

                fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND disponible = 1", listeDeroulanteVehicule1.VehiculeSelectionne.Id),null);
                fichePackOptions1.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptions1.TexteFiltrePackOptions != "")
                    {
                        fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND nom_pack LIKE {1} AND disponible = 1", listeDeroulanteVehicule1.VehiculeSelectionne.Id, string.Format(c_FiltreAvecLike,fichePackOptions1.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptions1.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN popv_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = popv_vehicule.fk_id_popv"), new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND disponible = 1", listeDeroulanteVehicule1.VehiculeSelectionne.Id), null);
                    }
                };
                #endregion

                textBoxPrix.Text = listeDeroulanteVehicule1.VehiculeSelectionne.PrixVehicule.ToString();
                int VehiculeDispo = Program.GMBD.DisponibiliteVehicule(listeDeroulanteVehicule1.VehiculeSelectionne.Id);
                if (VehiculeDispo > 1) labelDisponibilite.Text = "Disponibilités";
                textBoxDispo.Text = VehiculeDispo.ToString();
                if (VehiculeDispo > 0) buttonDisponibilites.Enabled = true;
                else buttonDisponibilites.Enabled = false;
                textBoxEstimationLivraison.Text = listeDeroulanteVehicule1.VehiculeSelectionne.TempsLivraison.ToString();
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage +""))
                {
                    pictureBoxVoiture.Image = Image.FromFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString()+"/ImagesVehicule/" + listeDeroulanteVehicule1.VehiculeSelectionne.NomImage + "");
                }
            }
        }

        

        /// <summary>
        /// S'active au moment du changement de sélection sur la liste déroulante des types d'options
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListeDeroulanteTypeOption_SurChangementSelection(object sender,EventArgs e)
        {
            if((listeDeroulanteTypeOptions1.TypeOptionsSelectionne != null)&& (listeDeroulanteVehicule1.VehiculeSelectionne != null))
            {
                ficheOptions1.Options = Program.GMBD.EnumererOptionVehicule(null,
                                                                                        new PDSGBD.MyDB.CodeSql("JOIN vehicule_option_vehicule ON option_vehicule.id_option_vehicule = vehicule_option_vehicule.fk_id_option_vehicule"),
                                                                                        new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_vehicule = {0} AND option_vehicule.fk_id_type_option = {1} AND disponible = 1", listeDeroulanteVehicule1.VehiculeSelectionne.Id, listeDeroulanteTypeOptions1.TypeOptionsSelectionne.Id),
                                                                                        null);                
            }
        }

        private void buttonDisponibilité_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Disponibilites>(
                                (Page) =>
                                {
                                    Page.IdVehiculeType = listeDeroulanteVehicule1.VehiculeSelectionne.Id;
                                    return true;
                                });
        }

        private void buttonPasserCommande_Click(object sender, EventArgs e)
        {
            Form_Principal.Instance.CreerPageCourante<Page_Personnalisation>(
                                (Page) =>
                                {
                                    Page.VehiculeChoisi = listeDeroulanteVehicule1.VehiculeSelectionne;
                                    return true;
                                });
        }
        
    }
}
