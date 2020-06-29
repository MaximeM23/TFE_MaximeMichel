namespace app_tfe_michel_maxime
{
    partial class Page_Facture
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
            this.labelTitreFacture = new System.Windows.Forms.Label();
            this.panelFactureVente = new System.Windows.Forms.Panel();
            this.buttonImprimerFacture = new System.Windows.Forms.Button();
            this.buttonImprimerBonCommande = new System.Windows.Forms.Button();
            this.ficheFactureVente1 = new app_tfe_michel_maxime.FicheFactureVente();
            this.listeDeroulanteClient1 = new app_tfe_michel_maxime.ListeDeroulanteClient();
            this.labelRechercheClient = new System.Windows.Forms.Label();
            this.labelRechercheFacture = new System.Windows.Forms.Label();
            this.listeDeroulanteFactureVente1 = new app_tfe_michel_maxime.ListeDeroulanteFactureVente();
            this.buttonFactureVente = new System.Windows.Forms.Button();
            this.buttonFactureReparation = new System.Windows.Forms.Button();
            this.panelFacturesReparationsEntretiens = new System.Windows.Forms.Panel();
            this.buttonFactureEntretienReparation = new System.Windows.Forms.Button();
            this.listeDeroulanteFacture1 = new app_tfe_michel_maxime.ListeDeroulanteFacture();
            this.listeDeroulanteClient2 = new app_tfe_michel_maxime.ListeDeroulanteClient();
            this.ficheFacture = new app_tfe_michel_maxime.FicheFacture();
            this.labelFacture = new System.Windows.Forms.Label();
            this.labelNomClient = new System.Windows.Forms.Label();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.panel1.SuspendLayout();
            this.panelFactureVente.SuspendLayout();
            this.panelFacturesReparationsEntretiens.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelTitreFacture);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 42);
            this.panel1.TabIndex = 10;
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
            // labelTitreFacture
            // 
            this.labelTitreFacture.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitreFacture.AutoSize = true;
            this.labelTitreFacture.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitreFacture.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitreFacture.Location = new System.Drawing.Point(385, 1);
            this.labelTitreFacture.Name = "labelTitreFacture";
            this.labelTitreFacture.Size = new System.Drawing.Size(128, 39);
            this.labelTitreFacture.TabIndex = 0;
            this.labelTitreFacture.Text = "Factures";
            this.labelTitreFacture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitreFacture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitreFacture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // panelFactureVente
            // 
            this.panelFactureVente.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFactureVente.Controls.Add(this.buttonImprimerFacture);
            this.panelFactureVente.Controls.Add(this.buttonImprimerBonCommande);
            this.panelFactureVente.Controls.Add(this.ficheFactureVente1);
            this.panelFactureVente.Controls.Add(this.listeDeroulanteClient1);
            this.panelFactureVente.Controls.Add(this.labelRechercheClient);
            this.panelFactureVente.Controls.Add(this.labelRechercheFacture);
            this.panelFactureVente.Controls.Add(this.listeDeroulanteFactureVente1);
            this.panelFactureVente.Location = new System.Drawing.Point(200, 83);
            this.panelFactureVente.Name = "panelFactureVente";
            this.panelFactureVente.Size = new System.Drawing.Size(900, 667);
            this.panelFactureVente.TabIndex = 11;
            // 
            // buttonImprimerFacture
            // 
            this.buttonImprimerFacture.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImprimerFacture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonImprimerFacture.Enabled = false;
            this.buttonImprimerFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimerFacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimerFacture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonImprimerFacture.Location = new System.Drawing.Point(443, 619);
            this.buttonImprimerFacture.Name = "buttonImprimerFacture";
            this.buttonImprimerFacture.Size = new System.Drawing.Size(341, 40);
            this.buttonImprimerFacture.TabIndex = 6;
            this.buttonImprimerFacture.Text = "Imprimer la facture";
            this.buttonImprimerFacture.UseVisualStyleBackColor = false;
            this.buttonImprimerFacture.Click += new System.EventHandler(this.buttonImprimerFacture_Click);
            // 
            // buttonImprimerBonCommande
            // 
            this.buttonImprimerBonCommande.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonImprimerBonCommande.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonImprimerBonCommande.Enabled = false;
            this.buttonImprimerBonCommande.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimerBonCommande.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimerBonCommande.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonImprimerBonCommande.Location = new System.Drawing.Point(96, 619);
            this.buttonImprimerBonCommande.Name = "buttonImprimerBonCommande";
            this.buttonImprimerBonCommande.Size = new System.Drawing.Size(341, 40);
            this.buttonImprimerBonCommande.TabIndex = 5;
            this.buttonImprimerBonCommande.Text = "Imprimer le bon de commande";
            this.buttonImprimerBonCommande.UseVisualStyleBackColor = false;
            this.buttonImprimerBonCommande.Click += new System.EventHandler(this.buttonImprimerBonCommande_Click);
            // 
            // ficheFactureVente1
            // 
            this.ficheFactureVente1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ficheFactureVente1.FactureVenteSelectionnee = null;
            this.ficheFactureVente1.Location = new System.Drawing.Point(0, 64);
            this.ficheFactureVente1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheFactureVente1.Name = "ficheFactureVente1";
            this.ficheFactureVente1.Size = new System.Drawing.Size(900, 550);
            this.ficheFactureVente1.TabIndex = 234;
            this.ficheFactureVente1.TexteFiltreFactureVente = "";
            this.ficheFactureVente1.SizeChanged += new System.EventHandler(this.ficheFactureVente1_SizeChanged);
            // 
            // listeDeroulanteClient1
            // 
            this.listeDeroulanteClient1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listeDeroulanteClient1.ClientSelectionne = null;
            this.listeDeroulanteClient1.Location = new System.Drawing.Point(540, 25);
            this.listeDeroulanteClient1.Name = "listeDeroulanteClient1";
            this.listeDeroulanteClient1.Size = new System.Drawing.Size(164, 21);
            this.listeDeroulanteClient1.TabIndex = 4;
            // 
            // labelRechercheClient
            // 
            this.labelRechercheClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelRechercheClient.AutoSize = true;
            this.labelRechercheClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheClient.Location = new System.Drawing.Point(537, 7);
            this.labelRechercheClient.Name = "labelRechercheClient";
            this.labelRechercheClient.Size = new System.Drawing.Size(167, 15);
            this.labelRechercheClient.TabIndex = 232;
            this.labelRechercheClient.Text = "Rechercher par nom de client";
            // 
            // labelRechercheFacture
            // 
            this.labelRechercheFacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelRechercheFacture.AutoSize = true;
            this.labelRechercheFacture.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheFacture.Location = new System.Drawing.Point(193, 7);
            this.labelRechercheFacture.Name = "labelRechercheFacture";
            this.labelRechercheFacture.Size = new System.Drawing.Size(193, 15);
            this.labelRechercheFacture.TabIndex = 231;
            this.labelRechercheFacture.Text = "Rechercher par numéro de facture";
            // 
            // listeDeroulanteFactureVente1
            // 
            this.listeDeroulanteFactureVente1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listeDeroulanteFactureVente1.FactureVenteSelectionne = null;
            this.listeDeroulanteFactureVente1.Location = new System.Drawing.Point(208, 25);
            this.listeDeroulanteFactureVente1.Name = "listeDeroulanteFactureVente1";
            this.listeDeroulanteFactureVente1.Size = new System.Drawing.Size(164, 21);
            this.listeDeroulanteFactureVente1.TabIndex = 3;
            this.listeDeroulanteFactureVente1.Load += new System.EventHandler(this.listeDeroulanteFactureVente1_Load);
            // 
            // buttonFactureVente
            // 
            this.buttonFactureVente.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFactureVente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonFactureVente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFactureVente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFactureVente.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFactureVente.Location = new System.Drawing.Point(653, 45);
            this.buttonFactureVente.Name = "buttonFactureVente";
            this.buttonFactureVente.Size = new System.Drawing.Size(264, 34);
            this.buttonFactureVente.TabIndex = 2;
            this.buttonFactureVente.Text = "Facture de ventes";
            this.buttonFactureVente.UseVisualStyleBackColor = false;
            this.buttonFactureVente.Click += new System.EventHandler(this.buttonFactureVente_Click);
            // 
            // buttonFactureReparation
            // 
            this.buttonFactureReparation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonFactureReparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(173)))));
            this.buttonFactureReparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFactureReparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFactureReparation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFactureReparation.Location = new System.Drawing.Point(383, 45);
            this.buttonFactureReparation.Name = "buttonFactureReparation";
            this.buttonFactureReparation.Size = new System.Drawing.Size(264, 34);
            this.buttonFactureReparation.TabIndex = 1;
            this.buttonFactureReparation.Text = "Facture de réparations ou d\'entretiens";
            this.buttonFactureReparation.UseVisualStyleBackColor = false;
            this.buttonFactureReparation.Click += new System.EventHandler(this.buttonFactureReparation_Click);
            // 
            // panelFacturesReparationsEntretiens
            // 
            this.panelFacturesReparationsEntretiens.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelFacturesReparationsEntretiens.Controls.Add(this.buttonFactureEntretienReparation);
            this.panelFacturesReparationsEntretiens.Controls.Add(this.listeDeroulanteFacture1);
            this.panelFacturesReparationsEntretiens.Controls.Add(this.listeDeroulanteClient2);
            this.panelFacturesReparationsEntretiens.Controls.Add(this.ficheFacture);
            this.panelFacturesReparationsEntretiens.Controls.Add(this.labelFacture);
            this.panelFacturesReparationsEntretiens.Controls.Add(this.labelNomClient);
            this.panelFacturesReparationsEntretiens.Location = new System.Drawing.Point(200, 83);
            this.panelFacturesReparationsEntretiens.Name = "panelFacturesReparationsEntretiens";
            this.panelFacturesReparationsEntretiens.Size = new System.Drawing.Size(900, 667);
            this.panelFacturesReparationsEntretiens.TabIndex = 238;
            // 
            // buttonFactureEntretienReparation
            // 
            this.buttonFactureEntretienReparation.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonFactureEntretienReparation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonFactureEntretienReparation.Enabled = false;
            this.buttonFactureEntretienReparation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFactureEntretienReparation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFactureEntretienReparation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonFactureEntretienReparation.Location = new System.Drawing.Point(275, 619);
            this.buttonFactureEntretienReparation.Name = "buttonFactureEntretienReparation";
            this.buttonFactureEntretienReparation.Size = new System.Drawing.Size(341, 40);
            this.buttonFactureEntretienReparation.TabIndex = 9;
            this.buttonFactureEntretienReparation.Text = "Imprimer la facture";
            this.buttonFactureEntretienReparation.UseVisualStyleBackColor = false;
            this.buttonFactureEntretienReparation.Click += new System.EventHandler(this.buttonFactureEntretienReparation_Click);
            // 
            // listeDeroulanteFacture1
            // 
            this.listeDeroulanteFacture1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listeDeroulanteFacture1.FactureSelectionne = null;
            this.listeDeroulanteFacture1.Location = new System.Drawing.Point(238, 25);
            this.listeDeroulanteFacture1.Name = "listeDeroulanteFacture1";
            this.listeDeroulanteFacture1.Size = new System.Drawing.Size(164, 21);
            this.listeDeroulanteFacture1.TabIndex = 7;
            this.listeDeroulanteFacture1.Load += new System.EventHandler(this.listeDeroulanteFacture1_Load);
            // 
            // listeDeroulanteClient2
            // 
            this.listeDeroulanteClient2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.listeDeroulanteClient2.ClientSelectionne = null;
            this.listeDeroulanteClient2.Location = new System.Drawing.Point(511, 25);
            this.listeDeroulanteClient2.Name = "listeDeroulanteClient2";
            this.listeDeroulanteClient2.Size = new System.Drawing.Size(164, 21);
            this.listeDeroulanteClient2.TabIndex = 8;
            // 
            // ficheFacture
            // 
            this.ficheFacture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ficheFacture.FactureSelectionnee = null;
            this.ficheFacture.Location = new System.Drawing.Point(2, 51);
            this.ficheFacture.Margin = new System.Windows.Forms.Padding(2);
            this.ficheFacture.Name = "ficheFacture";
            this.ficheFacture.Size = new System.Drawing.Size(898, 563);
            this.ficheFacture.TabIndex = 0;
            this.ficheFacture.TexteFiltreFacture = "";
            this.ficheFacture.SizeChanged += new System.EventHandler(this.ficheFacture_SizeChanged);
            // 
            // labelFacture
            // 
            this.labelFacture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelFacture.AutoSize = true;
            this.labelFacture.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFacture.Location = new System.Drawing.Point(225, 7);
            this.labelFacture.Name = "labelFacture";
            this.labelFacture.Size = new System.Drawing.Size(193, 15);
            this.labelFacture.TabIndex = 235;
            this.labelFacture.Text = "Rechercher par numéro de facture";
            // 
            // labelNomClient
            // 
            this.labelNomClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.labelNomClient.AutoSize = true;
            this.labelNomClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomClient.Location = new System.Drawing.Point(508, 7);
            this.labelNomClient.Name = "labelNomClient";
            this.labelNomClient.Size = new System.Drawing.Size(167, 15);
            this.labelNomClient.TabIndex = 234;
            this.labelNomClient.Text = "Rechercher par nom de client";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 750);
            this.menu1.TabIndex = 9;
            // 
            // Page_Facture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonFactureReparation);
            this.Controls.Add(this.buttonFactureVente);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.panelFacturesReparationsEntretiens);
            this.Controls.Add(this.panelFactureVente);
            this.Name = "Page_Facture";
            this.Size = new System.Drawing.Size(1100, 750);
            this.Load += new System.EventHandler(this.Page_Facture_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelFactureVente.ResumeLayout(false);
            this.panelFactureVente.PerformLayout();
            this.panelFacturesReparationsEntretiens.ResumeLayout(false);
            this.panelFacturesReparationsEntretiens.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelTitreFacture;
        private Menu menu1;
        private System.Windows.Forms.Panel panelFactureVente;
        private System.Windows.Forms.Button buttonImprimerFacture;
        private System.Windows.Forms.Button buttonImprimerBonCommande;
        private FicheFactureVente ficheFactureVente1;
        private ListeDeroulanteClient listeDeroulanteClient1;
        private System.Windows.Forms.Label labelRechercheClient;
        private System.Windows.Forms.Label labelRechercheFacture;
        private ListeDeroulanteFactureVente listeDeroulanteFactureVente1;
        private System.Windows.Forms.Button buttonFactureVente;
        private System.Windows.Forms.Button buttonFactureReparation;
        private System.Windows.Forms.Panel panelFacturesReparationsEntretiens;
        private FicheFacture ficheFacture;
        private System.Windows.Forms.Label labelFacture;
        private System.Windows.Forms.Label labelNomClient;
        private ListeDeroulanteClient listeDeroulanteClient2;
        private ListeDeroulanteFacture listeDeroulanteFacture1;
        private System.Windows.Forms.Button buttonFactureEntretienReparation;
    }
}
