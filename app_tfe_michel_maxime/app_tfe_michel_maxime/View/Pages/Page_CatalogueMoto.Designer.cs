namespace app_tfe_michel_maxime
{
    partial class Page_CatalogueMoto
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.labelCatalogueMoto = new System.Windows.Forms.Label();
            this.labelChercherMoto = new System.Windows.Forms.Label();
            this.labelFicheTechnique = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelTypeOption = new System.Windows.Forms.Label();
            this.labelRechercheFicheTechnique = new System.Windows.Forms.Label();
            this.labelRechercheOptions = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.labelPrixCatalogue = new System.Windows.Forms.Label();
            this.labelEstimationDateLivraison = new System.Windows.Forms.Label();
            this.textBoxEstimationLivraison = new System.Windows.Forms.TextBox();
            this.labelDisponibilite = new System.Windows.Forms.Label();
            this.textBoxDispo = new System.Windows.Forms.TextBox();
            this.buttonDisponibilité = new System.Windows.Forms.Button();
            this.buttonPasserCommande = new System.Windows.Forms.Button();
            this.pictureBoxMoto = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPackDisponible = new System.Windows.Forms.Label();
            this.fichePackOptions1 = new app_tfe_michel_maxime.FichePackOptions();
            this.ficheOptions1 = new app_tfe_michel_maxime.FicheOptions();
            this.listeDeroulanteTypeOptions1 = new app_tfe_michel_maxime.ListeDeroulanteTypeOptions();
            this.ficheTechnique1 = new app_tfe_michel_maxime.FicheTechnique();
            this.listeDeroulanteVehicule1 = new app_tfe_michel_maxime.ListeDeroulanteVehicule();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoto)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelCatalogueMoto);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 42);
            this.panel1.TabIndex = 8;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(789, 1);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(108, 37);
            this.buttonClose1.TabIndex = 9;
            // 
            // labelCatalogueMoto
            // 
            this.labelCatalogueMoto.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCatalogueMoto.AutoSize = true;
            this.labelCatalogueMoto.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCatalogueMoto.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCatalogueMoto.Location = new System.Drawing.Point(299, -1);
            this.labelCatalogueMoto.Name = "labelCatalogueMoto";
            this.labelCatalogueMoto.Size = new System.Drawing.Size(291, 39);
            this.labelCatalogueMoto.TabIndex = 0;
            this.labelCatalogueMoto.Text = "Catalogue des motos";
            this.labelCatalogueMoto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelCatalogueMoto.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelCatalogueMoto.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelChercherMoto
            // 
            this.labelChercherMoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelChercherMoto.AutoSize = true;
            this.labelChercherMoto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChercherMoto.Location = new System.Drawing.Point(503, 51);
            this.labelChercherMoto.Name = "labelChercherMoto";
            this.labelChercherMoto.Size = new System.Drawing.Size(122, 15);
            this.labelChercherMoto.TabIndex = 10;
            this.labelChercherMoto.Text = "Rechercher une moto";
            // 
            // labelFicheTechnique
            // 
            this.labelFicheTechnique.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFicheTechnique.AutoSize = true;
            this.labelFicheTechnique.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFicheTechnique.Location = new System.Drawing.Point(378, 85);
            this.labelFicheTechnique.Name = "labelFicheTechnique";
            this.labelFicheTechnique.Size = new System.Drawing.Size(154, 15);
            this.labelFicheTechnique.TabIndex = 12;
            this.labelFicheTechnique.Text = "Fiche technique de la moto";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel2.Location = new System.Drawing.Point(283, 103);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 1);
            this.panel2.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(283, 305);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(342, 1);
            this.panel3.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(344, 287);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Les options disponibles pour cette moto";
            // 
            // labelTypeOption
            // 
            this.labelTypeOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTypeOption.AutoSize = true;
            this.labelTypeOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypeOption.Location = new System.Drawing.Point(329, 316);
            this.labelTypeOption.Name = "labelTypeOption";
            this.labelTypeOption.Size = new System.Drawing.Size(85, 15);
            this.labelTypeOption.TabIndex = 17;
            this.labelTypeOption.Text = "Type d\'options";
            // 
            // labelRechercheFicheTechnique
            // 
            this.labelRechercheFicheTechnique.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheFicheTechnique.AutoSize = true;
            this.labelRechercheFicheTechnique.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheFicheTechnique.Location = new System.Drawing.Point(395, 113);
            this.labelRechercheFicheTechnique.Name = "labelRechercheFicheTechnique";
            this.labelRechercheFicheTechnique.Size = new System.Drawing.Size(122, 15);
            this.labelRechercheFicheTechnique.TabIndex = 19;
            this.labelRechercheFicheTechnique.Text = "Recherche spécifique";
            // 
            // labelRechercheOptions
            // 
            this.labelRechercheOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheOptions.AutoSize = true;
            this.labelRechercheOptions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheOptions.Location = new System.Drawing.Point(395, 341);
            this.labelRechercheOptions.Name = "labelRechercheOptions";
            this.labelRechercheOptions.Size = new System.Drawing.Size(122, 15);
            this.labelRechercheOptions.TabIndex = 20;
            this.labelRechercheOptions.Text = "Recherche spécifique";
            // 
            // textBoxPrix
            // 
            this.textBoxPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrix.Location = new System.Drawing.Point(900, 328);
            this.textBoxPrix.Name = "textBoxPrix";
            this.textBoxPrix.Size = new System.Drawing.Size(142, 20);
            this.textBoxPrix.TabIndex = 22;
            // 
            // labelPrixCatalogue
            // 
            this.labelPrixCatalogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixCatalogue.AutoSize = true;
            this.labelPrixCatalogue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixCatalogue.Location = new System.Drawing.Point(756, 330);
            this.labelPrixCatalogue.Name = "labelPrixCatalogue";
            this.labelPrixCatalogue.Size = new System.Drawing.Size(86, 15);
            this.labelPrixCatalogue.TabIndex = 23;
            this.labelPrixCatalogue.Text = "Prix catalogue";
            // 
            // labelEstimationDateLivraison
            // 
            this.labelEstimationDateLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEstimationDateLivraison.AutoSize = true;
            this.labelEstimationDateLivraison.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstimationDateLivraison.Location = new System.Drawing.Point(713, 404);
            this.labelEstimationDateLivraison.Name = "labelEstimationDateLivraison";
            this.labelEstimationDateLivraison.Size = new System.Drawing.Size(181, 15);
            this.labelEstimationDateLivraison.TabIndex = 25;
            this.labelEstimationDateLivraison.Text = "Estimation de livraison en jours";
            // 
            // textBoxEstimationLivraison
            // 
            this.textBoxEstimationLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEstimationLivraison.Location = new System.Drawing.Point(900, 401);
            this.textBoxEstimationLivraison.Name = "textBoxEstimationLivraison";
            this.textBoxEstimationLivraison.Size = new System.Drawing.Size(142, 20);
            this.textBoxEstimationLivraison.TabIndex = 24;
            // 
            // labelDisponibilite
            // 
            this.labelDisponibilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDisponibilite.AutoSize = true;
            this.labelDisponibilite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisponibilite.Location = new System.Drawing.Point(756, 367);
            this.labelDisponibilite.Name = "labelDisponibilite";
            this.labelDisponibilite.Size = new System.Drawing.Size(79, 15);
            this.labelDisponibilite.TabIndex = 27;
            this.labelDisponibilite.Text = "Disponibilité";
            // 
            // textBoxDispo
            // 
            this.textBoxDispo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDispo.Location = new System.Drawing.Point(900, 365);
            this.textBoxDispo.Name = "textBoxDispo";
            this.textBoxDispo.Size = new System.Drawing.Size(142, 20);
            this.textBoxDispo.TabIndex = 26;
            // 
            // buttonDisponibilité
            // 
            this.buttonDisponibilité.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDisponibilité.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonDisponibilité.Enabled = false;
            this.buttonDisponibilité.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDisponibilité.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDisponibilité.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDisponibilité.Location = new System.Drawing.Point(776, 524);
            this.buttonDisponibilité.Name = "buttonDisponibilité";
            this.buttonDisponibilité.Size = new System.Drawing.Size(231, 40);
            this.buttonDisponibilité.TabIndex = 2;
            this.buttonDisponibilité.Text = "Voir les disponibilités";
            this.buttonDisponibilité.UseVisualStyleBackColor = false;
            this.buttonDisponibilité.Click += new System.EventHandler(this.buttonDisponibilité_Click);
            // 
            // buttonPasserCommande
            // 
            this.buttonPasserCommande.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPasserCommande.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonPasserCommande.Enabled = false;
            this.buttonPasserCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPasserCommande.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPasserCommande.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonPasserCommande.Location = new System.Drawing.Point(776, 582);
            this.buttonPasserCommande.Name = "buttonPasserCommande";
            this.buttonPasserCommande.Size = new System.Drawing.Size(231, 40);
            this.buttonPasserCommande.TabIndex = 3;
            this.buttonPasserCommande.Text = "Passer commande";
            this.buttonPasserCommande.UseVisualStyleBackColor = false;
            this.buttonPasserCommande.Click += new System.EventHandler(this.buttonPasserCommande_Click);
            // 
            // pictureBoxMoto
            // 
            this.pictureBoxMoto.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxMoto.Location = new System.Drawing.Point(739, 130);
            this.pictureBoxMoto.Name = "pictureBoxMoto";
            this.pictureBoxMoto.Size = new System.Drawing.Size(320, 192);
            this.pictureBoxMoto.TabIndex = 21;
            this.pictureBoxMoto.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(395, 550);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 51;
            this.label2.Text = "Recherche spécifique";
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel4.Location = new System.Drawing.Point(283, 546);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 1);
            this.panel4.TabIndex = 49;
            // 
            // labelPackDisponible
            // 
            this.labelPackDisponible.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPackDisponible.AutoSize = true;
            this.labelPackDisponible.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPackDisponible.Location = new System.Drawing.Point(344, 528);
            this.labelPackDisponible.Name = "labelPackDisponible";
            this.labelPackDisponible.Size = new System.Drawing.Size(216, 15);
            this.labelPackDisponible.TabIndex = 48;
            this.labelPackDisponible.Text = "Les packs disponibles pour cette moto";
            // 
            // fichePackOptions1
            // 
            this.fichePackOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fichePackOptions1.Location = new System.Drawing.Point(283, 567);
            this.fichePackOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptions1.Name = "fichePackOptions1";
            this.fichePackOptions1.PackOptionsSelectionnee = null;
            this.fichePackOptions1.Size = new System.Drawing.Size(347, 158);
            this.fichePackOptions1.TabIndex = 50;
            this.fichePackOptions1.TexteFiltrePackOptions = "";
            // 
            // ficheOptions1
            // 
            this.ficheOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptions1.FicheAvecFiltre = true;
            this.ficheOptions1.Location = new System.Drawing.Point(283, 358);
            this.ficheOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptions1.Name = "ficheOptions1";
            this.ficheOptions1.OptionsSelectionnee = null;
            this.ficheOptions1.Size = new System.Drawing.Size(347, 166);
            this.ficheOptions1.TabIndex = 18;
            this.ficheOptions1.TexteFiltreOptions = "";
            // 
            // listeDeroulanteTypeOptions1
            // 
            this.listeDeroulanteTypeOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteTypeOptions1.Location = new System.Drawing.Point(431, 312);
            this.listeDeroulanteTypeOptions1.Name = "listeDeroulanteTypeOptions1";
            this.listeDeroulanteTypeOptions1.Size = new System.Drawing.Size(175, 21);
            this.listeDeroulanteTypeOptions1.TabIndex = 16;
            this.listeDeroulanteTypeOptions1.TypeOptionsSelectionne = null;
            // 
            // ficheTechnique1
            // 
            this.ficheTechnique1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheTechnique1.CaracteristiqueSelectionnee = null;
            this.ficheTechnique1.Location = new System.Drawing.Point(283, 130);
            this.ficheTechnique1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheTechnique1.Name = "ficheTechnique1";
            this.ficheTechnique1.Size = new System.Drawing.Size(347, 155);
            this.ficheTechnique1.TabIndex = 11;
            this.ficheTechnique1.TexteFiltreTechnique = "";
            // 
            // listeDeroulanteVehicule1
            // 
            this.listeDeroulanteVehicule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteVehicule1.Location = new System.Drawing.Point(634, 48);
            this.listeDeroulanteVehicule1.Name = "listeDeroulanteVehicule1";
            this.listeDeroulanteVehicule1.Size = new System.Drawing.Size(178, 21);
            this.listeDeroulanteVehicule1.TabIndex = 1;
            this.listeDeroulanteVehicule1.VehiculeSelectionne = null;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 750);
            this.menu1.TabIndex = 0;
            // 
            // Page_CatalogueMoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fichePackOptions1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelPackDisponible);
            this.Controls.Add(this.buttonPasserCommande);
            this.Controls.Add(this.buttonDisponibilité);
            this.Controls.Add(this.labelDisponibilite);
            this.Controls.Add(this.textBoxDispo);
            this.Controls.Add(this.labelEstimationDateLivraison);
            this.Controls.Add(this.textBoxEstimationLivraison);
            this.Controls.Add(this.labelPrixCatalogue);
            this.Controls.Add(this.textBoxPrix);
            this.Controls.Add(this.pictureBoxMoto);
            this.Controls.Add(this.labelRechercheOptions);
            this.Controls.Add(this.labelRechercheFicheTechnique);
            this.Controls.Add(this.ficheOptions1);
            this.Controls.Add(this.labelTypeOption);
            this.Controls.Add(this.listeDeroulanteTypeOptions1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelFicheTechnique);
            this.Controls.Add(this.ficheTechnique1);
            this.Controls.Add(this.labelChercherMoto);
            this.Controls.Add(this.listeDeroulanteVehicule1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Name = "Page_CatalogueMoto";
            this.Size = new System.Drawing.Size(1100, 750);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Menu menu1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCatalogueMoto;
        private ButtonClose buttonClose1;
        private ListeDeroulanteVehicule listeDeroulanteVehicule1;
        private System.Windows.Forms.Label labelChercherMoto;
        private FicheTechnique ficheTechnique1;
        private System.Windows.Forms.Label labelFicheTechnique;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private ListeDeroulanteTypeOptions listeDeroulanteTypeOptions1;
        private System.Windows.Forms.Label labelTypeOption;
        private FicheOptions ficheOptions1;
        private System.Windows.Forms.Label labelRechercheFicheTechnique;
        private System.Windows.Forms.Label labelRechercheOptions;
        private System.Windows.Forms.PictureBox pictureBoxMoto;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.Label labelPrixCatalogue;
        private System.Windows.Forms.Label labelEstimationDateLivraison;
        private System.Windows.Forms.TextBox textBoxEstimationLivraison;
        private System.Windows.Forms.Label labelDisponibilite;
        private System.Windows.Forms.TextBox textBoxDispo;
        private System.Windows.Forms.Button buttonDisponibilité;
        private System.Windows.Forms.Button buttonPasserCommande;
        private System.Windows.Forms.Label label2;
        private FichePackOptions fichePackOptions1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPackDisponible;
    }
}
