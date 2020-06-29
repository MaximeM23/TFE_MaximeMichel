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
    public partial class FicheFacture : UserControl
    {

        public FicheFacture()
        {
            InitializeComponent();
            listViewFacture.View = View.Details;
            listViewFacture.FullRowSelect = true;
            listViewFacture.LabelEdit = false;
            listViewFacture.Scrollable = true;
            listViewFacture.AllowColumnReorder = false;
            listViewFacture.MultiSelect = false;
            listViewFacture.GridLines = true;
            listViewFacture.HideSelection = false;
            listViewFacture.Items.Clear();
            listViewFacture.Columns.Clear();
            listViewFacture.SelectedIndexChanged += listViewFacture_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreFacture
        {
            get
            {
                return textBoxRecherche.Text;
            }
            set
            {
                if (value == null) value = string.Empty;
                if (value != textBoxRecherche.Text)
                {
                    textBoxRecherche.Text = value;
                }
            }
        }

        /// <summary>
        /// Evénement déclenché lorsque le filtre change
        /// </summary>
        public event EventHandler SurChangementFiltre = null;

        public IEnumerable<Facture> Facture
        {
            get
            {
                return listViewFacture.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is Facture)
                    .Select(Element => Element.Tag as Facture);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Facture sélectionné
        /// </summary>
        public Facture FactureSelectionnee
        {
            get
            {
                return (listViewFacture.SelectedItems.Count == 1) && (listViewFacture.SelectedItems[0].Tag is Facture)
                    ? listViewFacture.SelectedItems[0].Tag as Facture
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewFacture.Items)
                    {
                        if ((Element.Tag is Facture) && (Element.Tag as Facture).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewFacture.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection d'Facture
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des Factures et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstFacture = typeof(T).Equals(typeof(Facture));
            if (!EstFacture) return false;
            listViewFacture.Items.Clear();
            if (Entites == null) return false;
            if (EstFacture && (listViewFacture.Columns.Count != 2))
            {
                listViewFacture.Columns.Clear();

                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Prenom",
                    Text = "Prénom",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Nom",
                    Text = "Nom",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "NumeroFacture",
                    Text = "Numéro de facture",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Modele",
                    Text = "Modèle du véhicule",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Immatriculation",
                    Text = "Immatriculation",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Statut",
                    Text = "Statut",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                Facture Facture = Entite as Facture;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Facture.RendezVous.ClientVehicule.Client.Prenom,
                };
                NouvelElement.SubItems.Add(Facture.RendezVous.ClientVehicule.Client.Nom);                
                NouvelElement.SubItems.Add(Facture.NumeroFacture);
                NouvelElement.SubItems.Add(Facture.RendezVous.ClientVehicule.Vehicule.Modele);
                NouvelElement.SubItems.Add(Facture.RendezVous.ClientVehicule.Immatriculation);
                NouvelElement.SubItems.Add(Facture.RendezVous.Statut.StatutOperation);
                listViewFacture.Items.Add(NouvelElement);               
            }

            listViewFacture.Visible = false;
            foreach (ColumnHeader Colonne in listViewFacture.Columns)
            {
                Colonne.Width = listViewFacture.Width / listViewFacture.Columns.Count;
            }

            listViewFacture.Visible = true;
            listViewFacture_SelectedIndexChanged(listViewFacture, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'Facture
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);

            }
        }

        /// <summary>
        /// Evénement déclenché en cas de changement de contenu de la zone de texte pour le filtrage
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void textFiltre_TextChanged(object sender, EventArgs e)
        {
            if (SurChangementFiltre != null)
            {
                SurChangementFiltre(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Evénement déclenché en cas d'appui sur une touche quand la zone de texte pour le filtrage a le focus
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void textFiltre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (SurChangementFiltre != null)
                {
                    SurChangementFiltre(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Nettoie la listview des elements s'y trouvant
        /// </summary>
        public void NettoyerListView()
        {
            listViewFacture.Clear();
        }


        public void CacheTextBoxFiltre()
        {
            textBoxRecherche.Hide();
        }

    }
}

