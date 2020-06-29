namespace app_tfe_michel_maxime
{
    partial class Page_Personnalisation
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
            this.labelChoixDesOptions = new System.Windows.Forms.Label();
            this.pictureBoxRetirerO = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterO = new System.Windows.Forms.PictureBox();
            this.labelOptionsChoisie = new System.Windows.Forms.Label();
            this.labelPackOptions = new System.Windows.Forms.Label();
            this.labelPackSurVehicule = new System.Windows.Forms.Label();
            this.pictureBoxRetirerP = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterP = new System.Windows.Forms.PictureBox();
            this.labelPrixtotal = new System.Windows.Forms.Label();
            this.textBoxPrixTotal = new System.Windows.Forms.TextBox();
            this.labelEstimationDateLivraison = new System.Windows.Forms.Label();
            this.textBoxEstimationLivraison = new System.Windows.Forms.TextBox();
            this.labelPrixCatalogue = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.pictureBoxVoiture = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelInfoClient = new System.Windows.Forms.Label();
            this.labelTypeOption = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonCommander = new System.Windows.Forms.Button();
            this.listeDeroulanteTypeOptions1 = new app_tfe_michel_maxime.ListeDeroulanteTypeOptions();
            this.formulaire_Client1 = new app_tfe_michel_maxime.Formulaire_Client();
            this.fichePackOptionsChoisis = new app_tfe_michel_maxime.FichePackOptions();
            this.fichePackOptionsGeneral = new app_tfe_michel_maxime.FichePackOptions();
            this.ficheOptionsChoisies = new app_tfe_michel_maxime.FicheOptions();
            this.ficheOptionsGeneral = new app_tfe_michel_maxime.FicheOptions();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoiture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Location = new System.Drawing.Point(195, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1297, 42);
            this.panel1.TabIndex = 12;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(1186, 1);
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
            this.labelTitre.Location = new System.Drawing.Point(497, -1);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(388, 39);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Personnalisation du véhicule";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelChoixDesOptions
            // 
            this.labelChoixDesOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelChoixDesOptions.AutoSize = true;
            this.labelChoixDesOptions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChoixDesOptions.Location = new System.Drawing.Point(356, 102);
            this.labelChoixDesOptions.Name = "labelChoixDesOptions";
            this.labelChoixDesOptions.Size = new System.Drawing.Size(104, 15);
            this.labelChoixDesOptions.TabIndex = 17;
            this.labelChoixDesOptions.Text = "Choix des options";
            this.labelChoixDesOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelChoixDesOptions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelChoixDesOptions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // pictureBoxRetirerO
            // 
            this.pictureBoxRetirerO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerO.Image = global::app_tfe_michel_maxime.Properties.Resources.rowUp;
            this.pictureBoxRetirerO.Location = new System.Drawing.Point(440, 354);
            this.pictureBoxRetirerO.Name = "pictureBoxRetirerO";
            this.pictureBoxRetirerO.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxRetirerO.TabIndex = 41;
            this.pictureBoxRetirerO.TabStop = false;
            this.pictureBoxRetirerO.Click += new System.EventHandler(this.pictureBoxRetirerO_Click);
            // 
            // pictureBoxAjouterO
            // 
            this.pictureBoxAjouterO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterO.Image = global::app_tfe_michel_maxime.Properties.Resources.rowDown;
            this.pictureBoxAjouterO.Location = new System.Drawing.Point(330, 355);
            this.pictureBoxAjouterO.Name = "pictureBoxAjouterO";
            this.pictureBoxAjouterO.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxAjouterO.TabIndex = 40;
            this.pictureBoxAjouterO.TabStop = false;
            this.pictureBoxAjouterO.Click += new System.EventHandler(this.pictureBoxAjouterO_Click);
            // 
            // labelOptionsChoisie
            // 
            this.labelOptionsChoisie.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOptionsChoisie.AutoSize = true;
            this.labelOptionsChoisie.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptionsChoisie.Location = new System.Drawing.Point(367, 433);
            this.labelOptionsChoisie.Name = "labelOptionsChoisie";
            this.labelOptionsChoisie.Size = new System.Drawing.Size(99, 15);
            this.labelOptionsChoisie.TabIndex = 43;
            this.labelOptionsChoisie.Text = "Options choisies";
            this.labelOptionsChoisie.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelOptionsChoisie.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelOptionsChoisie.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPackOptions
            // 
            this.labelPackOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPackOptions.AutoSize = true;
            this.labelPackOptions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPackOptions.Location = new System.Drawing.Point(709, 102);
            this.labelPackOptions.Name = "labelPackOptions";
            this.labelPackOptions.Size = new System.Drawing.Size(152, 15);
            this.labelPackOptions.TabIndex = 44;
            this.labelPackOptions.Text = "Choix des packs  d\'options";
            this.labelPackOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPackOptions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPackOptions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPackSurVehicule
            // 
            this.labelPackSurVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPackSurVehicule.AutoSize = true;
            this.labelPackSurVehicule.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPackSurVehicule.Location = new System.Drawing.Point(750, 433);
            this.labelPackSurVehicule.Name = "labelPackSurVehicule";
            this.labelPackSurVehicule.Size = new System.Drawing.Size(82, 15);
            this.labelPackSurVehicule.TabIndex = 46;
            this.labelPackSurVehicule.Text = "Packs choisis";
            this.labelPackSurVehicule.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPackSurVehicule.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPackSurVehicule.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // pictureBoxRetirerP
            // 
            this.pictureBoxRetirerP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerP.Image = global::app_tfe_michel_maxime.Properties.Resources.rowUp;
            this.pictureBoxRetirerP.Location = new System.Drawing.Point(823, 355);
            this.pictureBoxRetirerP.Name = "pictureBoxRetirerP";
            this.pictureBoxRetirerP.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxRetirerP.TabIndex = 49;
            this.pictureBoxRetirerP.TabStop = false;
            this.pictureBoxRetirerP.Click += new System.EventHandler(this.pictureBoxRetirerP_Click);
            // 
            // pictureBoxAjouterP
            // 
            this.pictureBoxAjouterP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterP.Image = global::app_tfe_michel_maxime.Properties.Resources.rowDown;
            this.pictureBoxAjouterP.Location = new System.Drawing.Point(713, 354);
            this.pictureBoxAjouterP.Name = "pictureBoxAjouterP";
            this.pictureBoxAjouterP.Size = new System.Drawing.Size(56, 55);
            this.pictureBoxAjouterP.TabIndex = 48;
            this.pictureBoxAjouterP.TabStop = false;
            this.pictureBoxAjouterP.Click += new System.EventHandler(this.pictureBoxAjouterP_Click);
            // 
            // labelPrixtotal
            // 
            this.labelPrixtotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixtotal.AutoSize = true;
            this.labelPrixtotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixtotal.Location = new System.Drawing.Point(1357, 187);
            this.labelPrixtotal.Name = "labelPrixtotal";
            this.labelPrixtotal.Size = new System.Drawing.Size(58, 15);
            this.labelPrixtotal.TabIndex = 56;
            this.labelPrixtotal.Text = "Prix total";
            this.labelPrixtotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPrixtotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPrixtotal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxPrixTotal
            // 
            this.textBoxPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrixTotal.Enabled = false;
            this.textBoxPrixTotal.Location = new System.Drawing.Point(1314, 205);
            this.textBoxPrixTotal.Name = "textBoxPrixTotal";
            this.textBoxPrixTotal.Size = new System.Drawing.Size(142, 20);
            this.textBoxPrixTotal.TabIndex = 55;
            this.textBoxPrixTotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.textBoxPrixTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.textBoxPrixTotal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelEstimationDateLivraison
            // 
            this.labelEstimationDateLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEstimationDateLivraison.AutoSize = true;
            this.labelEstimationDateLivraison.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEstimationDateLivraison.Location = new System.Drawing.Point(1319, 128);
            this.labelEstimationDateLivraison.Name = "labelEstimationDateLivraison";
            this.labelEstimationDateLivraison.Size = new System.Drawing.Size(133, 15);
            this.labelEstimationDateLivraison.TabIndex = 54;
            this.labelEstimationDateLivraison.Text = "Estimation de livraison";
            this.labelEstimationDateLivraison.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelEstimationDateLivraison.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelEstimationDateLivraison.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxEstimationLivraison
            // 
            this.textBoxEstimationLivraison.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEstimationLivraison.Enabled = false;
            this.textBoxEstimationLivraison.Location = new System.Drawing.Point(1314, 146);
            this.textBoxEstimationLivraison.Name = "textBoxEstimationLivraison";
            this.textBoxEstimationLivraison.Size = new System.Drawing.Size(142, 20);
            this.textBoxEstimationLivraison.TabIndex = 53;
            this.textBoxEstimationLivraison.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.textBoxEstimationLivraison.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.textBoxEstimationLivraison.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPrixCatalogue
            // 
            this.labelPrixCatalogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixCatalogue.AutoSize = true;
            this.labelPrixCatalogue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixCatalogue.Location = new System.Drawing.Point(1345, 67);
            this.labelPrixCatalogue.Name = "labelPrixCatalogue";
            this.labelPrixCatalogue.Size = new System.Drawing.Size(86, 15);
            this.labelPrixCatalogue.TabIndex = 52;
            this.labelPrixCatalogue.Text = "Prix catalogue";
            this.labelPrixCatalogue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPrixCatalogue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPrixCatalogue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxPrix
            // 
            this.textBoxPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrix.Enabled = false;
            this.textBoxPrix.Location = new System.Drawing.Point(1314, 85);
            this.textBoxPrix.Name = "textBoxPrix";
            this.textBoxPrix.Size = new System.Drawing.Size(142, 20);
            this.textBoxPrix.TabIndex = 51;
            this.textBoxPrix.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.textBoxPrix.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.textBoxPrix.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // pictureBoxVoiture
            // 
            this.pictureBoxVoiture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxVoiture.Location = new System.Drawing.Point(988, 52);
            this.pictureBoxVoiture.Name = "pictureBoxVoiture";
            this.pictureBoxVoiture.Size = new System.Drawing.Size(320, 192);
            this.pictureBoxVoiture.TabIndex = 50;
            this.pictureBoxVoiture.TabStop = false;
            this.pictureBoxVoiture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.pictureBoxVoiture.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.pictureBoxVoiture.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel2.Location = new System.Drawing.Point(1040, 277);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 1);
            this.panel2.TabIndex = 58;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            // 
            // labelInfoClient
            // 
            this.labelInfoClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfoClient.AutoSize = true;
            this.labelInfoClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoClient.Location = new System.Drawing.Point(1148, 259);
            this.labelInfoClient.Name = "labelInfoClient";
            this.labelInfoClient.Size = new System.Drawing.Size(140, 15);
            this.labelInfoClient.TabIndex = 57;
            this.labelInfoClient.Text = "Information sur le client";
            this.labelInfoClient.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelInfoClient.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            // 
            // labelTypeOption
            // 
            this.labelTypeOption.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTypeOption.AutoSize = true;
            this.labelTypeOption.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTypeOption.Location = new System.Drawing.Point(295, 72);
            this.labelTypeOption.Name = "labelTypeOption";
            this.labelTypeOption.Size = new System.Drawing.Size(85, 15);
            this.labelTypeOption.TabIndex = 61;
            this.labelTypeOption.Text = "Type d\'options";
            this.labelTypeOption.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTypeOption.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTypeOption.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // buttonCommander
            // 
            this.buttonCommander.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCommander.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonCommander.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCommander.Enabled = false;
            this.buttonCommander.FlatAppearance.BorderSize = 0;
            this.buttonCommander.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCommander.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCommander.ForeColor = System.Drawing.Color.White;
            this.buttonCommander.Location = new System.Drawing.Point(1322, 648);
            this.buttonCommander.Name = "buttonCommander";
            this.buttonCommander.Size = new System.Drawing.Size(152, 38);
            this.buttonCommander.TabIndex = 62;
            this.buttonCommander.Text = "Commander";
            this.buttonCommander.UseVisualStyleBackColor = false;
            this.buttonCommander.Click += new System.EventHandler(this.buttonCommander_Click);
            // 
            // listeDeroulanteTypeOptions1
            // 
            this.listeDeroulanteTypeOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteTypeOptions1.Location = new System.Drawing.Point(385, 69);
            this.listeDeroulanteTypeOptions1.Name = "listeDeroulanteTypeOptions1";
            this.listeDeroulanteTypeOptions1.Size = new System.Drawing.Size(140, 21);
            this.listeDeroulanteTypeOptions1.TabIndex = 1;
            this.listeDeroulanteTypeOptions1.TypeOptionsSelectionne = null;
            // 
            // formulaire_Client1
            // 
            this.formulaire_Client1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formulaire_Client1.ClientEnCoursDeTraitement = null;
            this.formulaire_Client1.Location = new System.Drawing.Point(1025, 279);
            this.formulaire_Client1.Name = "formulaire_Client1";
            this.formulaire_Client1.Size = new System.Drawing.Size(390, 364);
            this.formulaire_Client1.TabIndex = 59;
            // 
            // fichePackOptionsChoisis
            // 
            this.fichePackOptionsChoisis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fichePackOptionsChoisis.Location = new System.Drawing.Point(620, 450);
            this.fichePackOptionsChoisis.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptionsChoisis.Name = "fichePackOptionsChoisis";
            this.fichePackOptionsChoisis.PackOptionsSelectionnee = null;
            this.fichePackOptionsChoisis.Size = new System.Drawing.Size(344, 214);
            this.fichePackOptionsChoisis.TabIndex = 47;
            this.fichePackOptionsChoisis.TexteFiltrePackOptions = "";
            // 
            // fichePackOptionsGeneral
            // 
            this.fichePackOptionsGeneral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fichePackOptionsGeneral.Location = new System.Drawing.Point(620, 119);
            this.fichePackOptionsGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptionsGeneral.Name = "fichePackOptionsGeneral";
            this.fichePackOptionsGeneral.PackOptionsSelectionnee = null;
            this.fichePackOptionsGeneral.Size = new System.Drawing.Size(344, 214);
            this.fichePackOptionsGeneral.TabIndex = 45;
            this.fichePackOptionsGeneral.TexteFiltrePackOptions = "";
            this.fichePackOptionsGeneral.Load += new System.EventHandler(this.fichePackOptionsGeneral_Load);
            // 
            // ficheOptionsChoisies
            // 
            this.ficheOptionsChoisies.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptionsChoisies.FicheAvecFiltre = true;
            this.ficheOptionsChoisies.Location = new System.Drawing.Point(244, 450);
            this.ficheOptionsChoisies.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsChoisies.Name = "ficheOptionsChoisies";
            this.ficheOptionsChoisies.OptionsSelectionnee = null;
            this.ficheOptionsChoisies.Size = new System.Drawing.Size(344, 214);
            this.ficheOptionsChoisies.TabIndex = 42;
            this.ficheOptionsChoisies.TexteFiltreOptions = "";
            // 
            // ficheOptionsGeneral
            // 
            this.ficheOptionsGeneral.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptionsGeneral.FicheAvecFiltre = true;
            this.ficheOptionsGeneral.Location = new System.Drawing.Point(244, 119);
            this.ficheOptionsGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsGeneral.Name = "ficheOptionsGeneral";
            this.ficheOptionsGeneral.OptionsSelectionnee = null;
            this.ficheOptionsGeneral.Size = new System.Drawing.Size(344, 214);
            this.ficheOptionsGeneral.TabIndex = 16;
            this.ficheOptionsGeneral.TexteFiltreOptions = "";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 699);
            this.menu1.TabIndex = 11;
            // 
            // Page_Personnalisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCommander);
            this.Controls.Add(this.labelTypeOption);
            this.Controls.Add(this.listeDeroulanteTypeOptions1);
            this.Controls.Add(this.formulaire_Client1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelInfoClient);
            this.Controls.Add(this.labelPrixtotal);
            this.Controls.Add(this.textBoxPrixTotal);
            this.Controls.Add(this.labelEstimationDateLivraison);
            this.Controls.Add(this.textBoxEstimationLivraison);
            this.Controls.Add(this.labelPrixCatalogue);
            this.Controls.Add(this.textBoxPrix);
            this.Controls.Add(this.pictureBoxVoiture);
            this.Controls.Add(this.pictureBoxRetirerP);
            this.Controls.Add(this.pictureBoxAjouterP);
            this.Controls.Add(this.fichePackOptionsChoisis);
            this.Controls.Add(this.labelPackSurVehicule);
            this.Controls.Add(this.fichePackOptionsGeneral);
            this.Controls.Add(this.labelPackOptions);
            this.Controls.Add(this.labelOptionsChoisie);
            this.Controls.Add(this.ficheOptionsChoisies);
            this.Controls.Add(this.pictureBoxRetirerO);
            this.Controls.Add(this.pictureBoxAjouterO);
            this.Controls.Add(this.labelChoixDesOptions);
            this.Controls.Add(this.ficheOptionsGeneral);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.panel1);
            this.Name = "Page_Personnalisation";
            this.Size = new System.Drawing.Size(1489, 699);
            this.Load += new System.EventHandler(this.Page_Personnalisation_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVoiture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelTitre;
        private Menu menu1;
        private FicheOptions ficheOptionsGeneral;
        private System.Windows.Forms.Label labelChoixDesOptions;
        private System.Windows.Forms.PictureBox pictureBoxRetirerO;
        private System.Windows.Forms.PictureBox pictureBoxAjouterO;
        private FicheOptions ficheOptionsChoisies;
        private System.Windows.Forms.Label labelOptionsChoisie;
        private System.Windows.Forms.Label labelPackOptions;
        private FichePackOptions fichePackOptionsGeneral;
        private FichePackOptions fichePackOptionsChoisis;
        private System.Windows.Forms.Label labelPackSurVehicule;
        private System.Windows.Forms.PictureBox pictureBoxRetirerP;
        private System.Windows.Forms.PictureBox pictureBoxAjouterP;
        private System.Windows.Forms.Label labelPrixtotal;
        private System.Windows.Forms.TextBox textBoxPrixTotal;
        private System.Windows.Forms.Label labelEstimationDateLivraison;
        private System.Windows.Forms.TextBox textBoxEstimationLivraison;
        private System.Windows.Forms.Label labelPrixCatalogue;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.PictureBox pictureBoxVoiture;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelInfoClient;
        private Formulaire_Client formulaire_Client1;
        private System.Windows.Forms.Label labelTypeOption;
        private ListeDeroulanteTypeOptions listeDeroulanteTypeOptions1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.Button buttonCommander;
    }
}
