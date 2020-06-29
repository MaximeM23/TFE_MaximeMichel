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
    public partial class FicheFactureVente : UserControl
    {

        public FicheFactureVente()
        {
            InitializeComponent();
            listViewFactureVente.View = View.Details;
            listViewFactureVente.FullRowSelect = true;
            listViewFactureVente.LabelEdit = false;
            listViewFactureVente.Scrollable = true;
            listViewFactureVente.AllowColumnReorder = false;
            listViewFactureVente.MultiSelect = false;
            listViewFactureVente.GridLines = true;
            listViewFactureVente.HideSelection = false;
            listViewFactureVente.Items.Clear();
            listViewFactureVente.Columns.Clear();
            listViewFactureVente.SelectedIndexChanged += listViewFactureVente_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreFactureVente
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

        public IEnumerable<FactureVente> FactureVente
        {
            get
            {
                return listViewFactureVente.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is FactureVente)
                    .Select(Element => Element.Tag as FactureVente);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// FactureVente sélectionné
        /// </summary>
        public FactureVente FactureVenteSelectionnee
        {
            get
            {
                return (listViewFactureVente.SelectedItems.Count == 1) && (listViewFactureVente.SelectedItems[0].Tag is FactureVente)
                    ? listViewFactureVente.SelectedItems[0].Tag as FactureVente
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewFactureVente.Items)
                    {
                        if ((Element.Tag is FactureVente) && (Element.Tag as FactureVente).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewFactureVente.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection d'FactureVente
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des FactureVentes et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstFactureVente = typeof(T).Equals(typeof(FactureVente));
            if (!EstFactureVente) return false;
            listViewFactureVente.Items.Clear();
            if (Entites == null) return false;
            if (EstFactureVente && (listViewFactureVente.Columns.Count != 2))
            {
                listViewFactureVente.Columns.Clear();

                listViewFactureVente.Columns.Add(new ColumnHeader()
                {
                    Name = "Prenom",
                    Text = "Prénom",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewFactureVente.Columns.Add(new ColumnHeader()
                {
                    Name = "Nom",
                    Text = "Nom",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFactureVente.Columns.Add(new ColumnHeader()
                {
                    Name = "NumeroFacture",
                    Text = "Numéro de facture",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFactureVente.Columns.Add(new ColumnHeader()
                {
                    Name = "Modele",
                    Text = "Modèle du véhicule",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewFactureVente.Columns.Add(new ColumnHeader()
                {
                    Name = "Statut",
                    Text = "Statut",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                FactureVente FactureVente = Entite as FactureVente;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = FactureVente.Client.Prenom,
                };
                NouvelElement.SubItems.Add(FactureVente.Client.Nom);                
                NouvelElement.SubItems.Add(FactureVente.NumeroFacture);
                NouvelElement.SubItems.Add(FactureVente.VehiculeVente.Vehicule.Modele);
                NouvelElement.SubItems.Add(FactureVente.VehiculeVente.StatutLivraison.StatutOperation);
                listViewFactureVente.Items.Add(NouvelElement);               
            }

            listViewFactureVente.Visible = false;
            foreach (ColumnHeader Colonne in listViewFactureVente.Columns)
            {
                Colonne.Width = listViewFactureVente.Width / listViewFactureVente.Columns.Count;
            }

            listViewFactureVente.Visible = true;
            listViewFactureVente_SelectedIndexChanged(listViewFactureVente, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'FactureVente
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewFactureVente_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewFactureVente.Clear();
        }


        public void CacheTextBoxFiltre()
        {
            textBoxRecherche.Hide();
        }

    }
}

