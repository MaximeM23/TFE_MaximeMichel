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
    public partial class ListeDeroulanteAdresse : UserControl
    {
       
        private class Element
        {


            public Adresse Adresse { get; private set; }

            public Element(Adresse Adresse)
            {
                this.Adresse = Adresse;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1}",Adresse.CodePostal, Adresse.Localite);
            }

        }

        public IEnumerable<Adresse> Adresse
        {
            get
            {
                return comboBoxAdresse.Items.OfType<Element>().Select(Element => Element.Adresse);
            }
            set
            {
                if (value != null)
                {
                    comboBoxAdresse.Items.Clear();
                    foreach (Adresse Adresse in value)
                    {
                        comboBoxAdresse.Items.Add(new Element(Adresse));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxAdresse.SelectedIndex = Index - 1;
        }

        public Adresse AdresseSelectionne
        {
            get
            {
                return (comboBoxAdresse.SelectedItem is Element) ? (comboBoxAdresse.SelectedItem as Element).Adresse : null;
            }
            set
            {
                comboBoxAdresse.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxAdresse.Text = value.CodePostal + " - " + value.Localite;
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteAdresse()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteAdresse_SizeChanged;
            comboBoxAdresse.SelectedIndexChanged += ComboAdresse_SelectedIndexChanged;
        }


        private void ComboAdresse_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteAdresse_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxAdresse.Height);
        }
    }
}

