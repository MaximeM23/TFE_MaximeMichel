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
    public partial class ListeDeroulanteEmploye : UserControl
    {
       
        private class Element
        {


            public Employe Employe { get; private set; }

            public Element(Employe Employe)
            {
                this.Employe = Employe;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1}", Employe.Nom, Employe.Prenom);
            }

        }

        public IEnumerable<Employe> Employe
        {
            get
            {
                return comboBoxEmploye.Items.OfType<Element>().Select(Element => Element.Employe);
            }
            set
            {
                if (value != null)
                {
                    comboBoxEmploye.Items.Clear();
                    foreach (Employe Employe in value)
                    {
                        comboBoxEmploye.Items.Add(new Element(Employe));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxEmploye.SelectedIndex = Index - 1;
        }

        public Employe EmployeSelectionne
        {
            get
            {
                return (comboBoxEmploye.SelectedItem is Element) ? (comboBoxEmploye.SelectedItem as Element).Employe : null;
            }
            set
            {
                comboBoxEmploye.SelectedItem = (value != null) ? new Element(value) : null;            
                if (value != null) comboBoxEmploye.Text = string.Format("{0} - {1}", value.Nom,value.Prenom);
            }
        }

        public EventHandler SurChangementSelection = null;

        public EventHandler SurChangementSelectionDeuxiemeMethode = null;

        public ListeDeroulanteEmploye()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteEmploye_SizeChanged;
            comboBoxEmploye.SelectedIndexChanged += ComboEmploye_SelectedIndexChanged;
        }


        private void ComboEmploye_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
                if(SurChangementSelectionDeuxiemeMethode != null)
                {
                    SurChangementSelectionDeuxiemeMethode(this, EventArgs.Empty);
                }
            }
        }

        private void ListeDeroulanteEmploye_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxEmploye.Height);
        }
    }
}

