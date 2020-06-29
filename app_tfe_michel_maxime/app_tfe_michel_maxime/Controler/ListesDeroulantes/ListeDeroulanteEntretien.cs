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
    public partial class ListeDeroulanteEntretien : UserControl
    {
       
        private class Element
        {


            public Entretien Entretien { get; private set; }

            public Element(Entretien Entretien)
            {
                this.Entretien = Entretien;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1} €", Entretien.TypeEntretien, Entretien.Prix);
            }

        }

        public string TextBoxNomEntretien
        {
            get
            {
                return comboBoxEntretien.Text;
            }
        }

        public IEnumerable<Entretien> Entretien
        {
            get
            {
                return comboBoxEntretien.Items.OfType<Element>().Select(Element => Element.Entretien);
            }
            set
            {
                if (value != null)
                {
                    comboBoxEntretien.Items.Clear();
                    foreach (Entretien Entretien in value)
                    {
                        comboBoxEntretien.Items.Add(new Element(Entretien));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxEntretien.SelectedIndex = Index - 1;
        }
        

        public Entretien EntretienSelectionne
        {
            get
            {
                return (comboBoxEntretien.SelectedItem is Element) ? (comboBoxEntretien.SelectedItem as Element).Entretien : null;
            }
            set
            {
                comboBoxEntretien.SelectedItem = (value != null) ? value : null;
                if (value != null) comboBoxEntretien.Text = string.Format("{0} - {1} €", value.TypeEntretien,value.Prix);
                else comboBoxEntretien.Text = "";
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteEntretien()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteEntretien_SizeChanged;
            comboBoxEntretien.SelectedIndexChanged += ComboEntretien_SelectedIndexChanged;
        }
        
        private void ComboEntretien_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteEntretien_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxEntretien.Height);
        }
    }
}

