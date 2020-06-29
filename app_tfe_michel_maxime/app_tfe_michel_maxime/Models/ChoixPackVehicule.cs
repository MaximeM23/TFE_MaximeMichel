using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class ChoixPackVehicule : Entite<ChoixPackVehicule,ChoixPackVehicule.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de choix_pack_vehicule
            /// </summary>
            Id,
            /// <summary>
            /// Lien vers le véhicule ayant ce pack
            /// </summary>
            VehiculeVente,
            /// <summary>
            /// Lien vers le pack que dispose ce véhicule
            /// </summary>
            PackOptionPackVehicule
        }

        private VehiculeVente m_VehiculeVente;
        private PackOptionPackVehicule m_PackOptionPackVehicule;


        /// <summary>
        /// Propriété publique permettant l'accès au véhicule ayant ce pack
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
        /// Propriété publique permettant l'accès au pack que dispose ce véhicule
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
        public ChoixPackVehicule()
            : base()
        {
            m_VehiculeVente = null;
            m_PackOptionPackVehicule = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="VehiculeVente">Vehicule lié à cette option</param>
        /// <param name="PackOptionPackVehicule">Pack lié à ce véhicule</param>
        public ChoixPackVehicule(VehiculeVente VehiculeVente, PackOptionPackVehicule PackOptionPackVehicule)
            : this()
        {
            DefinirId(Id);
            this.VehiculeVente = VehiculeVente;
            this.PackOptionPackVehicule = PackOptionPackVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public ChoixPackVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_choix_pack_vehicule"));
            this.VehiculeVente = new VehiculeVente(Connexion, Enregistrement);
            this.PackOptionPackVehicule = new PackOptionPackVehicule(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<ChoixPackVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new ChoixPackVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "choix_pack_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_vehicule_vente = {0}, fk_id_popv = {1}",
                    m_VehiculeVente.Id, m_PackOptionPackVehicule.Id);
            }
        }


    }
}
