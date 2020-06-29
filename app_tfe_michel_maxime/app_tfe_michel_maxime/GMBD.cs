using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    class GMBD
    {

        private static readonly MyDB.CodeSql c_NomTable_Employe = new MyDB.CodeSql(new Employe().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Rdv = new MyDB.CodeSql(new RendezVousEntretienReparation().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Facture = new MyDB.CodeSql(new Facture().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_FactureEntretien = new MyDB.CodeSql(new FactureEntretien().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Reparation = new MyDB.CodeSql(new Reparation().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Entretien = new MyDB.CodeSql(new Entretien().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Client = new MyDB.CodeSql(new Client().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Adresse = new MyDB.CodeSql(new Adresse().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Civilite = new MyDB.CodeSql(new Civilite().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_ClientVehicule = new MyDB.CodeSql(new ClientVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Vehicule = new MyDB.CodeSql(new Vehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Statut = new MyDB.CodeSql(new Statut().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Article = new MyDB.CodeSql(new Article().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_ArticleFacture = new MyDB.CodeSql(new Article().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_TypeOption = new MyDB.CodeSql(new TypeOption().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_OptionVehicule = new MyDB.CodeSql(new OptionVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_FactureVente = new MyDB.CodeSql(new FactureVente().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_VehiculeCaracteristique = new MyDB.CodeSql(new VehiculeCaracteristique().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_Caracteristique = new MyDB.CodeSql(new Caracteristique().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_PackOptionVehicule = new MyDB.CodeSql(new PackOptionPackVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_VehiculeVente = new MyDB.CodeSql(new VehiculeVente().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_PackOption = new MyDB.CodeSql(new PackOption().NomDeLaTablePrincipale); 
        private static readonly MyDB.CodeSql c_NomTable_TypeVehicule = new MyDB.CodeSql(new TypeVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_StatutEmploye = new MyDB.CodeSql(new StatutEmploye().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_ChoixPackVehicule = new MyDB.CodeSql(new ChoixPackVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_ChoixOptionVehicule = new MyDB.CodeSql(new ChoixOptionVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_PopvVehicule = new MyDB.CodeSql(new PopvVehicule().NomDeLaTablePrincipale);
        private static readonly MyDB.CodeSql c_NomTable_VehiculeOptionVehicule = new MyDB.CodeSql(new VehiculeOptionVehicule().NomDeLaTablePrincipale);


        /// <summary>
        /// Référence l'objet de connexion au serveur de base de données MySql
        /// </summary>
        private MyDB m_BD;

        /// <summary>
        /// Référence de l'objet de connexion au serveur MySQL
        /// </summary>
        public MyDB BD
        {
            get
            {
                return m_BD;
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public GMBD()
        {
            m_BD = new MyDB("u_admin_tfe_maxime_michel", "BsAz0YQgdZCL8QgK", "tfe_maxime_michel");
            m_BD.SurErreur += (ConnexionEmettrice, MethodeEmettrice, RequeteSql, Valeurs, MessageErreur) =>
            {
                System.Diagnostics.Debug.WriteLine(string.Format("\nERREUR SQL :\nMéthode : {0}\nRequête initiale : {1}\nValeurs des {2} parties variables : {3}\nRequête exécutée : {4}\nMessage d'erreur : {5}\n",
                    MethodeEmettrice,
                    RequeteSql,
                    (Valeurs != null) ? Valeurs.Length : 0,
                    ((Valeurs != null) && (Valeurs.Length >= 1)) ? "\n* " + string.Join("\n* ", Valeurs.Select((Valeur, Indice) => string.Format("Valeurs[{0}] : {1}", Indice, (Valeur != null) ? Valeur.ToString() : "NULL")).ToArray()) : string.Empty,
                    MyDB.FormaterEnSql(RequeteSql, Valeurs),
                    MessageErreur));
            };
        }

        /// <summary>
        /// Permet d'initialiser ce gestionnaire de modèles
        /// </summary>
        /// <returns></returns>
        public bool Initialiser()
        {
            return m_BD.SeConnecter();
        }


        #region Requêtes de connexion
        //+=======================+
        //| Requêtes de connexion |
        //+=======================+

        /// <summary>
        /// Permet la connexion d'un utilisateur à l'application
        /// </summary>
        /// <param name="Email">Email de l'employé</param>
        /// <param name="MotDePasse">Mot de passe de l'employé</param>
        /// <returns></returns>
        public Employe ConnexionApplication(string Email, string MotDePasse)
        {
            return EnumererEmploye(null,
                                       new MyDB.CodeSql("JOIN statut_employe ON employe.fk_id_statut_employe = statut_employe.id_statut_employe"),
                                       new MyDB.CodeSql("WHERE email = {0} AND mot_de_passe = SHA2(CONCAT(SHA2({1}, 512), SHA2({1}, 512)), 512)", Email, MotDePasse),
                                       null).FirstOrDefault();
        }
        #endregion


        #region Employe
        //+=========+
        //| Employe |
        //+=========+
        public bool AjouterEmploye(Employe Employe)
        {
            return Employe.Enregistrer(m_BD, Employe, false);
        }

        public bool SupprimerEmploye(Employe Employe)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Employe.Supprimer(m_BD, Employe, false);
            return true;
        }
        public bool ModifierEmploye(Employe Employe)
        {
            return Employe.Enregistrer(m_BD, Employe, true);
        }
        #endregion

        #region Client
        //+========+
        //| Client |
        //+========+
        public bool AjouterClient(Client NouveauClient)
        {
            return NouveauClient.Enregistrer(m_BD, NouveauClient, false);
        }

        public bool SupprimerClient(Client Client)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Client.Supprimer(m_BD,Client,false);
            return true;
        }
        public bool ModifierClient(Client Client)
        {
            return Client.Enregistrer(m_BD, Client, true);
        }
        #endregion

        #region ClientVehicule
        //+================+
        //| ClientVehicule |
        //+================+
        public bool AjouterClientVehicule(ClientVehicule NouveauClientVehicule)
        {
            return NouveauClientVehicule.Enregistrer(m_BD, NouveauClientVehicule, false);
        }

        public bool SupprimerClientVehicule(ClientVehicule ClientVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            ClientVehicule.Supprimer(m_BD, ClientVehicule, false);
            return true;
        }
        public bool ModifierClientVehicule(ClientVehicule ClientVehicule)
        {
            return ClientVehicule.Enregistrer(m_BD, ClientVehicule, true);
        }
        #endregion

        #region Article
        //+=========+
        //| Article |
        //+=========+

        public bool AjouterArticle(Article NouvelArticle)
        {
            return NouvelArticle.Enregistrer(m_BD, NouvelArticle, false);
        }
        public bool SupprimerArticle(Article NouvelArticle)
        {
            if (!m_BD.EstConnecte) Initialiser();
            NouvelArticle.Supprimer(m_BD, NouvelArticle, false);
            return true;
        }
        public bool ModifierArticle(Article Article)
        {
            return Article.Enregistrer(m_BD, Article, true);
        }
        #endregion


        #region Entretien
        //+===========+
        //| Entretien |
        //+===========+

        public bool AjouterEntretien(Entretien Entretien)
        {
            return Entretien.Enregistrer(m_BD, Entretien, false);
        }
        public bool SupprimerEntretien(Entretien Entretien)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Entretien.Supprimer(m_BD, Entretien, false);
            return true;
        }
        public bool ModifierEntretien(Entretien Entretien)
        {
            return Entretien.Enregistrer(m_BD, Entretien, true);
        }
        #endregion

        #region Vehicule
        //+==========+
        //| Vehicule |
        //+==========+

        public bool AjouterVehicule(Vehicule Vehicule)
        {
            return Vehicule.Enregistrer(m_BD, Vehicule, false);
        }
        public bool SupprimerVehicule(Vehicule Vehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Vehicule.Supprimer(m_BD, Vehicule, true);
            return true;
        }
        public bool ModifierVehicule(Vehicule Vehicule)
        {
            return Vehicule.Enregistrer(m_BD, Vehicule, true);
        }
        #endregion


        #region Vehiculevente
        //+===============+
        //| VehiculeVente |
        //+===============+

        public bool AjouterVehiculeVente(VehiculeVente VehiculeVente)
        {
            return VehiculeVente.Enregistrer(m_BD, VehiculeVente, false);
        }
        public bool SupprimerVehiculeVente(VehiculeVente VehiculeVente)
        {
            if (!m_BD.EstConnecte) Initialiser();
            VehiculeVente.Supprimer(m_BD, VehiculeVente, true);
            return true;
        }
        public bool ModifierVehiculeVente(VehiculeVente VehiculeVente)
        {
            return VehiculeVente.Enregistrer(m_BD, VehiculeVente, true);
        }

        public int DisponibiliteVehicule(int IdVehicule)
        {
            return VehiculeVente.Enumerer(m_BD, m_BD.Enumerer(new MyDB.CodeSql("SELECT id_vehicule_vente FROM vehicule_vente JOIN statut ON statut.id_statut = vehicule_vente.fk_id_statut WHERE vehicule_vente.id_vehicule_vente NOT IN ( SELECT facture_vente.fk_id_vehicule_vente from facture_vente) AND fk_id_vehicule = {0} AND statut = 'En stock'", IdVehicule).ToString())).Count();
        }
        #endregion

        #region Caracteristique
        //+=================+
        //| Caracteristique |
        //+=================+

        public bool AjouterCaracteristique(Caracteristique Caracteristique)
        {
            return Caracteristique.Enregistrer(m_BD, Caracteristique, false);
        }
        public bool SupprimerCaracteristique(Caracteristique Caracteristique)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Caracteristique.Supprimer(m_BD, Caracteristique, false);
            return true;
        }
        public bool ModifierCaracteristique(Caracteristique Caracteristique)
        {
            return Caracteristique.Enregistrer(m_BD, Caracteristique, true);
        }
        #endregion

        #region VehiculeOptionVehicule
        //+========================+
        //| VehiculeOptionVehicule |
        //+========================+

        public bool AjouterVehiculeOptionVehicule(VehiculeOptionVehicule VehiculeOptionVehicule)
        {
            return VehiculeOptionVehicule.Enregistrer(m_BD, VehiculeOptionVehicule, false);
        }
        public bool SupprimerVehiculeOptionVehicule(VehiculeOptionVehicule VehiculeOptionVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            VehiculeOptionVehicule.Supprimer(m_BD, VehiculeOptionVehicule, false);
            return true;
        }
        public bool ModifierVehiculeOptionVehicule(VehiculeOptionVehicule VehiculeOptionVehicule)
        {
            return VehiculeOptionVehicule.Enregistrer(m_BD, VehiculeOptionVehicule, true);
        }
        #endregion

        #region VehiculeCaracteristique
        //+==========================+
        //| Vehicule Caracteristique |
        //+==========================+

        public bool AjouterVehiculeCaracteristique(VehiculeCaracteristique VehiculeCaracteristique)
        {
            return VehiculeCaracteristique.Enregistrer(m_BD, VehiculeCaracteristique, false);
        }
        public bool SupprimerVehiculeCaracteristique(VehiculeCaracteristique VehiculeCaracteristique)
        {
            if (!m_BD.EstConnecte) Initialiser();
            VehiculeCaracteristique.Supprimer(m_BD, VehiculeCaracteristique, false);
            return true;
        }
        public bool ModifierVehiculeCaracteristique(VehiculeCaracteristique VehiculeCaracteristique)
        {
            return VehiculeCaracteristique.Enregistrer(m_BD, VehiculeCaracteristique, true);
        }
        #endregion

        #region PackOptionPackVehicule
        //+===========================+
        //| Pack Option Pack Vehicule |
        //+===========================+

        public bool AjouterPackOptionPackVehicule(PackOptionPackVehicule PackOptionPackVehicule)
        {
            return PackOptionPackVehicule.Enregistrer(m_BD, PackOptionPackVehicule, false);
        }
        public bool SupprimerPackOptionPackVehicule(PackOptionPackVehicule PackOptionPackVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            PackOptionPackVehicule.Supprimer(m_BD, PackOptionPackVehicule, false);
            return true;
        }
        public bool ModifierPackOptionPackVehicule(PackOptionPackVehicule PackOptionPackVehicule)
        {
            return PackOptionPackVehicule.Enregistrer(m_BD, PackOptionPackVehicule, true);
        }
        #endregion

        #region PackOption
        //+=============+
        //| Pack Option |
        //+=============+

        public bool AjouterPackOption(PackOption PackOption)
        {
            return PackOption.Enregistrer(m_BD, PackOption, false);
        }
        public bool SupprimerPackOption(PackOption PackOption)
        {
            if (!m_BD.EstConnecte) Initialiser();
            PackOption.Supprimer(m_BD, PackOption, false);
            return true;
        }
        public bool ModifierPackOption(PackOption PackOption)
        {
            return PackOption.Enregistrer(m_BD, PackOption, true);
        }
        #endregion

        #region PopvVehicule
        //+==============+
        //| PopvVehicule |
        //+==============+

        public bool AjouterPopvVehicule(PopvVehicule PopvVehicule)
        {
            return PopvVehicule.Enregistrer(m_BD, PopvVehicule, false);
        }
        public bool SupprimerPopvVehicule(PopvVehicule PopvVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            PopvVehicule.Supprimer(m_BD, PopvVehicule, false);
            return true;
        }
        public bool ModifierPopvVehicule(PopvVehicule PopvVehicule)
        {
            return PopvVehicule.Enregistrer(m_BD, PopvVehicule, true);
        }
        #endregion


        #region Reparation
        //+============+
        //| Reparation |
        //+============+

        public bool AjouterArticleFacture(Reparation NouvelArticleFacture)
        {
            return NouvelArticleFacture.Enregistrer(m_BD, NouvelArticleFacture, false);
        }
        public bool SupprimerArticleFacture(Reparation NouvelArticleFacture)
        {
            if (!m_BD.EstConnecte) Initialiser();
            NouvelArticleFacture.Supprimer(m_BD, NouvelArticleFacture, false);
            return true;
        }
        public bool ModifierArticleFacture(Reparation ArticleFacture)
        {
            return ArticleFacture.Enregistrer(m_BD, ArticleFacture, true);
        }
        #endregion

        #region RendezVousEntretienReparation
        //+=================================+
        //| Rendez Vous Entretien Reparation|
        //+=================================+
        public bool AjouterRendezvous(RendezVousEntretienReparation NouveauRendezvous)
        {
            return NouveauRendezvous.Enregistrer(m_BD, NouveauRendezvous, false);
        }
        public bool SupprimerRendezvous(RendezVousEntretienReparation Rendezvous)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Rendezvous.Supprimer(m_BD, Rendezvous, false);
            return true;
        }
        public bool ModifierRendezvous(RendezVousEntretienReparation Rendezvous)
        {
            return Rendezvous.Enregistrer(m_BD, Rendezvous, true);
        }
        #endregion

        #region Factures des ventes

        //+===================+
        //| Factures de vente | 
        //+===================+
        public bool AjouterNouvelleFactureVente(FactureVente NouvelleFactureVente)
        {
            return NouvelleFactureVente.Enregistrer(m_BD, NouvelleFactureVente, false);
        }
        public bool SupprimerFactureVente(FactureVente FactureVente)
        {
            if (!m_BD.EstConnecte) Initialiser();
            FactureVente.Supprimer(m_BD, FactureVente, false);
            return true;
        }
        public bool ModifierFactureVente(FactureVente Facture)
        {
            return Facture.Enregistrer(m_BD, Facture, true);
        }

        #endregion

        #region Factures(entretiens et réparations)
        //+======================================+
        //| Factures (entretiens et réparations) | 
        //+======================================+
        public bool AjouterNouvelleFacture(Facture NouvelleFacture)
        {
            return NouvelleFacture.Enregistrer(m_BD, NouvelleFacture, false);
        }
        public bool SupprimerFacture(Facture Facture)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Facture.Supprimer(m_BD, Facture, false);
            return true;
        }
        public bool ModifierFacture(Facture Facture)
        {
            return Facture.Enregistrer(m_BD, Facture, true);
        }
        #endregion        

        #region OptionVehicule
        //+=================+
        //| Option Vehicule | 
        //+=================+
        public bool AjouterOptionVehicule(OptionVehicule OptionVehicule)
        {
            return OptionVehicule.Enregistrer(m_BD, OptionVehicule, false);
        }
        public bool SupprimerOptionVehicule(OptionVehicule OptionVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            OptionVehicule.Supprimer(m_BD, OptionVehicule, false);
            return true;
        }
        public bool ModifierOptionVehicule(OptionVehicule OptionVehicule)
        {
            return OptionVehicule.Enregistrer(m_BD, OptionVehicule, true);
        }
        #endregion        

        #region ChoixOptionVehicule
        //+=======================+
        //| Choix Option Vehicule | 
        //+=======================+
        public bool AjouterChoixOptionVehicule(ChoixOptionVehicule ChoixOptionVehicule)
        {
            return ChoixOptionVehicule.Enregistrer(m_BD, ChoixOptionVehicule, false);
        }
        public bool SupprimerChoixOptionVehicule(ChoixOptionVehicule ChoixOptionVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            ChoixOptionVehicule.Supprimer(m_BD, ChoixOptionVehicule, false);
            return true;
        }
        public bool ModifierChoixOptionVehicule(ChoixOptionVehicule ChoixOptionVehicule)
        {
            return ChoixOptionVehicule.Enregistrer(m_BD, ChoixOptionVehicule, true);
        }

        #endregion

        #region ChoixPackVehicule
        //+=====================+
        //| Choix Pack Vehicule | 
        //+=====================+
        public bool AjouterChoixPackVehicule(ChoixPackVehicule ChoixPackVehicule)
        {
            return ChoixPackVehicule.Enregistrer(m_BD, ChoixPackVehicule, false);
        }
        public bool SupprimerChoixPackVehicule(ChoixPackVehicule ChoixPackVehicule)
        {
            if (!m_BD.EstConnecte) Initialiser();
            ChoixPackVehicule.Supprimer(m_BD, ChoixPackVehicule, false);
            return true;
        }
        public bool ModifierChoixPackVehicule(ChoixPackVehicule ChoixPackVehicule)
        {
            return ChoixPackVehicule.Enregistrer(m_BD, ChoixPackVehicule, true);
        }

        #endregion        

        #region FactureEntretien
        //+==================+
        //| FactureEntretien |
        //+==================+
        public bool AjouterFactureEntretien(FactureEntretien Entretien)
        {
            return Entretien.Enregistrer(m_BD, Entretien, false);
        }
        public bool SupprimerFactureEntretien(FactureEntretien Entretien)
        {
            if (!m_BD.EstConnecte) Initialiser();
            Entretien.Supprimer(m_BD, Entretien, false);
            return true;
        }

        public bool ModifierFactureEntretien(FactureEntretien FactureEntretien)
        {
            return FactureEntretien.Enregistrer(m_BD, FactureEntretien, true);
        }
        #endregion

        #region Toutes les énumérations
        //+==================+
        //| Les énumérations |
        //+==================+

        /// <summary>
        /// Permet l'enumeration d'un employé en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Employe> EnumererEmploye(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Employe.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Employe, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'un rendez vous en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<RendezVousEntretienReparation> EnumererRdv(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return RendezVousEntretienReparation.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Rdv, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'une facture en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Facture> EnumererFacture(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Facture.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Facture, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'une réparation en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Reparation> EnumererReparation(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Reparation.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Reparation, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'une facture entretien en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<FactureEntretien> EnumererFactureEntretien(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return FactureEntretien.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_FactureEntretien, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'une liaison entre une option et un véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<VehiculeOptionVehicule> EnumererVehiculeOptionVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return VehiculeOptionVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_VehiculeOptionVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'un entretien en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Entretien> EnumererEntretien(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Entretien.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Entretien, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'une liaison entre facture et entretien en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<FactureEntretien> EnumererEntretienFacture(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return FactureEntretien.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_FactureEntretien, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'un client en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Client> EnumererClient(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Client.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Client, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'une adresse en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Adresse> EnumererAdresse(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Adresse.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Adresse, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'un statut de facture en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Statut> EnumererStatut(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Statut.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Statut, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'un statut de facture en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<StatutEmploye> EnumererStatutEmploye(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return StatutEmploye.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_StatutEmploye, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'une civilité en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Civilite> EnumererCivilite(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Civilite.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Civilite, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'un véhicule de client en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<ClientVehicule> EnumererClientVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return ClientVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_ClientVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration d'un véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Vehicule> EnumererVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Vehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Vehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'articles en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Article> EnumererArticle(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Article.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Article, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }

        /// <summary>
        /// Permet l'enumeration d'articles facturés en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Reparation> EnumererArticleFacture(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Reparation.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_ArticleFacture, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes type d'options en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<TypeOption> EnumererTypeOptions(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return TypeOption.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_TypeOption, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différents choix de packs en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<ChoixPackVehicule> EnumererChoixPackVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return ChoixPackVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_ChoixPackVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes type d'options en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<TypeVehicule> EnumererTypeVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return TypeVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_TypeVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes options en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<OptionVehicule> EnumererOptionVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return OptionVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_OptionVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes options en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<ChoixOptionVehicule> EnumererChoixOptionVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return ChoixOptionVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_ChoixOptionVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes options en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<FactureVente> EnumererFactureVente(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return FactureVente.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_FactureVente, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des liaison entre un véhicule et un pack en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<PopvVehicule> EnumererPopvVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return PopvVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_PopvVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes caractéristiques du véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<VehiculeCaracteristique> EnumererVehiculeCaracteristique(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return VehiculeCaracteristique.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_VehiculeCaracteristique, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes caractéristiques du véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<Caracteristique> EnumererCaracteristique(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return Caracteristique.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_Caracteristique, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes caractéristiques du véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<PackOptionPackVehicule> EnumererPackOptionVehicule(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return PackOptionPackVehicule.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_PackOptionVehicule, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes caractéristiques du véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<PackOption> EnumererPackOption(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return PackOption.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_PackOption, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        /// <summary>
        /// Permet l'enumeration des différentes caractéristiques du véhicule en rajoutant les parties de la requête par paramètre
        /// </summary>
        /// <param name="ValeurSouhaitee">Les valeurs que l'ont souhaite avoir accès</param>
        /// <param name="ClauseJoin">Jointure</param>
        /// <param name="ClauseWhere">Where</param>
        /// <param name="ClauseOrderBy">Tri</param>
        /// <returns></returns>
        public IEnumerable<VehiculeVente> EnumererVehiculeVente(MyDB.CodeSql ValeurSouhaitee, MyDB.CodeSql ClauseJoin, MyDB.CodeSql ClauseWhere, MyDB.CodeSql ClauseOrderBy)
        {
            if (ClauseWhere == null) ClauseWhere = MyDB.CodeSql.Vide;
            if (ClauseOrderBy == null) ClauseOrderBy = MyDB.CodeSql.Vide;
            if (ClauseJoin == null) ClauseJoin = MyDB.CodeSql.Vide;
            if (ValeurSouhaitee == null) ValeurSouhaitee = new MyDB.CodeSql("*");
            return VehiculeVente.Enumerer(m_BD, m_BD.Enumerer("SELECT {0} FROM  {1} {2} {3} {4}", ValeurSouhaitee, c_NomTable_VehiculeVente, ClauseJoin, ClauseWhere, ClauseOrderBy));
        }
        #endregion

    }
}
