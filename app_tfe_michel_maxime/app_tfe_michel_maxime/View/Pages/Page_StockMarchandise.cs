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
    public partial class Page_StockMarchandise : UserControl
    {

        #region Event de déplacement de l'application
        Point DernierClic;
        bool dragging;
        private void Page_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            DernierClic = e.Location;
        }

        private void Page_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                if (e.Button == MouseButtons.Left)
                {
                    ParentForm.Left += e.X - DernierClic.X;
                    ParentForm.Top += e.Y - DernierClic.Y;
                }
            }
        }

        private void Page_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        #endregion


        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";

        public Page_StockMarchandise()
        {
            InitializeComponent();
            ficheArticle1.SurChangementSelection += FicheArticle1_SurChangementSelection;
            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());
            this.MinimumSize = new Size(1100, 750);
            numericUpDownPrixUnitaire.Maximum = 10000;
            numericUpDownPrixUnitaire.Minimum = 0;
            numericUpDownQuantite.Maximum = 10000;
            numericUpDownQuantite.Minimum = 0;
        }

        private void FicheArticle1_SurChangementSelection(object sender, EventArgs e)
        {
            if(ficheArticle1.ArticleSelectionnee != null)
            {
                errorProvider.Clear();
                ValidationProvider.Clear();
                textBoxNomArticle.Text = ficheArticle1.ArticleSelectionnee.NomArticle;
                numericUpDownPrixUnitaire.Value = decimal.Parse(ficheArticle1.ArticleSelectionnee.PrixUnite.ToString());
                numericUpDownQuantite.Value = decimal.Parse(ficheArticle1.ArticleSelectionnee.Stock.ToString());

                Reparation LiaisonExistante = Program.GMBD.EnumererReparation(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_article = {0}", ficheArticle1.ArticleSelectionnee.Id), null).FirstOrDefault();

                if(LiaisonExistante != null)
                {
                    numericUpDownPrixUnitaire.Enabled = false;
                    textBoxNomArticle.Enabled = false;
                }
                else
                {
                    numericUpDownPrixUnitaire.Enabled = true;
                    textBoxNomArticle.Enabled = true;
                }

                buttonModifier.Enabled = true;
                buttonAjouter.Enabled = false;
                buttonSupprimer.Enabled = true;
            }
            else
            {
                numericUpDownPrixUnitaire.Enabled = true;
            }
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            Article NouvelArticle = new Article();
            NouvelArticle.SurErreur += Article_SurErreur;
            NouvelArticle.NomArticle = textBoxNomArticle.Text;
            NouvelArticle.PrixUnite = double.Parse(numericUpDownPrixUnitaire.Value.ToString());
            NouvelArticle.Stock = int.Parse(numericUpDownQuantite.Value.ToString());
            NouvelArticle.Disponible = 1;

            Article ArticleExiste = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE nom_article = {0} AND disponible = 1", textBoxNomArticle.Text), null).FirstOrDefault();
            if ((ArticleExiste != null) && (ArticleExiste.Disponible == 1))
            {
                errorProvider.SetError(buttonAjouter, "Cet article existe déjà");
            }
            else
            {
                if ((NouvelArticle.EstValide) && (Program.GMBD.AjouterArticle(NouvelArticle)))
                {
                    RefreshPage();
                    ValidationProvider.SetError(buttonAjouter, "Article correctement ajouté");
                }
            }
        }

        private void RefreshPage()
        {
            textBoxNomArticle.Text = "";
            numericUpDownPrixUnitaire.Value = 0;
            numericUpDownQuantite.Value = 0;
            ValidationProvider.Clear();
            errorProvider.Clear();
            ficheArticle1.Article = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
            buttonAjouter.Enabled = true;
            buttonModifier.Enabled = false;
            buttonSupprimer.Enabled = false;
        }
        
        private void Article_SurErreur(Article Entite, Article.Champs Champ, string MessageErreur)
        {
            switch(Champ)
            {
                case Article.Champs.NomArticle:
                    errorProvider.SetError(textBoxNomArticle, MessageErreur);
                    break;
                case Article.Champs.PrixUnite:
                    errorProvider.SetError(numericUpDownPrixUnitaire, MessageErreur);
                    break;
                case Article.Champs.Stock:
                    errorProvider.SetError(numericUpDownQuantite, MessageErreur);
                    break;
                default:
                    break;
            }
        }

        private void buttonModifier_Click(object sender, EventArgs e)
        {
            if (ficheArticle1.ArticleSelectionnee != null)
            {
                Article ArticleAModifier = ficheArticle1.ArticleSelectionnee;
                ArticleAModifier.SurErreur += Article_SurErreur;
                ArticleAModifier.NomArticle = textBoxNomArticle.Text;
                ArticleAModifier.PrixUnite = double.Parse(numericUpDownPrixUnitaire.Value.ToString());
                ArticleAModifier.Stock = int.Parse(numericUpDownQuantite.Value.ToString());

                Article ArticleExiste = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE nom_article = {0} AND id_article != {1}", textBoxNomArticle.Text, ficheArticle1.ArticleSelectionnee.Id), null).FirstOrDefault();
                if ((ArticleExiste != null)&&(ArticleExiste.Disponible == 1))
                {
                    errorProvider.SetError(buttonModifier,"Cet article existe déjà, veuillez choisir un autre nom pour l'article");
                }
                else
                {
                    if ((ArticleAModifier.EstValide) && (Program.GMBD.ModifierArticle(ArticleAModifier)))
                    {
                        RefreshPage();
                        ValidationProvider.SetError(buttonModifier, "Article correctement modifié");
                    }
                }               
            }
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            if (ficheArticle1.ArticleSelectionnee != null)
            {
                if (ficheArticle1.ArticleSelectionnee.Stock > 0)
                {
                    errorProvider.SetError(buttonSupprimer, "Suppression impossible tant qu'il y a encore du stock pour cet article");
                }
                else
                {
                    Reparation ArticleReference = Program.GMBD.EnumererReparation(null, null, new PDSGBD.MyDB.CodeSql("WHERE fk_id_article = {0}", ficheArticle1.ArticleSelectionnee.Id), null).FirstOrDefault();
                    if (ArticleReference != null)
                    {
                        // Afin de garder la trace de cet article pour la facture, l'article deviendra indisponible et sera considéré comme supprimé
                        Article ArticleIndisponible = ficheArticle1.ArticleSelectionnee;
                        ArticleIndisponible.Disponible = 0;
                        Program.GMBD.ModifierArticle(ArticleIndisponible);
                        RefreshPage();
                        ValidationProvider.SetError(buttonSupprimer, "Article correctement supprimé");
                    }
                    else
                    {
                        Program.GMBD.SupprimerArticle(ficheArticle1.ArticleSelectionnee);
                        RefreshPage();
                        ValidationProvider.SetError(buttonSupprimer, "Article correctement supprimé");
                    }
                }
            }
        }

        private void ficheArticle1_Load(object sender, EventArgs e)
        {
            ficheArticle1.Article = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
            ficheArticle1.SurChangementFiltre += (s, ev) =>
            {
                // Cette condition permet la simplification de la requête si l'utilisateur revient sur un filtre vide
                if (ficheArticle1.TexteFiltreArticle != "")
                {
                    ficheArticle1.Article = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE nom_article LIKE {0} AND disponible = 1", string.Format(c_FiltreAvecLike, ficheArticle1.TexteFiltreArticle)),
                                                                    null);
                }
                else
                {
                    ficheArticle1.Article = Program.GMBD.EnumererArticle(null, null, new PDSGBD.MyDB.CodeSql("WHERE disponible = 1"), null);
                }
            };
        }

        private void ficheArticle1_SizeChanged(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void buttonAnnuler_Click(object sender, EventArgs e)
        {
            textBoxNomArticle.Text = "";
            numericUpDownPrixUnitaire.Value = 0;
            numericUpDownQuantite.Value = 0;
            textBoxNomArticle.Enabled = true;
            numericUpDownPrixUnitaire.Enabled = true;
            buttonAjouter.Enabled = true;
            buttonModifier.Enabled = false;
            buttonSupprimer.Enabled = false;
            ficheArticle1.ArticleSelectionnee = null;
        }
    }
}
