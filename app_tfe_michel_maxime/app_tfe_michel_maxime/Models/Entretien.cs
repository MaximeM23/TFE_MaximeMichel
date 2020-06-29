using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Entretien : Entite<Entretien,Entretien.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de l'entretien
            /// </summary>
            Id,
            /// <summary>
            /// Nom du type d'entretien
            /// </summary>
            TypeEntretien,
            /// <summary>
            /// Prix de l'entretien
            /// </summary>
            Prix,
            /// <summary>
            /// Permet de savoir si ce type d'entretien est toujours disponible
            /// </summary>
            Disponible,
        }

        private string m_TypeEntretien;
        private double m_Prix;
        private int m_Disponible;

        /// <summary>
        /// Propriété publique permettant l'accès au type de l'entretien
        /// </summary>
        public string TypeEntretien
        {
            get
            {
                return m_TypeEntretien;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.TypeEntretien, "Le type d'entretien est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.TypeEntretien);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.TypeEntretien, "Le type d'entretien doit être compris entre 1 à 100 caractères");
                        ChampDevientInvalide(Champs.TypeEntretien);
                    }
                    else if (!string.Equals(value, m_TypeEntretien))
                    {
                        ModifierChamp(Champs.TypeEntretien, ref m_TypeEntretien, value);
                    }
                }
            }
        }        

        /// <summary>
        /// Propriété publique permettant l'accès au prix de l'entretien
        /// </summary>
        public double Prix
        {
            get
            {
                return m_Prix;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.Prix, "Le prix ne peut pas être négatif");
                    ChampDevientInvalide(Champs.Prix);
                }
                else if (value > 1000)
                {
                    Declencher_SurErreur(this, Champs.Prix, "Le prix ne peut pas dépasser 1000 €");
                    ChampDevientInvalide(Champs.Prix);
                }
                else
                {
                    if (!double.Equals(value, m_Prix))
                    {
                        ModifierChamp(Champs.Prix, ref m_Prix, value);
                    }
                }
            }
        }


        /// <summary>
        /// Propriété publique permettant de savoir si l'entretien est toujours disponible dans la liste d'entretiens existants
        /// </summary>
        public int Disponible
        {
            get
            {
                return m_Disponible;
            }
            set
            {
                if (value != -1)
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
        public Entretien()
            : base()
        {
            m_TypeEntretien = null;
            m_Prix = -1.0;
            m_Disponible = -1;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="TypeEntretien">Type de l'entretien</param>
        /// <param name="Prix">Prix de cet entretien</param>
        /// <param name="Disponible">Permet de savoir si l'entretien est toujours disponible</param>
        public Entretien(string TypeEntretien, double Prix,int Disponible)
            : this()
        {
            DefinirId(Id);
            this.TypeEntretien = TypeEntretien;
            this.Prix = Prix;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Entretien(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_entretien"));
            this.TypeEntretien = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "type_entretien");
            this.Prix = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix");
            this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Entretien> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Entretien(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "entretien";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("type_entretien = {0}, prix = {1}, disponible = {2}", m_TypeEntretien,m_Prix,m_Disponible);
            }
        }
    }
}
