using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public class Client : Entite<Client,Client.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id du client
            /// </summary>
            Id,
            /// <summary>
            /// Nom du client
            /// </summary>
            Nom,
            /// <summary>
            /// Prénom du client
            /// </summary>
            Prenom,
            /// <summary>
            /// Date de naissance du client
            /// </summary>
            DateNaissance,
            /// <summary>
            /// Email du client
            /// </summary>
            Email,
            /// <summary>
            /// Numéro de téléphone du client
            /// </summary>
            NumeroTelephone,
            /// <summary>
            /// Rue du client
            /// </summary>
            Rue,
            /// <summary>
            /// Numéro d'habitation du client
            /// </summary>
            NumeroHabitation,
            /// <summary>
            /// Civilité du client
            /// </summary>
            Civilite,
            /// <summary>
            /// Adresse du client
            /// </summary>
            Adresse
        }

        #region Membres privés
        private string m_Nom;
        private string m_Prenom;
        private DateTime m_DateNaissance;
        private string m_Email;
        private string m_NumeroTelephone;
        private string m_Rue;
        private string m_NumeroHabitation;
        private Civilite m_Civilite;
        private Adresse m_Adresse;
        #endregion

        /// <summary>
        /// Propriété publique permettant l'accès au nom du client
        /// </summary>
        public string Nom
        {
            get
            {
                return m_Nom;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Nom, "Le nom est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Nom);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) ||(value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.Nom, "Le nom doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.Nom);
                    }
                    else if (!string.Equals(value, m_Nom))
                    {
                        ModifierChamp(Champs.Nom, ref m_Nom, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au prénom du client
        /// </summary>
        public string Prenom
        {
            get
            {
                return m_Prenom;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Prenom, "Le prénom est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Prenom);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.Prenom, "Le prénom doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.Prenom);
                    }
                    else if (!string.Equals(value, m_Prenom))
                    {
                        ModifierChamp(Champs.Prenom, ref m_Prenom, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la date de naissance du client
        /// </summary>
        public DateTime DateNaissance
        {
            get
            {
                return m_DateNaissance;
            }
            set
            {
                int Majeur = DateTime.Now.Year - 18;
                if (value.Year > Majeur)
                {
                    Declencher_SurErreur(this,Champs.DateNaissance,"Le client ne semble pas majeur, la date est probablement incorrecte");
                }
                if (!DateTime.Equals(value, m_DateNaissance))
                {
                    ModifierChamp(Champs.DateNaissance, ref m_DateNaissance, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'email du client
        /// </summary>
        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Email, "L'email est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Email);
                }
                else
                {
                    value = value.Trim();
                    int NombreArobase = Outils.NombreDeCaractereCorrespondant(value, '@');
                    if ((value.Length > 250) || (value.Length <= 5))
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email doit être compris entre 5 et 250 caractères");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if (NombreArobase > 1)
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email ne semble pas valide, il contient " + NombreArobase + "arobases");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if (NombreArobase == 0)
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email ne semble pas valide, il ne contient pas d'arobase");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if (!string.Equals(value, m_Email))
                    {
                        ModifierChamp(Champs.Email, ref m_Email, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au numéro de téléphone du client
        /// </summary>
        public string NumeroTelephone
        {
            get
            {
                return m_NumeroTelephone;
            }
            set
            {
                long NumTel = 0;
                if (long.TryParse(value, out NumTel))
                {
                    if ((value.Length < 8) || (value.Length > 10))
                    {
                        Declencher_SurErreur(this, Champs.NumeroTelephone, "Le numéro de téléphone doit être compris de 8 à 10 chiffres");
                        ChampDevientInvalide(Champs.NumeroTelephone);
                    }
                    else
                    {
                        if (!long.Equals(value, NumeroTelephone))
                        {
                            ModifierChamp(Champs.NumeroTelephone, ref m_NumeroTelephone, value);
                        }
                    }
                }
                else
                {
                    Declencher_SurErreur(this, Champs.NumeroTelephone, "Le numéro de téléphone doit être de type numérique");
                    ChampDevientInvalide(Champs.NumeroTelephone);
                }
            }
        }


        /// <summary>
        /// Propriété publique permettant l'accès au nom de la rue de la personne
        /// </summary>
        public string Rue
        {
            get
            {
                return m_Rue;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Rue, "Le nom de la rue est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Rue);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.Rue, "Le nom de la rue doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.Rue);
                    }
                    else if (!string.Equals(value, m_Rue))
                    {
                        ModifierChamp(Champs.Rue, ref m_Rue, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au numéro d'habitation de la personne
        /// </summary>
        public string NumeroHabitation
        {
            get
            {
                return m_NumeroHabitation;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NumeroHabitation, "Le numéro d'habitation est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NumeroHabitation);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 20) || (value.Length < 1))
                    {
                        Declencher_SurErreur(this, Champs.NumeroHabitation, "Le numéro d'habitation doit être compris entre 1 et 20 caractères");
                        ChampDevientInvalide(Champs.NumeroHabitation);
                    }
                    else if (!string.Equals(value, m_NumeroHabitation))
                    {
                        ModifierChamp(Champs.NumeroHabitation, ref m_NumeroHabitation, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la civilité du client
        /// </summary>
        public Civilite Civilite
        {
            get
            {
                return m_Civilite;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Civilite, "Veuillez choisir une civilité correspondante");
                }
                else if (!object.Equals(value, m_Civilite))
                {
                    ModifierChamp(Champs.Civilite, ref m_Civilite, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'adresse du client
        /// </summary>
        public Adresse Adresse
        {
            get
            {
                return m_Adresse;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Adresse, "Veuillez choisir un enregistrement");
                }
                else if (!object.Equals(value, m_Adresse))
                {
                    ModifierChamp(Champs.Adresse, ref m_Adresse, value);
                }
            }
        }        

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Client()
            :base()
        {
            m_Nom = null;
            m_Prenom = null;
            m_DateNaissance = DateTime.Now;
            m_Email = null;
            m_NumeroTelephone = null;
            m_Civilite = null;
            m_Adresse = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Nom">Nom du client</param>
        /// <param name="Prenom">Prénom du client</param>
        /// <param name="DateNaissance">Date de naissance du client</param>
        /// <param name="Email">Email du client</param>
        /// <param name="NumeroTelephone">Numéro de téléphone du client</param>
        /// <param name="Rue">Rue du client</param>
        /// <param name="NumeroHabitation">Numéro d'habitation du client</param>
        /// <param name="Civilite">Civilité du client</param>
        /// <param name="Adresse">Adresse du client</param>
        public Client(string Nom, string Prenom, DateTime DateNaissance, string Email, string NumeroTelephone,string NumeroHabitation,string Rue, Civilite Civilite, Adresse Adresse)
            :this()
        {
            DefinirId(Id);
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.DateNaissance = DateNaissance;
            this.Email = Email;
            this.NumeroTelephone = NumeroTelephone;
            this.NumeroHabitation = NumeroHabitation;
            this.Rue = Rue;
            this.Civilite = Civilite;
            this.Adresse = Adresse;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Client(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            :this()
        {
            base.Connexion = Connexion;
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_client"));
            this.Nom = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_client");
            this.Prenom = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "prenom_client");
            this.DateNaissance = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_naissance_client");
            this.Email = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "email_client");
            this.NumeroTelephone = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_telephone_client");
            this.Rue = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_de_rue_client");
            this.NumeroHabitation = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_habitation_client");
            this.Civilite = new Civilite(Connexion, Enregistrement);
            this.Adresse = new Adresse(Connexion, Enregistrement);
            
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Client> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Client(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "client";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_client = {0}, prenom_client = {1}, date_naissance_client = {2}, email_client = {3}, numero_telephone_client = {4},nom_de_rue_client = {5}, numero_habitation_client = {6}, fk_id_civilite = {7}, fk_id_adresse = {8}",
                    m_Nom, m_Prenom, m_DateNaissance, m_Email, m_NumeroTelephone,m_Rue,m_NumeroHabitation, m_Civilite.Id, m_Adresse.Id);
            }
        }        

        public IEnumerable<ClientVehicule> EnumererVehiculeActifDuClient()
        {
            return ClientVehicule.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM client_vehicule
                                                                        JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                        JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule 
                                                                        WHERE client.id_client = {0} AND vehicule_actif = 1", Id));
        }

    }
}
