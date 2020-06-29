using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class OptionVehicule : Entite<OptionVehicule,OptionVehicule.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de cette option
            /// </summary>
            Id,
            /// <summary>
            /// Nom de l'option
            /// </summary>
            NomOption,
            /// <summary>
            /// Prix de cette option
            /// </summary>
            Prix,
            /// <summary>
            /// Type d'option
            /// </summary>
            TypeOption,
            /// <summary>
            /// Permet de savoir si l'option figure encore parmis les options possibles à la vente
            /// </summary>
            Disponible
        }

        private string m_NomOption;
        private double m_Prix;
        private TypeOption m_TypeOption;
        private int m_Disponible;
        
        /// <summary>
        /// Propriété publique permettant l'accès au nom de l'option
        /// </summary>
        public string NomOption
        {
            get
            {
                return m_NomOption;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomOption, "Le nom de l'option est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomOption);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length < 1))
                    {
                        Declencher_SurErreur(this, Champs.NomOption, "Le nom de l'option doit être compris entre 1 à 100 caractères");
                        ChampDevientInvalide(Champs.NomOption);
                    }
                    else if (!string.Equals(value, m_NomOption))
                    {
                        ModifierChamp(Champs.NomOption, ref m_NomOption, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au prix de cette option
        /// </summary>
        public double Prix
        {
            get
            {
                return m_Prix;
            }
            set
            {
                if(value < 0)
                {
                    Declencher_SurErreur(this, Champs.Prix, "Le prix de cette option ne peut pas être inférieur à 0 €");
                    ChampDevientInvalide(Champs.Prix);
                }
                else if(value > 100000)
                {
                    Declencher_SurErreur(this, Champs.Prix, "Le prix ne peut pas être supérieur à 100 000 €");
                    ChampDevientInvalide(Champs.Prix);
                }
                else if (!double.Equals(value, m_Prix))
                {
                    ModifierChamp(Champs.Prix, ref m_Prix, value);
                }                
            }
        }

        /// <summary>
        /// Propriété publique permettant de savoir si l'option est disponible
        /// </summary>
        public int Disponible
        {
            get
            {
                return m_Disponible;
            }
            set
            {                               
                ModifierChamp(Champs.Disponible, ref m_Disponible, value);                
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au type de l'option
        /// </summary>
        public TypeOption TypeOption
        {
            get
            {
                return m_TypeOption;
            }
            set
            {
                if(value == null)
                {
                    Declencher_SurErreur(this, Champs.TypeOption, "Veuillez choisir un type d'option");
                }
                if (!object.Equals(value, m_TypeOption))
                {
                    ModifierChamp(Champs.TypeOption, ref m_TypeOption, value);
                }
            }
        }


        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public OptionVehicule()
            : base()
        {
            m_NomOption = null;
            m_Prix = -1.0;
            m_TypeOption = null;
            m_Disponible = -1;
        }


        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomOption">Nom de l'option</param>
        /// <param name="Prix">Prix de l'option</param>
        /// <param name="TypeOption">Type de l'option</param>
        public OptionVehicule(string NomOption, double Prix, TypeOption TypeOption,int Disponible)
            : this()
        {
            DefinirId(Id);
            this.NomOption = NomOption;
            this.Prix = Prix;
            this.TypeOption = TypeOption;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public OptionVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_option_vehicule"));
            this.NomOption = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_option");
            this.Prix = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix");
            this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
            this.TypeOption = new TypeOption(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<OptionVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new OptionVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "option_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_option = {0}, prix = {1}, fk_id_type_option = {2}, disponible = {3}"
                    , m_NomOption,m_Prix,m_TypeOption.Id,m_Disponible);
            }
        }

    }
}
