using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public partial class PopUpPerteConnexion : Form
    {

        public PopUpPerteConnexion()
        {
            InitializeComponent();
        }

        private void buttonContinuer_Click(object sender, EventArgs e)
        {
            if(Program.GMBD.Initialiser())
            {

                Close();
            }
        }

        private void buttonFermer_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
    }
}
