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
    public partial class Entretiens : UserControl
    {        

        private Entretien m_EntretienSelectionner;

        private bool m_EstAjouter = false;
        private bool m_EstModification = false;

        public bool EstAjouter
        {
            get
            {
                return m_EstAjouter;
            }
            set
            {
                if(value != m_EstAjouter)
                {
                    m_EstAjouter = value;
                    if(value == true)
                    {
                        buttonValider.Text = "Ajouter";
                    }
                }
            }
        }

        public bool EstModification
        {
            get
            {
                return m_EstModification;
            }
            set
            {
                if (value != m_EstModification)
                {
                    m_EstModification = value;
                    if (value == true)
                    {
                        buttonValider.Text = "Modifier";
                    }
                }
            }
        }


        public Entretien EntretienSelectionner
        {
            get
            {
                return m_EntretienSelectionner;
            }
            set
            {
                if ((value != null)&&(value != m_EntretienSelectionner))
                {
                    m_EntretienSelectionner = value;
                    textBoxEntretien.Text = value.TypeEntretien;
                    numericUpDown1.Value = decimal.Parse(value.Prix.ToString());
                }
                else
                {
                    textBoxEntretien.Text = "";
                    numericUpDown1.Value = 0;
                }
            }
        }        

        public Entretiens()
        {
            InitializeComponent();
            m_EntretienSelectionner = null;

            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
        }

        private void buttonValider_Click(object sender, EventArgs e)
        {
            if(m_EstAjouter)
            {
                Entretien NouvelEntretien = new Entretien();
                NouvelEntretien.SurErreur += Entretien_SurErreur;
                NouvelEntretien.AvantChangement += NouvelEntretien_AvantChangement;
                NouvelEntretien.TypeEntretien = textBoxEntretien.Text;
                NouvelEntretien.Prix = double.Parse(numericUpDown1.Value.ToString());
                NouvelEntretien.Disponible = 1;
                if((NouvelEntretien.EstValide) && (Program.GMBD.AjouterEntretien(NouvelEntretien)))
                {
                    ValidationProvider.SetError(buttonValider, "Entretien correctement ajouté");
                    if (RefreshApresAction != null)
                    {
                        EntretienSelectionner = NouvelEntretien;
                        RefreshApresAction(this, e);                        
                    }
                }
            }
            else if (m_EstModification)
            {
                FactureEntretien ConnexionExistante = Program.GMBD.EnumererFactureEntretien(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_entretien = {0}", EntretienSelectionner.Id), null).FirstOrDefault();
                if(ConnexionExistante == null)
                {
                    numericUpDown1.Enabled = true;
                    Entretien EntretienAModifier = EntretienSelectionner;
                    EntretienAModifier.SurErreur += Entretien_SurErreur;
                    EntretienAModifier.AvantChangement += EntretienAModifier_AvantChangement;
                    EntretienAModifier.Prix = double.Parse(numericUpDown1.Value.ToString());
                    EntretienAModifier.TypeEntretien = textBoxEntretien.Text;
                    EntretienAModifier.Disponible = EntretienSelectionner.Disponible;
                    if ((EntretienAModifier.EstValide) && (Program.GMBD.ModifierEntretien(EntretienAModifier)))
                    {
                        ValidationProvider.SetError(buttonValider, "Entretien correctement modifié");
                        if (RefreshApresAction != null)
                        {
                            EntretienSelectionner = EntretienAModifier;
                            RefreshApresAction(this, e);
                        }
                    }
                }
                else
                {
                    numericUpDown1.Enabled = false;
                    Entretien EntretienAModifier = EntretienSelectionner;
                    EntretienAModifier.SurErreur += Entretien_SurErreur;
                    EntretienAModifier.AvantChangement += EntretienAModifier_AvantChangement;
                    EntretienAModifier.TypeEntretien = textBoxEntretien.Text;
                    EntretienAModifier.Disponible = EntretienSelectionner.Disponible;
                    if ((EntretienAModifier.EstValide) && (Program.GMBD.ModifierEntretien(EntretienAModifier)))
                    {
                        ValidationProvider.SetError(buttonValider, "Entretien correctement modifié");
                        if (RefreshApresAction != null)
                        {
                            EntretienSelectionner = EntretienAModifier;
                            RefreshApresAction(this, e);
                        }
                    }
                }
            }
        }

        private void EntretienAModifier_AvantChangement(Entretien Entite, Entretien.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Entretien.Champs.TypeEntretien:
                    Entretien EntretienExiste = Program.GMBD.EnumererEntretien(null, null, new PDSGBD.MyDB.CodeSql("WHERE type_entretien = {0} AND id_entretien != {1} AND disponible = 1", textBoxEntretien.Text,EntretienSelectionner.Id), null).FirstOrDefault();
                    if (EntretienExiste != null)
                    {
                        AccumulateurErreur.NotifierErreur("Un entretien portant ce nom existe déjà");
                    }
                    break;
                default:
                    break;
            }
        }

        private void NouvelEntretien_AvantChangement(Entretien Entite, Entretien.Champs Champ, object ValeurActuelle, object NouvelleValeur, AccumulateurErreur AccumulateurErreur)
        {
            switch (Champ)
            {
                case Entretien.Champs.TypeEntretien:
                    Entretien EntretienExiste = Program.GMBD.EnumererEntretien(null, null, new PDSGBD.MyDB.CodeSql("WHERE type_entretien = {0} AND disponible = 1", textBoxEntretien.Text), null).FirstOrDefault();
                    if (EntretienExiste != null)
                    {
                        AccumulateurErreur.NotifierErreur("Un entretien portant ce nom existe déjà");
                    }
                    break;
                default:
                    break;
            }
        }

        private void Entretien_SurErreur(Entretien Entite, Entretien.Champs Champ, string MessageErreur)
        {
            switch (Champ)
            {
                case Entretien.Champs.TypeEntretien:
                    errorProvider.SetError(textBoxEntretien, MessageErreur);
                    break;
                case Entretien.Champs.Prix:
                    errorProvider.SetError(numericUpDown1, MessageErreur);
                    break;
                default:
                    break;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            errorProvider.Clear();
            ValidationProvider.Clear();
        }

        public EventHandler RefreshApresAction;
    }
}
