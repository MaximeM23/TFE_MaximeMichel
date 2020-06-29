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
    public partial class ListeDeroulantePackOptions : UserControl
    {
       
        private class Element
        {

            public PackOptionPackVehicule PackOptionPackVehicule { get; private set; }

            public Element(PackOptionPackVehicule PackOptionPackVehicule)
            {
                this.PackOptionPackVehicule = PackOptionPackVehicule;
            }

            public override string ToString()
            {
                return string.Format("{0}",PackOptionPackVehicule.NomPack);
            }

        }

        public string TexteAfficher
        {
            get
            {
                return comboBoxPackOptionPackVehicule.Text;
            }
        }

        public IEnumerable<PackOptionPackVehicule> PackOptionPackVehicule
        {
            get
            {
                return comboBoxPackOptionPackVehicule.Items.OfType<Element>().Select(Element => Element.PackOptionPackVehicule);
            }
            set
            {
                if (value != null)
                {
                    comboBoxPackOptionPackVehicule.Items.Clear();
                    foreach (PackOptionPackVehicule PackOptionPackVehicule in value)
                    {
                        comboBoxPackOptionPackVehicule.Items.Add(new Element(PackOptionPackVehicule));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxPackOptionPackVehicule.SelectedIndex = Index - 1;
        }

        public PackOptionPackVehicule PackOptionPackVehiculeSelectionne
        {
            get
            {
                return (comboBoxPackOptionPackVehicule.SelectedItem is Element) ? (comboBoxPackOptionPackVehicule.SelectedItem as Element).PackOptionPackVehicule : null;
            }
            set
            {
                comboBoxPackOptionPackVehicule.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxPackOptionPackVehicule.Text = value.NomPack;
                else comboBoxPackOptionPackVehicule.Text = "";
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulantePackOptions()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulantePackOptionPackVehicule_SizeChanged;
            comboBoxPackOptionPackVehicule.SelectedIndexChanged += ComboPackOptionPackVehicule_SelectedIndexChanged;
        }


        private void ComboPackOptionPackVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulantePackOptionPackVehicule_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxPackOptionPackVehicule.Height);
        }
        
    }
}

