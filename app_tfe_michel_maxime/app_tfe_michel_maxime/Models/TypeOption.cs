using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class TypeOption : Entite<TypeOption,TypeOption.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id du type d'option
            /// </summary>
            Id,
            /// <summary>
            /// Nom du type d'option
            /// </summary>
            NomType
        }

        private string m_NomType;

        /// <summary>
        /// Propriété publique permettant l'accès au nom du type de l'option
        /// </summary>
        public string NomType
        {
            get
            {
                return m_NomType;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomType, "Le nom du type d'option est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomType);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 250) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.NomType, "Le nom du type d'option doit être compris entre 1 et 250 caractères");
                        ChampDevientInvalide(Champs.NomType);
                    }
                    else if (!string.Equals(value, m_NomType))
                    {
                        ModifierChamp(Champs.NomType, ref m_NomType, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public TypeOption()
            : base()
        {
            m_NomType = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomType">Nom du type d'option</param>
        public TypeOption(string NomType)
            : this()
        {
            DefinirId(Id);
            this.NomType = NomType;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public TypeOption(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_type_option"));
            this.NomType = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_type");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<TypeOption> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new TypeOption(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "type_option";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_type = {0}", m_NomType);
            }
        }
    }
}
