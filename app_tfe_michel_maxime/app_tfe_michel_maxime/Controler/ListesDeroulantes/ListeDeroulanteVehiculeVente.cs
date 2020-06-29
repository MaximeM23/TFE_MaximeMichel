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
    public partial class ListeDeroulanteVehiculeVente : UserControl
    {
       
        private class Element
        {


            public VehiculeVente VehiculeVente { get; private set; }

            public Element(VehiculeVente VehiculeVente)
            {
                this.VehiculeVente = VehiculeVente;
            }


            public override string ToString()
            {
                return string.Format("{0}", VehiculeVente.NumeroChassis);
            }

        }

        public IEnumerable<VehiculeVente> VehiculeVente
        {
            get
            {
                return comboBoxVehiculeVente.Items.OfType<Element>().Select(Element => Element.VehiculeVente);
            }
            set
            {
                if (value != null)
                {
                    comboBoxVehiculeVente.Items.Clear();
                    foreach (VehiculeVente VehiculeVente in value)
                    {
                        comboBoxVehiculeVente.Items.Add(new Element(VehiculeVente));
                    }
                }
                else if(value == null)
                {
                    comboBoxVehiculeVente.Text = "";
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxVehiculeVente.SelectedIndex = Index - 1;
        }

        public VehiculeVente VehiculeVenteSelectionne
        {
            get
            {
                return (comboBoxVehiculeVente.SelectedItem is Element) ? (comboBoxVehiculeVente.SelectedItem as Element).VehiculeVente : null;
            }
            set
            {
                comboBoxVehiculeVente.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxVehiculeVente.Text = string.Format("{0}", value.NumeroChassis);
                else if (value == null) comboBoxVehiculeVente.Text = "";
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteVehiculeVente()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteVehiculeVente_SizeChanged;
            comboBoxVehiculeVente.SelectedIndexChanged += ComboVehiculeVente_SelectedIndexChanged;
        }


        private void ComboVehiculeVente_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteVehiculeVente_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxVehiculeVente.Height);
        }
    }
}

