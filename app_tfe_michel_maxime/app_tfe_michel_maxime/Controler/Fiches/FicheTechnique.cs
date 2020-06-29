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
    public partial class FicheTechnique : UserControl
    {
       
        public FicheTechnique()
        {
            InitializeComponent();
            listViewTechnique.View = View.Details;
            listViewTechnique.FullRowSelect = true;
            listViewTechnique.LabelEdit = false;
            listViewTechnique.Scrollable = true;
            listViewTechnique.AllowColumnReorder = false;
            listViewTechnique.MultiSelect = false;
            listViewTechnique.GridLines = true;
            listViewTechnique.HideSelection = false;
            listViewTechnique.Items.Clear();
            listViewTechnique.Columns.Clear();
            listViewTechnique.SelectedIndexChanged += listViewTechnique_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreTechnique
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

        public IEnumerable<VehiculeCaracteristique> Caracteristique
        {
            get
            {
                return listViewTechnique.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is VehiculeCaracteristique)
                    .Select(Element => Element.Tag as VehiculeCaracteristique);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Caractèristique sélectionnée
        /// </summary>
        public VehiculeCaracteristique CaracteristiqueSelectionnee
        {
            get
            {
                return (listViewTechnique.SelectedItems.Count == 1) && (listViewTechnique.SelectedItems[0].Tag is VehiculeCaracteristique)
                    ? listViewTechnique.SelectedItems[0].Tag as VehiculeCaracteristique
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewTechnique.Items)
                    {
                        if ((Element.Tag is VehiculeCaracteristique) && (Element.Tag as VehiculeCaracteristique).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewTechnique.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection de caractéristique
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des caractèristiques et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstCaracteristique = typeof(T).Equals(typeof(VehiculeCaracteristique));
            if (!EstCaracteristique) return false;
            listViewTechnique.Items.Clear();
            if (Entites == null) return false;
            if (EstCaracteristique && (listViewTechnique.Columns.Count != 2))
            {
                listViewTechnique.Columns.Clear();

                listViewTechnique.Columns.Add(new ColumnHeader()
                {
                    Name = "Caracteristiques",
                    Text = "Caractèristiques",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewTechnique.Columns.Add(new ColumnHeader()
                {
                    Name = "Informations",
                    Text = "Informations",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                VehiculeCaracteristique Caracteristique = Entite as VehiculeCaracteristique;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Caracteristique.Caracteristique.NomCaracteristique.ToString(),
                };
                NouvelElement.SubItems.Add(Caracteristique.Valeur);            
                listViewTechnique.Items.Add(NouvelElement);               
            }

            listViewTechnique.Visible = false;
            foreach (ColumnHeader Colonne in listViewTechnique.Columns)
            {
                Colonne.Width = listViewTechnique.Width / listViewTechnique.Columns.Count;
            }

            listViewTechnique.Visible = true;
            listViewTechnique_SelectedIndexChanged(listViewTechnique, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection de caractéristique
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewTechnique_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewTechnique.Clear();
        }

        public void CacheTextBoxFiltre()
        {
            textBoxRecherche.Hide();
        }

    }
}

