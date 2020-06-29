using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class RendezVousEntretienReparation : Entite<RendezVousEntretienReparation,RendezVousEntretienReparation.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id du rendez-vous
            /// </summary>
            Id,
            /// <summary>
            /// Date du début du rendez-vous
            /// </summary>
            DateDebut,
            /// <summary>
            /// Date de fin du rendez-vous
            /// </summary>
            DateFin,
            /// <summary>
            /// Statut de l'avancement
            /// </summary>
            Statut,
            /// <summary>
            /// Véhicule du client ayant ce rendez-vous
            /// </summary>
            ClientVehicule,
        }

        private DateTime m_DateDebut;
        private DateTime m_DateFin;
        private Statut m_Statut;
        private ClientVehicule m_ClientVehicule;
        private Facture m_Facture;

        public IEnumerable<Facture> EnumFacture
        {
            get
            {
                return EnumererFacture();
            }
            set
            {
                ChargerFacture();
            }
        }

        private bool ChargerFacture()
        {
            if (Id <= 0) return false;
            m_Facture = EnumererFacture().ElementAt(0);
            return true;
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la date du début de l'entretien ou de la réparation
        /// </summary>
        public DateTime DateDebut
        {
            get
            {
                return m_DateDebut;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateDebut))
                {
                    ModifierChamp(Champs.DateDebut, ref m_DateDebut, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès à la date de fin de l'entretien ou de la réparation
        /// </summary>
        public DateTime DateFin
        {
            get
            {
                return m_DateFin;
            }
            set
            {
                if (!DateTime.Equals(value, m_DateFin))
                {
                    ModifierChamp(Champs.DateFin, ref m_DateFin, value);
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au statut lié à ce rendez-vous
        /// </summary>
        public Statut Statut
        {
            get
            {
                return m_Statut;
            }
            set
            {
                if(value != null)
                {
                    if (value.GetType() == typeof(Statut))
                    {
                        ModifierChamp(Champs.Statut, ref m_Statut, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au véhicule du client ayant ce rendez-vous
        /// </summary>
        public ClientVehicule ClientVehicule
        {
            get
            {
                return m_ClientVehicule;
            }
            set
            {
                if(value != null)
                {
                    if (value.GetType() == typeof(ClientVehicule))
                    {
                        ModifierChamp(Champs.ClientVehicule, ref m_ClientVehicule, value);
                    }
                }
            }
        }



        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public RendezVousEntretienReparation()
            : base()
        {
            m_DateDebut = DateTime.Now;
            m_DateFin = DateTime.Now;
            m_Statut = null;
            m_ClientVehicule = null;
            m_Facture = null;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="DateDebut">Date du début de l'entretien</param>
        /// <param name="DateFin">Date de fin de l'entretien</param>
        /// <param name="Statut">Statut du rendez-vous</param>
        /// <param name="ClientVehicule">Véhicule du client ayant ce rendez-vous</param>
        public RendezVousEntretienReparation(DateTime DateDebut, DateTime DateFin, Statut Statut, ClientVehicule ClientVehicule)
            : this()
        {
            DefinirId(Id);
            this.DateDebut = DateDebut;
            this.DateFin = DateFin;
            this.Statut = Statut;
            this.ClientVehicule = ClientVehicule;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public RendezVousEntretienReparation(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {

            base.Connexion = Connexion;
            if (Enregistrement != null)
            {
                DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_rendez_vous_entretien_reparation"));
                this.DateDebut = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_debut");
                this.DateFin = Enregistrement.ValeurChampComplet<DateTime>(NomDeLaTablePrincipale, "date_fin");
                this.Statut = new Statut(Connexion, Enregistrement);
                this.ClientVehicule = new ClientVehicule(Connexion, Enregistrement);
            }
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<RendezVousEntretienReparation> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new RendezVousEntretienReparation(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "rendez_vous_entretien_reparation";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("date_debut = {0}, date_fin = {1}, fk_id_statut = {2}, fk_id_client_vehicule = {3}", m_DateDebut, m_DateFin, m_Statut.Id, m_ClientVehicule.Id);
            }
        }    
        
        public IEnumerable<Facture> EnumererFacture()
        {
            return Facture.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * FROM facture 
                                                                JOIN reparation ON facture.id_facture = reparation.fk_id_facture
                                                                JOIN article ON reparation.fk_id_article = article.id_article
                                                                JOIN facture_entretien ON facture.id_facture = facture_entretien.id_facture_entretien
                                                                JOIN entretien ON facture_entretien.fk_id_entretien = entretien.id_entretien
                                                                JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule
                                                                WHERE facture.fk_id_rdv = {0}", Id));
            
        }    
        
    }

}

