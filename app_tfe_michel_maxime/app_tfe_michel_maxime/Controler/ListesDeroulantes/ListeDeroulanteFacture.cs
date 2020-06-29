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
    public partial class ListeDeroulanteFacture : UserControl
    {
       
        private class Element
        {


            public Facture Facture { get; private set; }

            public Element(Facture Facture)
            {
                this.Facture = Facture;
            }


            public override string ToString()
            {
                return string.Format("{0}", Facture.NumeroFacture);
            }

        }

        public IEnumerable<Facture> Facture
        {
            get
            {
                return comboBoxFacture.Items.OfType<Element>().Select(Element => Element.Facture);
            }
            set
            {
                if (value != null)
                {
                    comboBoxFacture.Items.Clear();
                    foreach (Facture Facture in value)
                    {
                        comboBoxFacture.Items.Add(new Element(Facture));
                    }
                }
                else if(value == null)
                {
                    comboBoxFacture.Text = "";
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxFacture.SelectedIndex = Index - 1;
        }

        public Facture FactureSelectionne
        {
            get
            {
                return (comboBoxFacture.SelectedItem is Element) ? (comboBoxFacture.SelectedItem as Element).Facture : null;
            }
            set
            {
                comboBoxFacture.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null)
                {
                    comboBoxFacture.Text = string.Format("{0}",value.NumeroFacture);
                }
                
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteFacture()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteFacture_SizeChanged;
            comboBoxFacture.SelectedIndexChanged += ComboFacture_SelectedIndexChanged;
        }


        private void ComboFacture_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteFacture_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxFacture.Height);
        }
        
        private void comboBoxFacture_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (SurChangementSelection != null)
                {
                    SurChangementSelection(this, EventArgs.Empty);
                }
            }
        }
    }
}

