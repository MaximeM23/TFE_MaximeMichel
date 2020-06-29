namespace app_tfe_michel_maxime
{
    partial class Page_Commandes
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
            this.labelCommandes = new System.Windows.Forms.Label();
            this.textBoxCP = new System.Windows.Forms.TextBox();
            this.textBoxLoc = new System.Windows.Forms.TextBox();
            this.textBoxDateNaissance = new System.Windows.Forms.TextBox();
            this.textBoxCivilite = new System.Windows.Forms.TextBox();
            this.labelVehiculeRepris = new System.Windows.Forms.Label();
            this.labelRemise = new System.Windows.Forms.Label();
            this.textBoxRemise = new System.Windows.Forms.TextBox();
            this.numericUpDownTVA = new System.Windows.Forms.NumericUpDown();
            this.labelPourcentageTVA = new System.Windows.Forms.Label();
            this.buttonImprimerFacture = new System.Windows.Forms.Button();
            this.textBoxNumHabitation = new System.Windows.Forms.TextBox();
            this.labelNumHabitation = new System.Windows.Forms.Label();
            this.labelDateNaissance = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNumTel = new System.Windows.Forms.TextBox();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelNumTel = new System.Windows.Forms.Label();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.labelCP = new System.Windows.Forms.Label();
            this.labelLocalite = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelCivilite = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.labelClient = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxNumChassis = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelDateArrivee = new System.Windows.Forms.Label();
            this.labelDateCommande = new System.Windows.Forms.Label();
            this.textBoxDateCommande = new System.Windows.Forms.TextBox();
            this.labelPrixTotal = new System.Windows.Forms.Label();
            this.textBoxPrixTotal = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPackCompris = new System.Windows.Forms.Label();
            this.labelPrixCatalogue = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.pictureBoxVehicule = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelOptionComprisAveCeVehicule = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelFicheTechnique = new System.Windows.Forms.Label();
            this.labelBonCommande = new System.Windows.Forms.Label();
            this.dateTimePickerDateReception = new System.Windows.Forms.DateTimePicker();
            this.labelKilometrage = new System.Windows.Forms.Label();
            this.numericUpDownKilometrage = new System.Windows.Forms.NumericUpDown();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.listeDeroulanteFactureVente1 = new app_tfe_michel_maxime.ListeDeroulanteFactureVente();
            this.listeDeroulanteClientVehicule1 = new app_tfe_michel_maxime.ListeDeroulanteClientVehicule();
            this.fichePackOptions1 = new app_tfe_michel_maxime.FichePackOptions();
            this.ficheOptions1 = new app_tfe_michel_maxime.FicheOptions();
            this.ficheTechnique1 = new app_tfe_michel_maxime.FicheTechnique();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.numericUpDownAnneeConstruction = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTVA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilometrage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnneeConstruction)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelCommandes);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1279, 42);
            this.panel1.TabIndex = 29;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(1168, 1);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(108, 37);
            this.buttonClose1.TabIndex = 9;
            // 
            // labelCommandes
            // 
            this.labelCommandes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelCommandes.AutoSize = true;
            this.labelCommandes.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCommandes.ForeColor = System.Drawing.SystemColors.Window;
            this.labelCommandes.Location = new System.Drawing.Point(550, -1);
            this.labelCommandes.Name = "labelCommandes";
            this.labelCommandes.Size = new System.Drawing.Size(181, 39);
            this.labelCommandes.TabIndex = 0;
            this.labelCommandes.Text = "Commandes";
            this.labelCommandes.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelCommandes.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelCommandes.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxCP
            // 
            this.textBoxCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCP.Enabled = false;
            this.textBoxCP.Location = new System.Drawing.Point(1264, 482);
            this.textBoxCP.Name = "textBoxCP";
            this.textBoxCP.Size = new System.Drawing.Size(181, 20);
            this.textBoxCP.TabIndex = 237;
            // 
            // textBoxLoc
            // 
            this.textBoxLoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxLoc.Enabled = false;
            this.textBoxLoc.Location = new System.Drawing.Point(1264, 456);
            this.textBoxLoc.Name = "textBoxLoc";
            this.textBoxLoc.Size = new System.Drawing.Size(181, 20);
            this.textBoxLoc.TabIndex = 236;
            // 
            // textBoxDateNaissance
            // 
            this.textBoxDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDateNaissance.Enabled = false;
            this.textBoxDateNaissance.Location = new System.Drawing.Point(1264, 430);
            this.textBoxDateNaissance.Name = "textBoxDateNaissance";
            this.textBoxDateNaissance.Size = new System.Drawing.Size(181, 20);
            this.textBoxDateNaissance.TabIndex = 235;
            // 
            // textBoxCivilite
            // 
            this.textBoxCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxCivilite.Enabled = false;
            this.textBoxCivilite.Location = new System.Drawing.Point(1264, 404);
            this.textBoxCivilite.Name = "textBoxCivilite";
            this.textBoxCivilite.Size = new System.Drawing.Size(181, 20);
            this.textBoxCivilite.TabIndex = 234;
            // 
            // labelVehiculeRepris
            // 
            this.labelVehiculeRepris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVehiculeRepris.AutoSize = true;
            this.labelVehiculeRepris.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehiculeRepris.Location = new System.Drawing.Point(682, 532);
            this.labelVehiculeRepris.Name = "labelVehiculeRepris";
            this.labelVehiculeRepris.Size = new System.Drawing.Size(136, 15);
            this.labelVehiculeRepris.TabIndex = 232;
            this.labelVehiculeRepris.Text = "Véhicule existant repris";
            // 
            // labelRemise
            // 
            this.labelRemise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemise.AutoSize = true;
            this.labelRemise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemise.Location = new System.Drawing.Point(682, 557);
            this.labelRemise.Name = "labelRemise";
            this.labelRemise.Size = new System.Drawing.Size(72, 15);
            this.labelRemise.TabIndex = 231;
            this.labelRemise.Text = "Remise en €";
            // 
            // textBoxRemise
            // 
            this.textBoxRemise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRemise.Enabled = false;
            this.textBoxRemise.Location = new System.Drawing.Point(843, 555);
            this.textBoxRemise.Name = "textBoxRemise";
            this.textBoxRemise.Size = new System.Drawing.Size(181, 20);
            this.textBoxRemise.TabIndex = 9;
            // 
            // numericUpDownTVA
            // 
            this.numericUpDownTVA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownTVA.Enabled = false;
            this.numericUpDownTVA.Location = new System.Drawing.Point(843, 502);
            this.numericUpDownTVA.Name = "numericUpDownTVA";
            this.numericUpDownTVA.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownTVA.TabIndex = 7;
            // 
            // labelPourcentageTVA
            // 
            this.labelPourcentageTVA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPourcentageTVA.AutoSize = true;
            this.labelPourcentageTVA.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPourcentageTVA.Location = new System.Drawing.Point(682, 505);
            this.labelPourcentageTVA.Name = "labelPourcentageTVA";
            this.labelPourcentageTVA.Size = new System.Drawing.Size(38, 15);
            this.labelPourcentageTVA.TabIndex = 228;
            this.labelPourcentageTVA.Text = "% TVA";
            // 
            // buttonImprimerFacture
            // 
            this.buttonImprimerFacture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonImprimerFacture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonImprimerFacture.Enabled = false;
            this.buttonImprimerFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimerFacture.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimerFacture.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonImprimerFacture.Location = new System.Drawing.Point(683, 601);
            this.buttonImprimerFacture.Name = "buttonImprimerFacture";
            this.buttonImprimerFacture.Size = new System.Drawing.Size(341, 40);
            this.buttonImprimerFacture.TabIndex = 10;
            this.buttonImprimerFacture.Text = "Imprimer la facture";
            this.buttonImprimerFacture.UseVisualStyleBackColor = false;
            this.buttonImprimerFacture.Click += new System.EventHandler(this.buttonImprimerFacture_Click);
            // 
            // textBoxNumHabitation
            // 
            this.textBoxNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumHabitation.Enabled = false;
            this.textBoxNumHabitation.Location = new System.Drawing.Point(1264, 536);
            this.textBoxNumHabitation.Name = "textBoxNumHabitation";
            this.textBoxNumHabitation.Size = new System.Drawing.Size(181, 20);
            this.textBoxNumHabitation.TabIndex = 226;
            // 
            // labelNumHabitation
            // 
            this.labelNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumHabitation.AutoSize = true;
            this.labelNumHabitation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumHabitation.Location = new System.Drawing.Point(1101, 539);
            this.labelNumHabitation.Name = "labelNumHabitation";
            this.labelNumHabitation.Size = new System.Drawing.Size(120, 14);
            this.labelNumHabitation.TabIndex = 225;
            this.labelNumHabitation.Text = "Numéro d\'habitation";
            // 
            // labelDateNaissance
            // 
            this.labelDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNaissance.AutoSize = true;
            this.labelDateNaissance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateNaissance.Location = new System.Drawing.Point(1101, 434);
            this.labelDateNaissance.Name = "labelDateNaissance";
            this.labelDateNaissance.Size = new System.Drawing.Size(109, 14);
            this.labelDateNaissance.TabIndex = 224;
            this.labelDateNaissance.Text = "Date de naissance";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEmail.Enabled = false;
            this.textBoxEmail.Location = new System.Drawing.Point(1264, 590);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(181, 20);
            this.textBoxEmail.TabIndex = 223;
            // 
            // textBoxNumTel
            // 
            this.textBoxNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumTel.Enabled = false;
            this.textBoxNumTel.Location = new System.Drawing.Point(1264, 563);
            this.textBoxNumTel.Name = "textBoxNumTel";
            this.textBoxNumTel.Size = new System.Drawing.Size(181, 20);
            this.textBoxNumTel.TabIndex = 222;
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAdresse.Enabled = false;
            this.textBoxAdresse.Location = new System.Drawing.Point(1264, 510);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(181, 20);
            this.textBoxAdresse.TabIndex = 221;
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(1101, 593);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 14);
            this.labelEmail.TabIndex = 220;
            this.labelEmail.Text = "Email";
            // 
            // labelNumTel
            // 
            this.labelNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumTel.AutoSize = true;
            this.labelNumTel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumTel.Location = new System.Drawing.Point(1101, 566);
            this.labelNumTel.Name = "labelNumTel";
            this.labelNumTel.Size = new System.Drawing.Size(127, 14);
            this.labelNumTel.TabIndex = 219;
            this.labelNumTel.Text = "Numéro de téléphone";
            // 
            // labelAdresse
            // 
            this.labelAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdresse.Location = new System.Drawing.Point(1101, 513);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(51, 14);
            this.labelAdresse.TabIndex = 218;
            this.labelAdresse.Text = "Adresse";
            // 
            // labelCP
            // 
            this.labelCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCP.AutoSize = true;
            this.labelCP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCP.Location = new System.Drawing.Point(1101, 486);
            this.labelCP.Name = "labelCP";
            this.labelCP.Size = new System.Drawing.Size(72, 14);
            this.labelCP.TabIndex = 217;
            this.labelCP.Text = "Code postal";
            // 
            // labelLocalite
            // 
            this.labelLocalite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLocalite.AutoSize = true;
            this.labelLocalite.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocalite.Location = new System.Drawing.Point(1101, 459);
            this.labelLocalite.Name = "labelLocalite";
            this.labelLocalite.Size = new System.Drawing.Size(50, 14);
            this.labelLocalite.TabIndex = 216;
            this.labelLocalite.Text = "Localité";
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrenom.Enabled = false;
            this.textBoxPrenom.Location = new System.Drawing.Point(1264, 379);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrenom.TabIndex = 215;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNom.Enabled = false;
            this.textBoxNom.Location = new System.Drawing.Point(1264, 353);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(181, 20);
            this.textBoxNom.TabIndex = 214;
            // 
            // labelCivilite
            // 
            this.labelCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCivilite.AutoSize = true;
            this.labelCivilite.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCivilite.Location = new System.Drawing.Point(1101, 407);
            this.labelCivilite.Name = "labelCivilite";
            this.labelCivilite.Size = new System.Drawing.Size(45, 14);
            this.labelCivilite.TabIndex = 213;
            this.labelCivilite.Text = "Civilité";
            // 
            // labelPrenom
            // 
            this.labelPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenom.Location = new System.Drawing.Point(1101, 382);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(48, 14);
            this.labelPrenom.TabIndex = 212;
            this.labelPrenom.Text = "Prénom";
            // 
            // labelNom
            // 
            this.labelNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(1101, 356);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(32, 14);
            this.labelNom.TabIndex = 211;
            this.labelNom.Text = "Nom";
            // 
            // panel5
            // 
            this.panel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel5.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel5.Location = new System.Drawing.Point(1103, 348);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(342, 1);
            this.panel5.TabIndex = 199;
            // 
            // labelClient
            // 
            this.labelClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelClient.AutoSize = true;
            this.labelClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClient.Location = new System.Drawing.Point(1171, 330);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(200, 15);
            this.labelClient.TabIndex = 0;
            this.labelClient.Text = "Client ayant commandé ce véhicule";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(680, 478);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 210;
            this.label4.Text = "Numéro de châssis";
            // 
            // textBoxNumChassis
            // 
            this.textBoxNumChassis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumChassis.Enabled = false;
            this.textBoxNumChassis.Location = new System.Drawing.Point(843, 476);
            this.textBoxNumChassis.Name = "textBoxNumChassis";
            this.textBoxNumChassis.Size = new System.Drawing.Size(181, 20);
            this.textBoxNumChassis.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(680, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.label3.TabIndex = 208;
            this.label3.Text = "Année de construction";
            // 
            // labelDateArrivee
            // 
            this.labelDateArrivee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateArrivee.AutoSize = true;
            this.labelDateArrivee.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateArrivee.Location = new System.Drawing.Point(680, 400);
            this.labelDateArrivee.Name = "labelDateArrivee";
            this.labelDateArrivee.Size = new System.Drawing.Size(102, 15);
            this.labelDateArrivee.TabIndex = 206;
            this.labelDateArrivee.Text = "Date de réception";
            // 
            // labelDateCommande
            // 
            this.labelDateCommande.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateCommande.AutoSize = true;
            this.labelDateCommande.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateCommande.Location = new System.Drawing.Point(680, 374);
            this.labelDateCommande.Name = "labelDateCommande";
            this.labelDateCommande.Size = new System.Drawing.Size(111, 15);
            this.labelDateCommande.TabIndex = 204;
            this.labelDateCommande.Text = "Date de commande";
            // 
            // textBoxDateCommande
            // 
            this.textBoxDateCommande.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxDateCommande.Enabled = false;
            this.textBoxDateCommande.Location = new System.Drawing.Point(843, 372);
            this.textBoxDateCommande.Name = "textBoxDateCommande";
            this.textBoxDateCommande.Size = new System.Drawing.Size(181, 20);
            this.textBoxDateCommande.TabIndex = 3;
            // 
            // labelPrixTotal
            // 
            this.labelPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixTotal.AutoSize = true;
            this.labelPrixTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixTotal.Location = new System.Drawing.Point(680, 348);
            this.labelPrixTotal.Name = "labelPrixTotal";
            this.labelPrixTotal.Size = new System.Drawing.Size(58, 15);
            this.labelPrixTotal.TabIndex = 202;
            this.labelPrixTotal.Text = "Prix total";
            // 
            // textBoxPrixTotal
            // 
            this.textBoxPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrixTotal.Enabled = false;
            this.textBoxPrixTotal.Location = new System.Drawing.Point(843, 346);
            this.textBoxPrixTotal.Name = "textBoxPrixTotal";
            this.textBoxPrixTotal.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrixTotal.TabIndex = 2;
            // 
            // panel4
            // 
            this.panel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel4.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel4.Location = new System.Drawing.Point(1103, 97);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(342, 1);
            this.panel4.TabIndex = 196;
            // 
            // labelPackCompris
            // 
            this.labelPackCompris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPackCompris.AutoSize = true;
            this.labelPackCompris.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPackCompris.Location = new System.Drawing.Point(1166, 79);
            this.labelPackCompris.Name = "labelPackCompris";
            this.labelPackCompris.Size = new System.Drawing.Size(230, 15);
            this.labelPackCompris.TabIndex = 195;
            this.labelPackCompris.Text = "Liste des packs compris avec de véhicule";
            // 
            // labelPrixCatalogue
            // 
            this.labelPrixCatalogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixCatalogue.AutoSize = true;
            this.labelPrixCatalogue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixCatalogue.Location = new System.Drawing.Point(680, 322);
            this.labelPrixCatalogue.Name = "labelPrixCatalogue";
            this.labelPrixCatalogue.Size = new System.Drawing.Size(86, 15);
            this.labelPrixCatalogue.TabIndex = 194;
            this.labelPrixCatalogue.Text = "Prix catalogue";
            // 
            // textBoxPrix
            // 
            this.textBoxPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrix.Enabled = false;
            this.textBoxPrix.Location = new System.Drawing.Point(843, 320);
            this.textBoxPrix.Name = "textBoxPrix";
            this.textBoxPrix.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrix.TabIndex = 1;
            // 
            // pictureBoxVehicule
            // 
            this.pictureBoxVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxVehicule.Location = new System.Drawing.Point(690, 111);
            this.pictureBoxVehicule.Name = "pictureBoxVehicule";
            this.pictureBoxVehicule.Size = new System.Drawing.Size(320, 192);
            this.pictureBoxVehicule.TabIndex = 192;
            this.pictureBoxVehicule.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel3.Location = new System.Drawing.Point(240, 381);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 1);
            this.panel3.TabIndex = 188;
            // 
            // labelOptionComprisAveCeVehicule
            // 
            this.labelOptionComprisAveCeVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelOptionComprisAveCeVehicule.AutoSize = true;
            this.labelOptionComprisAveCeVehicule.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOptionComprisAveCeVehicule.Location = new System.Drawing.Point(294, 363);
            this.labelOptionComprisAveCeVehicule.Name = "labelOptionComprisAveCeVehicule";
            this.labelOptionComprisAveCeVehicule.Size = new System.Drawing.Size(238, 15);
            this.labelOptionComprisAveCeVehicule.TabIndex = 187;
            this.labelOptionComprisAveCeVehicule.Text = "Liste d\'options comprises avec ce véhicule";
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.SystemColors.WindowText;
            this.panel2.Location = new System.Drawing.Point(240, 97);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(344, 1);
            this.panel2.TabIndex = 186;
            // 
            // labelFicheTechnique
            // 
            this.labelFicheTechnique.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFicheTechnique.AutoSize = true;
            this.labelFicheTechnique.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFicheTechnique.Location = new System.Drawing.Point(329, 82);
            this.labelFicheTechnique.Name = "labelFicheTechnique";
            this.labelFicheTechnique.Size = new System.Drawing.Size(159, 15);
            this.labelFicheTechnique.TabIndex = 185;
            this.labelFicheTechnique.Text = "Fiche technique du véhicule";
            // 
            // labelBonCommande
            // 
            this.labelBonCommande.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelBonCommande.AutoSize = true;
            this.labelBonCommande.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBonCommande.Location = new System.Drawing.Point(761, 58);
            this.labelBonCommande.Name = "labelBonCommande";
            this.labelBonCommande.Size = new System.Drawing.Size(184, 15);
            this.labelBonCommande.TabIndex = 183;
            this.labelBonCommande.Text = "Rechercher le bon de commande";
            // 
            // dateTimePickerDateReception
            // 
            this.dateTimePickerDateReception.Enabled = false;
            this.dateTimePickerDateReception.Location = new System.Drawing.Point(843, 398);
            this.dateTimePickerDateReception.Name = "dateTimePickerDateReception";
            this.dateTimePickerDateReception.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerDateReception.TabIndex = 4;
            // 
            // labelKilometrage
            // 
            this.labelKilometrage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelKilometrage.AutoSize = true;
            this.labelKilometrage.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelKilometrage.Location = new System.Drawing.Point(682, 452);
            this.labelKilometrage.Name = "labelKilometrage";
            this.labelKilometrage.Size = new System.Drawing.Size(73, 15);
            this.labelKilometrage.TabIndex = 243;
            this.labelKilometrage.Text = "Kilométrage";
            // 
            // numericUpDownKilometrage
            // 
            this.numericUpDownKilometrage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownKilometrage.Enabled = false;
            this.numericUpDownKilometrage.Location = new System.Drawing.Point(843, 450);
            this.numericUpDownKilometrage.Name = "numericUpDownKilometrage";
            this.numericUpDownKilometrage.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownKilometrage.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // listeDeroulanteFactureVente1
            // 
            this.listeDeroulanteFactureVente1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteFactureVente1.FactureVenteSelectionne = null;
            this.listeDeroulanteFactureVente1.Location = new System.Drawing.Point(764, 76);
            this.listeDeroulanteFactureVente1.Name = "listeDeroulanteFactureVente1";
            this.listeDeroulanteFactureVente1.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteFactureVente1.TabIndex = 238;
            this.listeDeroulanteFactureVente1.Load += new System.EventHandler(this.listeDeroulanteBonCommande1_Load);
            // 
            // listeDeroulanteClientVehicule1
            // 
            this.listeDeroulanteClientVehicule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteClientVehicule1.ClientVehiculeSelectionne = null;
            this.listeDeroulanteClientVehicule1.Enabled = false;
            this.listeDeroulanteClientVehicule1.Location = new System.Drawing.Point(843, 528);
            this.listeDeroulanteClientVehicule1.Name = "listeDeroulanteClientVehicule1";
            this.listeDeroulanteClientVehicule1.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteClientVehicule1.TabIndex = 8;
            // 
            // fichePackOptions1
            // 
            this.fichePackOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fichePackOptions1.Location = new System.Drawing.Point(1102, 103);
            this.fichePackOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptions1.Name = "fichePackOptions1";
            this.fichePackOptions1.PackOptionsSelectionnee = null;
            this.fichePackOptions1.Size = new System.Drawing.Size(347, 222);
            this.fichePackOptions1.TabIndex = 198;
            this.fichePackOptions1.TexteFiltrePackOptions = "";
            // 
            // ficheOptions1
            // 
            this.ficheOptions1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheOptions1.FicheAvecFiltre = true;
            this.ficheOptions1.Location = new System.Drawing.Point(240, 387);
            this.ficheOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptions1.Name = "ficheOptions1";
            this.ficheOptions1.OptionsSelectionnee = null;
            this.ficheOptions1.Size = new System.Drawing.Size(349, 223);
            this.ficheOptions1.TabIndex = 189;
            this.ficheOptions1.TexteFiltreOptions = "";
            // 
            // ficheTechnique1
            // 
            this.ficheTechnique1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ficheTechnique1.CaracteristiqueSelectionnee = null;
            this.ficheTechnique1.Location = new System.Drawing.Point(240, 103);
            this.ficheTechnique1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheTechnique1.Name = "ficheTechnique1";
            this.ficheTechnique1.Size = new System.Drawing.Size(349, 222);
            this.ficheTechnique1.TabIndex = 184;
            this.ficheTechnique1.TexteFiltreTechnique = "";
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 657);
            this.menu1.TabIndex = 28;
            // 
            // numericUpDownAnneeConstruction
            // 
            this.numericUpDownAnneeConstruction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownAnneeConstruction.Enabled = false;
            this.numericUpDownAnneeConstruction.Location = new System.Drawing.Point(843, 424);
            this.numericUpDownAnneeConstruction.Name = "numericUpDownAnneeConstruction";
            this.numericUpDownAnneeConstruction.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownAnneeConstruction.TabIndex = 5;
            // 
            // Page_Commandes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownAnneeConstruction);
            this.Controls.Add(this.numericUpDownKilometrage);
            this.Controls.Add(this.labelKilometrage);
            this.Controls.Add(this.dateTimePickerDateReception);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.labelPackCompris);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelOptionComprisAveCeVehicule);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.labelFicheTechnique);
            this.Controls.Add(this.listeDeroulanteFactureVente1);
            this.Controls.Add(this.textBoxCP);
            this.Controls.Add(this.textBoxLoc);
            this.Controls.Add(this.textBoxDateNaissance);
            this.Controls.Add(this.textBoxCivilite);
            this.Controls.Add(this.listeDeroulanteClientVehicule1);
            this.Controls.Add(this.labelVehiculeRepris);
            this.Controls.Add(this.labelRemise);
            this.Controls.Add(this.textBoxRemise);
            this.Controls.Add(this.numericUpDownTVA);
            this.Controls.Add(this.labelPourcentageTVA);
            this.Controls.Add(this.buttonImprimerFacture);
            this.Controls.Add(this.textBoxNumHabitation);
            this.Controls.Add(this.labelNumHabitation);
            this.Controls.Add(this.labelDateNaissance);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNumTel);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelNumTel);
            this.Controls.Add(this.labelAdresse);
            this.Controls.Add(this.labelCP);
            this.Controls.Add(this.labelLocalite);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.labelCivilite);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.labelClient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxNumChassis);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelDateArrivee);
            this.Controls.Add(this.labelDateCommande);
            this.Controls.Add(this.textBoxDateCommande);
            this.Controls.Add(this.labelPrixTotal);
            this.Controls.Add(this.textBoxPrixTotal);
            this.Controls.Add(this.fichePackOptions1);
            this.Controls.Add(this.labelPrixCatalogue);
            this.Controls.Add(this.textBoxPrix);
            this.Controls.Add(this.pictureBoxVehicule);
            this.Controls.Add(this.ficheOptions1);
            this.Controls.Add(this.ficheTechnique1);
            this.Controls.Add(this.labelBonCommande);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Name = "Page_Commandes";
            this.Size = new System.Drawing.Size(1479, 657);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxVehicule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKilometrage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAnneeConstruction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelCommandes;
        private Menu menu1;
        private ListeDeroulanteFactureVente listeDeroulanteFactureVente1;
        private System.Windows.Forms.TextBox textBoxCP;
        private System.Windows.Forms.TextBox textBoxLoc;
        private System.Windows.Forms.TextBox textBoxDateNaissance;
        private System.Windows.Forms.TextBox textBoxCivilite;
        private ListeDeroulanteClientVehicule listeDeroulanteClientVehicule1;
        private System.Windows.Forms.Label labelVehiculeRepris;
        private System.Windows.Forms.Label labelRemise;
        private System.Windows.Forms.TextBox textBoxRemise;
        private System.Windows.Forms.NumericUpDown numericUpDownTVA;
        private System.Windows.Forms.Label labelPourcentageTVA;
        private System.Windows.Forms.Button buttonImprimerFacture;
        private System.Windows.Forms.TextBox textBoxNumHabitation;
        private System.Windows.Forms.Label labelNumHabitation;
        private System.Windows.Forms.Label labelDateNaissance;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNumTel;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelNumTel;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.Label labelCP;
        private System.Windows.Forms.Label labelLocalite;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelCivilite;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxNumChassis;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelDateArrivee;
        private System.Windows.Forms.Label labelDateCommande;
        private System.Windows.Forms.TextBox textBoxDateCommande;
        private System.Windows.Forms.Label labelPrixTotal;
        private System.Windows.Forms.TextBox textBoxPrixTotal;
        private FichePackOptions fichePackOptions1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPackCompris;
        private System.Windows.Forms.Label labelPrixCatalogue;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.PictureBox pictureBoxVehicule;
        private FicheOptions ficheOptions1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelOptionComprisAveCeVehicule;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelFicheTechnique;
        private FicheTechnique ficheTechnique1;
        private System.Windows.Forms.Label labelBonCommande;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateReception;
        private System.Windows.Forms.Label labelKilometrage;
        private System.Windows.Forms.NumericUpDown numericUpDownKilometrage;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.NumericUpDown numericUpDownAnneeConstruction;
    }
}
