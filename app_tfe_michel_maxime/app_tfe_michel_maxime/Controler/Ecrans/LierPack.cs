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
    public partial class LierPack : UserControl
    {
        
        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";        

        public Vehicule Vehicule;

        public LierPack()
        {
            InitializeComponent();
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
        }
        
        public void ChargerPanelPack()
        {
            if(Vehicule != null)
            {
                if (fichePackOptionsAChoisir.PackOptions != null)
                {
                    #region Requêtes pour les packs d'options liés à ce véhicule
                    //+========================================================================+
                    //| Requêtes pour les packs d'options disponibles pour ce type de véhicule |
                    //+========================================================================+
                    fichePackOptionsAChoisir.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql(" WHERE pack_option_pack_vehicule.id_pack_option_pack_vehicule NOT IN (select popv_vehicule.fk_id_popv from popv_vehicule WHERE popv_vehicule.fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
                    fichePackOptionsAChoisir.SurChangementFiltre += (s, ev) =>
                    {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptionsAChoisir.TexteFiltrePackOptions != "")
                        {
                            fichePackOptionsAChoisir.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                            null,
                                                                            new PDSGBD.MyDB.CodeSql(" WHERE pack_option_pack_vehicule.id_pack_option_pack_vehicule NOT IN (select popv_vehicule.fk_id_popv from popv_vehicule WHERE fk_id_vehicule = {0}) AND nom_pack LIKE {1} AND disponible = 1", Vehicule.Id, string.Format(c_FiltreAvecLike, fichePackOptionsAChoisir.TexteFiltrePackOptions)),
                                                                            null);
                        }
                        else
                        {
                            fichePackOptionsAChoisir.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql(" WHERE pack_option_pack_vehicule.id_pack_option_pack_vehicule NOT IN (select popv_vehicule.fk_id_popv from popv_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
                        }
                    };
                    #endregion
                }
                #region Requêtes pour les packs d'options liés à ce véhicule
                //+======================================================+
                //| Requêtes pour les packs d'options liés à ce véhicule |
                //+======================================================+

                fichePackOptionsLier.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN popv_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"), 
                                                                                                                                new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND disponible = 1", Vehicule.Id), null);
                fichePackOptionsLier.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (fichePackOptionsLier.TexteFiltrePackOptions != "")
                    {
                        fichePackOptionsLier.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null,
                                                                        new PDSGBD.MyDB.CodeSql(@"JOIN popv_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND nom_pack LIKE {1} AND disponible = 1", Vehicule.Id, string.Format(c_FiltreAvecLike, fichePackOptionsLier.TexteFiltrePackOptions)),
                                                                        null);
                    }
                    else
                    {
                        fichePackOptionsLier.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN popv_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"),
                                                                                                                                new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND disponible = 1", Vehicule.Id), null);
                    }
                };
                #endregion


            }
        }

        private void pictureBoxAjouterP_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if(fichePackOptionsAChoisir.PackOptionsSelectionnee != null)
            {
                PopvVehicule NouvelleLiaisonPack = new PopvVehicule();
                NouvelleLiaisonPack.Vehicule = Vehicule;
                NouvelleLiaisonPack.PackOptionPackVehicule = fichePackOptionsAChoisir.PackOptionsSelectionnee;
                PopvVehicule LiaisonExiste = Program.GMBD.EnumererPopvVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN pack_option_pack_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE fk_id_popv = {0} AND fk_id_vehicule = {1} AND disponible = 1", fichePackOptionsAChoisir.PackOptionsSelectionnee.Id, Vehicule.Id), null).FirstOrDefault();
                if(LiaisonExiste == null)
                {
                    if ((NouvelleLiaisonPack.EstValide) && (Program.GMBD.AjouterPopvVehicule(NouvelleLiaisonPack)))
                    {
                        RefreshFichePackDispo();
                        RefreshFichePacksLies();
                        ValidationProvider.SetError(pictureBoxAjouterP, "Pack correctement lié à ce véhicule");
                    }
                }
                else
                {
                    errorProvider.SetError(pictureBoxAjouterP, "Ce pack existe déjà pour ce véhicule");
                }
            }
            else
            {
                errorProvider.SetError(pictureBoxAjouterP, "Vous devez séléctionner un pack dans la liste");
            }
        }        

        private void pictureBoxRetirerP_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if (fichePackOptionsLier.PackOptionsSelectionnee != null)
            {
                PopvVehicule LiaisonExiste = Program.GMBD.EnumererPopvVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN pack_option_pack_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE fk_id_popv = {0} AND fk_id_vehicule = {1} AND disponible = 1", fichePackOptionsLier.PackOptionsSelectionnee.Id, Vehicule.Id), null).FirstOrDefault();
                if ((LiaisonExiste != null) && (fichePackOptionsLier.PackOptionsSelectionnee.EstValide) && (Program.GMBD.SupprimerPopvVehicule(LiaisonExiste)))
                {
                    RefreshFichePackDispo();
                    RefreshFichePacksLies();
                    ValidationProvider.SetError(pictureBoxRetirerP, "Liaison entre ce pack et ce véhicule correcement retirée");
                }
            }
            else
            {
                errorProvider.SetError(pictureBoxRetirerP, "Vous devez séléctionner un pack dans la liste");
            }
        }

        private void RefreshFichePacksLies()
        {
            fichePackOptionsLier.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, new PDSGBD.MyDB.CodeSql(@"JOIN popv_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule"),
                                                                                                                                   new PDSGBD.MyDB.CodeSql("WHERE popv_vehicule.fk_id_vehicule = {0} AND disponible = 1", Vehicule.Id), null);
        }

        private void RefreshFichePackDispo()
        {
            fichePackOptionsAChoisir.PackOptions = Program.GMBD.EnumererPackOptionVehicule(null, null, new PDSGBD.MyDB.CodeSql(" WHERE pack_option_pack_vehicule.id_pack_option_pack_vehicule NOT IN (select popv_vehicule.fk_id_popv from popv_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
        }

    }
}
