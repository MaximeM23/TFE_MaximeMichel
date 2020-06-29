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
    public partial class ListeDeroulanteCodePostal : UserControl
    {
       
        private class Element
        {


            public Adresse CodePostal { get; private set; }

            public Element(Adresse CodePostal)
            {
                this.CodePostal = CodePostal;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1}", CodePostal.CodePostal, CodePostal.Localite);
            }

        }

        public IEnumerable<Adresse> CodePostal
        {
            get
            {
                return comboBoxCodePostal.Items.OfType<Element>().Select(Element => Element.CodePostal);
            }
            set
            {
                if (value != null)
                {
                    comboBoxCodePostal.Items.Clear();
                    foreach (Adresse Adresse in value)
                    {
                        comboBoxCodePostal.Items.Add(new Element(Adresse));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxCodePostal.SelectedIndex = Index - 1;
        }

        public Adresse CodePostalSelectionne
        {
            get
            {
                return (comboBoxCodePostal.SelectedItem is Element) ? (comboBoxCodePostal.SelectedItem as Element).CodePostal : null;
            }
            set
            {
                comboBoxCodePostal.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxCodePostal.Text = value.CodePostal.ToString() + " - " + value.Localite.ToString();
                else comboBoxCodePostal.Text = "";
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteCodePostal()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteCodePostal_SizeChanged;
            comboBoxCodePostal.SelectedIndexChanged += CodePostal_SelectedIndexChanged;
        }


        private void CodePostal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteCodePostal_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxCodePostal.Height);
        }
    }
}

