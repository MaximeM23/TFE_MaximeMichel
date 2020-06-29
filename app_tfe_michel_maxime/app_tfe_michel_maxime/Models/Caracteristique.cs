using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Caracteristique : Entite<Caracteristique, Caracteristique.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de la caractéristique
            /// </summary>
            Id,
            /// <summary>
            /// Valeur de cette caractéristique
            /// </summary>
            Caracteristique,
            /// <summary>
            /// Référence au véhicule dont appartient cette caractéristique avec cette valeur spécifique
            /// </summary>
            Type,
            /// <summary>
            /// Permet de savoir si la caractéristique est encore existante à l'utilisation
            /// </summary>
            Disponible,
        }


        private string m_Caracteristique;
        private TypeVehicule m_TypeVehicule;
        private int m_Disponible;


        /// <summary>
        /// Propriété publique permettant l'accès au nom de cette caractéristique
        /// </summary>
        public string NomCaracteristique
        {
            get
            {
                return m_Caracteristique;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Caracteristique, "Le nom de cette caractéristique est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Caracteristique);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.Caracteristique, "Le nom de la caractéristique doit être compris entre 1 à 100 caractères");
                        ChampDevientInvalide(Champs.Caracteristique);
                    }
                    else if (!string.Equals(value, m_Caracteristique))
                    {
                        ModifierChamp(Champs.Caracteristique, ref m_Caracteristique, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au type dont appartient cette caractéristique
        /// </summary>
        public TypeVehicule TypeVehicule
        {
            get
            {
                return m_TypeVehicule;
            }
            set
            {
                if(value == null)
                {
                    Declencher_SurErreur(this, Champs.Type, "Veuillez choisir un type correspondant");
                }
                if (!object.Equals(value, m_TypeVehicule))
                {
                    ModifierChamp(Champs.Type, ref m_TypeVehicule, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant de savoir si la caractéristique est toujours disponible
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
        public Caracteristique()
            : base()
        {
            m_Caracteristique = null;
            m_TypeVehicule = null;
            m_Disponible = -1;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Caracteristique">Nom de cette caractéristique</param>
        /// <param name="TypeVehicule">Type de véhicule lié à cette caractéristique</param>
        /// <param name="Disponible">Permet de savoir si la caractéristique est encore disponible à l'utilisation ( 1 = true, 0 = false)</param>
        public Caracteristique(string Caracteristique, TypeVehicule TypeVehicule, int Disponible)
            : this()
        {
            DefinirId(Id);
            this.NomCaracteristique = Caracteristique;
            this.TypeVehicule = TypeVehicule;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Caracteristique(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_caracteristique"));
            this.NomCaracteristique = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "caracteristique");
            this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
            this.TypeVehicule = new TypeVehicule(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Caracteristique> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Caracteristique(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "caracteristique";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("caracteristique = {0}, fk_id_type = {1}, disponible = {2}",
                    m_Caracteristique, m_TypeVehicule.Id, m_Disponible);
            }
        }
    }
}

