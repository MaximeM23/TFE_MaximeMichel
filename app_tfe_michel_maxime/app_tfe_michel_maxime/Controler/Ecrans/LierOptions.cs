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
    public partial class LierOptions : UserControl
    {
        


        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";        

        public Vehicule Vehicule;

        public LierOptions()
        {
            InitializeComponent();
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
        }
        
        public void ChargerPanelOptions()
        {
            if(Vehicule != null)
            {
                // Si elles sont déjà chargées plus besoin de les recharger
                if (ficheOptionsDisponibles.Options != null)
                {
                    #region Requêtes pour les options disponibles
                    //+========================================================+
                    //| Requêtes pour les options disponibles pour le véhicule |
                    //+========================================================+
                    ficheOptionsDisponibles.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql(" WHERE option_vehicule.id_option_vehicule NOT IN (select vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
                    ficheOptionsDisponibles.SurChangementFiltre += (s, ev) =>
                    {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptionsDisponibles.TexteFiltreOptions != "")
                        {
                            ficheOptionsDisponibles.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql(" WHERE option_vehicule.id_option_vehicule NOT IN (select vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND nom_option LIKE {1} AND disponible = 1", Vehicule.Id, string.Format(c_FiltreAvecLike, ficheOptionsDisponibles.TexteFiltreOptions)),
                                                                            null);
                        }
                        else
                        {
                            ficheOptionsDisponibles.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql(" WHERE option_vehicule.id_option_vehicule NOT IN (select vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
                        }
                    };

                    #endregion
                }

                #region Requêtes pour les options liées au véhicule séléctionné
                //+========================================================+
                //| Requêtes pour les options liées au véhicule séléctionné|
                //+========================================================+
                ficheOptionsLiees.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE option_vehicule.id_option_vehicule IN (SELECT vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1", Vehicule.Id), null);
                ficheOptionsLiees.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                    if (ficheOptionsLiees.TexteFiltreOptions != "")
                    {
                        ficheOptionsLiees.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE option_vehicule.id_option_vehicule IN (SELECT vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND nom_option LIKE {1} AND disponible = 1 ",Vehicule.Id, string.Format(c_FiltreAvecLike, ficheOptionsLiees.TexteFiltreOptions)),
                                                                        null);
                    }
                    else
                    {
                        ficheOptionsLiees.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE option_vehicule.id_option_vehicule IN (SELECT vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1", Vehicule.Id), null);
                    }
                };

                #endregion

            }
        }

        private void pictureBoxAjouterO_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if(ficheOptionsDisponibles.OptionsSelectionnee != null)
            {
                VehiculeOptionVehicule NouvelleLiaisonOption = new VehiculeOptionVehicule();
                NouvelleLiaisonOption.Vehicule = Vehicule;
                NouvelleLiaisonOption.OptionVehicule = ficheOptionsDisponibles.OptionsSelectionnee;
                VehiculeOptionVehicule LiaisonExiste = Program.GMBD.EnumererVehiculeOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN option_vehicule ON vehicule_option_vehicule.fk_id_option_vehicule = option_vehicule.id_option_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_option_vehicule = {0} AND vehicule_option_vehicule.fk_id_vehicule = {1} AND disponible = 1", ficheOptionsDisponibles.OptionsSelectionnee.Id, Vehicule.Id), null).FirstOrDefault();
                if(LiaisonExiste == null)
                {
                    if ((NouvelleLiaisonOption.EstValide) && (Program.GMBD.AjouterVehiculeOptionVehicule(NouvelleLiaisonOption)))
                    {
                        RefreshFicheOptionDispo();
                        RefreshFicheOptionsLiees();
                        ValidationProvider.SetError(pictureBoxAjouterO, "Option correctement liée à ce véhicule");
                    }
                }
                else
                {
                    errorProvider.SetError(pictureBoxAjouterO, "Cette option existe déjà pour ce véhicule");
                }
            }
            else
            {
                errorProvider.SetError(pictureBoxAjouterO, "Vous devez sélectionner une option dans la liste");
            }
        }
        
        private void pictureBoxRetirerO_Click(object sender, EventArgs e)
        {
            ValidationProvider.Clear();
            errorProvider.Clear();
            if (ficheOptionsLiees.OptionsSelectionnee != null)
            {
                VehiculeOptionVehicule LiaisonExiste = Program.GMBD.EnumererVehiculeOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN option_vehicule ON vehicule_option_vehicule.fk_id_option_vehicule = option_vehicule.id_option_vehicule"), new PDSGBD.MyDB.CodeSql("WHERE vehicule_option_vehicule.fk_id_option_vehicule = {0} AND vehicule_option_vehicule.fk_id_vehicule = {1} AND disponible = 1", ficheOptionsLiees.OptionsSelectionnee.Id, Vehicule.Id), null).FirstOrDefault();
                if ((LiaisonExiste != null) && (Program.GMBD.SupprimerVehiculeOptionVehicule(LiaisonExiste)))
                {
                    RefreshFicheOptionDispo();
                    RefreshFicheOptionsLiees();
                    ValidationProvider.SetError(pictureBoxRetirerO, "Liaison entre cette option et ce véhicule correctement retirée");
                }
            }
            else
            {
                errorProvider.SetError(pictureBoxRetirerO, "Vous devez sélectionner un pack dans la liste");
            }
        }

        private void RefreshFicheOptionsLiees()
        {
            ficheOptionsLiees.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql("WHERE option_vehicule.id_option_vehicule IN (SELECT vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1", Vehicule.Id), null);
        }

        private void RefreshFicheOptionDispo()
        {
            ficheOptionsDisponibles.Options = Program.GMBD.EnumererOptionVehicule(null, new PDSGBD.MyDB.CodeSql("JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option"), new PDSGBD.MyDB.CodeSql(" WHERE option_vehicule.id_option_vehicule NOT IN (select vehicule_option_vehicule.fk_id_option_vehicule from vehicule_option_vehicule WHERE fk_id_vehicule = {0}) AND disponible = 1",Vehicule.Id), null);
        }

    }
}
