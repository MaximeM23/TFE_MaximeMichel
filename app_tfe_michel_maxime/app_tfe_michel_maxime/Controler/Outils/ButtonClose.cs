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
    public partial class ButtonClose : UserControl
    {
        public static bool EstPleinEcran = false;
        public static Size TailleOriginal;

        public ButtonClose()
        {
            InitializeComponent();
        }

        /// <summary>
        /// S'activer au moment du click sur la fermeture de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        /// <summary>
        /// S'active au moment du click sur la réduction de fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// S'active au moment du click sur l'image de redimensionnement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            if (EstPleinEcran == false)
            {
                ParentForm.Top = 0;
                ParentForm.Left = 0;
                ParentForm.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 40);
                pictureBox3.Image = Properties.Resources.sizer;
                EstPleinEcran = true;
            }
            else
            {
                ParentForm.Size = TailleOriginal;
                pictureBox3.Image = Properties.Resources.Sizer2;
                EstPleinEcran = false;
            }
        }


        /// <summary>
        /// S'active au chargement de mon userControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClose_Load(object sender, EventArgs e)
        {
            // Me permet de contrer une erreur d'appel sur l'initialisation visuel des interfaces utilisant ce controler
            if (ParentForm != null)
            {
                if (EstPleinEcran == false)
                {
                    ParentForm.Top = 0;
                    ParentForm.Left = 0;
                    TailleOriginal = ParentForm.Size;
                    ParentForm.Size = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height - 40);
                    pictureBox3.Image = Properties.Resources.Sizer2;
                }
                else
                {
                    ParentForm.Size = TailleOriginal;
                    pictureBox3.Image = Properties.Resources.sizer;
                }
            }
        }
    }
}
