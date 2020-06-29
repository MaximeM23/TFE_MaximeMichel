using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class VehiculeVente : Entite<VehiculeVente, VehiculeVente.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id du véhicule vendu
            /// </summary>
            Id,
            /// <summary>
            /// L'année de construction du véhicule
            /// </summary>
            AnneeConstruction,
            /// <summary>
            /// Date d'arrivée en concession du véhicule
            /// </summary>
            DateArrivee,
            /// <summary>
            /// Date de commande du véhicule
            /// </summary>
            DateCommande,
            /// <summary>
            /// Date de la mise en circulation du véhicule
            /// </summary>
            DateMiseEnCirculation,
            /// <summary>
            /// Date de mise en circulation du véhicule
            /// </summary>
            Kilometrage,
            /// <summary>
            /// Prix total du véhicule
            /// </summary>
            PrixTotal,
            /// <summary>
            /// Numéro de châssis du véhicule
            /// </summary>
            NumeroChassis,
            /// <summary>
            /// Statut de livraison du véhicule
            /// </summary>
            StatutLivraison,
            /// <summary>
            /// Modèle du véhicule
            /// </summary>
            Vehicule,
        }

        private int m_AnneeConstruction;
        private DateTime m_DateArrivee;
        private DateTime m_DateMiseEnCirculation;
        private DateTime m_DateCommande;
        private int m_Kilometrage;
        private double m_PrixTotal;
        private string m_NumeroChassis;
        private Statut m_StatutLivraison;
        private Vehicule m_Vehicule;
        private List<ChoixOptionVehicule> m_ChoixOptionVehicule;
        private List<ChoixPackVehicule> m_ChoixPackVehicule;
        private FactureVente m_FactureVente;

        public IEnumerable<ChoixOptionVehicule> EnumChoixOptionVehicule
        {
            get
            {
                return EnumererChoixOptionVehicule();
            }
            set
            {
                ChargerChoixOptionVehicule();
            }
        }

        public IEnumerable<ChoixPackVehicule> EnumChoixPackVehicule
        {
            get
            {
                return EnumererChoixPackVehicule();
            }
            set
            {
                ChargerChoixPackVehicule();
            }
        }        

        public IEnumerable<FactureVente> EnumFactureVente
        {
            get
            {
                return EnumererFactureVente();
            }
            set
            {
                ChargerFactureVente();
            }
        }
        private bool ChargerChoixOptionVehicule()
        {
            if (Id <= 0) return false;
            m_ChoixOptionVehicule.Clear();
            m_ChoixOptionVehicule.AddRange(EnumererChoixOptionVehicule());
            return true;
        }

        private bool ChargerChoixPackVehicule()
        {
            if (Id <= 0) return false;
            m_ChoixPackVehicule.Clear();
            m_ChoixPackVehicule.AddRange(EnumererChoixPackVehicule());
            return true;
        }

        private bool ChargerFactureVente()
        {
            if (Id <= 0) return false;
            m_FactureVente = EnumererFactureVente().ElementAt(0);
            return true;
        }


        /// <summary>
        /// Propriété publique permettant l'accès à l'année de construction du véhicule
        /// </summary>
        public int AnneeConstruction
        {
            get
            {
                return m_AnneeConstruction;
            }
            set
            {
                if (!int.Equals(value, m_AnneeConstruction))
                {
                    ModifierChamp(Champs.AnneeConstruction, ref m_AnneeConstruction, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la date d'arrivée du véhicule en concession
        /// </summary>
        public DateTime DateArrivee
        {
            get
            {
                return m_DateArrivee;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateArrivee))
                {
                    ModifierChamp(Champs.DateArrivee, ref m_DateArrivee, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant la date de commande du véhicule
        /// </summary>
        public DateTime DateCommande
        {
            get
            {
                return m_DateCommande;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateCommande))
                {
                    ModifierChamp(Champs.DateCommande, ref m_DateCommande, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au prix total
        /// </summary>
        public double PrixTotal
        {
            get
            {
                return m_PrixTotal;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.PrixTotal, "Le prix total ne peut pas être négatif");
                    ChampDevientInvalide(Champs.PrixTotal);
                }
                else if (value > 5500000000)
                {
                    Declencher_SurErreur(this, Champs.PrixTotal, "Le prix ne peut dépasser 5 500 000 000 €");
                    ChampDevientInvalide(Champs.PrixTotal);
                }
                else
                {
                    if (!double.Equals(value, m_PrixTotal))
                    {
                        ModifierChamp(Champs.PrixTotal, ref m_PrixTotal, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la date de mise en circulation du véhicule
        /// </summary>
        public DateTime DateMiseEnCirculation
        {
            get
            {
                return m_DateMiseEnCirculation;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateMiseEnCirculation))
                {
                    ModifierChamp(Champs.DateMiseEnCirculation, ref m_DateMiseEnCirculation, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au kilomètrage du véhicule
        /// </summary>
        public int Kilometrage
        {
            get
            {
                return m_Kilometrage;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.Kilometrage, "Le kilomètrage ne peut pas être négatif");
                    ChampDevientInvalide(Champs.Kilometrage);
                }
                else if (value > 500000)
                {
                    Declencher_SurErreur(this, Champs.Kilometrage, "Le kilomètrage ne peut pas dépasser 500 000 km");
                    ChampDevientInvalide(Champs.Kilometrage);
                }
                else
                {
                    if (!double.Equals(value, m_Kilometrage))
                    {
                        ModifierChamp(Champs.Kilometrage, ref m_Kilometrage, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au numéro de châssis du véhicule
        /// </summary>
        public string NumeroChassis
        {
            get
            {
                return m_NumeroChassis;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value.Length > 250)
                    {
                        Declencher_SurErreur(this, Champs.NumeroChassis, "Le numéro de châssis doit être inférieur à 250 caractères");
                        ChampDevientInvalide(Champs.NumeroChassis);
                    }           
                    // Aucune vérification afin de permettre de repasser sur la vérification de la méthode avant changement d'une modification         
                    ModifierChamp(Champs.NumeroChassis, ref m_NumeroChassis, value);                    
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'état de livraison de ce véhicule
        /// </summary>
        public Statut StatutLivraison
        {
            get
            {
                return m_StatutLivraison;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.StatutLivraison, "Veuillez choisir un statut de livraison correspondant");
                }
                if (!object.Equals(value, m_StatutLivraison))
                {
                    ModifierChamp(Champs.StatutLivraison, ref m_StatutLivraison, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au modèle du véhicule
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
        /// Constructeur par défaut
        /// </summary>
        public VehiculeVente()
            : base()
        {
            m_AnneeConstruction = -1;
            m_DateArrivee = DateTime.MaxValue;
            m_DateMiseEnCirculation = DateTime.MaxValue;
            m_DateCommande = DateTime.MaxValue;
            m_Kilometrage = -1;
            m_PrixTotal = -1.0;
            m_NumeroChassis = null;
            m_StatutLivraison = null;
            m_Vehicule = null;
            m_ChoixOptionVehicule = null;
            m_ChoixPackVehicule = null;
            m_FactureVente = null;            
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="AnneeConstruction">L'année de construction du véhicule</param>
        /// <param name="DateArrivee">La date d'arrivée du véhicule en concession</param>
        /// <param name="DateCommande">La date de commande du véhicule</param>
        /// <param name="DateMiseEnCirculation">La date de mise en circulation du véhicule</param>
        /// <param name="Kilometrage">Le kilomètrage du véhicule</param>
        /// <param name="NumeroChassis">Le numéro de châssis du véhicule</param>
        /// <param name="PrixTotal">Prix total du véhicule</param>
        /// <param name="StatutLivraison">Le statut de livraison du véhicule</param>
        /// <param name="Vehicule">Le modèle du véhicule</param>
        public VehiculeVente(int AnneeConstruction, DateTime DateArrivee, DateTime DateCommande, DateTime DateMiseEnCirculation, int Kilometrage, string NumeroChassis,double PrixTotal, Statut StatutLivraison, Vehicule Vehicule)
            : this()
        {
            DefinirId(Id);
            this.AnneeConstruction = AnneeConstruction;
            this.DateArrivee = DateArrivee;
            this.DateCommande = DateCommande;
            this.DateMiseEnCirculation = DateMiseEnCirculation;
            this.Kilometrage = Kilometrage;
            this.NumeroChassis = NumeroChassis;
            this.PrixTotal = PrixTotal;
            this.StatutLivraison = StatutLivraison;
            this.Vehicule = Vehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public VehiculeVente(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_vehicule_vente"));
            this.AnneeConstruction = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "annee_construction");
            this.DateArrivee = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_arrivee");
            this.DateCommande = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_commande");
            this.DateMiseEnCirculation = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_mise_en_circulation");
            this.Kilometrage = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "kilometrage");
            this.NumeroChassis = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_chassis");
            this.PrixTotal = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix_total");
            this.StatutLivraison = new Statut(Connexion, Enregistrement);
            this.Vehicule = new Vehicule(Connexion, Enregistrement);
            
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<VehiculeVente> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new VehiculeVente(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "vehicule_vente";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("annee_construction = {0}, date_arrivee = {1}, date_commande = {2}, date_mise_en_circulation = {3}, kilometrage = {4}, numero_chassis = {5}, prix_total = {6}, fk_id_statut = {7}, fk_id_vehicule = {8}",
                    m_AnneeConstruction,m_DateArrivee,m_DateCommande,m_DateMiseEnCirculation,m_Kilometrage,m_NumeroChassis,m_PrixTotal,m_StatutLivraison.Id,m_Vehicule.Id);
            }
        }

        private IEnumerable<ChoixOptionVehicule> EnumererChoixOptionVehicule()
        {
            if(Connexion == null) Connexion = Program.GMBD.BD;
            return ChoixOptionVehicule.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM choix_option_vehicule
                                                                        JOIN option_vehicule ON option_vehicule.id_option_vehicule =  choix_option_vehicule.fk_id_option_vehicule
                                                                        JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option
                                                                        WHERE choix_option_vehicule.fk_id_vehicule_vente = {0}", Id));         
        }

        private IEnumerable<ChoixPackVehicule> EnumererChoixPackVehicule()
        {
            if (Connexion == null) Connexion = Program.GMBD.BD;
            return ChoixPackVehicule.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM choix_pack_vehicule
                                                                                JOIN pack_option_pack_vehicule ON choix_pack_vehicule.fk_id_popv = pack_option_pack_vehicule.id_pack_option_pack_vehicule
                                                                                WHERE choix_pack_vehicule.fk_id_vehicule_vente = {0}", Id));
        }

        private IEnumerable<FactureVente> EnumererFactureVente()
        {
            if (Connexion == null) Connexion = Program.GMBD.BD;
            return FactureVente.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM facture_vente
                                                                        JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente
                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                        JOIN employe ON facture_vente.fk_id_employe = employe.id_employe
                                                                        WHERE facture_vente.fk_id_vehicule_vente = {0}", Id));
        }

        /// <summary>
        /// Permet de supprimer les enregistrements liés à ce véhicule
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        public override void SupprimerEnCascade(PDSGBD.MyDB Connexion)
        {
            Connexion.Executer("DELETE FROM choix_option_vehicule WHERE fk_id_vehicule_vente = {0}", Id);
            Connexion.Executer("DELETE FROM choix_pack_vehicule WHERE fk_id_vehicule_vente = {0}", Id);
            Connexion.Executer("DELETE FROM vehicule_vente WHERE id_vehicule_vente = {0}", Id);
        }
    }
}

