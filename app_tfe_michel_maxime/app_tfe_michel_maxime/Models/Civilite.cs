using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Civilite : Entite<Civilite,Civilite.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de la civilité
            /// </summary>
            Id,
            /// <summary>
            /// Civilité de la personne
            /// </summary>
            Civilite
        }

        private string m_Civilite;

        /// <summary>
        /// Propriété publique permettant l'accès à la civilité de la personne
        /// </summary>
        public string CiviliteDeLaPersonne
        {
            get
            {
                return m_Civilite;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Civilite, "La civilité est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Civilite);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.Civilite, "La civilité doit être comprise entre 1 et 100 caractère");
                        ChampDevientInvalide(Champs.Civilite);
                    }
                    else if (!string.Equals(value, m_Civilite))
                    {
                        ModifierChamp(Champs.Civilite, ref m_Civilite, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Civilite()
            : base()
        {
            m_Civilite = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Civilite">Civilité de la personne</param>
        public Civilite(string Civilite)
            : this()
        {
            DefinirId(Id);
            this.CiviliteDeLaPersonne = Civilite;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Civilite(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_civilite"));
            this.CiviliteDeLaPersonne = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "civilite");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Civilite> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Civilite(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "civilite";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("civilite = {0}", m_Civilite);
            }
        }
    }
}
