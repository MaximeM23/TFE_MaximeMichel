namespace app_tfe_michel_maxime
{
    partial class Page_Options
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
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelOptions = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPacks = new System.Windows.Forms.Label();
            this.labelRechercheOptions = new System.Windows.Forms.Label();
            this.labelRecherchePack = new System.Windows.Forms.Label();
            this.textBoxNomOption = new System.Windows.Forms.TextBox();
            this.labelNomOption = new System.Windows.Forms.Label();
            this.labelCategorie = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAnnulerO = new System.Windows.Forms.Button();
            this.buttonModifierO = new System.Windows.Forms.Button();
            this.buttonAjouterO = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNomDuPack = new System.Windows.Forms.Label();
            this.textBoxNomPack = new System.Windows.Forms.TextBox();
            this.labelPrixPack = new System.Windows.Forms.Label();
            this.numericUpDownPrixOption = new System.Windows.Forms.NumericUpDown();
            this.pictureBoxPackR = new System.Windows.Forms.PictureBox();
            this.pictureBoxPackA = new System.Windows.Forms.PictureBox();
            this.buttonAnnulerP = new System.Windows.Forms.Button();
            this.buttonModifierP = new System.Windows.Forms.Button();
            this.buttonAjouterP = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.numericUpDownPrixPack = new System.Windows.Forms.NumericUpDown();
            this.labelRechercheListePack = new System.Windows.Forms.Label();
            this.buttonSupprimerOptions = new System.Windows.Forms.Button();
            this.buttonSupprimerPack = new System.Windows.Forms.Button();
            this.listeDeroulantePackOptions1 = new app_tfe_michel_maxime.ListeDeroulantePackOptions();
            this.ficheOptionsPackRecherche = new app_tfe_michel_maxime.FicheOptions();
            this.ficheOptionsPackActuel = new app_tfe_michel_maxime.FicheOptions();
            this.listeDeroulanteTypeOptions1 = new app_tfe_michel_maxime.ListeDeroulanteTypeOptions();
            this.ficheOptionsAjouter = new app_tfe_michel_maxime.FicheOptions();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixOption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPackR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPackA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixPack)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Location = new System.Drawing.Point(193, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1155, 42);
            this.panel1.TabIndex = 14;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelTitre
            // 
            this.labelTitre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitre.Location = new System.Drawing.Point(497, -1);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(230, 39);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Packs et options";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelOptions
            // 
            this.labelOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptions.Location = new System.Drawing.Point(256, 45);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(98, 23);
            this.labelOptions.TabIndex = 18;
            this.labelOptions.Text = "Les options";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(260, 349);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1025, 1);
            this.panel2.TabIndex = 17;
            // 
            // labelPacks
            // 
            this.labelPacks.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPacks.AutoSize = true;
            this.labelPacks.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPacks.Location = new System.Drawing.Point(256, 353);
            this.labelPacks.Name = "labelPacks";
            this.labelPacks.Size = new System.Drawing.Size(160, 23);
            this.labelPacks.TabIndex = 19;
            this.labelPacks.Text = "Les packs d\'options";
            // 
            // labelRechercheOptions
            // 
            this.labelRechercheOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheOptions.AutoSize = true;
            this.labelRechercheOptions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheOptions.Location = new System.Drawing.Point(431, 78);
            this.labelRechercheOptions.Name = "labelRechercheOptions";
            this.labelRechercheOptions.Size = new System.Drawing.Size(122, 15);
            this.labelRechercheOptions.TabIndex = 20;
            this.labelRechercheOptions.Text = "Recherche spécifique";
            // 
            // labelRecherchePack
            // 
            this.labelRecherchePack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRecherchePack.AutoSize = true;
            this.labelRecherchePack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRecherchePack.Location = new System.Drawing.Point(339, 391);
            this.labelRecherchePack.Name = "labelRecherchePack";
            this.labelRecherchePack.Size = new System.Drawing.Size(301, 15);
            this.labelRecherchePack.TabIndex = 21;
            this.labelRecherchePack.Text = "Recherche spécifique sur les options liées au véhicule";
            // 
            // textBoxNomOption
            // 
            this.textBoxNomOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNomOption.Location = new System.Drawing.Point(883, 125);
            this.textBoxNomOption.Name = "textBoxNomOption";
            this.textBoxNomOption.Size = new System.Drawing.Size(187, 20);
            this.textBoxNomOption.TabIndex = 1;
            // 
            // labelNomOption
            // 
            this.labelNomOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomOption.AutoSize = true;
            this.labelNomOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomOption.Location = new System.Drawing.Point(757, 127);
            this.labelNomOption.Name = "labelNomOption";
            this.labelNomOption.Size = new System.Drawing.Size(93, 15);
            this.labelNomOption.TabIndex = 23;
            this.labelNomOption.Text = "Nom de l\'option";
            // 
            // labelCategorie
            // 
            this.labelCategorie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCategorie.AutoSize = true;
            this.labelCategorie.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCategorie.Location = new System.Drawing.Point(757, 186);
            this.labelCategorie.Name = "labelCategorie";
            this.labelCategorie.Size = new System.Drawing.Size(114, 15);
            this.labelCategorie.TabIndex = 24;
            this.labelCategorie.Text = "Liste des catégories";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(757, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 15);
            this.label1.TabIndex = 25;
            this.label1.Text = "Prix de l\'option";
            // 
            // buttonAnnulerO
            // 
            this.buttonAnnulerO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulerO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulerO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulerO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnulerO.Location = new System.Drawing.Point(1119, 256);
            this.buttonAnnulerO.Name = "buttonAnnulerO";
            this.buttonAnnulerO.Size = new System.Drawing.Size(152, 40);
            this.buttonAnnulerO.TabIndex = 7;
            this.buttonAnnulerO.Text = "Annuler";
            this.buttonAnnulerO.UseVisualStyleBackColor = false;
            this.buttonAnnulerO.Click += new System.EventHandler(this.buttonAnnulerO_Click);
            // 
            // buttonModifierO
            // 
            this.buttonModifierO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifierO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifierO.Enabled = false;
            this.buttonModifierO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifierO.Location = new System.Drawing.Point(1119, 150);
            this.buttonModifierO.Name = "buttonModifierO";
            this.buttonModifierO.Size = new System.Drawing.Size(152, 40);
            this.buttonModifierO.TabIndex = 5;
            this.buttonModifierO.Text = "Modifier";
            this.buttonModifierO.UseVisualStyleBackColor = false;
            this.buttonModifierO.Click += new System.EventHandler(this.buttonModifierO_Click);
            // 
            // buttonAjouterO
            // 
            this.buttonAjouterO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouterO.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouterO.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterO.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouterO.Location = new System.Drawing.Point(1119, 92);
            this.buttonAjouterO.Name = "buttonAjouterO";
            this.buttonAjouterO.Size = new System.Drawing.Size(152, 40);
            this.buttonAjouterO.TabIndex = 4;
            this.buttonAjouterO.Text = "Ajouter";
            this.buttonAjouterO.UseVisualStyleBackColor = false;
            this.buttonAjouterO.Click += new System.EventHandler(this.buttonAjouterO_Click);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(950, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(274, 15);
            this.label2.TabIndex = 155;
            this.label2.Text = "Recherche spécifique sur les options disponibles";
            // 
            // labelNomDuPack
            // 
            this.labelNomDuPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomDuPack.AutoSize = true;
            this.labelNomDuPack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomDuPack.Location = new System.Drawing.Point(304, 674);
            this.labelNomDuPack.Name = "labelNomDuPack";
            this.labelNomDuPack.Size = new System.Drawing.Size(78, 15);
            this.labelNomDuPack.TabIndex = 157;
            this.labelNomDuPack.Text = "Nom du pack";
            // 
            // textBoxNomPack
            // 
            this.textBoxNomPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNomPack.Location = new System.Drawing.Point(388, 672);
            this.textBoxNomPack.Name = "textBoxNomPack";
            this.textBoxNomPack.Size = new System.Drawing.Size(187, 20);
            this.textBoxNomPack.TabIndex = 9;
            // 
            // labelPrixPack
            // 
            this.labelPrixPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixPack.AutoSize = true;
            this.labelPrixPack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixPack.Location = new System.Drawing.Point(304, 699);
            this.labelPrixPack.Name = "labelPrixPack";
            this.labelPrixPack.Size = new System.Drawing.Size(75, 15);
            this.labelPrixPack.TabIndex = 159;
            this.labelPrixPack.Text = "Prix du pack";
            // 
            // numericUpDownPrixOption
            // 
            this.numericUpDownPrixOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownPrixOption.Location = new System.Drawing.Point(883, 246);
            this.numericUpDownPrixOption.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownPrixOption.Name = "numericUpDownPrixOption";
            this.numericUpDownPrixOption.Size = new System.Drawing.Size(187, 20);
            this.numericUpDownPrixOption.TabIndex = 3;
            // 
            // pictureBoxPackR
            // 
            this.pictureBoxPackR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxPackR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPackR.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheDroite;
            this.pictureBoxPackR.Location = new System.Drawing.Point(760, 534);
            this.pictureBoxPackR.Name = "pictureBoxPackR";
            this.pictureBoxPackR.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxPackR.TabIndex = 162;
            this.pictureBoxPackR.TabStop = false;
            this.pictureBoxPackR.Click += new System.EventHandler(this.pictureBoxPackR_Click);
            // 
            // pictureBoxPackA
            // 
            this.pictureBoxPackA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxPackA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxPackA.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheGauche;
            this.pictureBoxPackA.Location = new System.Drawing.Point(760, 447);
            this.pictureBoxPackA.Name = "pictureBoxPackA";
            this.pictureBoxPackA.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxPackA.TabIndex = 161;
            this.pictureBoxPackA.TabStop = false;
            this.pictureBoxPackA.Click += new System.EventHandler(this.pictureBoxPackA_Click);
            // 
            // buttonAnnulerP
            // 
            this.buttonAnnulerP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulerP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulerP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulerP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnulerP.Location = new System.Drawing.Point(1181, 674);
            this.buttonAnnulerP.Name = "buttonAnnulerP";
            this.buttonAnnulerP.Size = new System.Drawing.Size(152, 40);
            this.buttonAnnulerP.TabIndex = 14;
            this.buttonAnnulerP.Text = "Annuler";
            this.buttonAnnulerP.UseVisualStyleBackColor = false;
            this.buttonAnnulerP.Click += new System.EventHandler(this.buttonAnnulerP_Click);
            // 
            // buttonModifierP
            // 
            this.buttonModifierP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifierP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifierP.Enabled = false;
            this.buttonModifierP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifierP.Location = new System.Drawing.Point(815, 674);
            this.buttonModifierP.Name = "buttonModifierP";
            this.buttonModifierP.Size = new System.Drawing.Size(152, 40);
            this.buttonModifierP.TabIndex = 12;
            this.buttonModifierP.Text = "Modifier";
            this.buttonModifierP.UseVisualStyleBackColor = false;
            this.buttonModifierP.Click += new System.EventHandler(this.buttonModifierP_Click);
            // 
            // buttonAjouterP
            // 
            this.buttonAjouterP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouterP.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouterP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouterP.Location = new System.Drawing.Point(630, 674);
            this.buttonAjouterP.Name = "buttonAjouterP";
            this.buttonAjouterP.Size = new System.Drawing.Size(152, 40);
            this.buttonAjouterP.TabIndex = 11;
            this.buttonAjouterP.Text = "Ajouter";
            this.buttonAjouterP.UseVisualStyleBackColor = false;
            this.buttonAjouterP.Click += new System.EventHandler(this.buttonAjouterP_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // numericUpDownPrixPack
            // 
            this.numericUpDownPrixPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownPrixPack.Location = new System.Drawing.Point(388, 698);
            this.numericUpDownPrixPack.Name = "numericUpDownPrixPack";
            this.numericUpDownPrixPack.Size = new System.Drawing.Size(187, 20);
            this.numericUpDownPrixPack.TabIndex = 10;
            // 
            // labelRechercheListePack
            // 
            this.labelRechercheListePack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheListePack.AutoSize = true;
            this.labelRechercheListePack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheListePack.Location = new System.Drawing.Point(735, 356);
            this.labelRechercheListePack.Name = "labelRechercheListePack";
            this.labelRechercheListePack.Size = new System.Drawing.Size(114, 15);
            this.labelRechercheListePack.TabIndex = 170;
            this.labelRechercheListePack.Text = "Rechercher un pack";
            // 
            // buttonSupprimerOptions
            // 
            this.buttonSupprimerOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSupprimerOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSupprimerOptions.Enabled = false;
            this.buttonSupprimerOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimerOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimerOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSupprimerOptions.Location = new System.Drawing.Point(1119, 203);
            this.buttonSupprimerOptions.Name = "buttonSupprimerOptions";
            this.buttonSupprimerOptions.Size = new System.Drawing.Size(152, 40);
            this.buttonSupprimerOptions.TabIndex = 6;
            this.buttonSupprimerOptions.Text = "Supprimer";
            this.buttonSupprimerOptions.UseVisualStyleBackColor = false;
            this.buttonSupprimerOptions.Click += new System.EventHandler(this.buttonSupprimerOptions_Click);
            // 
            // buttonSupprimerPack
            // 
            this.buttonSupprimerPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSupprimerPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSupprimerPack.Enabled = false;
            this.buttonSupprimerPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimerPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimerPack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSupprimerPack.Location = new System.Drawing.Point(997, 674);
            this.buttonSupprimerPack.Name = "buttonSupprimerPack";
            this.buttonSupprimerPack.Size = new System.Drawing.Size(152, 40);
            this.buttonSupprimerPack.TabIndex = 13;
            this.buttonSupprimerPack.Text = "Supprimer";
            this.buttonSupprimerPack.UseVisualStyleBackColor = false;
            this.buttonSupprimerPack.Click += new System.EventHandler(this.buttonSupprimerPack_Click);
            // 
            // listeDeroulantePackOptions1
            // 
            this.listeDeroulantePackOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulantePackOptions1.Location = new System.Drawing.Point(721, 374);
            this.listeDeroulantePackOptions1.Name = "listeDeroulantePackOptions1";
            this.listeDeroulantePackOptions1.PackOptionPackVehiculeSelectionne = null;
            this.listeDeroulantePackOptions1.Size = new System.Drawing.Size(150, 20);
            this.listeDeroulantePackOptions1.TabIndex = 8;
            // 
            // ficheOptionsPackRecherche
            // 
            this.ficheOptionsPackRecherche.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptionsPackRecherche.FicheAvecFiltre = true;
            this.ficheOptionsPackRecherche.Location = new System.Drawing.Point(883, 408);
            this.ficheOptionsPackRecherche.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsPackRecherche.Name = "ficheOptionsPackRecherche";
            this.ficheOptionsPackRecherche.OptionsSelectionnee = null;
            this.ficheOptionsPackRecherche.Size = new System.Drawing.Size(388, 240);
            this.ficheOptionsPackRecherche.TabIndex = 167;
            this.ficheOptionsPackRecherche.TexteFiltreOptions = "";
            // 
            // ficheOptionsPackActuel
            // 
            this.ficheOptionsPackActuel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptionsPackActuel.FicheAvecFiltre = true;
            this.ficheOptionsPackActuel.Location = new System.Drawing.Point(300, 408);
            this.ficheOptionsPackActuel.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsPackActuel.Name = "ficheOptionsPackActuel";
            this.ficheOptionsPackActuel.OptionsSelectionnee = null;
            this.ficheOptionsPackActuel.Size = new System.Drawing.Size(388, 240);
            this.ficheOptionsPackActuel.TabIndex = 166;
            this.ficheOptionsPackActuel.TexteFiltreOptions = "";
            // 
            // listeDeroulanteTypeOptions1
            // 
            this.listeDeroulanteTypeOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteTypeOptions1.Location = new System.Drawing.Point(883, 182);
            this.listeDeroulanteTypeOptions1.Name = "listeDeroulanteTypeOptions1";
            this.listeDeroulanteTypeOptions1.Size = new System.Drawing.Size(187, 21);
            this.listeDeroulanteTypeOptions1.TabIndex = 2;
            this.listeDeroulanteTypeOptions1.TypeOptionsSelectionne = null;
            // 
            // ficheOptionsAjouter
            // 
            this.ficheOptionsAjouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptionsAjouter.FicheAvecFiltre = true;
            this.ficheOptionsAjouter.Location = new System.Drawing.Point(300, 94);
            this.ficheOptionsAjouter.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsAjouter.Name = "ficheOptionsAjouter";
            this.ficheOptionsAjouter.OptionsSelectionnee = null;
            this.ficheOptionsAjouter.Size = new System.Drawing.Size(388, 240);
            this.ficheOptionsAjouter.TabIndex = 16;
            this.ficheOptionsAjouter.TexteFiltreOptions = "";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 748);
            this.menu1.TabIndex = 13;
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(1045, 1);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(108, 37);
            this.buttonClose1.TabIndex = 9;
            // 
            // Page_Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSupprimerPack);
            this.Controls.Add(this.buttonSupprimerOptions);
            this.Controls.Add(this.labelRechercheListePack);
            this.Controls.Add(this.listeDeroulantePackOptions1);
            this.Controls.Add(this.numericUpDownPrixPack);
            this.Controls.Add(this.ficheOptionsPackRecherche);
            this.Controls.Add(this.ficheOptionsPackActuel);
            this.Controls.Add(this.buttonAnnulerP);
            this.Controls.Add(this.buttonModifierP);
            this.Controls.Add(this.buttonAjouterP);
            this.Controls.Add(this.pictureBoxPackR);
            this.Controls.Add(this.pictureBoxPackA);
            this.Controls.Add(this.numericUpDownPrixOption);
            this.Controls.Add(this.labelPrixPack);
            this.Controls.Add(this.labelNomDuPack);
            this.Controls.Add(this.textBoxNomPack);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonAnnulerO);
            this.Controls.Add(this.buttonModifierO);
            this.Controls.Add(this.buttonAjouterO);
            this.Controls.Add(this.listeDeroulanteTypeOptions1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelCategorie);
            this.Controls.Add(this.labelNomOption);
            this.Controls.Add(this.textBoxNomOption);
            this.Controls.Add(this.labelRecherchePack);
            this.Controls.Add(this.labelRechercheOptions);
            this.Controls.Add(this.labelPacks);
            this.Controls.Add(this.labelOptions);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ficheOptionsAjouter);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.panel1);
            this.Name = "Page_Options";
            this.Size = new System.Drawing.Size(1347, 748);
            this.Load += new System.EventHandler(this.Page_Options_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixOption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPackR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPackA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrixPack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Menu menu1;
        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelTitre;
        private FicheOptions ficheOptionsAjouter;
        private System.Windows.Forms.Label labelOptions;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelPacks;
        private System.Windows.Forms.Label labelRechercheOptions;
        private System.Windows.Forms.Label labelRecherchePack;
        private System.Windows.Forms.TextBox textBoxNomOption;
        private System.Windows.Forms.Label labelNomOption;
        private System.Windows.Forms.Label labelCategorie;
        private System.Windows.Forms.Label label1;
        private ListeDeroulanteTypeOptions listeDeroulanteTypeOptions1;
        private System.Windows.Forms.Button buttonAnnulerO;
        private System.Windows.Forms.Button buttonModifierO;
        private System.Windows.Forms.Button buttonAjouterO;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNomDuPack;
        private System.Windows.Forms.TextBox textBoxNomPack;
        private System.Windows.Forms.Label labelPrixPack;
        private System.Windows.Forms.NumericUpDown numericUpDownPrixOption;
        private System.Windows.Forms.PictureBox pictureBoxPackA;
        private System.Windows.Forms.PictureBox pictureBoxPackR;
        private System.Windows.Forms.Button buttonAnnulerP;
        private System.Windows.Forms.Button buttonModifierP;
        private System.Windows.Forms.Button buttonAjouterP;
        private FicheOptions ficheOptionsPackActuel;
        private FicheOptions ficheOptionsPackRecherche;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.NumericUpDown numericUpDownPrixPack;
        private System.Windows.Forms.Label labelRechercheListePack;
        private ListeDeroulantePackOptions listeDeroulantePackOptions1;
        private System.Windows.Forms.Button buttonSupprimerOptions;
        private System.Windows.Forms.Button buttonSupprimerPack;
    }
}
