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
    public partial class ListeDeroulanteOptions : UserControl
    {
       
        private class Element
        {

            public OptionVehicule Options { get; private set; }

            public Element(OptionVehicule Options)
            {
                this.Options = Options;
            }

            public override string ToString()
            {
                return string.Format("{0}",Options.NomOption);
            }

        }

        public string TexteAfficher
        {
            get
            {
                return comboBoxOptions.Text;
            }
        }

        public IEnumerable<OptionVehicule> Options
        {
            get
            {
                return comboBoxOptions.Items.OfType<Element>().Select(Element => Element.Options);
            }
            set
            {
                if (value != null)
                {
                    comboBoxOptions.Items.Clear();
                    foreach (OptionVehicule Options in value)
                    {
                        comboBoxOptions.Items.Add(new Element(Options));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxOptions.SelectedIndex = Index - 1;
        }

        public OptionVehicule OptionsSelectionne
        {
            get
            {
                return (comboBoxOptions.SelectedItem is Element) ? (comboBoxOptions.SelectedItem as Element).Options : null;
            }
            set
            {
                comboBoxOptions.SelectedItem = (value != null) ? new Element(value) : null;
                if(value != null) comboBoxOptions.Text = value.NomOption;
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteOptions()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteOptions_SizeChanged;
            comboBoxOptions.SelectedIndexChanged += ComboOptions_SelectedIndexChanged;
        }


        private void ComboOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteOptions_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxOptions.Height);
        }
        
    }
}

