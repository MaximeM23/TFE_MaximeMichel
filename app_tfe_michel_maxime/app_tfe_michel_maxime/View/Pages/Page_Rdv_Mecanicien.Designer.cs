namespace app_tfe_michel_maxime
{
    partial class Page_Rdv_Mecanicien
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
            this.labelEntretienReparation = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelDateArrivee = new System.Windows.Forms.Label();
            this.dateTimePickerArrivee = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.labelDateFin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelReparation = new System.Windows.Forms.Label();
            this.checkBoxReparation = new System.Windows.Forms.CheckBox();
            this.labelInfoReparation = new System.Windows.Forms.Label();
            this.textBoxInfoReparation = new System.Windows.Forms.TextBox();
            this.buttonReactualiser = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonAnnulationRendezvous = new System.Windows.Forms.Button();
            this.buttonReactiveRdv = new System.Windows.Forms.Button();
            this.pictureBoxSupprimerEntretien = new System.Windows.Forms.PictureBox();
            this.pictureBoxModifierEntretien = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterEntretien = new System.Windows.Forms.PictureBox();
            this.buttonImprimerLaFacture = new System.Windows.Forms.Button();
            this.entretiens = new app_tfe_michel_maxime.Entretiens();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.listeDeroulanteEntretien = new app_tfe_michel_maxime.ListeDeroulanteEntretien();
            this.ClientVehicule = new app_tfe_michel_maxime.Formulaire_ClientVehicule();
            this.CalendrierRdv = new app_tfe_michel_maxime.CalendrierRdv();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSupprimerEntretien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModifierEntretien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterEntretien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.labelEntretienReparation);
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1100, 42);
            this.panel1.TabIndex = 7;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelEntretienReparation
            // 
            this.labelEntretienReparation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelEntretienReparation.AutoSize = true;
            this.labelEntretienReparation.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEntretienReparation.ForeColor = System.Drawing.SystemColors.Window;
            this.labelEntretienReparation.Location = new System.Drawing.Point(400, -1);
            this.labelEntretienReparation.Name = "labelEntretienReparation";
            this.labelEntretienReparation.Size = new System.Drawing.Size(342, 39);
            this.labelEntretienReparation.TabIndex = 0;
            this.labelEntretienReparation.Text = "Entretiens et réparations";
            this.labelEntretienReparation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelEntretienReparation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelEntretienReparation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(206, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 1);
            this.panel2.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 23);
            this.label1.TabIndex = 13;
            this.label1.Text = "Informations sur le client";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(927, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(258, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Informations sur le rendez-vous";
            // 
            // panel3
            // 
            this.panel3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel3.BackColor = System.Drawing.Color.Black;
            this.panel3.Location = new System.Drawing.Point(927, 248);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(350, 1);
            this.panel3.TabIndex = 14;
            // 
            // labelDateArrivee
            // 
            this.labelDateArrivee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateArrivee.AutoSize = true;
            this.labelDateArrivee.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateArrivee.Location = new System.Drawing.Point(924, 269);
            this.labelDateArrivee.Name = "labelDateArrivee";
            this.labelDateArrivee.Size = new System.Drawing.Size(84, 15);
            this.labelDateArrivee.TabIndex = 16;
            this.labelDateArrivee.Text = "Date d\'arrivée";
            // 
            // dateTimePickerArrivee
            // 
            this.dateTimePickerArrivee.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerArrivee.Location = new System.Drawing.Point(1047, 266);
            this.dateTimePickerArrivee.Name = "dateTimePickerArrivee";
            this.dateTimePickerArrivee.Size = new System.Drawing.Size(230, 20);
            this.dateTimePickerArrivee.TabIndex = 17;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerFin.Location = new System.Drawing.Point(1047, 314);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(230, 20);
            this.dateTimePickerFin.TabIndex = 18;
            // 
            // labelDateFin
            // 
            this.labelDateFin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateFin.AutoSize = true;
            this.labelDateFin.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateFin.Location = new System.Drawing.Point(924, 317);
            this.labelDateFin.Name = "labelDateFin";
            this.labelDateFin.Size = new System.Drawing.Size(65, 15);
            this.labelDateFin.TabIndex = 18;
            this.labelDateFin.Text = "Date de fin";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(924, 367);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 15);
            this.label3.TabIndex = 20;
            this.label3.Text = "Type d\'entretien";
            // 
            // labelReparation
            // 
            this.labelReparation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelReparation.AutoSize = true;
            this.labelReparation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelReparation.Location = new System.Drawing.Point(924, 419);
            this.labelReparation.Name = "labelReparation";
            this.labelReparation.Size = new System.Drawing.Size(67, 15);
            this.labelReparation.TabIndex = 22;
            this.labelReparation.Text = "Réparation";
            // 
            // checkBoxReparation
            // 
            this.checkBoxReparation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBoxReparation.AutoSize = true;
            this.checkBoxReparation.Location = new System.Drawing.Point(1047, 420);
            this.checkBoxReparation.Name = "checkBoxReparation";
            this.checkBoxReparation.Size = new System.Drawing.Size(15, 14);
            this.checkBoxReparation.TabIndex = 20;
            this.checkBoxReparation.UseVisualStyleBackColor = true;
            this.checkBoxReparation.Click += new System.EventHandler(this.checkBoxReparation_Click);
            // 
            // labelInfoReparation
            // 
            this.labelInfoReparation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfoReparation.AutoSize = true;
            this.labelInfoReparation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfoReparation.Location = new System.Drawing.Point(924, 467);
            this.labelInfoReparation.Name = "labelInfoReparation";
            this.labelInfoReparation.Size = new System.Drawing.Size(210, 15);
            this.labelInfoReparation.TabIndex = 24;
            this.labelInfoReparation.Text = "Information sur la ou les réparations";
            // 
            // textBoxInfoReparation
            // 
            this.textBoxInfoReparation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxInfoReparation.Enabled = false;
            this.textBoxInfoReparation.Location = new System.Drawing.Point(927, 485);
            this.textBoxInfoReparation.Multiline = true;
            this.textBoxInfoReparation.Name = "textBoxInfoReparation";
            this.textBoxInfoReparation.Size = new System.Drawing.Size(350, 128);
            this.textBoxInfoReparation.TabIndex = 21;
            // 
            // buttonReactualiser
            // 
            this.buttonReactualiser.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReactualiser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonReactualiser.Enabled = false;
            this.buttonReactualiser.FlatAppearance.BorderSize = 0;
            this.buttonReactualiser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReactualiser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReactualiser.ForeColor = System.Drawing.Color.White;
            this.buttonReactualiser.Location = new System.Drawing.Point(607, 327);
            this.buttonReactualiser.Name = "buttonReactualiser";
            this.buttonReactualiser.Size = new System.Drawing.Size(284, 35);
            this.buttonReactualiser.TabIndex = 41;
            this.buttonReactualiser.Text = "Réactualiser";
            this.buttonReactualiser.UseVisualStyleBackColor = false;
            this.buttonReactualiser.Click += new System.EventHandler(this.buttonReactualiser_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.Enabled = false;
            this.buttonModifier.FlatAppearance.BorderSize = 0;
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.White;
            this.buttonModifier.Location = new System.Drawing.Point(1127, 630);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(150, 35);
            this.buttonModifier.TabIndex = 23;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouter.Enabled = false;
            this.buttonAjouter.FlatAppearance.BorderSize = 0;
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouter.ForeColor = System.Drawing.Color.White;
            this.buttonAjouter.Location = new System.Drawing.Point(927, 630);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(150, 35);
            this.buttonAjouter.TabIndex = 22;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // buttonAnnulationRendezvous
            // 
            this.buttonAnnulationRendezvous.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnulationRendezvous.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnulationRendezvous.Enabled = false;
            this.buttonAnnulationRendezvous.FlatAppearance.BorderSize = 0;
            this.buttonAnnulationRendezvous.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnulationRendezvous.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnulationRendezvous.ForeColor = System.Drawing.Color.White;
            this.buttonAnnulationRendezvous.Location = new System.Drawing.Point(607, 283);
            this.buttonAnnulationRendezvous.Name = "buttonAnnulationRendezvous";
            this.buttonAnnulationRendezvous.Size = new System.Drawing.Size(284, 35);
            this.buttonAnnulationRendezvous.TabIndex = 44;
            this.buttonAnnulationRendezvous.Text = "Annuler le rendez-vous";
            this.buttonAnnulationRendezvous.UseVisualStyleBackColor = false;
            this.buttonAnnulationRendezvous.Click += new System.EventHandler(this.buttonAnnulationRendezvous_Click);
            // 
            // buttonReactiveRdv
            // 
            this.buttonReactiveRdv.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonReactiveRdv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonReactiveRdv.Enabled = false;
            this.buttonReactiveRdv.FlatAppearance.BorderSize = 0;
            this.buttonReactiveRdv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReactiveRdv.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReactiveRdv.ForeColor = System.Drawing.Color.White;
            this.buttonReactiveRdv.Location = new System.Drawing.Point(607, 236);
            this.buttonReactiveRdv.Name = "buttonReactiveRdv";
            this.buttonReactiveRdv.Size = new System.Drawing.Size(284, 35);
            this.buttonReactiveRdv.TabIndex = 45;
            this.buttonReactiveRdv.Text = "Réactiver le rendez-vous";
            this.buttonReactiveRdv.UseVisualStyleBackColor = false;
            this.buttonReactiveRdv.Click += new System.EventHandler(this.buttonReactiveRdv_Click);
            // 
            // pictureBoxSupprimerEntretien
            // 
            this.pictureBoxSupprimerEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxSupprimerEntretien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSupprimerEntretien.Image = global::app_tfe_michel_maxime.Properties.Resources.corbeille;
            this.pictureBoxSupprimerEntretien.Location = new System.Drawing.Point(1251, 361);
            this.pictureBoxSupprimerEntretien.Name = "pictureBoxSupprimerEntretien";
            this.pictureBoxSupprimerEntretien.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSupprimerEntretien.TabIndex = 49;
            this.pictureBoxSupprimerEntretien.TabStop = false;
            this.pictureBoxSupprimerEntretien.Click += new System.EventHandler(this.pictureBoxSupprimerEntretien_Click);
            // 
            // pictureBoxModifierEntretien
            // 
            this.pictureBoxModifierEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxModifierEntretien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxModifierEntretien.Enabled = false;
            this.pictureBoxModifierEntretien.Image = global::app_tfe_michel_maxime.Properties.Resources.tools;
            this.pictureBoxModifierEntretien.Location = new System.Drawing.Point(1221, 361);
            this.pictureBoxModifierEntretien.Name = "pictureBoxModifierEntretien";
            this.pictureBoxModifierEntretien.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxModifierEntretien.TabIndex = 48;
            this.pictureBoxModifierEntretien.TabStop = false;
            this.pictureBoxModifierEntretien.Click += new System.EventHandler(this.pictureBoxModifierEntretien_Click);
            // 
            // pictureBoxAjouterEntretien
            // 
            this.pictureBoxAjouterEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterEntretien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterEntretien.Image = global::app_tfe_michel_maxime.Properties.Resources.plus;
            this.pictureBoxAjouterEntretien.Location = new System.Drawing.Point(1191, 361);
            this.pictureBoxAjouterEntretien.Name = "pictureBoxAjouterEntretien";
            this.pictureBoxAjouterEntretien.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAjouterEntretien.TabIndex = 47;
            this.pictureBoxAjouterEntretien.TabStop = false;
            this.pictureBoxAjouterEntretien.Click += new System.EventHandler(this.pictureBoxAjouterEntretien_Click);
            // 
            // buttonImprimerLaFacture
            // 
            this.buttonImprimerLaFacture.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonImprimerLaFacture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonImprimerLaFacture.Enabled = false;
            this.buttonImprimerLaFacture.FlatAppearance.BorderSize = 0;
            this.buttonImprimerLaFacture.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonImprimerLaFacture.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImprimerLaFacture.ForeColor = System.Drawing.Color.White;
            this.buttonImprimerLaFacture.Location = new System.Drawing.Point(607, 370);
            this.buttonImprimerLaFacture.Name = "buttonImprimerLaFacture";
            this.buttonImprimerLaFacture.Size = new System.Drawing.Size(284, 35);
            this.buttonImprimerLaFacture.TabIndex = 51;
            this.buttonImprimerLaFacture.Text = "Imprimer la facture";
            this.buttonImprimerLaFacture.UseVisualStyleBackColor = false;
            this.buttonImprimerLaFacture.Click += new System.EventHandler(this.buttonImprimerLaFacture_Click);
            // 
            // entretiens
            // 
            this.entretiens.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.entretiens.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.entretiens.EntretienSelectionner = null;
            this.entretiens.EstAjouter = false;
            this.entretiens.EstModification = false;
            this.entretiens.Location = new System.Drawing.Point(953, 385);
            this.entretiens.Name = "entretiens";
            this.entretiens.Size = new System.Drawing.Size(322, 98);
            this.entretiens.TabIndex = 50;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 750);
            this.menu1.TabIndex = 46;
            // 
            // listeDeroulanteEntretien
            // 
            this.listeDeroulanteEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteEntretien.EntretienSelectionne = null;
            this.listeDeroulanteEntretien.Location = new System.Drawing.Point(1047, 363);
            this.listeDeroulanteEntretien.Name = "listeDeroulanteEntretien";
            this.listeDeroulanteEntretien.Size = new System.Drawing.Size(138, 21);
            this.listeDeroulanteEntretien.TabIndex = 19;
            // 
            // ClientVehicule
            // 
            this.ClientVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ClientVehicule.ClientSelectionneCalendrier = null;
            this.ClientVehicule.ClientVehiculeEnCoursDeTraitement = null;
            this.ClientVehicule.Location = new System.Drawing.Point(206, 265);
            this.ClientVehicule.Name = "ClientVehicule";
            this.ClientVehicule.Size = new System.Drawing.Size(372, 457);
            this.ClientVehicule.TabIndex = 11;
            this.ClientVehicule.Load += new System.EventHandler(this.formulaire_ClientVehicule1_Load);
            // 
            // CalendrierRdv
            // 
            this.CalendrierRdv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CalendrierRdv.FactureSelectionnee = null;
            this.CalendrierRdv.Location = new System.Drawing.Point(200, 41);
            this.CalendrierRdv.Name = "CalendrierRdv";
            this.CalendrierRdv.Size = new System.Drawing.Size(1100, 162);
            this.CalendrierRdv.TabIndex = 8;
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(992, 6);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(105, 32);
            this.buttonClose1.TabIndex = 4;
            // 
            // Page_Rdv_Mecanicien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonImprimerLaFacture);
            this.Controls.Add(this.entretiens);
            this.Controls.Add(this.pictureBoxSupprimerEntretien);
            this.Controls.Add(this.pictureBoxModifierEntretien);
            this.Controls.Add(this.pictureBoxAjouterEntretien);
            this.Controls.Add(this.menu1);
            this.Controls.Add(this.buttonReactiveRdv);
            this.Controls.Add(this.buttonAnnulationRendezvous);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonReactualiser);
            this.Controls.Add(this.textBoxInfoReparation);
            this.Controls.Add(this.labelInfoReparation);
            this.Controls.Add(this.checkBoxReparation);
            this.Controls.Add(this.labelReparation);
            this.Controls.Add(this.listeDeroulanteEntretien);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.labelDateFin);
            this.Controls.Add(this.dateTimePickerArrivee);
            this.Controls.Add(this.labelDateArrivee);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ClientVehicule);
            this.Controls.Add(this.CalendrierRdv);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "Page_Rdv_Mecanicien";
            this.Size = new System.Drawing.Size(1300, 750);
            this.Load += new System.EventHandler(this.PageRdvMecanicien_Load);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSupprimerEntretien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxModifierEntretien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterEntretien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelEntretienReparation;
        private Formulaire_ClientVehicule ClientVehicule;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelDateArrivee;
        private System.Windows.Forms.DateTimePicker dateTimePickerArrivee;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Label labelDateFin;
        private System.Windows.Forms.Label label3;
        private ListeDeroulanteEntretien listeDeroulanteEntretien;
        private System.Windows.Forms.Label labelReparation;
        private System.Windows.Forms.CheckBox checkBoxReparation;
        private System.Windows.Forms.Label labelInfoReparation;
        private System.Windows.Forms.TextBox textBoxInfoReparation;
        private System.Windows.Forms.Button buttonReactualiser;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAjouter;
        private app_tfe_michel_maxime.CalendrierRdv CalendrierRdv;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button buttonAnnulationRendezvous;
        private System.Windows.Forms.Button buttonReactiveRdv;
        private Menu menu1;
        private System.Windows.Forms.PictureBox pictureBoxAjouterEntretien;
        private System.Windows.Forms.PictureBox pictureBoxModifierEntretien;
        private System.Windows.Forms.PictureBox pictureBoxSupprimerEntretien;
        private Entretiens entretiens;
        private System.Windows.Forms.Button buttonImprimerLaFacture;
    }
}
