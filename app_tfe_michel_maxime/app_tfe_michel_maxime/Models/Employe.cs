using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Employe : Entite<Employe,Employe.Champs>
    {
        public enum Champs
        {
            /// <summary>
            /// Id de l'employé
            /// </summary>
            Id,
            /// <summary>
            /// Mot de passe de connexion
            /// </summary>
            MotDePasse,
            /// <summary>
            /// Nom de l'employé
            /// </summary>
            Nom,
            /// <summary>
            /// Prénom de l'employé
            /// </summary>
            Prenom,
            /// <summary>
            /// Date de naissance de l'employé
            /// </summary>
            DateNaissance,
            /// <summary>
            /// Email de l'employé
            /// </summary>
            Email,
            /// <summary>
            /// Numéro de téléphone de l'employé
            /// </summary>
            NumeroTelephone,
            /// <summary>
            /// Indique si le compte est actif
            /// </summary>
            CompteActif,
            /// <summary>
            /// Nom de la rue de l'employé
            /// </summary>
            NomDeRue,
            /// <summary>
            /// Numéro d'habitation de l'employé
            /// </summary>
            NumeroHabitation,
            /// <summary>
            /// Civilité de l'employé
            /// </summary>
            Civilite,
            /// <summary>
            /// Adresse de l'employé
            /// </summary>
            Adresse,
            /// <summary>
            /// Statut de l'employé (son poste)
            /// </summary>
            Statut,
            
        }

        #region Membres privés
        private string m_MotDePasse;
        private string m_Nom;
        private string m_Prenom;
        private DateTime m_DateNaissance;
        private string m_Email;
        private string m_NumeroTelephone;
        private int m_CompteActif;
        private string m_NomDeRue;
        private string m_NumeroHabitation;
        private Civilite m_Civilite;
        private Adresse m_Adresse;
        private StatutEmploye m_Statut;
        #endregion

        private bool _ModificationSansMotDePasse;

        /// <summary>
        /// Permet de savoir si le mot de passe a été changé lors d'une modification, ou l'inverse
        /// </summary>
        public bool ModificationSansMotDePasse
        {
            get
            {
                return _ModificationSansMotDePasse;
            }
            set
            {
                _ModificationSansMotDePasse = value;
            }
        }
        

        /// <summary>
        /// Propriété publique permettant l'accès au mot de passe de l'employé
        /// </summary>
        public string MotDePasse
        {
            get
            {
                return m_MotDePasse;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.MotDePasse, "Le mot de passe est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.MotDePasse);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 250) || (value.Length < 5))
                    {
                        Declencher_SurErreur(this, Champs.MotDePasse, "Le mot de passe doit être compris entre 5 et 250 caractères");
                        ChampDevientInvalide(Champs.MotDePasse);
                    }
                    else if (!string.Equals(value, m_MotDePasse))
                    {
                        ModifierChamp(Champs.MotDePasse, ref m_MotDePasse, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au nom de l'employé
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
                    if ((value.Length > 100) || (value.Length <= 1))
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
        /// Propriété publique permettant l'accès au prénom de l'employé
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
        /// Propriété publique permettant l'accès à la date de naissance de l'employé
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
                    Declencher_SurErreur(this,Champs.DateNaissance,"Le client ne semble pas majeur, la date n'est peut être pas correcte");
                }
                else
                {
                    if (!DateTime.Equals(value, m_DateNaissance))
                    {
                        ModifierChamp(Champs.DateNaissance, ref m_DateNaissance, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'email de l'employé
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
                    if ((value.Length > 100) || (value.Length <= 5))
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email doit être compris entre 5 et 100 caractères");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if(NombreArobase > 1)
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email ne semble pas valide, il ne peut pas contenir "+NombreArobase+" arobases");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if(NombreArobase == 0)
                    {
                        Declencher_SurErreur(this, Champs.Email, "L'email ne semble pas valide, il ne contient pas d'arobase");
                        ChampDevientInvalide(Champs.Email);
                    }
                    else if(NombreArobase == 1)
                    {
                        string emailValide = value.Substring(value.IndexOf("@"));
                        if(emailValide == "@BMWEcaussinnes.com")
                        {                            
                            if (!string.Equals(value, m_Email))
                            {
                                ModifierChamp(Champs.Email, ref m_Email, value);
                            }
                        }
                        else
                        {
                            Declencher_SurErreur(this, Champs.Email, "L'adresse email doit finir avec \"@BMWEcaussinnes.com\"");
                            ChampDevientInvalide(Champs.Email);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au numéro de téléphone de l'employé
        /// </summary>
        public string NumeroTelephone
        {
            get
            {
                return m_NumeroTelephone;
            }
            set
            {
                long Numtel = 0;
                if (long.TryParse(value, out Numtel))
                {
                    if (value.Length < 8)
                    {
                        Declencher_SurErreur(this, Champs.NumeroTelephone, "Le numéro de téléphone doit comporter au minimum 8 chiffres");
                        ChampDevientInvalide(Champs.NumeroTelephone);
                    }
                    else if (value.Length > 10)
                    {
                        Declencher_SurErreur(this, Champs.NumeroTelephone, "Le numéro de téléphone doit comporter au maximum 10 chiffres");
                        ChampDevientInvalide(Champs.NumeroTelephone);
                    }
                    else
                    {
                        if (!string.Equals(value, NumeroTelephone))
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
        /// Propriété publique permettant l'accès à l'information du compte de l'employé afin de savoir s'il est actif
        /// </summary>
        public int CompteActif
        {
            get
            {
                return m_CompteActif;
            }
            set
            {
                if (!int.Equals(value, m_CompteActif))
                {
                    ModifierChamp(Champs.CompteActif, ref m_CompteActif, value);
                }                
            }
        }


        /// <summary>
        /// Propriété publique permettant l'accès à la rue de la personne
        /// </summary>
        public string Rue
        {
            get
            {
                return m_NomDeRue;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomDeRue, "Le nom de la rue est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomDeRue);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.NomDeRue, "Le nom de la rue doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.NomDeRue);
                    }
                    else if (!string.Equals(value, m_NomDeRue))
                    {
                        ModifierChamp(Champs.NomDeRue, ref m_NomDeRue, value);
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
                    if ((value.Length > 50) || (value.Length <= 1))
                    {
                        Declencher_SurErreur(this, Champs.NumeroHabitation, "Le numéro d'habitation doit être compris entre 1 et 50 caractères");
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
        /// Propriété publique permettant l'accès à la civilité de l'employé
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
                else
                {
                    if (!object.Equals(value, m_Civilite))
                    {
                        ModifierChamp(Champs.Civilite, ref m_Civilite, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'adresse de l'employé
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
                    Declencher_SurErreur(this, Champs.Adresse, "Veuillez sélectionner un enregistrement");
                }
                else
                {
                    if (!object.Equals(value, m_Adresse))
                    {
                        ModifierChamp(Champs.Adresse, ref m_Adresse, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au statut de l'employé
        /// </summary>
        public StatutEmploye Statut
        {
            get
            {
                return m_Statut;
            }
            set
            {
                if (value == null)
                {
                    Declencher_SurErreur(this, Champs.Statut, "Veuillez choisir un statut");
                }
                else
                {
                    if (!object.Equals(value, m_Statut))
                    {
                        ModifierChamp(Champs.Statut, ref m_Statut, value);
                    }
                }
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Employe()
            :base()
        {
            m_MotDePasse = null;
            m_Nom = null;
            m_Prenom = null;
            m_DateNaissance = DateTime.Now;
            m_Email = null;
            m_NumeroTelephone = null;
            m_CompteActif = byte.MaxValue;
            m_Civilite = null;
            m_Adresse = null;
            m_Statut = null;
            m_NumeroHabitation = null;
            m_NomDeRue = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="MotDePasse">Mot de passe de l'employé</param>
        /// <param name="Nom">Nom de l'employé</param>
        /// <param name="Prenom">Prénom de l'employé</param>
        /// <param name="Email">Email de l'employé</param>
        /// <param name="NumeroTelephone">Numéro de téléphone de l'employé</param>
        /// <param name="DebutContrat">Début du contrat de l'employé</param>
        /// <param name="FinContrat">Fin du contrat de l'employé</param>
        /// <param name="CompteActif">Indique si le compte est actif</param>
        /// <param name="NomDeRue">Rue de l'employé</param>
        /// <param name="NumeroHabitation">Numéro d'habitation de l'employé</param>
        /// <param name="Civilite">Civilité de l'employé</param>
        /// <param name="Adresse">Adresse de l'employé</param>
        /// <param name="Statut">Statut de l'employé</param>
        public Employe(string MotDePasse, string Nom, string Prenom,DateTime DateNaissance, string Email, string NumeroTelephone,string NomDeRue,string NumeroHabitation, DateTime DebutContrat, DateTime FinContrat, int CompteActif, Civilite Civilite, Adresse Adresse, StatutEmploye Statut)
            :this()
        {
            DefinirId(Id);
            this.MotDePasse = MotDePasse;
            this.Nom = Nom;
            this.Prenom = Prenom;
            this.DateNaissance = DateNaissance;
            this.Email = Email;
            this.NumeroTelephone = NumeroTelephone;
            this.CompteActif = CompteActif;
            this.Civilite = Civilite;
            this.Adresse = Adresse;
            this.Statut = Statut;
            this.Rue = NomDeRue;
            this.NumeroHabitation = NumeroHabitation;
    }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Employe(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            :this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_employe"));   
            this.MotDePasse = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "mot_de_passe");
            this.Nom = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom");
            this.Prenom = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "prenom");
            this.DateNaissance = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_naissance");
            this.Email = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "email");
            this.NumeroTelephone = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_telephone");
            this.CompteActif = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "compte_actif");
            this.Rue = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_de_rue");
            this.NumeroHabitation = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_habitation");
            this.Civilite = new Civilite(Connexion,Enregistrement);
            this.Adresse = new Adresse(Connexion,Enregistrement);
            this.Statut = new StatutEmploye(Connexion,Enregistrement);

        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Employe> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Employe(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "employe";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                if(ModificationSansMotDePasse == false)
                {

                    return new PDSGBD.MyDB.CodeSql("mot_de_passe = {0}, nom = {1}, prenom = {2}, date_naissance = {3}, email = {4}, numero_telephone = {5}, compte_actif = {6},nom_de_rue = {7},numero_habitation = {8}, fk_id_civilite = {9}, fk_id_adresse = {10}, fk_id_statut_employe = {11}",
                        m_MotDePasse, m_Nom, m_Prenom, m_DateNaissance, m_Email, m_NumeroTelephone, m_CompteActif, m_NomDeRue, m_NumeroHabitation, m_Civilite.Id, m_Adresse.Id, m_Statut.Id);

                }
                else
                {
                    return new PDSGBD.MyDB.CodeSql("mot_de_passe = SHA2(CONCAT(SHA2({0}, 512), SHA2({0}, 512)), 512), nom = {1}, prenom = {2}, date_naissance = {3}, email = {4}, numero_telephone = {5}, compte_actif = {6},nom_de_rue = {7},numero_habitation = {8}, fk_id_civilite = {9}, fk_id_adresse = {10}, fk_id_statut_employe = {11}",
                       m_MotDePasse, m_Nom, m_Prenom, m_DateNaissance, m_Email, m_NumeroTelephone, m_CompteActif, m_NomDeRue, m_NumeroHabitation, m_Civilite.Id, m_Adresse.Id, m_Statut.Id);
                }
            }
        }


    }
}
