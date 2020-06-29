namespace app_tfe_michel_maxime
{
    partial class Page_NouveauVehicule
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
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.labelTitre = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAnnulerModele = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.numericUpDownPrix = new System.Windows.Forms.NumericUpDown();
            this.labelRechercheVehicule = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAjouterImage = new System.Windows.Forms.Button();
            this.numericUpDownTempsLivraison = new System.Windows.Forms.NumericUpDown();
            this.labelTempsLivraison = new System.Windows.Forms.Label();
            this.labelNomModele = new System.Windows.Forms.Label();
            this.textBoxModele = new System.Windows.Forms.TextBox();
            this.labelPrixCatalogue = new System.Windows.Forms.Label();
            this.panelLier = new System.Windows.Forms.Panel();
            this.listeDeroulanteTypeVehiculeFiltre = new app_tfe_michel_maxime.ListeDeroulanteTypeVehicule();
            this.labelChoixTypeCaract = new System.Windows.Forms.Label();
            this.buttonModifierLier = new System.Windows.Forms.Button();
            this.pictureBoxCaractR = new System.Windows.Forms.PictureBox();
            this.pictureBoxCaractA = new System.Windows.Forms.PictureBox();
            this.listeDeroulanteCaracteristique1 = new app_tfe_michel_maxime.ListeDeroulanteCaracteristique();
            this.buttonAnnulerCaract = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.ficheTechnique1 = new app_tfe_michel_maxime.FicheTechnique();
            this.labelCaractExistante = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFicheTechnique = new System.Windows.Forms.Label();
            this.buttonPanelAjouterCaract = new System.Windows.Forms.Button();
            this.buttonPanelLierCaract = new System.Windows.Forms.Button();
            this.panelAjouterCaract = new System.Windows.Forms.Panel();
            this.buttonAnnulerCaractAjout = new System.Windows.Forms.Button();
            this.labelTypeCorrespondant = new System.Windows.Forms.Label();
            this.listeDeroulanteTypeVehicule1 = new app_tfe_michel_maxime.ListeDeroulanteTypeVehicule();
            this.buttonSupprimerCaract = new System.Windows.Forms.Button();
            this.buttonModifierCaract = new System.Windows.Forms.Button();
            this.buttonAjouterCaract = new System.Windows.Forms.Button();
            this.listeDeroulanteCaracteristiqueAjouter = new app_tfe_michel_maxime.ListeDeroulanteCaracteristique();
            this.label2 = new System.Windows.Forms.Label();
            this.labelNomCaract = new System.Windows.Forms.Label();
            this.textBoxNomCaract = new System.Windows.Forms.TextBox();
            this.buttonLierPack = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonLierOptions = new System.Windows.Forms.Button();
            this.buttonSupprimer = new System.Windows.Forms.Button();
            this.listeDeroulanteVehicule1 = new app_tfe_michel_maxime.ListeDeroulanteVehicule();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.lierOptions = new app_tfe_michel_maxime.LierOptions();
            this.lierPack = new app_tfe_michel_maxime.LierPack();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrix)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempsLivraison)).BeginInit();
            this.panelLier.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaractR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaractA)).BeginInit();
            this.panelAjouterCaract.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(1108, 42);
            this.panel1.TabIndex = 20;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(998, 1);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(108, 37);
            this.buttonClose1.TabIndex = 9;
            // 
            // labelTitre
            // 
            this.labelTitre.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.ForeColor = System.Drawing.SystemColors.Window;
            this.labelTitre.Location = new System.Drawing.Point(490, -1);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(187, 39);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Les véhicules";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(259, 319);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1000, 1);
            this.panel2.TabIndex = 219;
            // 
            // buttonAnnulerModele
            // 
            this.buttonAnnulerModele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulerModele.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulerModele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulerModele.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerModele.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnulerModele.Location = new System.Drawing.Point(1072, 238);
            this.buttonAnnulerModele.Name = "buttonAnnulerModele";
            this.buttonAnnulerModele.Size = new System.Drawing.Size(111, 40);
            this.buttonAnnulerModele.TabIndex = 9;
            this.buttonAnnulerModele.Text = "Annuler";
            this.buttonAnnulerModele.UseVisualStyleBackColor = false;
            this.buttonAnnulerModele.Click += new System.EventHandler(this.buttonAnnulerModele_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.Enabled = false;
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifier.Location = new System.Drawing.Point(1072, 146);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(111, 40);
            this.buttonModifier.TabIndex = 7;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouter.Location = new System.Drawing.Point(1072, 100);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(111, 40);
            this.buttonAjouter.TabIndex = 6;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // numericUpDownPrix
            // 
            this.numericUpDownPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownPrix.Location = new System.Drawing.Point(464, 120);
            this.numericUpDownPrix.Name = "numericUpDownPrix";
            this.numericUpDownPrix.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownPrix.TabIndex = 3;
            // 
            // labelRechercheVehicule
            // 
            this.labelRechercheVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheVehicule.AutoSize = true;
            this.labelRechercheVehicule.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheVehicule.Location = new System.Drawing.Point(609, 52);
            this.labelRechercheVehicule.Name = "labelRechercheVehicule";
            this.labelRechercheVehicule.Size = new System.Drawing.Size(134, 15);
            this.labelRechercheVehicule.TabIndex = 199;
            this.labelRechercheVehicule.Text = "Rechercher un véhicule";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(318, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 15);
            this.label1.TabIndex = 197;
            this.label1.Text = "Choisir une image";
            // 
            // buttonAjouterImage
            // 
            this.buttonAjouterImage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouterImage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouterImage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouterImage.Location = new System.Drawing.Point(464, 171);
            this.buttonAjouterImage.Name = "buttonAjouterImage";
            this.buttonAjouterImage.Size = new System.Drawing.Size(181, 40);
            this.buttonAjouterImage.TabIndex = 5;
            this.buttonAjouterImage.Text = "Choisir une image";
            this.buttonAjouterImage.UseVisualStyleBackColor = false;
            this.buttonAjouterImage.Click += new System.EventHandler(this.buttonAjouterImage_Click);
            // 
            // numericUpDownTempsLivraison
            // 
            this.numericUpDownTempsLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownTempsLivraison.Location = new System.Drawing.Point(464, 145);
            this.numericUpDownTempsLivraison.Name = "numericUpDownTempsLivraison";
            this.numericUpDownTempsLivraison.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownTempsLivraison.TabIndex = 4;
            // 
            // labelTempsLivraison
            // 
            this.labelTempsLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTempsLivraison.AutoSize = true;
            this.labelTempsLivraison.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTempsLivraison.Location = new System.Drawing.Point(290, 147);
            this.labelTempsLivraison.Name = "labelTempsLivraison";
            this.labelTempsLivraison.Size = new System.Drawing.Size(172, 15);
            this.labelTempsLivraison.TabIndex = 194;
            this.labelTempsLivraison.Text = "Temps de livraison ( en jours )";
            // 
            // labelNomModele
            // 
            this.labelNomModele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomModele.AutoSize = true;
            this.labelNomModele.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomModele.Location = new System.Drawing.Point(327, 95);
            this.labelNomModele.Name = "labelNomModele";
            this.labelNomModele.Size = new System.Drawing.Size(92, 15);
            this.labelNomModele.TabIndex = 193;
            this.labelNomModele.Text = "Nom du modèle";
            // 
            // textBoxModele
            // 
            this.textBoxModele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxModele.Location = new System.Drawing.Point(464, 93);
            this.textBoxModele.Name = "textBoxModele";
            this.textBoxModele.Size = new System.Drawing.Size(181, 20);
            this.textBoxModele.TabIndex = 2;
            // 
            // labelPrixCatalogue
            // 
            this.labelPrixCatalogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixCatalogue.AutoSize = true;
            this.labelPrixCatalogue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixCatalogue.Location = new System.Drawing.Point(329, 121);
            this.labelPrixCatalogue.Name = "labelPrixCatalogue";
            this.labelPrixCatalogue.Size = new System.Drawing.Size(86, 15);
            this.labelPrixCatalogue.TabIndex = 191;
            this.labelPrixCatalogue.Text = "Prix catalogue";
            // 
            // panelLier
            // 
            this.panelLier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelLier.Controls.Add(this.listeDeroulanteTypeVehiculeFiltre);
            this.panelLier.Controls.Add(this.labelChoixTypeCaract);
            this.panelLier.Controls.Add(this.buttonModifierLier);
            this.panelLier.Controls.Add(this.pictureBoxCaractR);
            this.panelLier.Controls.Add(this.pictureBoxCaractA);
            this.panelLier.Controls.Add(this.listeDeroulanteCaracteristique1);
            this.panelLier.Controls.Add(this.buttonAnnulerCaract);
            this.panelLier.Controls.Add(this.textBoxInfo);
            this.panelLier.Controls.Add(this.ficheTechnique1);
            this.panelLier.Controls.Add(this.labelCaractExistante);
            this.panelLier.Controls.Add(this.label3);
            this.panelLier.Controls.Add(this.labelFicheTechnique);
            this.panelLier.Location = new System.Drawing.Point(259, 351);
            this.panelLier.Name = "panelLier";
            this.panelLier.Size = new System.Drawing.Size(1000, 302);
            this.panelLier.TabIndex = 223;
            // 
            // listeDeroulanteTypeVehiculeFiltre
            // 
            this.listeDeroulanteTypeVehiculeFiltre.Location = new System.Drawing.Point(633, 70);
            this.listeDeroulanteTypeVehiculeFiltre.Name = "listeDeroulanteTypeVehiculeFiltre";
            this.listeDeroulanteTypeVehiculeFiltre.Size = new System.Drawing.Size(205, 21);
            this.listeDeroulanteTypeVehiculeFiltre.TabIndex = 25;
            this.listeDeroulanteTypeVehiculeFiltre.TypeVehiculeSelectionne = null;
            this.listeDeroulanteTypeVehiculeFiltre.Load += new System.EventHandler(this.listeDeroulanteTypeVehiculeFiltre_Load);
            // 
            // labelChoixTypeCaract
            // 
            this.labelChoixTypeCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelChoixTypeCaract.AutoSize = true;
            this.labelChoixTypeCaract.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoixTypeCaract.Location = new System.Drawing.Point(630, 52);
            this.labelChoixTypeCaract.Name = "labelChoixTypeCaract";
            this.labelChoixTypeCaract.Size = new System.Drawing.Size(193, 15);
            this.labelChoixTypeCaract.TabIndex = 236;
            this.labelChoixTypeCaract.Text = "Choix d\'un type de caractéristique";
            // 
            // buttonModifierLier
            // 
            this.buttonModifierLier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifierLier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifierLier.Enabled = false;
            this.buttonModifierLier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierLier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierLier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifierLier.Location = new System.Drawing.Point(570, 240);
            this.buttonModifierLier.Name = "buttonModifierLier";
            this.buttonModifierLier.Size = new System.Drawing.Size(148, 40);
            this.buttonModifierLier.TabIndex = 28;
            this.buttonModifierLier.Text = "Modifier";
            this.buttonModifierLier.UseVisualStyleBackColor = false;
            this.buttonModifierLier.Click += new System.EventHandler(this.buttonModifierLier_Click);
            // 
            // pictureBoxCaractR
            // 
            this.pictureBoxCaractR.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCaractR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCaractR.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheDroite;
            this.pictureBoxCaractR.Location = new System.Drawing.Point(430, 175);
            this.pictureBoxCaractR.Name = "pictureBoxCaractR";
            this.pictureBoxCaractR.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxCaractR.TabIndex = 233;
            this.pictureBoxCaractR.TabStop = false;
            this.pictureBoxCaractR.Click += new System.EventHandler(this.pictureBoxCaractR_Click);
            // 
            // pictureBoxCaractA
            // 
            this.pictureBoxCaractA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxCaractA.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxCaractA.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheGauche;
            this.pictureBoxCaractA.Location = new System.Drawing.Point(430, 88);
            this.pictureBoxCaractA.Name = "pictureBoxCaractA";
            this.pictureBoxCaractA.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxCaractA.TabIndex = 232;
            this.pictureBoxCaractA.TabStop = false;
            this.pictureBoxCaractA.Click += new System.EventHandler(this.pictureBoxCaractA_Click);
            // 
            // listeDeroulanteCaracteristique1
            // 
            this.listeDeroulanteCaracteristique1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteCaracteristique1.CaracteristiqueSelectionne = null;
            this.listeDeroulanteCaracteristique1.Location = new System.Drawing.Point(633, 123);
            this.listeDeroulanteCaracteristique1.Name = "listeDeroulanteCaracteristique1";
            this.listeDeroulanteCaracteristique1.Size = new System.Drawing.Size(207, 21);
            this.listeDeroulanteCaracteristique1.TabIndex = 26;
            this.listeDeroulanteCaracteristique1.Load += new System.EventHandler(this.listeDeroulanteCaracteristique1_Load);
            // 
            // buttonAnnulerCaract
            // 
            this.buttonAnnulerCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulerCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulerCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulerCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnulerCaract.Location = new System.Drawing.Point(756, 240);
            this.buttonAnnulerCaract.Name = "buttonAnnulerCaract";
            this.buttonAnnulerCaract.Size = new System.Drawing.Size(148, 40);
            this.buttonAnnulerCaract.TabIndex = 29;
            this.buttonAnnulerCaract.Text = "Annuler";
            this.buttonAnnulerCaract.UseVisualStyleBackColor = false;
            this.buttonAnnulerCaract.Click += new System.EventHandler(this.buttonAnnulerCaract_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxInfo.Location = new System.Drawing.Point(633, 175);
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.Size = new System.Drawing.Size(205, 20);
            this.textBoxInfo.TabIndex = 27;
            // 
            // ficheTechnique1
            // 
            this.ficheTechnique1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheTechnique1.CaracteristiqueSelectionnee = null;
            this.ficheTechnique1.Location = new System.Drawing.Point(36, 40);
            this.ficheTechnique1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheTechnique1.Name = "ficheTechnique1";
            this.ficheTechnique1.Size = new System.Drawing.Size(352, 240);
            this.ficheTechnique1.TabIndex = 224;
            this.ficheTechnique1.TexteFiltreTechnique = "";
            // 
            // labelCaractExistante
            // 
            this.labelCaractExistante.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCaractExistante.AutoSize = true;
            this.labelCaractExistante.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCaractExistante.Location = new System.Drawing.Point(630, 105);
            this.labelCaractExistante.Name = "labelCaractExistante";
            this.labelCaractExistante.Size = new System.Drawing.Size(210, 15);
            this.labelCaractExistante.TabIndex = 230;
            this.labelCaractExistante.Text = "Choix d\'une caractéristique existante";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(630, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 15);
            this.label3.TabIndex = 226;
            this.label3.Text = "Information ";
            // 
            // labelFicheTechnique
            // 
            this.labelFicheTechnique.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFicheTechnique.AutoSize = true;
            this.labelFicheTechnique.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFicheTechnique.Location = new System.Drawing.Point(134, 23);
            this.labelFicheTechnique.Name = "labelFicheTechnique";
            this.labelFicheTechnique.Size = new System.Drawing.Size(165, 15);
            this.labelFicheTechnique.TabIndex = 223;
            this.labelFicheTechnique.Text = "Fiche technique de la voiture";
            // 
            // buttonPanelAjouterCaract
            // 
            this.buttonPanelAjouterCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPanelAjouterCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonPanelAjouterCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelAjouterCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanelAjouterCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonPanelAjouterCaract.Location = new System.Drawing.Point(340, 321);
            this.buttonPanelAjouterCaract.Name = "buttonPanelAjouterCaract";
            this.buttonPanelAjouterCaract.Size = new System.Drawing.Size(198, 29);
            this.buttonPanelAjouterCaract.TabIndex = 10;
            this.buttonPanelAjouterCaract.Text = "Ajouter une caractéristique";
            this.buttonPanelAjouterCaract.UseVisualStyleBackColor = false;
            this.buttonPanelAjouterCaract.Click += new System.EventHandler(this.buttonPanelAjouterCaract_Click);
            // 
            // buttonPanelLierCaract
            // 
            this.buttonPanelLierCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonPanelLierCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonPanelLierCaract.Enabled = false;
            this.buttonPanelLierCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPanelLierCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPanelLierCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonPanelLierCaract.Location = new System.Drawing.Point(544, 321);
            this.buttonPanelLierCaract.Name = "buttonPanelLierCaract";
            this.buttonPanelLierCaract.Size = new System.Drawing.Size(198, 29);
            this.buttonPanelLierCaract.TabIndex = 11;
            this.buttonPanelLierCaract.Text = "Lier les caractéristiques";
            this.buttonPanelLierCaract.UseVisualStyleBackColor = false;
            this.buttonPanelLierCaract.Click += new System.EventHandler(this.buttonPanelLierCaract_Click);
            // 
            // panelAjouterCaract
            // 
            this.panelAjouterCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panelAjouterCaract.Controls.Add(this.buttonAnnulerCaractAjout);
            this.panelAjouterCaract.Controls.Add(this.labelTypeCorrespondant);
            this.panelAjouterCaract.Controls.Add(this.listeDeroulanteTypeVehicule1);
            this.panelAjouterCaract.Controls.Add(this.buttonSupprimerCaract);
            this.panelAjouterCaract.Controls.Add(this.buttonModifierCaract);
            this.panelAjouterCaract.Controls.Add(this.buttonAjouterCaract);
            this.panelAjouterCaract.Controls.Add(this.listeDeroulanteCaracteristiqueAjouter);
            this.panelAjouterCaract.Controls.Add(this.label2);
            this.panelAjouterCaract.Controls.Add(this.labelNomCaract);
            this.panelAjouterCaract.Controls.Add(this.textBoxNomCaract);
            this.panelAjouterCaract.Location = new System.Drawing.Point(259, 351);
            this.panelAjouterCaract.Name = "panelAjouterCaract";
            this.panelAjouterCaract.Size = new System.Drawing.Size(1000, 302);
            this.panelAjouterCaract.TabIndex = 234;
            // 
            // buttonAnnulerCaractAjout
            // 
            this.buttonAnnulerCaractAjout.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulerCaractAjout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulerCaractAjout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulerCaractAjout.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulerCaractAjout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnulerCaractAjout.Location = new System.Drawing.Point(652, 183);
            this.buttonAnnulerCaractAjout.Name = "buttonAnnulerCaractAjout";
            this.buttonAnnulerCaractAjout.Size = new System.Drawing.Size(111, 40);
            this.buttonAnnulerCaractAjout.TabIndex = 20;
            this.buttonAnnulerCaractAjout.Text = "Annuler";
            this.buttonAnnulerCaractAjout.UseVisualStyleBackColor = false;
            this.buttonAnnulerCaractAjout.Click += new System.EventHandler(this.buttonAnnulerCaractAjout_Click);
            // 
            // labelTypeCorrespondant
            // 
            this.labelTypeCorrespondant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTypeCorrespondant.AutoSize = true;
            this.labelTypeCorrespondant.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypeCorrespondant.Location = new System.Drawing.Point(373, 142);
            this.labelTypeCorrespondant.Name = "labelTypeCorrespondant";
            this.labelTypeCorrespondant.Size = new System.Drawing.Size(115, 15);
            this.labelTypeCorrespondant.TabIndex = 236;
            this.labelTypeCorrespondant.Text = "Type correspondant";
            // 
            // listeDeroulanteTypeVehicule1
            // 
            this.listeDeroulanteTypeVehicule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteTypeVehicule1.Location = new System.Drawing.Point(494, 138);
            this.listeDeroulanteTypeVehicule1.Name = "listeDeroulanteTypeVehicule1";
            this.listeDeroulanteTypeVehicule1.Size = new System.Drawing.Size(140, 21);
            this.listeDeroulanteTypeVehicule1.TabIndex = 16;
            this.listeDeroulanteTypeVehicule1.TypeVehiculeSelectionne = null;
            this.listeDeroulanteTypeVehicule1.Load += new System.EventHandler(this.listeDeroulanteTypeVehicule1_Load);
            // 
            // buttonSupprimerCaract
            // 
            this.buttonSupprimerCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSupprimerCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSupprimerCaract.Enabled = false;
            this.buttonSupprimerCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimerCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimerCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSupprimerCaract.Location = new System.Drawing.Point(516, 183);
            this.buttonSupprimerCaract.Name = "buttonSupprimerCaract";
            this.buttonSupprimerCaract.Size = new System.Drawing.Size(111, 40);
            this.buttonSupprimerCaract.TabIndex = 19;
            this.buttonSupprimerCaract.Text = "Supprimer";
            this.buttonSupprimerCaract.UseVisualStyleBackColor = false;
            this.buttonSupprimerCaract.Click += new System.EventHandler(this.buttonSupprimerCaract_Click);
            // 
            // buttonModifierCaract
            // 
            this.buttonModifierCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifierCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifierCaract.Enabled = false;
            this.buttonModifierCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifierCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifierCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifierCaract.Location = new System.Drawing.Point(377, 183);
            this.buttonModifierCaract.Name = "buttonModifierCaract";
            this.buttonModifierCaract.Size = new System.Drawing.Size(111, 40);
            this.buttonModifierCaract.TabIndex = 18;
            this.buttonModifierCaract.Text = "Modifier";
            this.buttonModifierCaract.UseVisualStyleBackColor = false;
            this.buttonModifierCaract.Click += new System.EventHandler(this.buttonModifierCaract_Click);
            // 
            // buttonAjouterCaract
            // 
            this.buttonAjouterCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouterCaract.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouterCaract.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouterCaract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouterCaract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouterCaract.Location = new System.Drawing.Point(234, 183);
            this.buttonAjouterCaract.Name = "buttonAjouterCaract";
            this.buttonAjouterCaract.Size = new System.Drawing.Size(111, 40);
            this.buttonAjouterCaract.TabIndex = 17;
            this.buttonAjouterCaract.Text = "Ajouter";
            this.buttonAjouterCaract.UseVisualStyleBackColor = false;
            this.buttonAjouterCaract.Click += new System.EventHandler(this.buttonAjouterCaract_Click);
            // 
            // listeDeroulanteCaracteristiqueAjouter
            // 
            this.listeDeroulanteCaracteristiqueAjouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteCaracteristiqueAjouter.CaracteristiqueSelectionne = null;
            this.listeDeroulanteCaracteristiqueAjouter.Location = new System.Drawing.Point(403, 52);
            this.listeDeroulanteCaracteristiqueAjouter.Name = "listeDeroulanteCaracteristiqueAjouter";
            this.listeDeroulanteCaracteristiqueAjouter.Size = new System.Drawing.Size(207, 21);
            this.listeDeroulanteCaracteristiqueAjouter.TabIndex = 14;
            this.listeDeroulanteCaracteristiqueAjouter.Load += new System.EventHandler(this.listeDeroulanteCaracteristiqueAjouter_Load);
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(400, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 15);
            this.label2.TabIndex = 230;
            this.label2.Text = "Choix d\'une caractéristique existante";
            // 
            // labelNomCaract
            // 
            this.labelNomCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomCaract.AutoSize = true;
            this.labelNomCaract.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomCaract.Location = new System.Drawing.Point(386, 107);
            this.labelNomCaract.Name = "labelNomCaract";
            this.labelNomCaract.Size = new System.Drawing.Size(91, 15);
            this.labelNomCaract.TabIndex = 226;
            this.labelNomCaract.Text = "Caractéristique";
            // 
            // textBoxNomCaract
            // 
            this.textBoxNomCaract.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNomCaract.Location = new System.Drawing.Point(494, 105);
            this.textBoxNomCaract.Name = "textBoxNomCaract";
            this.textBoxNomCaract.Size = new System.Drawing.Size(140, 20);
            this.textBoxNomCaract.TabIndex = 15;
            // 
            // buttonLierPack
            // 
            this.buttonLierPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLierPack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonLierPack.Enabled = false;
            this.buttonLierPack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLierPack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLierPack.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonLierPack.Location = new System.Drawing.Point(748, 321);
            this.buttonLierPack.Name = "buttonLierPack";
            this.buttonLierPack.Size = new System.Drawing.Size(198, 29);
            this.buttonLierPack.TabIndex = 12;
            this.buttonLierPack.Text = "Lier les packs";
            this.buttonLierPack.UseVisualStyleBackColor = false;
            this.buttonLierPack.Click += new System.EventHandler(this.buttonLierPack_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Location = new System.Drawing.Point(687, 93);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(320, 192);
            this.pictureBox1.TabIndex = 218;
            this.pictureBox1.TabStop = false;
            // 
            // buttonLierOptions
            // 
            this.buttonLierOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonLierOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonLierOptions.Enabled = false;
            this.buttonLierOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLierOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLierOptions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonLierOptions.Location = new System.Drawing.Point(952, 321);
            this.buttonLierOptions.Name = "buttonLierOptions";
            this.buttonLierOptions.Size = new System.Drawing.Size(198, 29);
            this.buttonLierOptions.TabIndex = 13;
            this.buttonLierOptions.Text = "Lier les options";
            this.buttonLierOptions.UseVisualStyleBackColor = false;
            this.buttonLierOptions.Click += new System.EventHandler(this.buttonLierOptions_Click);
            // 
            // buttonSupprimer
            // 
            this.buttonSupprimer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSupprimer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSupprimer.Enabled = false;
            this.buttonSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSupprimer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSupprimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonSupprimer.Location = new System.Drawing.Point(1072, 192);
            this.buttonSupprimer.Name = "buttonSupprimer";
            this.buttonSupprimer.Size = new System.Drawing.Size(111, 40);
            this.buttonSupprimer.TabIndex = 8;
            this.buttonSupprimer.Text = "Supprimer";
            this.buttonSupprimer.UseVisualStyleBackColor = false;
            this.buttonSupprimer.Click += new System.EventHandler(this.buttonSupprimer_Click);
            // 
            // listeDeroulanteVehicule1
            // 
            this.listeDeroulanteVehicule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteVehicule1.Location = new System.Drawing.Point(753, 49);
            this.listeDeroulanteVehicule1.Name = "listeDeroulanteVehicule1";
            this.listeDeroulanteVehicule1.Size = new System.Drawing.Size(150, 20);
            this.listeDeroulanteVehicule1.TabIndex = 1;
            this.listeDeroulanteVehicule1.VehiculeSelectionne = null;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 672);
            this.menu1.TabIndex = 19;
            // 
            // lierOptions
            // 
            this.lierOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lierOptions.Location = new System.Drawing.Point(261, 353);
            this.lierOptions.Name = "lierOptions";
            this.lierOptions.Size = new System.Drawing.Size(1000, 300);
            this.lierOptions.TabIndex = 238;
            // 
            // lierPack
            // 
            this.lierPack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lierPack.Location = new System.Drawing.Point(263, 353);
            this.lierPack.Name = "lierPack";
            this.lierPack.Size = new System.Drawing.Size(1000, 300);
            this.lierPack.TabIndex = 236;
            // 
            // Page_NouveauVehicule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonSupprimer);
            this.Controls.Add(this.buttonLierOptions);
            this.Controls.Add(this.buttonLierPack);
            this.Controls.Add(this.buttonPanelLierCaract);
            this.Controls.Add(this.buttonPanelAjouterCaract);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonAnnulerModele);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.numericUpDownPrix);
            this.Controls.Add(this.labelRechercheVehicule);
            this.Controls.Add(this.listeDeroulanteVehicule1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAjouterImage);
            this.Controls.Add(this.numericUpDownTempsLivraison);
            this.Controls.Add(this.labelTempsLivraison);
            this.Controls.Add(this.labelNomModele);
            this.Controls.Add(this.textBoxModele);
            this.Controls.Add(this.labelPrixCatalogue);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lierPack);
            this.Controls.Add(this.panelLier);
            this.Controls.Add(this.panelAjouterCaract);
            this.Controls.Add(this.lierOptions);
            this.Name = "Page_NouveauVehicule";
            this.Size = new System.Drawing.Size(1300, 672);
            this.Load += new System.EventHandler(this.Page_NouveauVehicule_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPrix)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTempsLivraison)).EndInit();
            this.panelLier.ResumeLayout(false);
            this.panelLier.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaractR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCaractA)).EndInit();
            this.panelAjouterCaract.ResumeLayout(false);
            this.panelAjouterCaract.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Menu menu1;
        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAnnulerModele;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.NumericUpDown numericUpDownPrix;
        private System.Windows.Forms.Label labelRechercheVehicule;
        private ListeDeroulanteVehicule listeDeroulanteVehicule1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAjouterImage;
        private System.Windows.Forms.NumericUpDown numericUpDownTempsLivraison;
        private System.Windows.Forms.Label labelTempsLivraison;
        private System.Windows.Forms.Label labelNomModele;
        private System.Windows.Forms.TextBox textBoxModele;
        private System.Windows.Forms.Label labelPrixCatalogue;
        private System.Windows.Forms.Panel panelLier;
        private System.Windows.Forms.PictureBox pictureBoxCaractR;
        private System.Windows.Forms.PictureBox pictureBoxCaractA;
        private ListeDeroulanteCaracteristique listeDeroulanteCaracteristique1;
        private System.Windows.Forms.Label labelCaractExistante;
        private System.Windows.Forms.Button buttonAnnulerCaract;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxInfo;
        private FicheTechnique ficheTechnique1;
        private System.Windows.Forms.Label labelFicheTechnique;
        private System.Windows.Forms.Button buttonPanelLierCaract;
        private System.Windows.Forms.Button buttonPanelAjouterCaract;
        private System.Windows.Forms.Panel panelAjouterCaract;
        private System.Windows.Forms.Button buttonSupprimerCaract;
        private System.Windows.Forms.Button buttonModifierCaract;
        private System.Windows.Forms.Button buttonAjouterCaract;
        private ListeDeroulanteCaracteristique listeDeroulanteCaracteristiqueAjouter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelNomCaract;
        private System.Windows.Forms.TextBox textBoxNomCaract;
        private System.Windows.Forms.Label labelTypeCorrespondant;
        private ListeDeroulanteTypeVehicule listeDeroulanteTypeVehicule1;
        private System.Windows.Forms.Button buttonAnnulerCaractAjout;
        private System.Windows.Forms.Button buttonModifierLier;
        private System.Windows.Forms.Button buttonLierPack;
        private LierPack lierPack;
        private System.Windows.Forms.Button buttonLierOptions;
        private LierOptions lierOptions;
        private System.Windows.Forms.Button buttonSupprimer;
        private System.Windows.Forms.Label labelChoixTypeCaract;
        private ListeDeroulanteTypeVehicule listeDeroulanteTypeVehiculeFiltre;
    }
}
