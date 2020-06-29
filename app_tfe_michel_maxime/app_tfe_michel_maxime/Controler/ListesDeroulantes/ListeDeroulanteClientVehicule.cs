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
    public partial class ListeDeroulanteClientVehicule : UserControl
    {
       
        private class Element
        {


            public ClientVehicule ClientVehicule { get; private set; }

            public Element(ClientVehicule ClientVehicule)
            {
                this.ClientVehicule = ClientVehicule;
            }


            public override string ToString()
            {                
                return string.Format("{0} - {1}", ClientVehicule.Vehicule.Modele, ClientVehicule.Immatriculation);
            }

        }

        public IEnumerable<ClientVehicule> ClientVehicule
        {
            get
            {
                return comboBoxClientVehicule.Items.OfType<Element>().Select(Element => Element.ClientVehicule);
            }
            set
            {
                if (value != null)
                {
                    comboBoxClientVehicule.Items.Clear();
                    foreach (ClientVehicule ClientVehicule in value)
                    {
                        comboBoxClientVehicule.Items.Add(new Element(ClientVehicule));
                    }
                }
                else if(value == null)
                {
                    comboBoxClientVehicule.Items.Clear();
                    comboBoxClientVehicule.Text = "";
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxClientVehicule.SelectedIndex = Index - 1;
        }

        public ClientVehicule ClientVehiculeSelectionne
        {
            get
            {
                return (comboBoxClientVehicule.SelectedItem is Element) ? (comboBoxClientVehicule.SelectedItem as Element).ClientVehicule : null;
            }
            set
            {
                comboBoxClientVehicule.SelectedItem = (value != null) ? new Element(value) : null;
                if ((value != null) && (value.Vehicule != null))
                {
                    comboBoxClientVehicule.Text = string.Format("{0} - {1}", value.Vehicule.Modele, value.Immatriculation);
                }
                
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteClientVehicule()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteClientVehicule_SizeChanged;
            comboBoxClientVehicule.SelectedIndexChanged += ComboClientVehicule_SelectedIndexChanged;
        }


        private void ComboClientVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteClientVehicule_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxClientVehicule.Height);
        }
    }
}

