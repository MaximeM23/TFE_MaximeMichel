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
    public partial class FicheArticleFacture : UserControl
    {
        public int NombreDeLigne { get; private set; }

        public FicheArticleFacture()
        {
            InitializeComponent();
            listViewArticleFacture.View = View.Details;
            listViewArticleFacture.FullRowSelect = true;
            listViewArticleFacture.LabelEdit = false;
            listViewArticleFacture.Scrollable = true;
            listViewArticleFacture.AllowColumnReorder = false;
            listViewArticleFacture.MultiSelect = false;
            listViewArticleFacture.GridLines = true;
            listViewArticleFacture.HideSelection = false;
            listViewArticleFacture.Items.Clear();
            listViewArticleFacture.Columns.Clear();
            listViewArticleFacture.SelectedIndexChanged += listViewArticleFacture_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreArticleFacture
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

        public IEnumerable<Reparation> ArticleFacture
        {
            get
            {
                return listViewArticleFacture.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is Reparation)
                    .Select(Element => Element.Tag as Reparation);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Article sélectionné
        /// </summary>
        public Reparation ArticleSelectionnee
        {
            get
            {
                return (listViewArticleFacture.SelectedItems.Count == 1) && (listViewArticleFacture.SelectedItems[0].Tag is Reparation)
                    ? listViewArticleFacture.SelectedItems[0].Tag as Reparation
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewArticleFacture.Items)
                    {
                        if ((Element.Tag is Reparation) && (Element.Tag as Reparation).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewArticleFacture.SelectedItems.Clear();
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
            bool EstArticle = typeof(T).Equals(typeof(Reparation));
            if (!EstArticle) return false;
            listViewArticleFacture.Items.Clear();
            if (Entites == null) return false;
            int NbLignes = 0;
            if (EstArticle && (listViewArticleFacture.Columns.Count != 2))
            {
                listViewArticleFacture.Columns.Clear();

                listViewArticleFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "NomArticle",
                    Text = "Nom de l'Article",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewArticleFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "Quantite",
                    Text = "Quantité",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewArticleFacture.Columns.Add(new ColumnHeader()
                {
                    Name = "PrixUnitaire",
                    Text = "PrixUnitaire",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                Reparation ArticleFacture = Entite as Reparation;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = ArticleFacture.Article.NomArticle.ToString(),
                };
                NouvelElement.SubItems.Add(ArticleFacture.QuantiteArticle.ToString());                
                NouvelElement.SubItems.Add(ArticleFacture.Article.PrixUnite.ToString());      
                listViewArticleFacture.Items.Add(NouvelElement);               
            }

            listViewArticleFacture.Visible = false;
            foreach (ColumnHeader Colonne in listViewArticleFacture.Columns)
            {
                NbLignes++;
                Colonne.Width = listViewArticleFacture.Width / listViewArticleFacture.Columns.Count;
            }

            NombreDeLigne = NbLignes;
            listViewArticleFacture.Visible = true;
            listViewArticleFacture_SelectedIndexChanged(listViewArticleFacture, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'article
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewArticleFacture_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewArticleFacture.Clear();
        }
                
    }
}

