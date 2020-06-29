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
    public partial class FicheArticle : UserControl
    {

        public FicheArticle()
        {
            InitializeComponent();
            listViewArticle.View = View.Details;
            listViewArticle.FullRowSelect = true;
            listViewArticle.LabelEdit = false;
            listViewArticle.Scrollable = true;
            listViewArticle.AllowColumnReorder = false;
            listViewArticle.MultiSelect = false;
            listViewArticle.GridLines = true;
            listViewArticle.HideSelection = false;
            listViewArticle.Items.Clear();
            listViewArticle.Columns.Clear();
            listViewArticle.SelectedIndexChanged += listViewArticle_SelectedIndexChanged;
        }        

        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreArticle
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

        public IEnumerable<Article> Article
        {
            get
            {
                return listViewArticle.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is Article)
                    .Select(Element => Element.Tag as Article);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Article sélectionné
        /// </summary>
        public Article ArticleSelectionnee
        {
            get
            {
                return (listViewArticle.SelectedItems.Count == 1) && (listViewArticle.SelectedItems[0].Tag is Article)
                    ? listViewArticle.SelectedItems[0].Tag as Article
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewArticle.Items)
                    {
                        if ((Element.Tag is Article) && (Element.Tag as Article).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                else
                {
                    listViewArticle.Refresh();
                }
                listViewArticle.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection d'article
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des articles et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstArticle = typeof(T).Equals(typeof(Article));
            if (!EstArticle) return false;
            listViewArticle.Items.Clear();
            if (Entites == null) return false;
            if (EstArticle && (listViewArticle.Columns.Count != 2))
            {
                listViewArticle.Columns.Clear();

                listViewArticle.Columns.Add(new ColumnHeader()
                {
                    Name = "NomArticle",
                    Text = "Nom de l'article",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewArticle.Columns.Add(new ColumnHeader()
                {
                    Name = "Quantite",
                    Text = "Quantité",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewArticle.Columns.Add(new ColumnHeader()
                {
                    Name = "PrixUnitaire",
                    Text = "Prix unitaire",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                Article Article = Entite as Article;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Article.NomArticle.ToString(),
                };
                NouvelElement.SubItems.Add(Article.Stock.ToString());                
                NouvelElement.SubItems.Add(string.Format("{0} €", Article.PrixUnite.ToString())); 
                listViewArticle.Items.Add(NouvelElement);               
            }

            listViewArticle.Visible = false;
            foreach (ColumnHeader Colonne in listViewArticle.Columns)
            {
                Colonne.Width = listViewArticle.Width / listViewArticle.Columns.Count;
            }

            listViewArticle.Visible = true;
            listViewArticle_SelectedIndexChanged(listViewArticle, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'article
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewArticle_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewArticle.Clear();
        }
        
    }
}

