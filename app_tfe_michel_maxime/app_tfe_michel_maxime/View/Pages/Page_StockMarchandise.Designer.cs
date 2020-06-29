namespace app_tfe_michel_maxime
{
    partial class Page_StockMarchandise
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
            this.components = new System.ComponentModel.Container();
            this.labelRechercheClient = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.labelStockDeMarchandise = new System.Windows.Forms.Label();
            this.textBoxNomArticle = new System.Windows.Forms.TextBox();
            this.labelNomArticle = new System.Windows.Forms.Label();
            this.labelPrixUnitaire = new System.Windows.Forms.Label();
            this.labelQuantite = new System.Windows.Forms.Label();
            this.numericUpDownQuantite = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPrixUnitaire = new System.Windows.Forms.NumericUpDown();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.ficheArticle1 = new app_tfe_michel_maxime.FicheArticle();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixUnitaire)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelRechercheClient
            // 
            this.labelRechercheClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheClient.AutoSize = true;
            this.labelRechercheClient.Font = new System.Drawing.Font("Calibri", 12F);
            this.labelRechercheClient.Location = new System.Drawing.Point(582, 85);
            this.labelRechercheClient.Name = "labelRechercheClient";
            this.labelRechercheClient.Size = new System.Drawing.Size(147, 19);
            this.labelRechercheClient.TabIndex = 191;
            this.labelRechercheClient.Text = "Rechercher un article";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelStockDeMarchandise);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 42);
            this.panel1.TabIndex = 189;
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
            // labelStockDeMarchandise
            // 
            this.labelStockDeMarchandise.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelStockDeMarchandise.AutoSize = true;
            this.labelStockDeMarchandise.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStockDeMarchandise.ForeColor = System.Drawing.SystemColors.Window;
            this.labelStockDeMarchandise.Location = new System.Drawing.Point(313, 1);
            this.labelStockDeMarchandise.Name = "labelStockDeMarchandise";
            this.labelStockDeMarchandise.Size = new System.Drawing.Size(317, 39);
            this.labelStockDeMarchandise.TabIndex = 0;
            this.labelStockDeMarchandise.Text = "Stock de marchandises";
            this.labelStockDeMarchandise.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelStockDeMarchandise.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelStockDeMarchandise.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxNomArticle
            // 
            this.textBoxNomArticle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNomArticle.Location = new System.Drawing.Point(331, 619);
            this.textBoxNomArticle.Name = "textBoxNomArticle";
            this.textBoxNomArticle.Size = new System.Drawing.Size(152, 20);
            this.textBoxNomArticle.TabIndex = 1;
            // 
            // labelNomArticle
            // 
            this.labelNomArticle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomArticle.AutoSize = true;
            this.labelNomArticle.Font = new System.Drawing.Font("Calibri", 9.2F);
            this.labelNomArticle.Location = new System.Drawing.Point(356, 601);
            this.labelNomArticle.Name = "labelNomArticle";
            this.labelNomArticle.Size = new System.Drawing.Size(93, 15);
            this.labelNomArticle.TabIndex = 194;
            this.labelNomArticle.Text = "Nom de l\'article";
            // 
            // labelPrixUnitaire
            // 
            this.labelPrixUnitaire.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixUnitaire.AutoSize = true;
            this.labelPrixUnitaire.Font = new System.Drawing.Font("Calibri", 9.2F);
            this.labelPrixUnitaire.Location = new System.Drawing.Point(891, 602);
            this.labelPrixUnitaire.Name = "labelPrixUnitaire";
            this.labelPrixUnitaire.Size = new System.Drawing.Size(76, 15);
            this.labelPrixUnitaire.TabIndex = 195;
            this.labelPrixUnitaire.Text = "Prix unitaire";
            // 
            // labelQuantite
            // 
            this.labelQuantite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelQuantite.AutoSize = true;
            this.labelQuantite.Font = new System.Drawing.Font("Calibri", 9.2F);
            this.labelQuantite.Location = new System.Drawing.Point(638, 602);
            this.labelQuantite.Name = "labelQuantite";
            this.labelQuantite.Size = new System.Drawing.Size(54, 15);
            this.labelQuantite.TabIndex = 196;
            this.labelQuantite.Text = "Quantité";
            // 
            // numericUpDownQuantite
            // 
            this.numericUpDownQuantite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownQuantite.Location = new System.Drawing.Point(595, 620);
            this.numericUpDownQuantite.Name = "numericUpDownQuantite";
            this.numericUpDownQuantite.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownQuantite.TabIndex = 2;
            // 
            // numericUpDownPrixUnitaire
            // 
            this.numericUpDownPrixUnitaire.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownPrixUnitaire.Location = new System.Drawing.Point(857, 620);
            this.numericUpDownPrixUnitaire.Name = "numericUpDownPrixUnitaire";
            this.numericUpDownPrixUnitaire.Size = new System.Drawing.Size(152, 20);
            this.numericUpDownPrixUnitaire.TabIndex = 3;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouter.Location = new System.Drawing.Point(234, 690);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(152, 40);
            this.buttonAjouter.TabIndex = 4;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.Enabled = false;
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifier.Location = new System.Drawing.Point(468, 690);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(152, 40);
            this.buttonModifier.TabIndex = 5;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSupprimer.Enabled = false;
            this.buttonSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSupprimer.Location = new System.Drawing.Point(703, 690);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(152, 40);
            this.buttonSupprimer.TabIndex = 6;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = false;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnuler.Location = new System.Drawing.Point(918, 690);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(152, 40);
            this.buttonAnnuler.TabIndex = 197;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = false;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // ficheArticle1
            // 
            this.ficheArticle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ficheArticle1.ArticleSelectionnee = null;
            this.ficheArticle1.Location = new System.Drawing.Point(200, 106);
            this.ficheArticle1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheArticle1.Name = "ficheArticle1";
            this.ficheArticle1.Size = new System.Drawing.Size(900, 494);
            this.ficheArticle1.TabIndex = 192;
            this.ficheArticle1.TexteFiltreArticle = "";
            this.ficheArticle1.Load += new System.EventHandler(this.ficheArticle1_Load);
            this.ficheArticle1.SizeChanged += new System.EventHandler(this.ficheArticle1_SizeChanged);
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 750);
            this.menu1.TabIndex = 188;
            // 
            // Page_StockMarchandise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonSupprimer);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.numericUpDownPrixUnitaire);
            this.Controls.Add(this.numericUpDownQuantite);
            this.Controls.Add(this.labelQuantite);
            this.Controls.Add(this.labelPrixUnitaire);
            this.Controls.Add(this.labelNomArticle);
            this.Controls.Add(this.textBoxNomArticle);
            this.Controls.Add(this.ficheArticle1);
            this.Controls.Add(this.labelRechercheClient);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Name = "Page_StockMarchandise";
            this.Size = new System.Drawing.Size(1100, 750);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownQuantite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixUnitaire)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelRechercheClient;
        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelStockDeMarchandise;
        private Menu menu1;
        private FicheArticle ficheArticle1;
        private System.Windows.Forms.TextBox textBoxNomArticle;
        private System.Windows.Forms.Label labelNomArticle;
        private System.Windows.Forms.Label labelPrixUnitaire;
        private System.Windows.Forms.Label labelQuantite;
        private System.Windows.Forms.NumericUpDown numericUpDownQuantite;
        private System.Windows.Forms.NumericUpDown numericUpDownPrixUnitaire;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.Button buttonAnnuler;
    }
}
