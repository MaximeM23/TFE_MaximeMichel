using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public class FactureVente : Entite<FactureVente,FactureVente.Champs>
    {


        public enum Champs
        {
            /// <summary>
            /// Id de la facture
            /// </summary>
            Id,
            /// <summary>
            /// Numéro de la facture
            /// </summary>
            NumeroFacture,
            /// <summary>
            /// Date de vente du véhicule
            /// </summary>
            DateVente,
            /// <summary>
            /// Remise sur rachat éventuel lors de l'achat d'un véhicule
            /// </summary>
            RemiseSurReprise,
            /// <summary>
            /// Pourcentage de la TVA
            /// </summary>
            PourcentageTva,
            /// <summary>
            /// Véhicule lié à cette facture
            /// </summary>
            VehiculeVente,
            /// <summary>
            /// Client lié à cette facture
            /// </summary>
            Client,
            /// <summary>
            /// Employé lié à cette facture
            /// </summary>
            Employe
        }

        #region Membres privés
        private string m_NumeroFacture;
        private DateTime m_DateVente;
        private double m_RemiseSurReprise;
        private int m_PourcentageTva;
        private VehiculeVente m_VehiculeVente;
        private Client m_Client;
        private Employe m_Employe;
        #endregion


        /// <summary>
        /// Propriété publique permettant l'accès au numéro de la facture
        /// </summary>
        public string NumeroFacture
        {
            get
            {
                return m_NumeroFacture;
            }
            set
            {
                if(value != null)
                {
                    value = value.Trim();                    
                    if (!string.Equals(value, m_NumeroFacture))
                    {
                        ModifierChamp(Champs.NumeroFacture, ref m_NumeroFacture, value);
                    }
                }
            }
        }
        
        /// <summary>
        /// Propriété publique permettant l'accès à la date de vente du véhicule
        /// </summary>
        public DateTime DateVente
        {
            get
            {
                return m_DateVente;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateVente))
                {
                    ModifierChamp(Champs.DateVente, ref m_DateVente, value);
                }
            }
        }



        /// <summary>
        /// Propriété publique permettant l'accès à la remise sur rachat d'un véhicule par la concession
        /// </summary>
        public double RemiseSurReprise
        {
            get
            {
                return m_RemiseSurReprise;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.RemiseSurReprise, "La remise ne peut pas être vide ou inférieure à 0 €");
                    ChampDevientInvalide(Champs.RemiseSurReprise);
                }
                else
                {
                    if (!double.Equals(value, m_RemiseSurReprise))
                    {
                        ModifierChamp(Champs.RemiseSurReprise, ref m_RemiseSurReprise, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au pourcentage de TVA
        /// </summary>
        public int PourcentageTva
        {
            get
            {
                return m_PourcentageTva;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.PourcentageTva, "Le pourcentage de TVA ne peut pas être négatif");
                    ChampDevientInvalide(Champs.PourcentageTva);
                }
                else if (value > 100)
                {
                    Declencher_SurErreur(this, Champs.PourcentageTva, "Le pourcentage de TVA ne peut pas dépasser 100 €");
                    ChampDevientInvalide(Champs.PourcentageTva);
                }
                else
                {
                    if (!int.Equals(value, m_PourcentageTva))
                    {
                        ModifierChamp(Champs.PourcentageTva, ref m_PourcentageTva, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au véhicule de cette facture
        /// </summary>
        public VehiculeVente VehiculeVente
        {
            get
            {
                return m_VehiculeVente;
            }
            set
            {
                if (!object.Equals(value, m_VehiculeVente))
                {
                    ModifierChamp(Champs.VehiculeVente, ref m_VehiculeVente, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au client de cette facture
        /// </summary>
        public Client Client
        {
            get
            {
                return m_Client;
            }
            set
            {
                if (!object.Equals(value, m_Client))
                {
                    ModifierChamp(Champs.Client, ref m_Client, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à l'employé de cette facture
        /// </summary>
        public Employe Employe
        {
            get
            {
                return m_Employe;
            }
            set
            {
                if (!object.Equals(value, m_Employe))
                {
                    ModifierChamp(Champs.Employe, ref m_Employe, value);
                }
            }
        }



        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public FactureVente()
            : base()
        {
            m_NumeroFacture = null;
            m_DateVente = DateTime.MaxValue;
            m_RemiseSurReprise = -1.0;
            m_PourcentageTva = -1;
            m_VehiculeVente = null;
            m_Client = null;
            m_Employe = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NumeroFacture">Numéro de facture</param>
        /// <param name="DateVente">Date de vente du véhicule</param>
        /// <param name="RemiseSurReprise">Remise sur la reprise d'un éventuel rachat par la concession d'un ancien véhicule</param> 
        /// <param name="PourcentageTva">Pourcentage tva de la facture</param>
        /// <param name="VehiculeVente">Véhicule correspondant à cette facture</param>
        /// <param name="Client">Client lié à cette facture</param>
        /// <param name="Employe">Employé ayant vendu ce véhicule</param>
        public FactureVente(string NumeroFacture, DateTime DateVente, double RemiseSurReprise,int PourcentageTva, VehiculeVente VehiculeVente, Client Client, Employe Employe)
            : this()
        {
            DefinirId(Id);
            this.NumeroFacture = NumeroFacture;
            this.DateVente = DateVente;
            this.RemiseSurReprise = RemiseSurReprise;
            this.PourcentageTva = PourcentageTva;
            this.VehiculeVente = VehiculeVente;
            this.Client = Client;
            this.Employe = Employe;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public FactureVente(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_facture_vente"));
            this.NumeroFacture = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_facture");
            this.DateVente = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_vente");
            this.RemiseSurReprise = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "remise_sur_reprise");
            this.PourcentageTva = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "pourcentage_tva");
            this.VehiculeVente = new VehiculeVente(Connexion, Enregistrement);
            this.Client = new Client(Connexion, Enregistrement);
            this.Employe = new Employe(Connexion, Enregistrement);
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<FactureVente> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new FactureVente(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "facture_vente";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("numero_facture = {0}, date_vente = {1}, remise_sur_reprise = {2}, pourcentage_tva = {3}, fk_id_vehicule_vente = {4}, fk_id_client = {5}, fk_id_employe = {6}",
                    m_NumeroFacture,m_DateVente,m_RemiseSurReprise,m_PourcentageTva,m_VehiculeVente.Id,m_Client.Id,m_Employe.Id);
            }
        }

        public override void SupprimerEnCascade(MyDB Connexion)
        {
            Connexion.Executer("DELETE FROM choix_option_vehicule WHERE fk_id_vehicule_vente = {0}", VehiculeVente.Id);
            Connexion.Executer("DELETE FROM choix_pack_vehicule WHERE fk_id_vehicule_vente = {0}", VehiculeVente.Id);
            Connexion.Executer("DELETE FROM vehicule_vente WHERE id_vehicule_vente = {0}", VehiculeVente.Id);        
            Connexion.Executer("DELETE FROM facture_vente WHERE id_facture_vente = {0}", Id);
        }
    }
}
