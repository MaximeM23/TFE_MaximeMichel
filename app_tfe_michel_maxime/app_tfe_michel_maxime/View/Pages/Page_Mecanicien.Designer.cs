namespace app_tfe_michel_maxime
{
    partial class Page_Mecanicien
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelPlanning = new System.Windows.Forms.Label();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelModel = new System.Windows.Forms.Label();
            this.labelNumChassis = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxModele = new System.Windows.Forms.TextBox();
            this.textBoxImmatriculation = new System.Windows.Forms.TextBox();
            this.textBoxChassis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.InfoSupp = new System.Windows.Forms.Label();
            this.textBoxInfoSupp = new System.Windows.Forms.TextBox();
            this.labelHPrestation = new System.Windows.Forms.Label();
            this.labelActuel = new System.Windows.Forms.Label();
            this.numericUpDownH = new System.Windows.Forms.NumericUpDown();
            this.labelConseil = new System.Windows.Forms.Label();
            this.textBoxConseil = new System.Windows.Forms.TextBox();
            this.labelArticleUtilise = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.pictureBoxRetirerA = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterA = new System.Windows.Forms.PictureBox();
            this.pictureBoxRetirerH = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterH = new System.Windows.Forms.PictureBox();
            this.buttonTerminer = new System.Windows.Forms.Button();
            this.labelTotal = new System.Windows.Forms.Label();
            this.textBoxPrixTotal = new System.Windows.Forms.TextBox();
            this.labelEntretienPrévu = new System.Windows.Forms.Label();
            this.textBoxEntretienAFaire = new System.Windows.Forms.TextBox();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.ficheArticleFacture = new app_tfe_michel_maxime.FicheArticleFacture();
            this.ficheArticlesComplet = new app_tfe_michel_maxime.FicheArticle();
            this.ficheTechnique = new app_tfe_michel_maxime.FicheTechnique();
            this.CalendrierRdv = new app_tfe_michel_maxime.CalendrierRdv();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterH)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.labelPlanning);
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Location = new System.Drawing.Point(198, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1318, 48);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPlanning
            // 
            this.labelPlanning.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelPlanning.AutoSize = true;
            this.labelPlanning.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPlanning.ForeColor = System.Drawing.Color.White;
            this.labelPlanning.Location = new System.Drawing.Point(593, 5);
            this.labelPlanning.Name = "labelPlanning";
            this.labelPlanning.Size = new System.Drawing.Size(129, 39);
            this.labelPlanning.TabIndex = 0;
            this.labelPlanning.Text = "Planning";
            this.labelPlanning.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPlanning.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPlanning.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(1191, 3);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(121, 37);
            this.buttonClose1.TabIndex = 4;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(330, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Informations sur le véhicule";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(245, 246);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(418, 1);
            this.panel2.TabIndex = 14;
            // 
            // labelModel
            // 
            this.labelModel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelModel.AutoSize = true;
            this.labelModel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelModel.Location = new System.Drawing.Point(252, 274);
            this.labelModel.Name = "labelModel";
            this.labelModel.Size = new System.Drawing.Size(114, 15);
            this.labelModel.TabIndex = 17;
            this.labelModel.Text = "Modèle du véhicule";
            // 
            // labelNumChassis
            // 
            this.labelNumChassis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumChassis.AutoSize = true;
            this.labelNumChassis.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumChassis.Location = new System.Drawing.Point(399, 274);
            this.labelNumChassis.Name = "labelNumChassis";
            this.labelNumChassis.Size = new System.Drawing.Size(111, 15);
            this.labelNumChassis.TabIndex = 18;
            this.labelNumChassis.Text = "Numéro de châssis";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(547, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Immatriculation";
            // 
            // textBoxModele
            // 
            this.textBoxModele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxModele.Enabled = false;
            this.textBoxModele.Location = new System.Drawing.Point(245, 295);
            this.textBoxModele.Name = "textBoxModele";
            this.textBoxModele.Size = new System.Drawing.Size(129, 23);
            this.textBoxModele.TabIndex = 20;
            // 
            // textBoxImmatriculation
            // 
            this.textBoxImmatriculation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxImmatriculation.Enabled = false;
            this.textBoxImmatriculation.Location = new System.Drawing.Point(533, 295);
            this.textBoxImmatriculation.Name = "textBoxImmatriculation";
            this.textBoxImmatriculation.Size = new System.Drawing.Size(129, 23);
            this.textBoxImmatriculation.TabIndex = 21;
            // 
            // textBoxChassis
            // 
            this.textBoxChassis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxChassis.Enabled = false;
            this.textBoxChassis.Location = new System.Drawing.Point(391, 295);
            this.textBoxChassis.Name = "textBoxChassis";
            this.textBoxChassis.Size = new System.Drawing.Size(129, 23);
            this.textBoxChassis.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(408, 342);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 23;
            this.label3.Text = "Fiche technique";
            // 
            // InfoSupp
            // 
            this.InfoSupp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.InfoSupp.AutoSize = true;
            this.InfoSupp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InfoSupp.Location = new System.Drawing.Point(304, 602);
            this.InfoSupp.Name = "InfoSupp";
            this.InfoSupp.Size = new System.Drawing.Size(299, 15);
            this.InfoSupp.TabIndex = 25;
            this.InfoSupp.Text = "Informations sur les tâches à réaliser sur le véhicule ";
            // 
            // textBoxInfoSupp
            // 
            this.textBoxInfoSupp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxInfoSupp.Enabled = false;
            this.textBoxInfoSupp.Location = new System.Drawing.Point(245, 620);
            this.textBoxInfoSupp.Multiline = true;
            this.textBoxInfoSupp.Name = "textBoxInfoSupp";
            this.textBoxInfoSupp.Size = new System.Drawing.Size(417, 171);
            this.textBoxInfoSupp.TabIndex = 26;
            // 
            // labelHPrestation
            // 
            this.labelHPrestation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelHPrestation.AutoSize = true;
            this.labelHPrestation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHPrestation.Location = new System.Drawing.Point(768, 273);
            this.labelHPrestation.Name = "labelHPrestation";
            this.labelHPrestation.Size = new System.Drawing.Size(203, 15);
            this.labelHPrestation.TabIndex = 27;
            this.labelHPrestation.Text = "Heures de prestation sur le véhicule";
            // 
            // labelActuel
            // 
            this.labelActuel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelActuel.AutoSize = true;
            this.labelActuel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelActuel.Location = new System.Drawing.Point(768, 310);
            this.labelActuel.Name = "labelActuel";
            this.labelActuel.Size = new System.Drawing.Size(41, 15);
            this.labelActuel.TabIndex = 28;
            this.labelActuel.Text = "Actuel";
            // 
            // numericUpDownH
            // 
            this.numericUpDownH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownH.Enabled = false;
            this.numericUpDownH.Location = new System.Drawing.Point(822, 306);
            this.numericUpDownH.Name = "numericUpDownH";
            this.numericUpDownH.Size = new System.Drawing.Size(42, 23);
            this.numericUpDownH.TabIndex = 29;
            // 
            // labelConseil
            // 
            this.labelConseil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelConseil.AutoSize = true;
            this.labelConseil.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConseil.Location = new System.Drawing.Point(736, 372);
            this.labelConseil.Name = "labelConseil";
            this.labelConseil.Size = new System.Drawing.Size(265, 15);
            this.labelConseil.TabIndex = 33;
            this.labelConseil.Text = "Conseil pour une future réparation ou entretien";
            // 
            // textBoxConseil
            // 
            this.textBoxConseil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxConseil.Location = new System.Drawing.Point(737, 393);
            this.textBoxConseil.Multiline = true;
            this.textBoxConseil.Name = "textBoxConseil";
            this.textBoxConseil.Size = new System.Drawing.Size(305, 171);
            this.textBoxConseil.TabIndex = 1;
            // 
            // labelArticleUtilise
            // 
            this.labelArticleUtilise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelArticleUtilise.AutoSize = true;
            this.labelArticleUtilise.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelArticleUtilise.Location = new System.Drawing.Point(1159, 220);
            this.labelArticleUtilise.Name = "labelArticleUtilise";
            this.labelArticleUtilise.Size = new System.Drawing.Size(239, 23);
            this.labelArticleUtilise.TabIndex = 36;
            this.labelArticleUtilise.Text = "Articles utilisés sur le véhicule";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(1073, 246);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(418, 1);
            this.panel3.TabIndex = 35;
            // 
            // pictureBoxRetirerA
            // 
            this.pictureBoxRetirerA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerA.Image = global::app_tfe_michel_maxime.Properties.Resources.rowUp;
            this.pictureBoxRetirerA.Location = new System.Drawing.Point(1296, 461);
            this.pictureBoxRetirerA.Name = "pictureBoxRetirerA";
            this.pictureBoxRetirerA.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxRetirerA.TabIndex = 39;
            this.pictureBoxRetirerA.TabStop = false;
            this.pictureBoxRetirerA.Click += new System.EventHandler(this.pictureBoxRetirerA_Click);
            // 
            // pictureBoxAjouterA
            // 
            this.pictureBoxAjouterA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterA.Image = global::app_tfe_michel_maxime.Properties.Resources.rowDown;
            this.pictureBoxAjouterA.Location = new System.Drawing.Point(1234, 460);
            this.pictureBoxAjouterA.Name = "pictureBoxAjouterA";
            this.pictureBoxAjouterA.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxAjouterA.TabIndex = 38;
            this.pictureBoxAjouterA.TabStop = false;
            this.pictureBoxAjouterA.Click += new System.EventHandler(this.pictureBoxAjouterA_Click);
            // 
            // pictureBoxRetirerH
            // 
            this.pictureBoxRetirerH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerH.Image = global::app_tfe_michel_maxime.Properties.Resources.moins;
            this.pictureBoxRetirerH.Location = new System.Drawing.Point(937, 303);
            this.pictureBoxRetirerH.Name = "pictureBoxRetirerH";
            this.pictureBoxRetirerH.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxRetirerH.TabIndex = 32;
            this.pictureBoxRetirerH.TabStop = false;
            this.pictureBoxRetirerH.Click += new System.EventHandler(this.pictureBoxRetirerH_Click);
            // 
            // pictureBoxAjouterH
            // 
            this.pictureBoxAjouterH.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterH.Image = global::app_tfe_michel_maxime.Properties.Resources.plus;
            this.pictureBoxAjouterH.Location = new System.Drawing.Point(886, 303);
            this.pictureBoxAjouterH.Name = "pictureBoxAjouterH";
            this.pictureBoxAjouterH.Size = new System.Drawing.Size(28, 28);
            this.pictureBoxAjouterH.TabIndex = 31;
            this.pictureBoxAjouterH.TabStop = false;
            this.pictureBoxAjouterH.Click += new System.EventHandler(this.pictureBoxAjouterH_Click);
            // 
            // buttonTerminer
            // 
            this.buttonTerminer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonTerminer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonTerminer.Enabled = false;
            this.buttonTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTerminer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonTerminer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonTerminer.Location = new System.Drawing.Point(1347, 751);
            this.buttonTerminer.Name = "buttonTerminer";
            this.buttonTerminer.Size = new System.Drawing.Size(134, 40);
            this.buttonTerminer.TabIndex = 2;
            this.buttonTerminer.Text = "Terminer";
            this.buttonTerminer.UseVisualStyleBackColor = false;
            this.buttonTerminer.Click += new System.EventHandler(this.buttonTerminer_Click);
            // 
            // labelTotal
            // 
            this.labelTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTotal.AutoSize = true;
            this.labelTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTotal.Location = new System.Drawing.Point(1115, 764);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(58, 15);
            this.labelTotal.TabIndex = 43;
            this.labelTotal.Text = "Prix total";
            // 
            // textBoxPrixTotal
            // 
            this.textBoxPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrixTotal.Enabled = false;
            this.textBoxPrixTotal.Location = new System.Drawing.Point(1196, 761);
            this.textBoxPrixTotal.Name = "textBoxPrixTotal";
            this.textBoxPrixTotal.Size = new System.Drawing.Size(124, 23);
            this.textBoxPrixTotal.TabIndex = 44;
            this.textBoxPrixTotal.Text = "0 €";
            // 
            // labelEntretienPrévu
            // 
            this.labelEntretienPrévu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEntretienPrévu.AutoSize = true;
            this.labelEntretienPrévu.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntretienPrévu.Location = new System.Drawing.Point(845, 636);
            this.labelEntretienPrévu.Name = "labelEntretienPrévu";
            this.labelEntretienPrévu.Size = new System.Drawing.Size(89, 15);
            this.labelEntretienPrévu.TabIndex = 45;
            this.labelEntretienPrévu.Text = "Entretien prévu";
            // 
            // textBoxEntretienAFaire
            // 
            this.textBoxEntretienAFaire.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEntretienAFaire.Enabled = false;
            this.textBoxEntretienAFaire.Location = new System.Drawing.Point(739, 654);
            this.textBoxEntretienAFaire.Name = "textBoxEntretienAFaire";
            this.textBoxEntretienAFaire.Size = new System.Drawing.Size(303, 23);
            this.textBoxEntretienAFaire.TabIndex = 46;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(215, 801);
            this.menu1.TabIndex = 47;
            // 
            // ficheArticleFacture
            // 
            this.ficheArticleFacture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheArticleFacture.ArticleSelectionnee = null;
            this.ficheArticleFacture.Location = new System.Drawing.Point(1085, 521);
            this.ficheArticleFacture.Margin = new System.Windows.Forms.Padding(2);
            this.ficheArticleFacture.Name = "ficheArticleFacture";
            this.ficheArticleFacture.Size = new System.Drawing.Size(397, 225);
            this.ficheArticleFacture.TabIndex = 42;
            this.ficheArticleFacture.TexteFiltreArticleFacture = "";
            // 
            // ficheArticlesComplet
            // 
            this.ficheArticlesComplet.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheArticlesComplet.ArticleSelectionnee = null;
            this.ficheArticlesComplet.Location = new System.Drawing.Point(1086, 253);
            this.ficheArticlesComplet.Margin = new System.Windows.Forms.Padding(2);
            this.ficheArticlesComplet.Name = "ficheArticlesComplet";
            this.ficheArticlesComplet.Size = new System.Drawing.Size(396, 202);
            this.ficheArticlesComplet.TabIndex = 37;
            this.ficheArticlesComplet.TexteFiltreArticle = "";
            // 
            // ficheTechnique
            // 
            this.ficheTechnique.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheTechnique.CaracteristiqueSelectionnee = null;
            this.ficheTechnique.Location = new System.Drawing.Point(245, 359);
            this.ficheTechnique.Margin = new System.Windows.Forms.Padding(2);
            this.ficheTechnique.Name = "ficheTechnique";
            this.ficheTechnique.Size = new System.Drawing.Size(418, 238);
            this.ficheTechnique.TabIndex = 24;
            this.ficheTechnique.TexteFiltreTechnique = "";
            // 
            // CalendrierRdv
            // 
            this.CalendrierRdv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalendrierRdv.FactureSelectionnee = null;
            this.CalendrierRdv.Location = new System.Drawing.Point(211, 47);
            this.CalendrierRdv.Name = "CalendrierRdv";
            this.CalendrierRdv.Size = new System.Drawing.Size(1305, 162);
            this.CalendrierRdv.TabIndex = 8;
            // 
            // Page_Mecanicien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.textBoxEntretienAFaire);
            this.Controls.Add(this.labelEntretienPrévu);
            this.Controls.Add(this.textBoxPrixTotal);
            this.Controls.Add(this.labelTotal);
            this.Controls.Add(this.ficheArticleFacture);
            this.Controls.Add(this.buttonTerminer);
            this.Controls.Add(this.pictureBoxRetirerA);
            this.Controls.Add(this.pictureBoxAjouterA);
            this.Controls.Add(this.ficheArticlesComplet);
            this.Controls.Add(this.labelArticleUtilise);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.textBoxConseil);
            this.Controls.Add(this.labelConseil);
            this.Controls.Add(this.pictureBoxRetirerH);
            this.Controls.Add(this.pictureBoxAjouterH);
            this.Controls.Add(this.numericUpDownH);
            this.Controls.Add(this.labelActuel);
            this.Controls.Add(this.labelHPrestation);
            this.Controls.Add(this.textBoxInfoSupp);
            this.Controls.Add(this.InfoSupp);
            this.Controls.Add(this.ficheTechnique);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxChassis);
            this.Controls.Add(this.textBoxImmatriculation);
            this.Controls.Add(this.textBoxModele);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelNumChassis);
            this.Controls.Add(this.labelModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.CalendrierRdv);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Page_Mecanicien";
            this.Size = new System.Drawing.Size(1513, 801);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterH)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelPlanning;
        private app_tfe_michel_maxime.CalendrierRdv CalendrierRdv;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxChassis;
        private System.Windows.Forms.TextBox textBoxImmatriculation;
        private System.Windows.Forms.TextBox textBoxModele;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNumChassis;
        private System.Windows.Forms.Label labelModel;
        private System.Windows.Forms.Label InfoSupp;
        private FicheTechnique ficheTechnique;
        private System.Windows.Forms.PictureBox pictureBoxRetirerH;
        private System.Windows.Forms.PictureBox pictureBoxAjouterH;
        private System.Windows.Forms.NumericUpDown numericUpDownH;
        private System.Windows.Forms.Label labelActuel;
        private System.Windows.Forms.Label labelHPrestation;
        private System.Windows.Forms.TextBox textBoxInfoSupp;
        private System.Windows.Forms.Label labelArticleUtilise;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxConseil;
        private System.Windows.Forms.Label labelConseil;
        private FicheArticle ficheArticlesComplet;
        private System.Windows.Forms.PictureBox pictureBoxRetirerA;
        private System.Windows.Forms.PictureBox pictureBoxAjouterA;
        private System.Windows.Forms.Button buttonTerminer;
        private FicheArticleFacture ficheArticleFacture;
        private System.Windows.Forms.TextBox textBoxPrixTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.TextBox textBoxEntretienAFaire;
        private System.Windows.Forms.Label labelEntretienPrévu;
        private Menu menu1;
    }
}
