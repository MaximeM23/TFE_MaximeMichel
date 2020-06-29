using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Statut : Entite<Statut, Statut.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id du statut
            /// </summary>
            Id,
            /// <summary>
            /// Statut 
            /// </summary>
            Statut
        }

        private string m_Statut;

        /// <summary>
        /// Propriété publique permettant l'accès au statut 
        /// </summary>
        public string StatutOperation
        {
            get
            {
                return m_Statut;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Statut, "Le statut est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Statut);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 250) || (value.Length < 0))
                    {
                        Declencher_SurErreur(this, Champs.Statut, "Le statut doit être compris entre 0 et 250 caractères");
                        ChampDevientInvalide(Champs.Statut);
                    }
                    else if (!string.Equals(value, m_Statut))
                    {
                        ModifierChamp(Champs.Statut, ref m_Statut, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Statut()
            : base()
        {
            m_Statut = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Statut">Statut</param>
        public Statut(string StatutOperation)
            : this()
        {
            DefinirId(Id);
            this.StatutOperation = StatutOperation;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Statut(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_statut"));
            this.StatutOperation = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "statut");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Statut> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Statut(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "statut";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("statut = {0}", m_Statut);
            }
        }

    }
}
