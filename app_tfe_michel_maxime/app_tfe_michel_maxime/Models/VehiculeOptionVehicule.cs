using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class VehiculeOptionVehicule : Entite<VehiculeOptionVehicule,VehiculeOptionVehicule.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de vehicule_option_vehicule
            /// </summary>
            Id,
            /// <summary>
            /// Lien vers le véhicule à qui cette option est disponible
            /// </summary>
            Vehicule,
            /// <summary>
            /// Lien vers les options disponibles pour ce véhicule
            /// </summary>
            OptionVehicule
        }

        private Vehicule m_Vehicule;
        private OptionVehicule m_OptionVehicule;


        /// <summary>
        /// Propriété publique permettant l'accès aux véhicules ayant cette option disponible
        /// </summary>
        public Vehicule Vehicule
        {
            get
            {
                return m_Vehicule;
            }
            set
            {
                if (!object.Equals(value, m_Vehicule))
                {
                    ModifierChamp(Champs.Vehicule, ref m_Vehicule, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'option disponible pour ce véhicule
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
        public VehiculeOptionVehicule()
            : base()
        {
            m_Vehicule = null;
            m_OptionVehicule = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Vehicule">Vehicule ayant cette option disponible</param>
        /// <param name="OptionVehicule">Option disponible par ce véhicule</param>
        public VehiculeOptionVehicule(Vehicule Vehicule, OptionVehicule OptionVehicule)
            : this()
        {
            DefinirId(Id);
            this.Vehicule = Vehicule;
            this.OptionVehicule = OptionVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public VehiculeOptionVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            base.Connexion = Connexion;
            if (Enregistrement != null)
            {
                DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_vehicule_option_vehicule"));
                this.Vehicule = new Vehicule(Connexion, Enregistrement);
                this.OptionVehicule = new OptionVehicule(Connexion, Enregistrement);
            }
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<VehiculeOptionVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new VehiculeOptionVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "vehicule_option_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_vehicule = {0}, fk_id_option_vehicule = {1}",
                    m_Vehicule.Id, m_OptionVehicule.Id);
            }
        }
        

    }
}
