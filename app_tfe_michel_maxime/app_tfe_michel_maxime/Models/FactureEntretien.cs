using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class FactureEntretien : Entite<FactureEntretien,FactureEntretien.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de l'entretien
            /// </summary>
            Id,
            /// <summary>
            /// Numéro de l'id de la facture de cet entretien
            /// </summary>
            FactureLiee,
            /// <summary>
            /// Type d'entretien
            /// </summary>
            Entretien
        }
        
        private Facture m_FactureLiee;
        private Entretien m_Entretien;

        
        /// <summary>
        /// Propriété publique permettant l'accès à la facture de l'entretien
        /// </summary>
        public Facture FactureLiee
        {
            get
            {
                return m_FactureLiee;
            }
            set
            {
                if (!object.Equals(value, m_FactureLiee))
                {
                    ModifierChamp(Champs.FactureLiee, ref m_FactureLiee, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au type de l'entretien
        /// </summary>
        public Entretien Entretien
        {
            get
            {
                return m_Entretien;
            }
            set
            {
                if (!object.Equals(value, m_Entretien))
                {
                    ModifierChamp(Champs.Entretien, ref m_Entretien, value);
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public FactureEntretien()
            : base()
        {
            m_FactureLiee = null;
            m_Entretien = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Facture">Facture liée à l'entretien</param>
        /// <param name="Entretien">Entretien lié à cette facture</param>
        public FactureEntretien(Facture Facture, Entretien Entretien)
            : this()
        {
            DefinirId(Id);
            this.FactureLiee = Facture;
            this.Entretien = Entretien;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public FactureEntretien(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_facture_entretien"));
            this.Entretien = new Entretien(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<FactureEntretien> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new FactureEntretien(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "facture_entretien";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("fk_id_facture = {0}, fk_id_entretien = {1}",
                    m_FactureLiee.Id, m_Entretien.Id);
            }
        }
    }
}
