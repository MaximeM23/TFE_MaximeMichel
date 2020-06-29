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
    public partial class ListeDeroulanteClient : UserControl
    {
       
        private class Element
        {


            public Client Client { get; private set; }

            public Element(Client Client)
            {
                this.Client = Client;
            }

            public override string ToString()
            {
                return string.Format("{0} - {1} - {2}",Client.Id, Client.Nom, Client.Prenom);
            }

        }

        public IEnumerable<Client> Client
        {
            get
            {
                return comboBoxClient.Items.OfType<Element>().Select(Element => Element.Client);
            }
            set
            {
                if (value != null)
                {
                    comboBoxClient.Items.Clear();
                    foreach (Client Client in value)
                    {
                        comboBoxClient.Items.Add(new Element(Client));
                    }
                }
            }
        }

        public int SelectedIndex(int Index)
        {
            return comboBoxClient.SelectedIndex = Index - 1;
        }

        public Client ClientSelectionne
        {
            get
            {
                return (comboBoxClient.SelectedItem is Element) ? (comboBoxClient.SelectedItem as Element).Client : null;
            }
            set
            {
                comboBoxClient.SelectedItem = (value != null) ? new Element(value) : null;
                if (value != null) comboBoxClient.Text = string.Format("{0} - {1} - {2}",value.Id , value.Nom, value.Prenom);
                else comboBoxClient.Text = "";
            }
        }

        public EventHandler SurChangementSelection = null;

        public EventHandler SurChangementSelectionDeuxiemeMethode = null;

        public ListeDeroulanteClient()
        {
            InitializeComponent();
            this.SizeChanged += ListeDeroulanteClient_SizeChanged;
            comboBoxClient.SelectedIndexChanged += ComboClient_SelectedIndexChanged;
        }


        private void ComboClient_SelectedIndexChanged(object sender, EventArgs e)
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

        private void ListeDeroulanteClient_SizeChanged(object sender, EventArgs e)
        {
            this.Size = new Size(this.Size.Width, comboBoxClient.Height);
        }

        private void ListeDeroulanteClient_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            { 
                if (SurChangementSelection != null)
                {
                    SurChangementSelection(this, EventArgs.Empty);
                }
            }
        }
    }
}

