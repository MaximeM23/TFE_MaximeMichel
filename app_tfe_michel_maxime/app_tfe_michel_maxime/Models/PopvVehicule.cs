using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class PopvVehicule : Entite<PopvVehicule,PopvVehicule.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de popv_vehicule
            /// </summary>
            Id,
            /// <summary>
            /// Lien vers le véhicule pour lequel ce pack est disponible
            /// </summary>
            Vehicule,
            /// <summary>
            /// Lien vers les packs disponibles pour ce véhicule
            /// </summary>
            PackOptionPackVehicule
        }

        private Vehicule m_Vehicule;
        private PackOptionPackVehicule m_PackOptionPackVehicule;


        /// <summary>
        /// Propriété publique permettant l'accès aux véhicules ayant ce pack
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
        /// Propriété publique permettant l'accès au pack disponible pour ce véhicule
        /// </summary>
        public PackOptionPackVehicule PackOptionPackVehicule
        {
            get
            {
                return m_PackOptionPackVehicule;
            }
            set
            {
                if (!object.Equals(value, m_PackOptionPackVehicule))
                {
                    ModifierChamp(Champs.PackOptionPackVehicule, ref m_PackOptionPackVehicule, value);
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PopvVehicule()
            : base()
        {
            m_Vehicule = null;
            m_PackOptionPackVehicule = null;
        }
        
        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Vehicule">Véhicule ayant ce pack disponible</param>
        /// <param name="PackOptionPackVehicule">Pack disponible pour ce véhicule</param>
        public PopvVehicule(Vehicule Vehicule,PackOptionPackVehicule PackOptionPackVehicule)
            : this()
        {
            DefinirId(Id);
            this.Vehicule = Vehicule;
            this.PackOptionPackVehicule = PackOptionPackVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public PopvVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_popv_vehicule"));
            this.Vehicule = new Vehicule(Connexion, Enregistrement);
            this.PackOptionPackVehicule= new PackOptionPackVehicule(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<PopvVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new PopvVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "popv_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_vehicule = {0}, fk_id_popv = {1}",
                    m_Vehicule.Id,m_PackOptionPackVehicule.Id);
            }
        }

    }
}
