using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class ClientVehicule : Entite<ClientVehicule,ClientVehicule.Champs>
    {


        public enum Champs
        {
            /// <summary>
            /// Id du véhicule
            /// </summary>
            Id,
            /// <summary>
            /// Immatriculation du véhicule
            /// </summary>
            Immatriculation,
            /// <summary>
            /// Numéro de châssis du véhicule
            /// </summary>
            NumeroChassis,
            /// <summary>
            /// Permet de savoir si le véhicule appartient toujours à ce client
            /// </summary>
            VehiculeActif,
            /// <summary>
            /// Client lié ce véhicule
            /// </summary>
            Client,
            /// <summary>
            /// Modèle du véhicule
            /// </summary>
            Vehicule,
        }

        #region Membres privés
        private string m_Immatriculation;
        private string m_NumeroChassis;
        private int m_VehiculeActif;
        private Client m_Client;
        private Vehicule m_Vehicule;
        #endregion

        /// <summary>
        /// Propriété publique permettant l'accès à l'immatriculation du véhicule
        /// </summary>
        public string Immatriculation
        {
            get
            {
                return m_Immatriculation;
            }
            set
            {
                if (value != null)
                {
                    value = value.Trim();
                    if (value.Length > 250)
                    {
                        Declencher_SurErreur(this, Champs.Immatriculation, "L'immatriculation ne peut pas dépasser 250 caractères");
                        ChampDevientInvalide(Champs.Immatriculation);
                    }
                    else
                    {
                        ModifierChamp(Champs.Immatriculation, ref m_Immatriculation, value);
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
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NumeroChassis, "Le numéro de châssis est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NumeroChassis);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 250) && (value.Length < 1))
                    {
                        Declencher_SurErreur(this, Champs.NumeroChassis, "Le numéro de châssis doit être compris entre 1 et 250 caractères");
                        ChampDevientInvalide(Champs.NumeroChassis);
                    }
                    else if (!string.Equals(value, m_NumeroChassis))
                    {
                        ModifierChamp(Champs.NumeroChassis, ref m_NumeroChassis, value);
                    }
                }
            }
        }


        /// <summary>
        /// Propriété publique permettant de savoir si le véhicule appartient toujours à ce client, 1 pour actif, 0 pour inactif
        /// </summary>
        public int VehiculeActif
        {
            get
            {
                return m_VehiculeActif;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.VehiculeActif, "L'indicateur de véhicule actif ne peut pas être négatif");
                    ChampDevientInvalide(Champs.VehiculeActif);
                }
                else if (value > 2)
                {
                    Declencher_SurErreur(this, Champs.VehiculeActif, "L'indicateur de véhicule actif ne peut pas dépasser 1");
                    ChampDevientInvalide(Champs.VehiculeActif);
                }
                else
                {
                    if (!int.Equals(value, m_VehiculeActif))
                    {
                        ModifierChamp(Champs.VehiculeActif, ref m_VehiculeActif, value);
                    }
                }
            }
        }


        /// <summary>
        /// Propriété publique permettant l'accès au client à qui appartient le véhicule
        /// </summary>
        public Client Client
        {
            get
            {
                return m_Client;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Client, "Veuillez choisir un client correspondant");
                }
                else if (!object.Equals(value, m_Client))
                {
                    ModifierChamp(Champs.Client, ref m_Client, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au véhicule du client
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
                else if (!object.Equals(value, m_Vehicule))
                {
                    ModifierChamp(Champs.Vehicule, ref m_Vehicule, value);
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ClientVehicule()
            : base()
        {
            m_Immatriculation = "";
            m_NumeroChassis = null;
            m_VehiculeActif = -1;
            m_Client = null;
            m_Vehicule = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Immatriculation">Immatriculation du véhicule</param>
        /// <param name="NumeroChassis">Numéro de châssis du véhicule</param>
        /// <param name="VehiculeActif">Permet de savoir si ce véhicule appartient toujours à ce client</param>
        /// <param name="Client">Client à qui appartient le véhicule</param>
        /// <param name="Vehicule">Modèle du véhicule</param>
        public ClientVehicule(string Immatriculation, string NumeroChassis, int VehiculeActif, Client Client, Vehicule Vehicule)
            : this()
        {
            DefinirId(Id);
            this.Immatriculation = Immatriculation;
            this.NumeroChassis = NumeroChassis;
            this.VehiculeActif = VehiculeActif;
            this.Client = Client;
            this.Vehicule = Vehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public ClientVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_client_vehicule"));
            this.Immatriculation = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "immatriculation");
            this.NumeroChassis = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_chassis");
            this.VehiculeActif = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "vehicule_actif");
            this.Client = new Client(Connexion, Enregistrement);
            this.Vehicule = new Vehicule(Connexion, Enregistrement);
        }


        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<ClientVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new ClientVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "client_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("immatriculation = {0}, numero_chassis = {1}, vehicule_actif = {2}, fk_id_client = {3}, fk_id_vehicule = {4}",m_Immatriculation,m_NumeroChassis,m_VehiculeActif,m_Client.Id,m_Vehicule.Id);
            }
        }

    }
}
