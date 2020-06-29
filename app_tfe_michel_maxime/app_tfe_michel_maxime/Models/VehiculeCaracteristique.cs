using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public class VehiculeCaracteristique : Entite<VehiculeCaracteristique,VehiculeCaracteristique.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de l'enregistrement
            /// </summary>
            Id,
            /// <summary>
            /// Valeur de cette caractéristique
            /// </summary>
            Valeur,
            /// <summary>
            /// Référence au véhicule dont appartient cette caractéristique 
            /// </summary>
            Vehicule,
            /// <summary>
            /// Caractéristique de cet enregistrement
            /// </summary>
            Caracteristique
        }

        private string m_Valeur;
        private Vehicule m_Vehicule;
        private Caracteristique m_Caracteristique;


        /// <summary>
        /// Propriété publique permettant l'accès à la valeur de cette caractéristique
        /// </summary>
        public string Valeur
        {
            get
            {
                return m_Valeur;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Valeur, "La valeur de cette caractéristique est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Valeur);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.Valeur, "La valeur doit être comprise entre 1 à 100 caractères");
                        ChampDevientInvalide(Champs.Valeur);
                    }
                    else if (!string.Equals(value, m_Valeur))
                    {
                        ModifierChamp(Champs.Valeur, ref m_Valeur, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au véhicule dont appartient cette caractéristique
        /// </summary>
        public Vehicule Vehicule
        {
            get
            {
                return m_Vehicule;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Vehicule, "Veuillez choisir un véhicule correspondant");
                }
                if (!object.Equals(value, m_Vehicule))
                {
                    ModifierChamp(Champs.Vehicule, ref m_Vehicule, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la caractéristique
        /// </summary>
        public Caracteristique Caracteristique
        {
            get
            {
                return m_Caracteristique;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Caracteristique, "Veuillez choisir une caractéristique correspondante");
                }
                if (!object.Equals(value, m_Caracteristique))
                {
                    ModifierChamp(Champs.Caracteristique, ref m_Caracteristique, value);
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public VehiculeCaracteristique()
            : base()
        {
            m_Valeur = null;
            m_Vehicule = null;
            m_Caracteristique = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Valeur">Valeur de cette caractéristique</param>
        /// <param name="Vehicule">Véhicule lié à cette caractéristique</param>
        /// <param name="Caracteristique">Caractéritique correspondant à cet enregistrement</param>
        public VehiculeCaracteristique(int Quantite, Vehicule Vehicule, Caracteristique Caracteristique)
            : this()
        {
            DefinirId(Id);
            this.Vehicule = Vehicule;
            this.Caracteristique = Caracteristique;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public VehiculeCaracteristique(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_vehicule_caracteristique"));
            this.Valeur = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "valeur");
            this.Caracteristique = new Caracteristique(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<VehiculeCaracteristique> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new VehiculeCaracteristique(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "vehicule_caracteristique";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("valeur = {0}, fk_id_vehicule = {1}, fk_id_caracteristique = {2}",
                    Valeur, Vehicule.Id, Caracteristique.Id);
            }
        }

        public override void SupprimerEnCascade(MyDB Connexion)
        {
            Connexion.Executer("DELETE FROM vehicule_caracteristique WHERE id_vehicule_caracteristique = {0}", Id);
            Connexion.Executer("DELETE FROM caracteristique WHERE id_caracteristique = {0}", Caracteristique.Id);
        }
    }
}
