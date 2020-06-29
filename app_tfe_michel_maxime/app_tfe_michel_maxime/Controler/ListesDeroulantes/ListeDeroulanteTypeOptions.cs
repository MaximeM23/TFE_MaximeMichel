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
    public partial class ListeDeroulanteTypeOptions : UserControl
    {
       
        private class Element
        {


            public TypeOption TypeOptions { get; private set; }

            public Element(TypeOption TypeOptions)
            {
                this.TypeOptions = TypeOptions;
            }

            public override string ToString()
            {
                return string.Format("{0}",TypeOptions.NomType);
            }

        }

        public string TexteAfficher
        {
            get
            {
                return comboBoxTypeOptions.Text;
            }
        }

        public IEnumerable<TypeOption> TypeOptions
        {
            get
            {
                return comboBoxTypeOptions.Items.OfType<Element>().Select(Element => Element.TypeOptions);
            }
            set
            {
                if (value != null)
                {
                    comboBoxTypeOptions.Items.Clear();
                    foreach (TypeOption TypeOptions in value)
                    {
                        comboBoxTypeOptions.Items.Add(new Element(TypeOptions));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxTypeOptions.SelectedIndex = Index - 1;
        }

        public TypeOption TypeOptionsSelectionne
        {
            get
            {
                return (comboBoxTypeOptions.SelectedItem is Element) ? (comboBoxTypeOptions.SelectedItem as Element).TypeOptions : null;
            }
            set
            {
                comboBoxTypeOptions.SelectedItem = (value != null) ? new Element(value) : null;
                if(value != null) comboBoxTypeOptions.Text = value.NomType;
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteTypeOptions()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteTypeOptions_SizeChanged;
            comboBoxTypeOptions.SelectedIndexChanged += ComboTypeOptions_SelectedIndexChanged;
        }


        private void ComboTypeOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteTypeOptions_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxTypeOptions.Height);
        }
        
    }
}

