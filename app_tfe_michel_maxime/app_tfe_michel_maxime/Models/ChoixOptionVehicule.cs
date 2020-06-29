using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class ChoixOptionVehicule : Entite<ChoixOptionVehicule,ChoixOptionVehicule.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de choix_option_vehicule
            /// </summary>
            Id,
            /// <summary>
            /// Lien vers le véhicule ayant cette option
            /// </summary>
            VehiculeVente,
            /// <summary>
            /// Lien vers l'option que ce véhicule dispose
            /// </summary>
            OptionVehicule
        }

        private VehiculeVente m_VehiculeVente;
        private OptionVehicule m_OptionVehicule;


        /// <summary>
        /// Propriété publique permettant l'accès au véhicule ayant cette option
        /// </summary>
        public VehiculeVente VehiculeVente
        {
            get
            {
                return m_VehiculeVente;
            }
            set
            {
                if (!object.Equals(value, m_VehiculeVente))
                {
                    ModifierChamp(Champs.VehiculeVente, ref m_VehiculeVente, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'option du véhicule
        /// </summary>
        public OptionVehicule OptionVehicule
        {
            get
            {
                return m_OptionVehicule;
            }
            set
            {
                if (!object.Equals(value, m_OptionVehicule))
                {
                    ModifierChamp(Champs.OptionVehicule, ref m_OptionVehicule, value);
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ChoixOptionVehicule()
            : base()
        {
            m_VehiculeVente = null;
            m_OptionVehicule = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="VehiculeVente">Vehicule lié à cette option</param>
        /// <param name="OptionVehicule">Option lié à ce véhicule</param>
        public ChoixOptionVehicule(VehiculeVente VehiculeVente, OptionVehicule OptionVehicule)
            : this()
        {
            DefinirId(Id);
            this.VehiculeVente = VehiculeVente;
            this.OptionVehicule = OptionVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public ChoixOptionVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_choix_option_vehicule"));
            this.VehiculeVente = new VehiculeVente(Connexion, Enregistrement);
            this.OptionVehicule = new OptionVehicule(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<ChoixOptionVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new ChoixOptionVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "choix_option_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_vehicule_vente = {0}, fk_id_option_vehicule = {1}",
                    m_VehiculeVente.Id, m_OptionVehicule.Id);
            }
        }

    }
}
