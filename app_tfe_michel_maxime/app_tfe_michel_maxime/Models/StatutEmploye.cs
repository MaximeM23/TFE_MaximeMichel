using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class StatutEmploye : Entite<StatutEmploye, StatutEmploye.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id du statut
            /// </summary>
            Id,
            /// <summary>
            /// Statut de l'employé
            /// </summary>
            NomStatut
        }

        private string m_NomStatut;

        /// <summary>
        /// Propriété publique permettant l'accès au statut de l'employé
        /// </summary>
        public string NomStatut
        {
            get
            {
                return m_NomStatut;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if ((value.Length > 250) || (value.Length <= 5))
                    {
                        Declencher_SurErreur(this, Champs.NomStatut, "Le statut doit être compris entre 5 et 250 caractères");
                        ChampDevientInvalide(Champs.NomStatut);
                    }
                    else if (!string.Equals(value, m_NomStatut))
                    {
                        ModifierChamp(Champs.NomStatut, ref m_NomStatut, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public StatutEmploye()
            : base()
        {
            m_NomStatut = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomStatut">Statut de l'employé</param>
        public StatutEmploye(string NomStatut)
            : this()
        {
            DefinirId(Id);
            this.NomStatut = NomStatut;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public StatutEmploye(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_statut_employe"));
            this.NomStatut = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_statut");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<StatutEmploye> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new StatutEmploye(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "statut_employe";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_statut = {0}", m_NomStatut);
            }
        }
    }
}
