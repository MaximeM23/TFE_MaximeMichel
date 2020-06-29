using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace app_tfe_michel_maxime
{
    public partial class Page_Facture : UserControl
    {

        #region Event de déplacement de l'application
        Point DernierClic;
        bool dragging;
        private void Page_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            DernierClic = e.Location;
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ParentForm.Left += e.X - DernierClic.X;
                    ParentForm.Top += e.Y - DernierClic.Y;
                }
            }
        }

        private void Page_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion


        private GenerationFacturePDF GenerationDocumentsPDF = new GenerationFacturePDF();

        public Page_Facture()
        {
            InitializeComponent();

            //Fiche de ventes
            ficheFactureVente1.CacheTextBoxFiltre();
            ficheFactureVente1.SurChangementSelection += FicheFactureVente1_SurChangementSelection;

            // Liste déroulante des factures pour les entretiens et réparations
            listeDeroulanteFacture1.SurChangementSelection += ListeDeroulanteFactureEntretienReparation_SurChangementSelection;            

            //Fiche facture entretiens et réparations
            ficheFacture.SurChangementSelection += FicheFacture_SurChangementSelection;

            //Liste déroulante de vente
            listeDeroulanteFactureVente1.SurChangementSelection += ListeDeroulanteFacture_SurChangementSelection;

            // Liste déroulante des clients pour les ventes
            listeDeroulanteClient1.SurChangementSelection += ListeDeroulanteClient_SurChangementSelection;

            // Liste déroulante des clients pour les entretiens et réparations
            listeDeroulanteClient2.SurChangementSelection += ListeDeroulanteClientEntretienReparation_SurChangementSelection;

            // Cache la textbox de filtre de la fiche d'entretiens et réparations
            ficheFacture.CacheTextBoxFiltre();           


            panelFactureVente.BringToFront();
            buttonFactureVente.Enabled = false;
            buttonFactureEntretienReparation.Enabled = false;

            this.MinimumSize = new Size(1100, 750);
        }

        private void ListeDeroulanteClientEntretienReparation_SurChangementSelection(object sender, EventArgs e)
        {
            RechargerFactureEntretienReparation();
        }

        private void ListeDeroulanteFactureEntretienReparation_SurChangementSelection(object sender, EventArgs e)
        {
            RechargerFactureEntretienReparation();
        }

        private void FicheFacture_SurChangementSelection(object sender, EventArgs e)
        {
            if(ficheFacture.FactureSelectionnee != null)
            {
                buttonFactureEntretienReparation.Enabled = true;
            }
        }

        private void ListeDeroulanteClient_SurChangementSelection(object sender, EventArgs e)
        {
            RechargerFicheVente();            
        }
        
       
        private void ListeDeroulanteFacture_SurChangementSelection(object sender, EventArgs e)
        {
            RechargerFicheVente();
        }

        private void FicheFactureVente1_SurChangementSelection(object sender, EventArgs e)
        {
            if (ficheFactureVente1.FactureVenteSelectionnee != null)
            {
                if(ficheFactureVente1.FactureVenteSelectionnee.VehiculeVente.StatutLivraison.StatutOperation == "En livraison")
                {
                    buttonImprimerBonCommande.Enabled = true;
                    buttonImprimerFacture.Enabled = false;                
                }
                else
                {
                    buttonImprimerBonCommande.Enabled = true;
                    buttonImprimerFacture.Enabled = true;
                }
            }
        }

        private void Page_Facture_Load(object sender, EventArgs e)
        {
            RechargerFicheVente();
            listeDeroulanteClient1.Client = Program.GMBD.EnumererClient(null,null,null, new PDSGBD.MyDB.CodeSql("ORDER BY id_client, nom_client"));
            listeDeroulanteClient2.Client = listeDeroulanteClient1.Client;
            RechargerFactureEntretienReparation();
        }

        private void buttonImprimerBonCommande_Click(object sender, EventArgs e)
        {
            if(ficheFactureVente1.FactureVenteSelectionnee != null)
            {
                GenerationDocumentsPDF.GenerationBonDeCommande(ficheFactureVente1.FactureVenteSelectionnee,false);
            }
        }

        private void buttonImprimerFacture_Click(object sender, EventArgs e)
        {
            GenerationDocumentsPDF.GenerationFactureVente(ficheFactureVente1.FactureVenteSelectionnee, false);
        }

        private void ficheFactureVente1_SizeChanged(object sender, EventArgs e)
        {
            RechargerFicheVente();
        }

        /// <summary>
        /// Permet de charger ou de recharger la fiche de vente en fonction des élements séléctionnés dans les filtres de listes déroulantes
        /// </summary>
        private void RechargerFicheVente()
        {            
            if((listeDeroulanteClient1.ClientSelectionne == null) && (listeDeroulanteFactureVente1.FactureVenteSelectionne != null))
            {
                ficheFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                                    new PDSGBD.MyDB.CodeSql("WHERE (statut.statut = \"En livraison\" OR statut.statut = \"Vendu\") AND facture_vente.id_facture_vente = {0}", listeDeroulanteFactureVente1.FactureVenteSelectionne.Id), null);
            }
            else if ((listeDeroulanteClient1.ClientSelectionne != null) && (listeDeroulanteFactureVente1.FactureVenteSelectionne != null))
            {

                ficheFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                                    new PDSGBD.MyDB.CodeSql("WHERE (statut.statut = \"En livraison\" OR statut.statut = \"Vendu\") AND client.id_client = {0} AND facture_vente.id_facture_vente = {1}", listeDeroulanteClient1.ClientSelectionne.Id, listeDeroulanteFactureVente1.FactureVenteSelectionne.Id), null);
            }
            else if((listeDeroulanteClient1.ClientSelectionne != null) && (listeDeroulanteFactureVente1.FactureVenteSelectionne == null))
            {
                ficheFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                                       new PDSGBD.MyDB.CodeSql("WHERE (statut.statut = \"En livraison\" OR statut.statut = \"Vendu\") AND client.id_client = {0} ", listeDeroulanteClient1.ClientSelectionne.Id), null);
            }
            else
            {
                ficheFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, new PDSGBD.MyDB.CodeSql(@"JOIN vehicule_vente ON facture_vente.fk_id_vehicule_vente = vehicule_vente.id_vehicule_vente 
                                                                                                                        JOIN statut ON vehicule_vente.fk_id_statut = statut.id_statut 
                                                                                                                        JOIN vehicule ON vehicule_vente.fk_id_vehicule = vehicule.id_vehicule
                                                                                                                        JOIN client ON facture_vente.fk_id_client = client.id_client
                                                                                                                        JOIN adresse ON client.fk_id_adresse = adresse.id_adresse
                                                                                                                        JOIN employe ON employe.id_employe = facture_vente.fk_id_employe
                                                                                                                        JOIN civilite ON client.fk_id_civilite = civilite.id_civilite"),
                                                                                                new PDSGBD.MyDB.CodeSql("WHERE statut.statut = \"En livraison\" OR statut.statut = \"Vendu\""), null);
            }
        }

        /// <summary>
        /// Permet de charger ou recharger la fiche de factures des entretiens et réparations en fonction des filtres séléctionnés dans les listes déroulantes 
        /// </summary>
        private void RechargerFactureEntretienReparation()
        {
            if ((listeDeroulanteFacture1.FactureSelectionne != null)&&(listeDeroulanteClient2.ClientSelectionne == null))
            {
                ficheFacture.Facture = Program.GMBD.EnumererFacture(null, new PDSGBD.MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                                                                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule
                                                                                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut"),        
                                                                        new PDSGBD.MyDB.CodeSql("WHERE facture.id_facture = {0} AND statut.statut != \"En attente\"", listeDeroulanteFacture1.FactureSelectionne.Id), null);
            }
            else if ((listeDeroulanteClient2.ClientSelectionne != null) && (listeDeroulanteFacture1.FactureSelectionne != null))
            {
                ficheFacture.Facture = Program.GMBD.EnumererFacture(null, new PDSGBD.MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                                                                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule
                                                                                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE facture.id_facture = {0} AND client.id_client = {1} AND statut.statut != \"En attente\"", listeDeroulanteFacture1.FactureSelectionne.Id,listeDeroulanteClient2.ClientSelectionne.Id), null);
            }
            else if ((listeDeroulanteClient2.ClientSelectionne != null)&& (listeDeroulanteFacture1.FactureSelectionne == null))
            {
                ficheFacture.Facture = Program.GMBD.EnumererFacture(null, new PDSGBD.MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                                                                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule
                                                                                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut"),
                                                                        new PDSGBD.MyDB.CodeSql("WHERE client.id_client = {0} AND statut.statut != \"En attente\"", listeDeroulanteClient2.ClientSelectionne.Id), null);
            }
            else
            {
                ficheFacture.Facture = Program.GMBD.EnumererFacture(null, new PDSGBD.MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                                                                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                                                                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule
                                                                                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut"),
                                                                           new PDSGBD.MyDB.CodeSql("WHERE statut.statut != \"En attente\""), null);
            }
        }

        private void buttonFactureVente_Click(object sender, EventArgs e)
        {
            panelFactureVente.BringToFront();
            buttonFactureVente.Enabled = false;
            buttonFactureReparation.Enabled = true;
        }

        private void buttonFactureReparation_Click(object sender, EventArgs e)
        {
            panelFacturesReparationsEntretiens.BringToFront();
            buttonFactureReparation.Enabled = false;
            buttonFactureVente.Enabled = true;
        }

        private void ficheFacture_SizeChanged(object sender, EventArgs e)
        {
            RechargerFactureEntretienReparation();
        }

        private void buttonFactureEntretienReparation_Click(object sender, EventArgs e)
        {
            GenerationDocumentsPDF.GenerationFactureEntretienReparation(ficheFacture.FactureSelectionnee, false);
        }

        private void listeDeroulanteFacture1_Load(object sender, EventArgs e)
        {
            listeDeroulanteFacture1.Facture = Program.GMBD.EnumererFacture(null, new PDSGBD.MyDB.CodeSql(@"JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                                                                                           JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut")
                                                                               , new PDSGBD.MyDB.CodeSql("WHERE statut.statut != \"En attente\""), null);
        }

        private void listeDeroulanteFactureVente1_Load(object sender, EventArgs e)
        {
            listeDeroulanteFactureVente1.FactureVente = Program.GMBD.EnumererFactureVente(null, null, null, null);
        }
    }
}
