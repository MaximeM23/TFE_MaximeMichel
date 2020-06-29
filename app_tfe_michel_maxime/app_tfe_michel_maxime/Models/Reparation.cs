using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Reparation : Entite<Reparation,Reparation.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de la réparation
            /// </summary>
            Id,
            /// <summary>
            /// Nombre d'articles utilisés pour cette réparation
            /// </summary>
            QuantiteArticle,
            /// <summary>
            /// Numéro de l'id de la facture de cette réparation
            /// </summary>
            FactureLiee,
            /// <summary>
            /// Article utilisé pour cette réparation
            /// </summary>
            Article
        }

        private int m_QuantiteArticle;
        private Facture m_FactureLiee;
        private Article m_Article;


        /// <summary>
        /// Propriété publique permettant l'accès à la quantité de cet article utilisé pour la réparation ou l'entretien
        /// </summary>
        public int QuantiteArticle
        {
            get
            {
                return m_QuantiteArticle;
            }
            set
            {
                if(value < 0)
                {
                    Declencher_SurErreur(this, Champs.QuantiteArticle, "La quantité ne peut pas être inférieure à 0");
                    ChampDevientInvalide(Champs.QuantiteArticle);
                }
                else if (value > int.MaxValue)
                {
                    Declencher_SurErreur(this, Champs.QuantiteArticle, "La quantité ne peut pas être inférieure à " + int.MaxValue);
                    ChampDevientInvalide(Champs.QuantiteArticle);
                }
                else if (!int.Equals(value, m_QuantiteArticle))
                {
                    ModifierChamp(Champs.QuantiteArticle, ref m_QuantiteArticle, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la facture de l'article utilisé
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
        /// Propriété publique permettant l'accès à l'article utilisé
        /// </summary>
        public Article Article
        {
            get
            {
                return m_Article;
            }
            set
            {
                if (!object.Equals(value, m_Article))
                {
                    ModifierChamp(Champs.Article, ref m_Article, value);
                }
            }
        }
        
        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Reparation()
            : base()
        {
            m_QuantiteArticle = -1;
            m_FactureLiee = null;
            m_Article = null;
        }
        
        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Quantite">Quantité de cet article utilisé pour cette facture</param>
        /// <param name="Facture">Facture liée à cette réparation ou entretien</param>
        /// <param name="Article">Article utilisé pour cette réparation ou cet entretien</param>
        public Reparation(int Quantite, Facture Facture, Article Article)
            : this()
        {
            DefinirId(Id);
            this.FactureLiee = Facture;
            this.Article = Article;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Reparation(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_reparation"));
            this.QuantiteArticle = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "quantite_article");
            this.FactureLiee = new Facture(Connexion, Enregistrement);
            this.Article = new Article(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Reparation> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Reparation(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "reparation";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("quantite_article = {0}, fk_id_facture = {1}, fk_id_article = {2}",
                    m_QuantiteArticle,m_FactureLiee.Id,m_Article.Id);
            }
        }
    }
}

