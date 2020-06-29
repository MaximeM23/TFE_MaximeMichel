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
    public partial class ListeDeroulanteFactureVente : UserControl
    {
       
        private class Element
        {


            public FactureVente FactureVente { get; private set; }

            public Element(FactureVente FactureVente)
            {
                this.FactureVente = FactureVente;
            }


            public override string ToString()
            {
                return string.Format("{0}", FactureVente.NumeroFacture);
            }

        }

        public IEnumerable<FactureVente> FactureVente
        {
            get
            {
                return comboBoxFactureVente.Items.OfType<Element>().Select(Element => Element.FactureVente);
            }
            set
            {
                if (value != null)
                {
                    comboBoxFactureVente.Items.Clear();
                    foreach (FactureVente FactureVente in value)
                    {
                        comboBoxFactureVente.Items.Add(new Element(FactureVente));
                    }
                }
                else if(value == null)
                {
                    comboBoxFactureVente.Text = "";
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxFactureVente.SelectedIndex = Index - 1;
        }

        public FactureVente FactureVenteSelectionne
        {
            get
            {
                return (comboBoxFactureVente.SelectedItem is Element) ? (comboBoxFactureVente.SelectedItem as Element).FactureVente : null;
            }
            set
            {
                comboBoxFactureVente.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null)
                {
                    comboBoxFactureVente.Text = string.Format("{0}",value.NumeroFacture);
                }
                
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteFactureVente()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteFactureVente_SizeChanged;
            comboBoxFactureVente.SelectedIndexChanged += ComboFactureVente_SelectedIndexChanged;
        }


        private void ComboFactureVente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteFactureVente_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxFactureVente.Height);
        }

        private void comboBoxFactureVente_KeyDown(object sender, KeyEventArgs e)
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

