using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public class Vehicule : Entite<Vehicule,Vehicule.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id du véhicule
            /// </summary>
            Id,
            /// <summary>
            /// Modèle du véhicule
            /// </summary>
            Modele,
            /// <summary>
            /// Prix du véhicule
            /// </summary>
            PrixVehicule,
            /// <summary>
            /// Nom de l'image de ce véhicule
            /// </summary>
            NomImage,
            /// <summary>
            /// Temps de livraison du véhicule
            /// </summary>
            TempsLivraison,
            /// <summary>
            /// Correspond au type de véhicule, moto ou voiture
            /// </summary>
            TypeVehicule,
            /// <summary>
            /// Permet de savoir si le véhicule figure toujours dans la liste des véhicules vendu par la concession
            /// </summary>
            Disponible,
        }

        #region Membres privés
        private string m_Modele;
        private double m_PrixVehicule;
        private string m_NomImage;
        private int m_TempsLivraison;
        private TypeVehicule m_TypeVehicule;
        private List<VehiculeCaracteristique> m_VehiculeCaracteristique;
        private List<VehiculeOptionVehicule> m_VehiculeOptionVehicule;
        private List<PopvVehicule> m_PopvVehicule;
        private int m_Disponible;
        #endregion

        public IEnumerable<VehiculeOptionVehicule> EnumVehiculeOptionVehicule
        {
            get
            {
                return EnumererVehiculeOptionVehicule();
            }
            set
            {
                ChargerVehiculeOptionVehicule();
            }
        }

        public IEnumerable<PopvVehicule> EnumPopvVehicule
        {
            get
            {
                return EnumererPackOptionPackVehicule();
            }
            set
            {
                ChargerPopvVehicule();
            }
        }

        public IEnumerable<VehiculeCaracteristique> EnumVehiculeCaracteristique
        {
            get
            {
                return EnumererVehiculeCaracteristique();
            }
            set
            {
                ChargerVehiculeCaracteristique();
            }
        }

        private bool ChargerVehiculeOptionVehicule()
        {
            if (Id <= 0) return false;
            m_VehiculeOptionVehicule.Clear();
            m_VehiculeOptionVehicule.AddRange(EnumererVehiculeOptionVehicule());
            return true;
        }

        private bool ChargerPopvVehicule()
        {
            if (Id <= 0) return false;
            m_PopvVehicule.Clear();
            m_PopvVehicule.AddRange(EnumererPackOptionPackVehicule());
            return true;
        }

        private bool ChargerVehiculeCaracteristique()
        {
            if (Id <= 0) return false;
            m_VehiculeCaracteristique.Clear();
            m_VehiculeCaracteristique.AddRange(EnumererVehiculeCaracteristique());
            return true;
        }


        /// <summary>
        /// Propriété publique permettant l'accès au modèle du véhicule
        /// </summary>
        public string Modele
        {
            get
            {
                return m_Modele;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Modele, "Le nom du modèle est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Modele);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 250) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.Modele, "Le nom du modèle doit être compris entre 1 et 250 caractères");
                        ChampDevientInvalide(Champs.Modele);
                    }
                    else if (!string.Equals(value, m_Modele))
                    {
                        ModifierChamp(Champs.Modele, ref m_Modele, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au prix du véhicule
        /// </summary>
        public double PrixVehicule
        {
            get
            {
                return m_PrixVehicule;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.PrixVehicule, "Le prix du véhicule ne peut pas être négatif");
                    ChampDevientInvalide(Champs.PrixVehicule);
                }
                else if (value > 5000000000)
                {
                    Declencher_SurErreur(this, Champs.PrixVehicule, "Le prix du véhicule ne peut pas dépasser 5 000 000 000 €");
                    ChampDevientInvalide(Champs.PrixVehicule);
                }
                else
                {
                    if (!double.Equals(value, m_PrixVehicule))
                    {
                        ModifierChamp(Champs.PrixVehicule, ref m_PrixVehicule, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au modèle du véhicule
        /// </summary>
        public string NomImage
        {
            get
            {
                return m_NomImage;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomImage, "Le nom de l'image est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomImage);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.NomImage, "Le nom de l'image doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.NomImage);
                    }
                    else if (!string.Equals(value, m_NomImage))
                    {
                        ModifierChamp(Champs.NomImage, ref m_NomImage, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au temps de livraison estimé du véhicule
        /// </summary>
        public int TempsLivraison
        {
            get
            {
                return m_TempsLivraison;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.TempsLivraison, "Le temps de livraison estimé doit être supérieur à 0");
                    ChampDevientInvalide(Champs.TempsLivraison);
                }
                else if (value > 60)
                {
                    Declencher_SurErreur(this, Champs.TempsLivraison, "Le temps de livraison estimé ne peut pas être supérieur à 60");
                    ChampDevientInvalide(Champs.TempsLivraison);
                }
                else
                {
                    if (!int.Equals(value, m_TempsLivraison))
                    {
                        ModifierChamp(Champs.TempsLivraison, ref m_TempsLivraison, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au type de véhicule correspondant à ce modèle
        /// </summary>
        public TypeVehicule TypeVehicule
        {
            get
            {
                return m_TypeVehicule;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.TypeVehicule, "Veuillez choisir un type de véhicule correspondant");
                }
                if (!object.Equals(value, m_TypeVehicule))
                {
                    ModifierChamp(Champs.TypeVehicule, ref m_TypeVehicule, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant de savoir si le véhicule est toujours disponible dans la liste des véhicules vendus par la concession
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
        public Vehicule()
            : base()
        {
            m_Modele = null;
            m_PrixVehicule = -1.0;
            m_NomImage = null;
            m_TempsLivraison = -1;
            m_VehiculeOptionVehicule = null;
            m_PopvVehicule = null;
            m_TypeVehicule = null;
            m_VehiculeCaracteristique = null;
            m_Disponible = -1;
        }



        public Vehicule(string Modele, double PrixVehicule, string NomImage, int TempsLivraison, TypeVehicule TypeVehicule,int Disponible)
            : this()
        {
            DefinirId(Id);
            this.Modele = Modele;
            this.PrixVehicule = PrixVehicule;
            this.NomImage = NomImage;
            this.TempsLivraison = TempsLivraison;
            this.TypeVehicule = TypeVehicule;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Vehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            base.Connexion = Connexion;
            if (Enregistrement != null)
            {
                DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_vehicule"));
                this.Modele = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "modele");
                this.PrixVehicule = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix_vehicule");
                this.NomImage = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_image");
                this.TempsLivraison = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "temps_livraison");
                this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
                this.TypeVehicule = new TypeVehicule(Connexion,Enregistrement);
            }
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Vehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Vehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("modele = {0}, prix_vehicule = {1}, nom_image = {2}, temps_livraison = {3}, fk_id_type = {4}, disponible = {5}",
                    m_Modele,m_PrixVehicule,m_NomImage,m_TempsLivraison, m_TypeVehicule.Id,m_Disponible);
            }
        }

        public override void SupprimerEnCascade(MyDB Connexion)
        {
            Connexion.Executer("DELETE FROM vehicule_option_vehicule WHERE fk_id_vehicule = {0}", Id);
            Connexion.Executer("DELETE FROM popv_vehicule WHERE fk_id_vehicule = {0}", Id);
            Connexion.Executer("DELETE FROM vehicule_caracteristique WHERE fk_id_vehicule = {0}", Id);
            Connexion.Executer("DELETE FROM vehicule WHERE id_vehicule = {0}", Id);
        }

        private IEnumerable<VehiculeOptionVehicule> EnumererVehiculeOptionVehicule()
        {
            return VehiculeOptionVehicule.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * from vehicule_option_vehicule
                                                                                    JOIN option_vehicule ON vehicule_option_vehicule.fk_id_option_vehicule = option_vehicule.id_option_vehicule
                                                                                    WHERE vehicule_option_vehicule.fk_id_vehicule =  {0}", Id));
        }

        private IEnumerable<PopvVehicule> EnumererPackOptionPackVehicule()
        {
            return PopvVehicule.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * from popv_vehicule
                                                                                    JOIN pack_option_pack_vehicule ON popv_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule
                                                                                    WHERE popv_vehicule.fk_id_vehicule =  {0}", Id));
        }

        private IEnumerable<VehiculeCaracteristique> EnumererVehiculeCaracteristique()
        {
            return VehiculeCaracteristique.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * from vehicule_caracteristique
                                                                                    JOIN caracteristique ON vehicule_caracteristique.fk_id_caracteristique = caracteristique.id_caracteristique
                                                                                    JOIN type ON caracteristique.fk_id_type = type.id_type    
                                                                                    WHERE vehicule_caracteristique.fk_id_vehicule = {0}", Id));
        }
        
    }
}
