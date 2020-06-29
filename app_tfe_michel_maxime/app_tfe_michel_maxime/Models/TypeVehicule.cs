using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class TypeVehicule : Entite<TypeVehicule, TypeVehicule.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id du type de caractéristique
            /// </summary>
            Id,
            /// <summary>
            /// Nom du type de caractéristique
            /// </summary>
            NomDuType,
        }

        private string m_NomDuType;

        /// <summary>
        /// Propriété publique permettant l'accès au nom du type de caractéristique (voiture / moto)
        /// </summary>
        public string NomDuType
        {
            get
            {
                return m_NomDuType;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomDuType, "Le nom du type de caractéristique est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomDuType);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.NomDuType, "Le nom du type de caractéristique doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.NomDuType);
                    }
                    else if (!string.Equals(value, m_NomDuType))
                    {
                        ModifierChamp(Champs.NomDuType, ref m_NomDuType, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public TypeVehicule()
            : base()
        {
            m_NomDuType = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomDuType">Nom du type de caractèristique (voiture/moto)</param>
        public TypeVehicule(string NomDuType)
            : this()
        {
            DefinirId(Id);
            this.NomDuType = NomDuType;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public TypeVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_type"));
            this.NomDuType = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "type");
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<TypeVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new TypeVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "type";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("type = {0}",
                    m_NomDuType);
            }
        }
    }

}
