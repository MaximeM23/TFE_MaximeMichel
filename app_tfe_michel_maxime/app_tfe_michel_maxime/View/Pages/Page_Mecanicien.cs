using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PDSGBD;

namespace app_tfe_michel_maxime
{
    public partial class Page_Mecanicien : UserControl
    {

        // Constante permettant la construction d'un filtre spécifique comprenant l'opérateur LIKE
        private const string c_FiltreAvecLike = "%{0}%";

        private const double c_PrixParHeure = 12.5;

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

        public Page_Mecanicien()
        {
            InitializeComponent();
            CalendrierRdv.SurChangementSelection += CalendrierRdvSurChangementSelection;
            ActualiserFicheArticle();
            CalendrierRdv.ChargerListViewRdv();


            Bitmap ImageRessource = new Bitmap(Properties.Resources.Validation25px);
            ValidationProvider.Icon = Icon.FromHandle(ImageRessource.GetHicon());

            this.MinimumSize = new Size(1513, 801);
        }

        private void CalendrierRdvSurChangementSelection(object sender, EventArgs e)
        {
            if(CalendrierRdv.FactureSelectionnee != null)
            {
                // Si le statut est à "terminé" ou à "annuler" ou que la date de fin est inférieure à la date du jour, il est impossible de terminer la tâche.
                if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "Terminé")
                    || (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "Annuler")
                    || (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin < DateTime.Now))
                {
                    buttonTerminer.Enabled = false;
                    textBoxConseil.Enabled = false;
                }
                else
                {
                    buttonTerminer.Enabled = true;
                    textBoxConseil.Enabled = true;
                }
                textBoxImmatriculation.Text = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.Immatriculation;
                textBoxChassis.Text = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.NumeroChassis;
                textBoxModele.Text = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.Vehicule.Modele;
                textBoxInfoSupp.Text = CalendrierRdv.FactureSelectionnee.Informations;
                numericUpDownH.Value = CalendrierRdv.FactureSelectionnee.HeurePrestation;
                textBoxPrixTotal.Text = string.Format("{0} €",CalendrierRdv.FactureSelectionnee.PrixTotal + (int.Parse(numericUpDownH.Value.ToString()) * c_PrixParHeure));
                if (CalendrierRdv.FactureSelectionnee.EnumFactureEntretien.ElementAtOrDefault(0) != null) textBoxEntretienAFaire.Text = CalendrierRdv.FactureSelectionnee.EnumFactureEntretien.ElementAt(0).Entretien.TypeEntretien;
                else textBoxEntretienAFaire.Text = "Aucun entretien à faire";
                ficheTechnique.Caracteristique = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.Vehicule.EnumVehiculeCaracteristique;
                ficheTechnique.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (ficheTechnique.TexteFiltreTechnique != "")
                    {

                        ficheTechnique.Caracteristique = Program.GMBD.EnumererVehiculeCaracteristique(null,
                                                                            new PDSGBD.MyDB.CodeSql("JOIN caracteristique ON vehicule_caracteristique.fk_id_caracteristique = caracteristique.id_caracteristique"),
                                                                            new PDSGBD.MyDB.CodeSql("WHERE vehicule_caracteristique.fk_id_vehicule = {0} AND caracteristique LIKE {1} ", CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.Vehicule.Id, string.Format(c_FiltreAvecLike, ficheTechnique.TexteFiltreTechnique)),
                                                                            null);
                    }
                    else
                    {
                        ficheTechnique.Caracteristique = CalendrierRdv.FactureSelectionnee.RendezVous.ClientVehicule.Vehicule.EnumVehiculeCaracteristique;
                    }
                };
                ActualiserFicheArticleFacture();
            }
        }

        private void pictureBoxAjouterA_Click(object sender, EventArgs e)
        {
            // Si ce n'est pas égal à "terminé" ou "annuler" et que la date de fin n'est pas encore passée, alors c'est bon
            if ((CalendrierRdv.FactureSelectionnee != null) && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Annuler")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin > DateTime.Now))
            {
                // Si c'est "en attente" et que la date de fin n'est pas encore passée, alors c'est bon
                if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "En attente") && (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin > DateTime.Now))
                {
                    if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé") && (ficheArticlesComplet.ArticleSelectionnee != null))
                    {
                        Reparation NouvelArticleFacture = new Reparation();
                        NouvelArticleFacture.Article = ficheArticlesComplet.ArticleSelectionnee;

                        Reparation ArticleDejaCree = Program.GMBD.EnumererReparation(null, new MyDB.CodeSql("JOIN article ON reparation.fk_id_article = id_article"), new MyDB.CodeSql("WHERE fk_id_article = {0} AND fk_id_facture = {1}", NouvelArticleFacture.Article.Id, CalendrierRdv.FactureSelectionnee.Id), null).FirstOrDefault();
                        // Si l'article n'existe pas encore pour cette facture dans la base de données
                        if (ArticleDejaCree == null)
                        {
                            NouvelArticleFacture.QuantiteArticle = 1;
                            NouvelArticleFacture.FactureLiee = CalendrierRdv.FactureSelectionnee;
                            if ((NouvelArticleFacture.EstValide) && (Program.GMBD.AjouterArticleFacture(NouvelArticleFacture)))
                            {
                                Article Article = NouvelArticleFacture.Article;
                                Article.Stock = Article.Stock - 1;                                
                                if ((Article.EstValide) && (Program.GMBD.ModifierArticle(Article)))
                                {
                                    double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) + NouvelArticleFacture.Article.PrixUnite;
                                    textBoxPrixTotal.Text = string.Format("{0} €", x);
                                    ActualiserFicheArticleFacture();
                                    ActualiserFicheArticle();
                                }
                                else
                                {
                                    Program.GMBD.SupprimerArticleFacture(NouvelArticleFacture);
                                    ActualiserFicheArticle();
                                }
                            }
                        }
                        // Si l'article est déjà existant pour cette facture dans la base de données
                        else
                        {
                            ArticleDejaCree.FactureLiee = CalendrierRdv.FactureSelectionnee;
                            ArticleDejaCree.QuantiteArticle = ArticleDejaCree.QuantiteArticle + 1;
                            if ((ArticleDejaCree.EstValide) && (Program.GMBD.ModifierArticleFacture(ArticleDejaCree)))
                            {
                                Article Article = NouvelArticleFacture.Article;
                                Article.Stock = Article.Stock - 1;
                                if ((Article.EstValide) && (Program.GMBD.ModifierArticle(Article)))
                                {
                                    double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) + NouvelArticleFacture.Article.PrixUnite;
                                    textBoxPrixTotal.Text = string.Format("{0} €", x);
                                    ActualiserFicheArticleFacture();
                                    ActualiserFicheArticle();
                                }
                                else
                                {
                                    Program.GMBD.SupprimerArticleFacture(NouvelArticleFacture);
                                    ActualiserFicheArticle();
                                }
                            }

                        }
                    }
                }
            }
        }

        private void ActualiserFicheArticleFacture()
        {
            if (CalendrierRdv.FactureSelectionnee != null)
            {
                ficheArticleFacture.ArticleFacture = Program.GMBD.EnumererArticleFacture(null, new MyDB.CodeSql("JOIN reparation ON reparation.fk_id_article = article.id_article"), new MyDB.CodeSql("WHERE reparation.fk_id_facture = {0} AND disponible = 1", CalendrierRdv.FactureSelectionnee.Id), null);
                ficheArticleFacture.SurChangementFiltre += (s, ev) =>
                {
                    // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                    if (ficheArticleFacture.TexteFiltreArticleFacture != "")
                        {
                            ficheArticleFacture.ArticleFacture = Program.GMBD.EnumererArticleFacture(null,
                                                                                    new MyDB.CodeSql("JOIN reparation ON reparation.fk_id_article = article.id_article"),
                                                                                    new PDSGBD.MyDB.CodeSql("WHERE nom_article LIKE {0} AND reparation.fk_id_facture = {1} AND disponible = 1", string.Format(c_FiltreAvecLike, ficheArticleFacture.TexteFiltreArticleFacture), CalendrierRdv.FactureSelectionnee.Id),
                                                                                    null);
                        }
                        else
                        {
                            ficheArticleFacture.ArticleFacture = Program.GMBD.EnumererArticleFacture(null, new MyDB.CodeSql("JOIN reparation ON reparation.fk_id_article = article.id_article"), new MyDB.CodeSql("WHERE reparation.fk_id_facture = {0} AND disponible = 1", CalendrierRdv.FactureSelectionnee.Id), null);
                        }
                    };
                
            }
        }

        private void ActualiserFicheArticle()
        {
            ficheArticlesComplet.Article = Program.GMBD.EnumererArticle(null, null, new MyDB.CodeSql("WHERE disponible = 1"), null);
            ficheArticlesComplet.SurChangementFiltre += (s, ev) =>
            {
                // Cette condition permet d'alléger la requête si l'utilisateur revient sur un filtre vide
                if (ficheArticlesComplet.TexteFiltreArticle != "")
                    {
                        ficheArticlesComplet.Article = Program.GMBD.EnumererArticle(null,
                                                                                null,
                                                                                new PDSGBD.MyDB.CodeSql("WHERE nom_article LIKE {0} AND disponible = 1", string.Format(c_FiltreAvecLike, ficheArticlesComplet.TexteFiltreArticle)),
                                                                                null);
                    }
                    else
                    {
                        ficheArticlesComplet.Article = Program.GMBD.EnumererArticle(null, null, new MyDB.CodeSql("WHERE disponible = 1"), null);
                    }
                };

            if(ficheArticlesComplet.Article.Count() < 1)
            {
                buttonTerminer.Enabled = false;
            }
            
        }
        
        private void pictureBoxRetirerA_Click(object sender, EventArgs e)
        {
            // Si ce n'est pas égal à "terminé" ou "annuler" et que la date de fin n'est pas encore passée, alors c'est bon
            if ((CalendrierRdv.FactureSelectionnee != null) && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Annuler")
                    && (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin > DateTime.Now))
            {
                // Si c'est "en attente" et que la date de fin n'est pas encore passée, alors c'est bon
                if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation == "En attente") && (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin > DateTime.Now))
                {
                    if ((CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé") && (ficheArticleFacture.ArticleSelectionnee != null))
                    {

                        Reparation ArticleExistant = Program.GMBD.EnumererReparation(null, new MyDB.CodeSql("JOIN article ON reparation.fk_id_article = article.id_article JOIN facture ON reparation.fk_id_facture = facture.id_facture"), new MyDB.CodeSql("WHERE fk_id_article = {0} AND fk_id_facture = {1}", ficheArticleFacture.ArticleSelectionnee.Article.Id, CalendrierRdv.FactureSelectionnee.Id), null).FirstOrDefault();
                        // Si l'article n'existe pas encore pour cette facture dans la base de données
                        if (ArticleExistant != null)
                        {
                            // Si la quantité facturée est strictement supérieure à 1
                            if (ArticleExistant.QuantiteArticle > 1)
                            {
                                ArticleExistant.QuantiteArticle = ArticleExistant.QuantiteArticle - 1;                                
                                // Je modifie la facture en y retirant un article
                                if ((ArticleExistant.EstValide) && (Program.GMBD.ModifierArticleFacture(ArticleExistant)))
                                {
                                    Article Article = ArticleExistant.Article;
                                    Article.Stock = Article.Stock + 1;
                                    // Je modifie l'article pour modifié la quantité
                                    if ((Article.EstValide) && (Program.GMBD.ModifierArticle(Article)))
                                    {                                        
                                        double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) - ArticleExistant.Article.PrixUnite;
                                        textBoxPrixTotal.Text = string.Format("{0} €", x);
                                        ActualiserFicheArticleFacture();
                                        ActualiserFicheArticle();
                                    }
                                    else
                                    {
                                        ArticleExistant.QuantiteArticle = ArticleExistant.QuantiteArticle + 1;
                                        Program.GMBD.ModifierArticleFacture(ArticleExistant);
                                    }
                                }
                            }
                            else
                            {
                                if ((ArticleExistant.EstValide) && (Program.GMBD.SupprimerArticleFacture(ArticleExistant)))
                                {
                                    Article Article = ArticleExistant.Article;
                                    Article.Stock = Article.Stock + 1;
                                    // Je modifie l'article pour modifiié la quantité
                                    if ((Article.EstValide) && (Program.GMBD.ModifierArticle(Article)))
                                    {
                                        double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) - ArticleExistant.Article.PrixUnite;
                                        textBoxPrixTotal.Text = string.Format("{0} €",x);
                                        ActualiserFicheArticleFacture();
                                        ActualiserFicheArticle();
                                    }
                                    else
                                    {
                                        ArticleExistant.QuantiteArticle = ArticleExistant.QuantiteArticle + 1;
                                        Program.GMBD.ModifierArticleFacture(ArticleExistant);
                                    }
                                }
                            }
                        }                        
                    }
                }
            }
        }

        private void pictureBoxAjouterH_Click(object sender, EventArgs e)
        {
            if ((CalendrierRdv.FactureSelectionnee != null)
                && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé")
                &&(CalendrierRdv.FactureSelectionnee.RendezVous.DateFin >= DateTime.Now))
            {
                Facture FactureExiste = Program.GMBD.EnumererFacture(null, new MyDB.CodeSql("JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation"), new MyDB.CodeSql("WHERE id_facture = {0}", CalendrierRdv.FactureSelectionnee.Id), null).FirstOrDefault();
                if (FactureExiste != null)
                {
                    FactureExiste.HeurePrestation = FactureExiste.HeurePrestation + 1;
                    if ((FactureExiste.EstValide) && (Program.GMBD.ModifierFacture(FactureExiste)))
                    {
                        numericUpDownH.Value = FactureExiste.HeurePrestation;
                        double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) + c_PrixParHeure;
                        textBoxPrixTotal.Text = string.Format("{0} €",x);
                    }
                }
            }
        }

        private void pictureBoxRetirerH_Click(object sender, EventArgs e)
        {
            if ((CalendrierRdv.FactureSelectionnee != null)
                && (CalendrierRdv.FactureSelectionnee.RendezVous.Statut.StatutOperation != "Terminé")
                && (CalendrierRdv.FactureSelectionnee.RendezVous.DateFin >= DateTime.Now))
            {
                Facture FactureExiste = Program.GMBD.EnumererFacture(null, new MyDB.CodeSql("JOIN rendez_vous_entretien_reparation ON facture.fk_id_rdv = .rendez_vous_entretien_reparation.id_rendez_vous_entretien_reparation"), new MyDB.CodeSql("WHERE id_facture = {0}", CalendrierRdv.FactureSelectionnee.Id), null).FirstOrDefault();
                if (FactureExiste != null)
                {
                    FactureExiste.HeurePrestation = FactureExiste.HeurePrestation - 1;
                    if ((FactureExiste.EstValide) && (Program.GMBD.ModifierFacture(FactureExiste)))
                    {
                        numericUpDownH.Value = FactureExiste.HeurePrestation;
                        double x = double.Parse(textBoxPrixTotal.Text.Remove(textBoxPrixTotal.Text.Length - 1)) - c_PrixParHeure;
                        textBoxPrixTotal.Text = string.Format("{0} €", x);
                    }
                }
            }
        }

        private void buttonTerminer_Click(object sender, EventArgs e)
        {
            if(CalendrierRdv.FactureSelectionnee != null)
            {
                ValidationProvider.Clear();
                errorProvider.Clear();
                if(numericUpDownH.Value < 1)
                {
                    errorProvider.SetError(numericUpDownH, "La réparation nécessite au minimum une heure de prestation");
                }
                else
                {
                    if(ficheArticleFacture.NombreDeLigne > 0)
                    {
                        RendezVousEntretienReparation RdvEntretienReparation = CalendrierRdv.FactureSelectionnee.RendezVous;
                        RdvEntretienReparation.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = {0}", string.Format("Terminé")), null).FirstOrDefault();
                        if((RdvEntretienReparation.EstValide) && (Program.GMBD.ModifierRendezvous(RdvEntretienReparation)))
                        {
                            Facture NouvelleFacture = CalendrierRdv.FactureSelectionnee;
                            NouvelleFacture.HeurePrestation = int.Parse(numericUpDownH.Value.ToString());
                            double PrixTotal = 0;
                            foreach (Reparation Reparation in NouvelleFacture.EnumReparation)
                            {
                                PrixTotal += Reparation.Article.PrixUnite * Reparation.QuantiteArticle;
                            }
                            foreach (FactureEntretien Entretien in NouvelleFacture.EnumFactureEntretien)
                            {
                                PrixTotal += Entretien.Entretien.Prix;
                            }
                            NouvelleFacture.PrixTotal = PrixTotal;
                            NouvelleFacture.Commentaire = textBoxConseil.Text;
                            if ((NouvelleFacture.EstValide) && (Program.GMBD.ModifierFacture(NouvelleFacture)))
                            {
                                ClearPage();
                                CalendrierRdv.ChargerListViewRdv();
                                ValidationProvider.SetError(buttonTerminer, "Votre facture a été correctement enregsitrée");
                            }
                            else
                            {
                                RdvEntretienReparation.Statut = Program.GMBD.EnumererStatut(null, null, new MyDB.CodeSql("WHERE statut = {0}", string.Format("En attente")), null).FirstOrDefault();
                                if (RdvEntretienReparation.EstValide) Program.GMBD.ModifierRendezvous(RdvEntretienReparation);
                                errorProvider.SetError(buttonTerminer,"Votre facture n'a pas été correctement enregistrée");
                            }
                        }
                        else
                        {
                            errorProvider.SetError(buttonTerminer, "Erreur interne, veuillez contacter un administrateur");
                        }


                    }
                    else
                    {
                        errorProvider.SetError(ficheArticleFacture, "Il vous faut au minimum un article");
                    }

                }
            }
        }

        private void ClearPage()
        {
            buttonTerminer.Enabled = false;
            ficheArticleFacture.ArticleFacture = null;
            ficheTechnique.Caracteristique = null;
            ValidationProvider.Clear();
            errorProvider.Clear();
            textBoxChassis.Text = "";
            textBoxConseil.Text = "";
            textBoxEntretienAFaire.Text = "";
            textBoxImmatriculation.Text = "";
            textBoxInfoSupp.Text = "";
            textBoxModele.Text = "";
            textBoxPrixTotal.Text = "0 €";
             
        }
    }
}
