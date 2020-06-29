using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Article : Entite<Article,Article.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de cet article
            /// </summary>
            Id,
            /// <summary>
            /// Nom de cet article
            /// </summary>
            NomArticle,
            /// <summary>
            /// Quantité dans le stock de cet article
            /// </summary>
            Stock,
            /// <summary>
            /// Prix unitaire de cet article
            /// </summary>
            PrixUnite,
            /// <summary>
            /// Permet de savoir si l'article est toujours disponible à l'achat
            /// </summary>
            Disponible,
        }

        private string m_NomArticle;
        private int m_Stock;
        private double m_PrixUnite;
        private int m_Disponible;

        /// <summary>
        /// Propriété publique permettant l'accès au nom de cet article
        /// </summary>
        public string NomArticle
        {
            get
            {
                return m_NomArticle;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomArticle, "Le nom de l'article est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomArticle);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.NomArticle, "Le nom de l'article doit être compris entre 1 à 100 caractères");
                        ChampDevientInvalide(Champs.NomArticle);
                    }
                    else if (!string.Equals(value, m_NomArticle))
                    {
                        ModifierChamp(Champs.NomArticle, ref m_NomArticle, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au stock de cet article
        /// </summary>
        public int Stock
        {
            get
            {
                return m_Stock;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.Stock, "La quantité ne peut pas être inférieure à 0");
                    ChampDevientInvalide(Champs.Stock);
                }
                else if (value > int.MaxValue)
                {
                    Declencher_SurErreur(this, Champs.Stock, "La quantité ne peut pas dépasser "+int.MaxValue);
                    ChampDevientInvalide(Champs.Stock);
                }
                else
                {
                    if (!int.Equals(value, m_Stock))
                    {
                        ModifierChamp(Champs.Stock, ref m_Stock, value);
                    }
                }
            }
        }
        
        /// <summary>
        /// Propriété publique permettant l'accès au prix unitaire d'un article
        /// </summary>
        public double PrixUnite
        {
            get
            {
                return m_PrixUnite;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.PrixUnite, "Le prix ne peut pas être négatif");
                    ChampDevientInvalide(Champs.PrixUnite);
                }
                else if (value > 5000)
                {
                    Declencher_SurErreur(this, Champs.PrixUnite, "Le prix ne peut pas dépasser 5 000 €");
                    ChampDevientInvalide(Champs.PrixUnite);
                }
                else
                {
                    if (!double.Equals(value, m_PrixUnite))
                    {
                        ModifierChamp(Champs.PrixUnite, ref m_PrixUnite, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant de savoir si l'article est toujours disponible dans la liste d'articles existants
        /// </summary>
        public int Disponible
        {
            get
            {
                return m_Disponible;
            }
            set
            {
                if(value != -1)
                { 
                    if (!int.Equals(value, m_Disponible))
                    {
                        ModifierChamp(Champs.Disponible, ref m_Disponible, value);
                    }
                }            
            }
        }


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Article()
            : base()
        {
            m_NomArticle = null;
            m_Stock = -1;
            m_PrixUnite = -1.0;
            m_Disponible = -1;

        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomArticle">Nom de cet article</param>
        /// <param name="Stock">Quantité de cet article dans le stock</param>
        /// <param name="PrixUnite">Prix à l'unité de cet article</param>
        /// <param name="Disponible">Prix à l'unité de cet article</param>
        public Article(string NomArticle, int Stock, double PrixUnite,int Disponible)
            : this()
        {
            DefinirId(Id);
            this.NomArticle = NomArticle;
            this.Stock = Stock;
            this.PrixUnite = PrixUnite;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Article(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_article"));
            this.NomArticle = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_article");
            this.Stock = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "stock");
            this.PrixUnite = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix_unite");
            this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Article> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Article(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "article";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_article = {0}, stock = {1}, prix_unite = {2}, disponible = {3}", m_NomArticle, m_Stock, m_PrixUnite,m_Disponible);
            }
        }
    }
}
