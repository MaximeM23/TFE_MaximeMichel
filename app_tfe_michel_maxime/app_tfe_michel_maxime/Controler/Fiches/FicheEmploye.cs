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
    public partial class FicheEmploye : UserControl
    {

        public FicheEmploye()
        {
            InitializeComponent();
            listViewEmploye.View = View.Details;
            listViewEmploye.FullRowSelect = true;
            listViewEmploye.LabelEdit = false;
            listViewEmploye.Scrollable = true;
            listViewEmploye.AllowColumnReorder = false;
            listViewEmploye.MultiSelect = false;
            listViewEmploye.GridLines = true;
            listViewEmploye.HideSelection = false;
            listViewEmploye.Items.Clear();
            listViewEmploye.Columns.Clear();
            listViewEmploye.SelectedIndexChanged += listViewEmploye_SelectedIndexChanged;
        }


        /// <summary>
        /// Texte du filtre
        /// </summary>
        public string TexteFiltreEmploye
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

        public IEnumerable<Employe> Employe
        {
            get
            {
                return listViewEmploye.Items
                    .OfType<ListViewItem>()
                    .Where(Element => Element.Tag is Employe)
                    .Select(Element => Element.Tag as Employe);
            }
            set
            {
                MettreAJourListe(value);
            }
        }


        /// <summary>
        /// Employe sélectionné
        /// </summary>
        public Employe EmployeSelectionnee
        {
            get
            {
                return (listViewEmploye.SelectedItems.Count == 1) && (listViewEmploye.SelectedItems[0].Tag is Employe)
                    ? listViewEmploye.SelectedItems[0].Tag as Employe
                    : null;
            }
            set
            {
                if (value != null)
                {
                    foreach (ListViewItem Element in listViewEmploye.Items)
                    {
                        if ((Element.Tag is Employe) && (Element.Tag as Employe).Id.Equals(value.Id))
                        {
                            Element.Selected = true;
                            return;
                        }
                    }
                }
                listViewEmploye.SelectedItems.Clear();
            }
        }


        /// <summary>
        /// Evénement déclenché quand il y a un changement de sélection d'Employe
        /// </summary>
        public event EventHandler SurChangementSelection = null;

        /// <summary>
        /// Met à jour la listview des Employes et y insére les elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Entites"></param>
        /// <returns></returns>
        private bool MettreAJourListe<T>(IEnumerable<T> Entites)
            where T : class, IEntiteMySQL
        {
            bool EstEmploye = typeof(T).Equals(typeof(Employe));
            if (!EstEmploye) return false;
            listViewEmploye.Items.Clear();
            if (Entites == null) return false;
            if (EstEmploye && (listViewEmploye.Columns.Count != 2))
            {
                listViewEmploye.Columns.Clear();

                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "Prenom",
                    Text = "Prénom",
                    TextAlign = HorizontalAlignment.Center,                              
                });
                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "Nom",
                    Text = "Nom",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "Adresse",
                    Text = "Adresse",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "CPLocalite",
                    Text = "Code postal / Localité",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "Poste",
                    Text = "Poste",
                    TextAlign = HorizontalAlignment.Center,
                });
                listViewEmploye.Columns.Add(new ColumnHeader()
                {
                    Name = "CompteActif",
                    Text = "Statut du compte",
                    TextAlign = HorizontalAlignment.Center,
                });
            }

            foreach (T Entite in Entites)
            {
                Employe Employe = Entite as Employe;

                ListViewItem NouvelElement = new ListViewItem()
                {
                    Tag = Entite,
                    Text = Employe.Prenom,
                };
                NouvelElement.SubItems.Add(Employe.Nom);                
                NouvelElement.SubItems.Add(string.Format("{0}, {1}",Employe.Rue,Employe.NumeroHabitation));
                NouvelElement.SubItems.Add(string.Format("{0}, {1}", Employe.Adresse.CodePostal, Employe.Adresse.Localite));
                NouvelElement.SubItems.Add(Employe.Statut.NomStatut);
                string CompteActif = null;
                if(Employe.CompteActif == 1)
                {
                    CompteActif = "Actif";
                }
                else if(Employe.CompteActif == 0)
                {
                    CompteActif = "Non actif";
                }
                NouvelElement.SubItems.Add(CompteActif);
                listViewEmploye.Items.Add(NouvelElement);               
            }

            listViewEmploye.Visible = false;
            foreach (ColumnHeader Colonne in listViewEmploye.Columns)
            {
                Colonne.Width = listViewEmploye.Width / listViewEmploye.Columns.Count;
            }

            listViewEmploye.Visible = true;
            listViewEmploye_SelectedIndexChanged(listViewEmploye, EventArgs.Empty);
            return true;
        }



        /// <summary>
        /// Evénement déclenché en cas de changement de sélection d'Employe
        /// </summary>
        /// <param name="sender">Emetteur ayant déclenché l'événement</param>
        /// <param name="e">Descriptif de l'événement</param>
        private void listViewEmploye_SelectedIndexChanged(object sender, EventArgs e)
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
            listViewEmploye.Clear();
        }

        public void HideFiltre()
        {
            textBoxRecherche.Hide();
        }
        
    }
}

