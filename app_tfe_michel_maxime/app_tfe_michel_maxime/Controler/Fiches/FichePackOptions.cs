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
    public partial class FichePackOptions : UserControl
    {

        public FichePackOptions()
        {
            InitializeComponent();
            listViewPackOptions.View = View.Details;
            listViewPackOptions.FullRowSelect = true;
            listViewPackOptions.LabelEdit = false;
            listViewPackOptions.Scrollable = true;
            listViewPackOptions.AllowColumnReorder = false;
            listViewPackOptions.MultiSelect = false;
            listViewPackOptions.GridLines = true;
            listViewPackOptions.HideSelection = false;
            listViewPackOptions.Items.Clear();
            listViewPackOptions.Columns.Clear();
            listViewPackOptions.SelectedIndexChanged += listViewPackOptions_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltrePackOptions
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

        public IEnumerable<PackOptionPackVehicule> PackOptions
        {
            get
            {
                return listViewPackOptions.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is PackOptionPackVehicule)
                    .Select(Element => Element.Tag as PackOptionPackVehicule);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// PackOptions sélectionné
        /// </summary>
        public PackOptionPackVehicule PackOptionsSelectionnee
        {
            get
            {
                return (listViewPackOptions.SelectedItems.Count == 1) && (listViewPackOptions.SelectedItems[0].Tag is PackOptionPackVehicule)
                    ? listViewPackOptions.SelectedItems[0].Tag as PackOptionPackVehicule
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewPackOptions.Items)
                    {
                        if ((Element.Tag is PackOptionPackVehicule) && (Element.Tag as PackOptionPackVehicule).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewPackOptions.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection de pack d'option
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des PackOptions et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstPackOptions = typeof(T).Equals(typeof(PackOptionPackVehicule));
            if (!EstPackOptions) return false;
            listViewPackOptions.Items.Clear();
            if (Entites == null) return false;
            if (EstPackOptions && (listViewPackOptions.Columns.Count != 2))
            {
                listViewPackOptions.Columns.Clear();

                listViewPackOptions.Columns.Add(new ColumnHeader()
                {
                    Name = "NomPackOptions",
                    Text = "Nom du pack",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewPackOptions.Columns.Add(new ColumnHeader()
                {
                    Name = "Prix",
                    Text = "Prix",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                PackOptionPackVehicule PackOptions = Entite as PackOptionPackVehicule;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = PackOptions.NomPack.ToString(),
                };
                NouvelElement.SubItems.Add(string.Format("{0} €", PackOptions.PrixPack.ToString())); 
                listViewPackOptions.Items.Add(NouvelElement);               
            }

            listViewPackOptions.Visible = false;
            foreach (ColumnHeader Colonne in listViewPackOptions.Columns)
            {
                Colonne.Width = listViewPackOptions.Width / listViewPackOptions.Columns.Count;
            }

            listViewPackOptions.Visible = true;
            listViewPackOptions_SelectedIndexChanged(listViewPackOptions, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'un pack d'option
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewPackOptions_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewPackOptions.Clear();
        }

        public void CacheTextBoxFiltre()
        {
            textBoxRecherche.Hide();
        }
        
    }
}

