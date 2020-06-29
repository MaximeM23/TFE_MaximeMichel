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
    public partial class ListeDeroulanteCaracteristique : UserControl
    {
       
        private class Element
        {


            public Caracteristique Caracteristique { get; private set; }

            public Element(Caracteristique Caracteristique)
            {
                this.Caracteristique = Caracteristique;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1}", Caracteristique.NomCaracteristique,Caracteristique.TypeVehicule.NomDuType);
            }

        }

        public IEnumerable<Caracteristique> Caracteristique
        {
            get
            {
                return comboBoxCaracteristique.Items.OfType<Element>().Select(Element => Element.Caracteristique);
            }
            set
            {
                if (value != null)
                {
                    comboBoxCaracteristique.Items.Clear();
                    foreach (Caracteristique Caracteristique in value)
                    {
                        comboBoxCaracteristique.Items.Add(new Element(Caracteristique));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxCaracteristique.SelectedIndex = Index - 1;
        }

        public Caracteristique CaracteristiqueSelectionne
        {
            get
            {
                return (comboBoxCaracteristique.SelectedItem is Element) ? (comboBoxCaracteristique.SelectedItem as Element).Caracteristique : null;
            }
            set
            {
                comboBoxCaracteristique.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxCaracteristique.Text = value.NomCaracteristique.ToString();
            }
        }

        public EventHandler SurChangementSelection = null;

        public ListeDeroulanteCaracteristique()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteCaracteristique_SizeChanged;
            comboBoxCaracteristique.SelectedIndexChanged += Caracteristique_SelectedIndexChanged;
        }


        private void Caracteristique_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SurChangementSelection != null)
            {
                SurChangementSelection(this, EventArgs.Empty);
            }
        }

        private void ListeDeroulanteCaracteristique_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxCaracteristique.Height);
        }
    }
}

