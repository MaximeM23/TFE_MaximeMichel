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
    public partial class ListeDeroulanteTypeVehicule : UserControl
    {
       
        private class Element
        {


            public TypeVehicule TypeVehicule { get; private set; }

            public Element(TypeVehicule TypeVehicule)
            {
                this.TypeVehicule = TypeVehicule;
            }

            public override string ToString()
            {
                return string.Format("{0}", TypeVehicule.NomDuType);
            }

        }

        public IEnumerable<TypeVehicule> TypeVehicule
        {
            get
            {
                return comboBoxTypeVehicule.Items.OfType<Element>().Select(Element => Element.TypeVehicule);
            }
            set
            {
                if (value != null)
                {
                    comboBoxTypeVehicule.Items.Clear();
                    foreach (TypeVehicule TypeVehicule in value)
                    {
                        comboBoxTypeVehicule.Items.Add(new Element(TypeVehicule));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxTypeVehicule.SelectedIndex = Index - 1;
        }

        public TypeVehicule TypeVehiculeSelectionne
        {
            get
            {
                return (comboBoxTypeVehicule.SelectedItem is Element) ? (comboBoxTypeVehicule.SelectedItem as Element).TypeVehicule : null;
            }
            set
            {
                comboBoxTypeVehicule.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxTypeVehicule.Text = value.NomDuType.ToString();
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteTypeVehicule()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteTypeVehicule_SizeChanged;
            comboBoxTypeVehicule.SelectedIndexChanged += TypeVehicule_SelectedIndexChanged;
        }


        private void TypeVehicule_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteTypeVehicule_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxTypeVehicule.Height);
        }
    }
}

