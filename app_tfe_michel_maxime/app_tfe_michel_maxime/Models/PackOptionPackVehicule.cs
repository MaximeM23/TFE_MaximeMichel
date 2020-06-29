using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app_tfe_michel_maxime
{
    public class PackOptionPackVehicule : Entite<PackOptionPackVehicule,PackOptionPackVehicule.Champs>
    {

        public enum Champs
        {
            /// <summary>
            /// Id de ce pack d'option
            /// </summary>
            Id,
            /// <summary>
            /// Nom du pack d'option
            /// </summary>
            NomPack,
            /// <summary>
            /// Prix de ce pack d'option
            /// </summary>
            PrixPack,
            /// <summary>
            /// Permet de savoir si le pack est disponible à la vente ou si celui-ci a été supprimé
            /// </summary>
            Disponible
        }

        private string m_NomPack;
        private double m_PrixPack;
        private List<PackOption> m_PackOption;
        private int m_Disponible;

        public IEnumerable<PackOption> EnumPackOption
        {
            get
            {
                return EnumererPackOption();
            }
            set
            {
                ChargerPackOption();
            }
        }

        private bool ChargerPackOption()
        {
            if (Id <= 0) return false;
            m_PackOption.Clear();
            m_PackOption.AddRange(EnumererPackOption());
            return true;
        }

        /// <summary>
        /// Propriété publique permettant l'accès au nom du pack d'option
        /// </summary>
        public string NomPack
        {
            get
            {
                return m_NomPack;
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Declencher_SurErreur(this, Champs.NomPack, "Le nom du pack est vide ou ne contient que des espaces");
                    ChampDevientInvalide(Champs.NomPack);
                }
                else
                {
                    value = value.Trim();
                    if ((value.Length > 100) || (value.Length <= 0))
                    {
                        Declencher_SurErreur(this, Champs.NomPack, "Le nom du pack doit être compris entre 1 et 100 caractères");
                        ChampDevientInvalide(Champs.NomPack);
                    }
                    else if (!string.Equals(value, m_NomPack))
                    {
                        ModifierChamp(Champs.NomPack, ref m_NomPack, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant l'accès au prix du pack d'option
        /// </summary>
        public double PrixPack
        {
            get
            {
                return m_PrixPack;
            }
            set
            {
                if (value < 0)
                {
                    Declencher_SurErreur(this, Champs.PrixPack, "Le prix ne peut être inférieur à 0 €");
                    ChampDevientInvalide(Champs.PrixPack);
                }
                else if (value > 10000)
                {
                    Declencher_SurErreur(this, Champs.PrixPack, "Le prix ne peut pas dépasser 10 000 €");
                    ChampDevientInvalide(Champs.PrixPack);
                }
                else
                {
                    if (!double.Equals(value, m_PrixPack))
                    {
                        ModifierChamp(Champs.PrixPack, ref m_PrixPack, value);
                    }
                }
            }
        }

        /// <summary>
        /// Propriété publique permettant de savoir si ce pack est disponible à la vente ou a été supprimé
        /// </summary>
        public int Disponible
        {
            get
            {
                return m_Disponible;
            }
            set
            {
                ModifierChamp(Champs.Disponible, ref m_Disponible, value);
            }
        }

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public PackOptionPackVehicule()
            : base()
        {
            m_NomPack = null;
            m_PrixPack = -1.0;
            m_PackOption = null;
            m_Disponible = -1;
        }


        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="NomPack">Nom du pack</param>
        /// <param name="PrixPack">Prix du pack</param>
        /// <param name="Disponible">Permet de savoir le pack est disponible à la vente</param>
        public PackOptionPackVehicule(string NomPack, double PrixPack,int Disponible)
            : this()
        {
            DefinirId(Id);
            this.NomPack = NomPack;
            this.PrixPack = PrixPack;
            this.Disponible = Disponible;
        }

        /// <summary>
        /// Constructeur spécifique
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrement">Enregistrement d'où extraire les valeurs de champs</param>
        public PackOptionPackVehicule(PDSGBD.MyDB Connexion, PDSGBD.MyDB.IEnregistrement Enregistrement)
            : this()
        {
            base.Connexion = Connexion;
            if (Enregistrement != null)
            {
                DefinirId(Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "id_pack_option_pack_vehicule"));
                this.NomPack = Enregistrement.ValeurChampComplet<string>(NomDeLaTablePrincipale, "nom_pack");
                this.PrixPack = Enregistrement.ValeurChampComplet<double>(NomDeLaTablePrincipale, "prix_pack");
                this.Disponible = Enregistrement.ValeurChampComplet<int>(NomDeLaTablePrincipale, "disponible");
            }
        }

        /// <summary>
        /// Permet d'énumérer les entités correspondant aux enregistrements énumérés
        /// </summary>
        /// <param name="Connexion">Connexion au serveur MySQL</param>
        /// <param name="Enregistrements">Enregistrements énumérés, sources des entités à créer</param>
        /// <returns>Enumération des entités issues des enregistrements énumérés</returns>
        public static IEnumerable<PackOptionPackVehicule> Enumerer(PDSGBD.MyDB Connexion, IEnumerable<PDSGBD.MyDB.IEnregistrement> Enregistrements)
        {
            return Enumerer(Enregistrements, Enregistrement => new PackOptionPackVehicule(Connexion, Enregistrement));
        }

        /// <summary>
        /// Nom de la table correspondant à cette entité
        /// </summary>
        public override string NomDeLaTablePrincipale
        {
            get
            {
                return "pack_option_pack_vehicule";
            }
        }

        /// <summary>
        /// Clause d'assignation utilisable dans une requête INSERT/UPDATE
        /// </summary>
        public override PDSGBD.MyDB.CodeSql ClauseAssignation
        {
            get
            {
                return new PDSGBD.MyDB.CodeSql("nom_pack = {0}, prix_pack = {1}, disponible = {2}",
                    m_NomPack, m_PrixPack,m_Disponible);
            }
        }

        private IEnumerable<PackOption> EnumererPackOption()
        {
            return PackOption.Enumerer(Connexion, Connexion.Enumerer(@"SELECT * from pack_option
                                                                        JOIN option_vehicule ON pack_option.fk_id_option_vehicule = option_vehicule.id_option_vehicule
                                                                        JOIN type_option ON option_vehicule.fk_id_type_option = type_option.id_type_option
                                                                        JOIN pack_option_pack_vehicule ON pack_option_pack_vehicule.id_pack_option_pack_vehicule = pack_option.fk_id_popv
                                                                        WHERE pack_option.fk_id_popv = {0}", Id));
        }
    }
}
