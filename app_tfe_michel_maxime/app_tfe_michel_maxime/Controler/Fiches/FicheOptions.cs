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
    public partial class FicheOptions : UserControl
    {
        private bool m_FicheAvecFiltre = true;

        public bool FicheAvecFiltre
        {
            get
            {
                return m_FicheAvecFiltre;
            }
            set
            {
                m_FicheAvecFiltre = value;
            }
        }

        public FicheOptions()
        {
            InitializeComponent();
            listViewOptions.View = View.Details;
            listViewOptions.FullRowSelect = true;
            listViewOptions.LabelEdit = false;
            listViewOptions.Scrollable = true;
            listViewOptions.AllowColumnReorder = false;
            listViewOptions.MultiSelect = false;
            listViewOptions.GridLines = true;
            listViewOptions.HideSelection = false;
            listViewOptions.Items.Clear();
            listViewOptions.Columns.Clear();
            listViewOptions.SelectedIndexChanged += listViewOptions_SelectedIndexChanged;            
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreOptions
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

        public IEnumerable<OptionVehicule> Options
        {
            get
            {
                return listViewOptions.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is OptionVehicule)
                    .Select(Element => Element.Tag as OptionVehicule);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Options sélectionné
        /// </summary>
        public OptionVehicule OptionsSelectionnee
        {
            get
            {
                return (listViewOptions.SelectedItems.Count == 1) && (listViewOptions.SelectedItems[0].Tag is OptionVehicule)
                    ? listViewOptions.SelectedItems[0].Tag as OptionVehicule
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewOptions.Items)
                    {
                        if ((Element.Tag is OptionVehicule) && (Element.Tag as OptionVehicule).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewOptions.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection d'Options
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des Optionss et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstOptions = typeof(T).Equals(typeof(OptionVehicule));
            if (!EstOptions) return false;
            listViewOptions.Items.Clear();
            if (Entites == null) return false;
            if (EstOptions && (listViewOptions.Columns.Count != 2))
            {
                listViewOptions.Columns.Clear();                
                listViewOptions.Columns.Add(new ColumnHeader()
                {
                    Name = "NomOptions",
                    Text = "Nom de l'option",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewOptions.Columns.Add(new ColumnHeader()
                {
                    Name = "Prix",
                    Text = "Prix",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewOptions.Columns.Add(new ColumnHeader()
                {
                    Name = "TypeOption",
                    Text = "Type de l'option",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                OptionVehicule Options = Entite as OptionVehicule;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Options.NomOption.ToString(),
                };
                NouvelElement.SubItems.Add(string.Format("{0} €", Options.Prix.ToString()));
                NouvelElement.SubItems.Add(Options.TypeOption.NomType);
                listViewOptions.Items.Add(NouvelElement);               
            }

            listViewOptions.Visible = false;
            foreach (ColumnHeader Colonne in listViewOptions.Columns)
            {
                Colonne.Width = listViewOptions.Width / listViewOptions.Columns.Count;
            }
            listViewOptions.Visible = true;
            listViewOptions_SelectedIndexChanged(listViewOptions, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'Options
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewOptions_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewOptions.Clear();
        }

        public void CacheTextBoxFiltre()
        {
            textBoxRecherche.Hide();
        }

        private void FicheOptions_Load(object sender, EventArgs e)
        {
            if(FicheAvecFiltre == false)
            {
                textBoxRecherche.Hide();
            }
        }
    }
}

