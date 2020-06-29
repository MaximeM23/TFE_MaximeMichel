using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public partial class CalendrierRdv : UserControl
    {
        
        public Facture FactureSelectionnee
        {
            get
            {
                return (listViewClientRdv.SelectedItems.Count == 1) && (listViewClientRdv.SelectedItems[0].Tag is Facture)
                    ? listViewClientRdv.SelectedItems[0].Tag as Facture
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewClientRdv.Items)
                    {
                        if ((Element.Tag is Facture) && (Element.Tag as Facture).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
            }
        }

        public CalendrierRdv()
        {
            InitializeComponent();
            listViewClientRdv.View = View.Details;
            listViewClientRdv.FullRowSelect = true;
            listViewClientRdv.LabelEdit = false;
            listViewClientRdv.AllowColumnReorder = false;
            listViewClientRdv.MultiSelect = false;
            listViewClientRdv.GridLines = true;
            listViewClientRdv.HideSelection = false;
            listViewClientRdv.Items.Clear();
            listViewClientRdv.Columns.Clear();
            listViewClientRdv.SelectedIndexChanged += listViewRdv_SelectedIndexChanged;
        }

        public IEnumerable<Facture> Facture
        {
            get
            {
                return listViewClientRdv.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is Facture)
                    .Select(Element => Element.Tag as Facture);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstRdv = typeof(T).Equals(typeof(Facture));
            if (!EstRdv) return false;
            listViewClientRdv.Items.Clear();
            if (Entites == null) return false;
            if (EstRdv && (listViewClientRdv.Columns.Count != 2))
            {
                listViewClientRdv.Columns.Clear();

                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "Statut",
                    Text = "Statut",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "PrenomNom",
                    Text = "Nom - Prénom",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "DateArrivee",
                    Text = "Date d'arrivée",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "DateFin",
                    Text = "Date de fin",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "Modele",
                    Text = "Modèle",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "Immatriculation",
                    Text = "Immatriculation",
                    TextAlign = HorizontalAlignment.Left
                });
                listViewClientRdv.Columns.Add(new ColumnHeader()
                {
                    Name = "Type",
                    Text = "Type",
                    TextAlign = HorizontalAlignment.Left
                });
            }


            foreach (T Entite in Entites)
            {

                Facture Facture = Entite as Facture;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Facture.RendezVous.Statut.StatutOperation,
                };
                
                NouvelElement.SubItems.Add(string.Format("{0} - {1}", Facture.RendezVous.ClientVehicule.Client.Nom, Facture.RendezVous.ClientVehicule.Client.Prenom));
                NouvelElement.SubItems.Add(Facture.RendezVous.DateDebut.ToString());
                NouvelElement.SubItems.Add(Facture.RendezVous.DateFin.ToString());
                NouvelElement.SubItems.Add(Facture.RendezVous.ClientVehicule.Vehicule.Modele);
                NouvelElement.SubItems.Add(Facture.RendezVous.ClientVehicule.Immatriculation);
                               
                                
                FactureEntretien AUnEntretien = Program.GMBD.EnumererFactureEntretien(null, null, new MyDB.CodeSql("WHERE fk_id_facture = {0}", Facture.Id),null).FirstOrDefault();
                if ((Facture.Informations != "") && (AUnEntretien == null))
                { 
                     NouvelElement.SubItems.Add("Réparation");
                }
                else if ((Facture.Informations == "") && (AUnEntretien != null))
                {
                    NouvelElement.SubItems.Add("Entretien");
                }
                else if ((Facture.Informations != "") && (AUnEntretien != null))
                {
                    NouvelElement.SubItems.Add("Réparation et entretien");
                }              

                listViewClientRdv.Items.Add(NouvelElement);

            }

            listViewClientRdv.Visible = false;
            foreach (ColumnHeader Colonne in listViewClientRdv.Columns)
            {
                Colonne.TextAlign = HorizontalAlignment.Center;
                Colonne.Width = listViewClientRdv.Width / listViewClientRdv.Columns.Count;
            }
            listViewClientRdv.Visible = true;
            listViewRdv_SelectedIndexChanged(listViewClientRdv, EventArgs.Empty);
            return true;
        }

        public event EventHandler SurChangementSelection = null;

        private void listViewRdv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        public void ChargerListViewRdv()
        {
            if(monthCalendar.SelectionStart.ToLocalTime() == monthCalendar.SelectionEnd.ToLocalTime())
            {
                Facture = Program.GMBD.EnumererFacture(
                null,
                new MyDB.CodeSql(@" JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut
                                JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                JOIN adresse ON client.fk_id_adresse = adresse.id_adresse 
                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
                new MyDB.CodeSql("WHERE date_debut BETWEEN {0} AND {1} OR date_fin BETWEEN {0} AND {1}", monthCalendar.SelectionStart.ToLocalTime()
                                                                                                       , monthCalendar.SelectionEnd.ToLocalTime().AddHours(23.59)),
                new MyDB.CodeSql("ORDER BY date_debut"));
            }
            else
            {
                Facture = Program.GMBD.EnumererFacture(
                null,
                new MyDB.CodeSql(@" JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation
                                JOIN client_vehicule ON rendez_vous_entretien_reparation.fk_id_client_vehicule = client_vehicule.id_client_vehicule
                                JOIN client ON client_vehicule.fk_id_client = client.id_client
                                JOIN statut ON rendez_vous_entretien_reparation.fk_id_statut = statut.id_statut
                                JOIN civilite ON client.fk_id_civilite = civilite.id_civilite
                                JOIN adresse ON client.fk_id_adresse = adresse.id_adresse 
                                JOIN vehicule ON client_vehicule.fk_id_vehicule = vehicule.id_vehicule"),
                new MyDB.CodeSql("WHERE date_debut BETWEEN {0} AND {1} OR date_fin BETWEEN {0} AND {1}", (monthCalendar.SelectionStart.ToLocalTime().Hour == 0) ? monthCalendar.SelectionStart.ToLocalTime() : monthCalendar.SelectionStart.ToLocalTime().AddHours(-2)
                                                                                                       , (monthCalendar.SelectionEnd.ToLocalTime().Hour == 0) ? monthCalendar.SelectionEnd.ToLocalTime() : monthCalendar.SelectionEnd.ToLocalTime().AddHours(-2)),
                new MyDB.CodeSql("ORDER BY date_debut"));
            }

        }

        // Permet l'affectation d'un événement lors du changement de sélection de date depuis un formulaire externe
        public EventHandler SurChangementDate = null;

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            ChargerListViewRdv();
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
            if(SurChangementDate != null)
            {
                SurChangementDate(this, EventArgs.Empty);
            }
        }

        public void RefreshListe()
        {
            listViewClientRdv.Clear();
            monthCalendar.SelectionStart = DateTime.Now;
            monthCalendar.SelectionEnd = DateTime.Now;
        }

        public void RetirerSelection()
        {
            listViewClientRdv.SelectedItems.Clear();
        }
        
    }
}
