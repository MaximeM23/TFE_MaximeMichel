using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Adresse : Entite<Adresse,Adresse.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id d'adresse
            /// </summary>
            Id,
            /// <summary>
            /// Localite de la personne
            /// </summary>
            Localite,
            /// <summary>
            /// Code postal de la personne
            /// </summary>
            CodePostal,
            
        }

        #region Membres privés
        private string m_Localite;
        private int m_CodePostal;       
        #endregion
        

        /// <summary>
        /// Propriété publique permettant l'accès à la localité de la personne
        /// </summary>
        public string Localite
        {
            get
            {
                return m_Localite;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Localite, "La localité est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Localite);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.Localite, "La localité doit être comprise entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.Localite);
                    }
                    else if (!string.Equals(value, m_Localite))
                    {
                        ModifierChamp(Champs.Localite, ref m_Localite, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au code postal de la personne
        /// </summary>
        public int CodePostal
        {
            get
            {
                return m_CodePostal;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.CodePostal, "Le code postal doit comporter au minimum 1 chiffre supérieur à 0");
                    ChampDevientInvalide(Champs.CodePostal);
                }
                else if (value > 999999999)
                {
                    Declencher_SurErreur(this, Champs.CodePostal, "Le numéro de téléphone doit comporter au maximum 9 chiffres");
                    ChampDevientInvalide(Champs.CodePostal);
                }
                else
                {
                    if (!int.Equals(value, m_CodePostal))
                    {
                        ModifierChamp(Champs.CodePostal, ref m_CodePostal, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Adresse()
            : base()
        {
            m_Localite = null;
            m_CodePostal = 0;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Localite">Localité de la personne</param>
        /// <param name="CodePostal">Code postal de la personne</param>
        /// <param name="Rue">Rue de la personne</param>
        /// <param name="Numero">Numéro d'habitation de la personne</param>
        public Adresse(string Localite, int CodePostal)
            : this()
        {
            DefinirId(Id);
            this.Localite = Localite;
            this.CodePostal = CodePostal;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Adresse(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_adresse"));
            this.Localite = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "localite");
            this.CodePostal = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "code_postal");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Adresse> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Adresse(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "adresse";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("localite = {0}, code_postal = {1}",m_Localite,m_CodePostal);
            }
        }
    }
}
