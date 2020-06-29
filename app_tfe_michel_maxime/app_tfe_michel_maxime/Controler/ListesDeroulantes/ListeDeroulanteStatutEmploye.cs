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
    public partial class ListeDeroulanteStatutEmploye : UserControl
    {
       
        private class Element
        {


            public StatutEmploye StatutEmploye { get; private set; }

            public Element(StatutEmploye StatutEmploye)
            {
                this.StatutEmploye = StatutEmploye;
            }

            public override string ToString()
            {
                return string.Format("{0}", StatutEmploye.NomStatut);
            }

        }

        public IEnumerable<StatutEmploye> StatutEmploye
        {
            get
            {
                return comboBoxStatutEmploye.Items.OfType<Element>().Select(Element => Element.StatutEmploye);
            }
            set
            {
                if (value != null)
                {
                    comboBoxStatutEmploye.Items.Clear();
                    foreach (StatutEmploye StatutEmploye in value)
                    {
                        comboBoxStatutEmploye.Items.Add(new Element(StatutEmploye));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxStatutEmploye.SelectedIndex = Index - 1;
        }

        public StatutEmploye StatutEmployeSelectionne
        {
            get
            {
                return (comboBoxStatutEmploye.SelectedItem is Element) ? (comboBoxStatutEmploye.SelectedItem as Element).StatutEmploye : null;
            }
            set
            {
                comboBoxStatutEmploye.SelectedItem = (value != null) ? new Element(value) : null;            
                if (value != null) comboBoxStatutEmploye.Text = string.Format("{0}", value.NomStatut);
            }
        }

        public EventHandler SurChangementSelection = null;

        public EventHandler SurChangementSelectionDeuxiemeMethode = null;

        public ListeDeroulanteStatutEmploye()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteStatutEmploye_SizeChanged;
            comboBoxStatutEmploye.SelectedIndexChanged += ComboStatutEmploye_SelectedIndexChanged;
        }


        private void ComboStatutEmploye_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ListeDeroulanteStatutEmploye_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxStatutEmploye.Height);
        }

        public override void ResetText()
        {
            comboBoxStatutEmploye.Text = "";
        }
    }
}

