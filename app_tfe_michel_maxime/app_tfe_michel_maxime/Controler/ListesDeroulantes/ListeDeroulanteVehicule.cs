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
    public partial class ListeDeroulanteVehicule : UserControl
    {
       
        private class Element
        {


            public Vehicule Vehicule { get; private set; }

            public Element(Vehicule Vehicule)
            {
                this.Vehicule = Vehicule;
            }


            public override string ToString()
            {
                return string.Format("{0}", Vehicule.Modele);
            }

        }

        public IEnumerable<Vehicule> Vehicule
        {
            get
            {
                return comboBoxVehicule.Items.OfType<Element>().Select(Element => Element.Vehicule);
            }
            set
            {
                if (value != null)
                {
                    comboBoxVehicule.Items.Clear();
                    foreach (Vehicule Vehicule in value)
                    {
                        comboBoxVehicule.Items.Add(new Element(Vehicule));
                    }
                }
                else if(value == null)
                {
                    comboBoxVehicule.Text = "";
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxVehicule.SelectedIndex = Index - 1;
        }

        public Vehicule VehiculeSelectionne
        {
            get
            {
                return (comboBoxVehicule.SelectedItem is Element) ? (comboBoxVehicule.SelectedItem as Element).Vehicule : null;
            }
            set
            {
                comboBoxVehicule.SelectedItem = (value != null) ? new Element(value) : null;
                if(value != null) comboBoxVehicule.Text = string.Format("{0}",value.Modele);
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteVehicule()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteVehicule_SizeChanged;
            comboBoxVehicule.SelectedIndexChanged += ComboVehicule_SelectedIndexChanged;
        }


        private void ComboVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteVehicule_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxVehicule.Height);
        }
    }
}

