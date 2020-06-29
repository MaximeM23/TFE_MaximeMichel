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
    public partial class ListeDeroulanteCivilite : UserControl
    {
       
        private class Element
        {


            public Civilite Civilite { get; private set; }

            public Element(Civilite Civilite)
            {
                this.Civilite = Civilite;
            }

            public override string ToString()
            {
                return string.Format("{0}",Civilite.CiviliteDeLaPersonne);
            }

        }

        public IEnumerable<Civilite> Civilite
        {
            get
            {
                return comboBoxCivilite.Items.OfType<Element>().Select(Element => Element.Civilite);
            }
            set
            {
                if (value != null)
                {
                    comboBoxCivilite.Items.Clear();
                    foreach (Civilite Civilite in value)
                    {
                        comboBoxCivilite.Items.Add(new Element(Civilite));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxCivilite.SelectedIndex = Index - 1;
        }

        public Civilite CiviliteSelectionne
        {
            get
            {
                return (comboBoxCivilite.SelectedItem is Element) ? (comboBoxCivilite.SelectedItem as Element).Civilite : null;
            }
            set
            {
                comboBoxCivilite.SelectedItem = (value != null) ? new Element(value) : null;
                if(value != null) comboBoxCivilite.Text = value.CiviliteDeLaPersonne;
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteCivilite()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteCivilite_SizeChanged;
            comboBoxCivilite.SelectedIndexChanged += ComboCivilite_SelectedIndexChanged;
        }


        private void ComboCivilite_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteCivilite_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxCivilite.Height);
        }
    }
}

