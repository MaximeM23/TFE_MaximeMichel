using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class PackOption : Entite<PackOption,PackOption.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de pack_option
            /// </summary>
            Id,
            /// <summary>
            /// Option disponible dans ce pack
            /// </summary>
            OptionVehicule,
            /// <summary>
            /// Lien vers le pack ayant cette option
            /// </summary>
            PackOptionPackVehicule
        }

        private OptionVehicule m_OptionVehicule;
        private PackOptionPackVehicule m_PackOptionPackVehicule;


        /// <summary>
        /// Propriété publique permettant l'accès à l'option disponible dans ce pack
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
        /// Propriété publique permettant l'accès au pack ayant cette option
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
        public PackOption()
            : base()
        {
            m_OptionVehicule = null;
            m_PackOptionPackVehicule = null;
        }


        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="OptionVehicule">Option liée à ce pack d'option</param>
        /// <param name="PackOptionPackVehicule">Pack ayant cette option</param>
        public PackOption(OptionVehicule OptionVehicule, PackOptionPackVehicule PackOptionPackVehicule)
            : this()
        {
            DefinirId(Id);
            this.OptionVehicule = OptionVehicule;
            this.PackOptionPackVehicule = PackOptionPackVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public PackOption(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_pack_option"));
            this.OptionVehicule = new OptionVehicule(Connexion, Enregistrement);
            this.PackOptionPackVehicule = new PackOptionPackVehicule(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<PackOption> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new PackOption(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "pack_option";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_option_vehicule = {0}, fk_id_popv = {1}",
                    m_OptionVehicule.Id,m_PackOptionPackVehicule.Id);
            }
        }


    }
}
