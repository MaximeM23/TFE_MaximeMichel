using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class Facture : Entite<Facture,Facture.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de cette facture
            /// </summary>
            Id,
            /// <summary>
            /// Numéro de la facture
            /// </summary>
            NumeroFacture,
            /// <summary>
            /// Heure(s) prestée(s) sur le véhicule
            /// </summary>
            HeurePrestation,
            /// <summary>
            /// Prix total de cette facture
            /// </summary>
            PrixTotal,
            /// <summary>
            /// Informations du vendeur sur l'éventuelle réparation
            /// </summary>
            Informations,
            /// <summary>
            /// Commentaire du mécanicien sur un conseil pour un prochain rendez-vous
            /// </summary>
            Commentaire,
            /// <summary>
            /// Rendez-vous de cette facture
            /// </summary>
            RendezVous
        }

        #region Membres privés
        private int m_HeurePrestation;
        private double m_PrixTotal;
        private string m_Informations;
        private string m_Commentaire;
        private string m_NumeroFacture;
        private RendezVousEntretienReparation m_RendezVous;
        private List<Reparation> m_Reparation;
        private IEnumerable<FactureEntretien> m_FactureEntretien;
        public bool m_ReparationCoche;   
        #endregion

        public IEnumerable<FactureEntretien> EnumFactureEntretien
        {
            get
            {
                return EnumererFactureEntretien();
            }
            set
            {
                ChargerFactureEntretien();
            }
        }

        public IEnumerable<Reparation> EnumReparation
        {
            get
            {
                return EnumererReparation();
            }
            set
            {
                ChargerReparation();
            }
        }

        private bool ChargerFactureEntretien()
        {
            if (Id <= 0) return false;
            m_FactureEntretien = EnumererFactureEntretien();
            return true;
        }

        private bool ChargerReparation()
        {
            if (Id <= 0) return false;
            m_Reparation.Clear();
            m_Reparation.AddRange(EnumererReparation());
            return true;
        }

        
        /// <summary>
        /// Propriété publique permettant l'accès aux heures de prestation sur le véhicule
        /// </summary>
        public int HeurePrestation
        {
            get
            {
                return m_HeurePrestation;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.HeurePrestation, "Les heures de prestation ne peuvent pas être négative");
                    ChampDevientInvalide(Champs.HeurePrestation);
                }
                else if (value > 50)
                {
                    Declencher_SurErreur(this, Champs.HeurePrestation, "Les heures de prestation ne peuvent pas dépasser 50 heures");
                    ChampDevientInvalide(Champs.HeurePrestation);
                }
                else
                {
                    if (!int.Equals(value, m_HeurePrestation) || (value == 0))
                    {
                        ModifierChamp(Champs.HeurePrestation, ref m_HeurePrestation, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès aux heures de prestation sur le véhicule
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
                    Declencher_SurErreur(this, Champs.PrixTotal, "Le prix ne peut pas être négatif");
                    ChampDevientInvalide(Champs.PrixTotal);
                }
                else if (value > 5000000000)
                {
                    Declencher_SurErreur(this, Champs.PrixTotal, "Le prix ne peut pas dépasser 5 000 000 000 €");
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
        /// Propriété publique permettant l'accès aux informations sur le véhicule encodé par le vendeur
        /// </summary>
        public string Informations
        {
            get
            {
                return m_Informations;
            }
            set
            {
                if(value != null)
                { 
                    value = value.Trim();
                    if (((value.Length > 500) || (value.Length < 1)) && m_ReparationCoche == true)
                    {
                        Declencher_SurErreur(this, Champs.Informations, "L'information doit être comprise entre 1 et 500 caractères");
                        ChampDevientInvalide(Champs.Informations);
                    }
                    else if (!string.Equals(value, m_Informations))
                    {
                        ModifierChamp(Champs.Informations, ref m_Informations, value);
                    }
                }
                
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au numéro de facture
        /// </summary>
        public string NumeroFacture
        {
            get
            {
                return m_NumeroFacture;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.Informations, "Le numéro de facture est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.Informations);
                }
                else
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
        /// Propriété publique permettant l'accès au commentaire encodé par le mécanicien
        /// </summary>
        public string Commentaire
        {
            get
            {
                return m_Commentaire;
            }
            set
            {
                if(value != null)
                {
                    value = value.Trim();
                    if ((value.Length > 500) || (value.Length < 0))
                    {
                        Declencher_SurErreur(this, Champs.Commentaire, "Le commentaire doit être compris entre 0 et 500 caractères");
                        ChampDevientInvalide(Champs.Commentaire);
                    }
                    else if (!string.Equals(value, m_Commentaire))
                    {
                        ModifierChamp(Champs.Commentaire, ref m_Commentaire, value);
                    }
                }         
            }
        }


        /// <summary>
        /// Propriété publique permettant l'accès au rendez-vous de cette facture
        /// </summary>
        public RendezVousEntretienReparation RendezVous
        {
            get
            {
                return m_RendezVous;
            }
            set
            {
                if (!object.Equals(value, m_RendezVous))
                {
                    ModifierChamp(Champs.RendezVous, ref m_RendezVous, value);
                }
            }
        }



        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public Facture()
            : base()
        {
            m_HeurePrestation = -1;
            m_PrixTotal = -1.0;
            m_Informations = null;
            m_Commentaire = null;
            m_RendezVous = null;
            m_FactureEntretien = null;
            m_Reparation = null;
            m_ReparationCoche = false;
            m_NumeroFacture = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NumeroFacture">Numéro de la facture</param>
        /// <param name="HeurePrestation">Heure(s) prestée(s) sur le véhicule</param>
        /// <param name="PrixTotal">Prix de l'entretien ou de la réparation</param>
        /// <param name="Informations">Informations encodées par le vendeur</param>
        /// <param name="Commentaire">Commentaire encodé par le mécanicien</param>
        /// <param name="RendezVous">Rendez-vous de cette facture</param>
        public Facture(string NumeroFacture, int HeurePrestation, double PrixTotal, string Informations, string Commentaire, RendezVousEntretienReparation RendezVous)
            : this()
        {
            DefinirId(Id);
            this.NumeroFacture = NumeroFacture;
            this.HeurePrestation = HeurePrestation;
            this.PrixTotal = PrixTotal;
            this.Informations = Informations;
            this.Commentaire = Commentaire;
            this.RendezVous = RendezVous;
            m_ReparationCoche = false;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public Facture(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            base.Connexion = Connexion;
            if (Enregistrement != null)
            {
                DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_facture"));
                this.NumeroFacture = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "numero_facture");
                this.HeurePrestation = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "heure_prestation");
                this.PrixTotal = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix_total");
                this.Informations = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "informations");
                this.Commentaire = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "commentaire");
                this.RendezVous = new RendezVousEntretienReparation(Connexion, Enregistrement);
            }
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<Facture> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new Facture(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "facture";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("numero_facture = {0}, heure_prestation = {1}, prix_total = {2}, informations = {3}, commentaire = {4}, fk_id_rdv = {5}",
                   m_NumeroFacture,m_HeurePrestation, m_PrixTotal, m_Informations, m_Commentaire, m_RendezVous.Id);
            }
        }

        private IEnumerable<Reparation> EnumererReparation()
        {
            return Reparation.Enumerer(Connexion,Connexion.Enumerer(@"SELECT * FROM reparation
                                        JOIN article ON reparation.fk_id_article = article.id_article
                                        JOIN facture ON reparation.fk_id_facture = facture.id_facture
                                         WHERE fk_id_facture = {0}", Id));
        }

        private IEnumerable<FactureEntretien> EnumererFactureEntretien()
        {
            return FactureEntretien.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM facture_entretien
                                        JOIN entretien ON facture_entretien.fk_id_entretien = entretien.id_entretien
                                         WHERE fk_id_facture = {0}", Id));
        }
    }
}

