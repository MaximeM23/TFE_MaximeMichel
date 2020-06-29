namespace app_tfe_michel_maxime
{
    partial class Page_Disponibilites
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
            this.labelDisponibilite = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listeDeroulanteClientVehicule1 = new app_tfe_michel_maxime.ListeDeroulanteClientVehicule();
            this.labelVehiculeRepris = new System.Windows.Forms.Label();
            this.labelRemise = new System.Windows.Forms.Label();
            this.textBoxRemise = new System.Windows.Forms.TextBox();
            this.numericUpDownTVA = new System.Windows.Forms.NumericUpDown();
            this.labelPourcentageTVA = new System.Windows.Forms.Label();
            this.labelPrixTotal = new System.Windows.Forms.Label();
            this.textBoxPrixTotal = new System.Windows.Forms.TextBox();
            this.labelPrixCatalogue = new System.Windows.Forms.Label();
            this.textBoxPrix = new System.Windows.Forms.TextBox();
            this.buttonAcheter = new System.Windows.Forms.Button();
            this.labelPackOptions = new System.Windows.Forms.Label();
            this.fichePackOptions1 = new app_tfe_michel_maxime.FichePackOptions();
            this.formulaire_Client1 = new app_tfe_michel_maxime.Formulaire_Client();
            this.labelOptions = new System.Windows.Forms.Label();
            this.ficheOptions1 = new app_tfe_michel_maxime.FicheOptions();
            this.panelSideChoice = new System.Windows.Forms.Panel();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTVA)).BeginInit();
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
            this.panel1.Controls.Add(this.labelDisponibilite);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1108, 42);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(997, 1);
            this.buttonClose1.Name = "buttonClose1";
            this.buttonClose1.Size = new System.Drawing.Size(108, 37);
            this.buttonClose1.TabIndex = 9;
            // 
            // labelDisponibilite
            // 
            this.labelDisponibilite.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelDisponibilite.AutoSize = true;
            this.labelDisponibilite.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisponibilite.ForeColor = System.Drawing.SystemColors.Window;
            this.labelDisponibilite.Location = new System.Drawing.Point(403, -1);
            this.labelDisponibilite.Name = "labelDisponibilite";
            this.labelDisponibilite.Size = new System.Drawing.Size(193, 39);
            this.labelDisponibilite.TabIndex = 0;
            this.labelDisponibilite.Text = "Disponibilités";
            this.labelDisponibilite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelDisponibilite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelDisponibilite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.listeDeroulanteClientVehicule1);
            this.panel2.Controls.Add(this.labelVehiculeRepris);
            this.panel2.Controls.Add(this.labelRemise);
            this.panel2.Controls.Add(this.textBoxRemise);
            this.panel2.Controls.Add(this.numericUpDownTVA);
            this.panel2.Controls.Add(this.labelPourcentageTVA);
            this.panel2.Controls.Add(this.labelPrixTotal);
            this.panel2.Controls.Add(this.textBoxPrixTotal);
            this.panel2.Controls.Add(this.labelPrixCatalogue);
            this.panel2.Controls.Add(this.textBoxPrix);
            this.panel2.Controls.Add(this.buttonAcheter);
            this.panel2.Controls.Add(this.labelPackOptions);
            this.panel2.Controls.Add(this.fichePackOptions1);
            this.panel2.Controls.Add(this.formulaire_Client1);
            this.panel2.Controls.Add(this.labelOptions);
            this.panel2.Controls.Add(this.ficheOptions1);
            this.panel2.Controls.Add(this.panelSideChoice);
            this.panel2.Location = new System.Drawing.Point(200, 39);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 650);
            this.panel2.TabIndex = 11;
            // 
            // listeDeroulanteClientVehicule1
            // 
            this.listeDeroulanteClientVehicule1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteClientVehicule1.ClientVehiculeSelectionne = null;
            this.listeDeroulanteClientVehicule1.Enabled = false;
            this.listeDeroulanteClientVehicule1.Location = new System.Drawing.Point(860, 491);
            this.listeDeroulanteClientVehicule1.Name = "listeDeroulanteClientVehicule1";
            this.listeDeroulanteClientVehicule1.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteClientVehicule1.TabIndex = 2;
            // 
            // labelVehiculeRepris
            // 
            this.labelVehiculeRepris.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVehiculeRepris.AutoSize = true;
            this.labelVehiculeRepris.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehiculeRepris.Location = new System.Drawing.Point(699, 495);
            this.labelVehiculeRepris.Name = "labelVehiculeRepris";
            this.labelVehiculeRepris.Size = new System.Drawing.Size(136, 15);
            this.labelVehiculeRepris.TabIndex = 153;
            this.labelVehiculeRepris.Text = "Véhicule existant repris";
            // 
            // labelRemise
            // 
            this.labelRemise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRemise.AutoSize = true;
            this.labelRemise.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRemise.Location = new System.Drawing.Point(699, 520);
            this.labelRemise.Name = "labelRemise";
            this.labelRemise.Size = new System.Drawing.Size(72, 15);
            this.labelRemise.TabIndex = 152;
            this.labelRemise.Text = "Remise en €";
            // 
            // textBoxRemise
            // 
            this.textBoxRemise.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxRemise.Enabled = false;
            this.textBoxRemise.Location = new System.Drawing.Point(860, 518);
            this.textBoxRemise.Name = "textBoxRemise";
            this.textBoxRemise.Size = new System.Drawing.Size(181, 20);
            this.textBoxRemise.TabIndex = 3;
            // 
            // numericUpDownTVA
            // 
            this.numericUpDownTVA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDownTVA.Enabled = false;
            this.numericUpDownTVA.Location = new System.Drawing.Point(860, 465);
            this.numericUpDownTVA.Name = "numericUpDownTVA";
            this.numericUpDownTVA.Size = new System.Drawing.Size(181, 20);
            this.numericUpDownTVA.TabIndex = 1;
            // 
            // labelPourcentageTVA
            // 
            this.labelPourcentageTVA.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPourcentageTVA.AutoSize = true;
            this.labelPourcentageTVA.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPourcentageTVA.Location = new System.Drawing.Point(699, 468);
            this.labelPourcentageTVA.Name = "labelPourcentageTVA";
            this.labelPourcentageTVA.Size = new System.Drawing.Size(38, 15);
            this.labelPourcentageTVA.TabIndex = 147;
            this.labelPourcentageTVA.Text = "% TVA";
            // 
            // labelPrixTotal
            // 
            this.labelPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixTotal.AutoSize = true;
            this.labelPrixTotal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixTotal.Location = new System.Drawing.Point(699, 441);
            this.labelPrixTotal.Name = "labelPrixTotal";
            this.labelPrixTotal.Size = new System.Drawing.Size(58, 15);
            this.labelPrixTotal.TabIndex = 146;
            this.labelPrixTotal.Text = "Prix total";
            // 
            // textBoxPrixTotal
            // 
            this.textBoxPrixTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrixTotal.Enabled = false;
            this.textBoxPrixTotal.Location = new System.Drawing.Point(860, 439);
            this.textBoxPrixTotal.Name = "textBoxPrixTotal";
            this.textBoxPrixTotal.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrixTotal.TabIndex = 2;
            this.textBoxPrixTotal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.textBoxPrixTotal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.textBoxPrixTotal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPrixCatalogue
            // 
            this.labelPrixCatalogue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrixCatalogue.AutoSize = true;
            this.labelPrixCatalogue.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrixCatalogue.Location = new System.Drawing.Point(699, 415);
            this.labelPrixCatalogue.Name = "labelPrixCatalogue";
            this.labelPrixCatalogue.Size = new System.Drawing.Size(86, 15);
            this.labelPrixCatalogue.TabIndex = 144;
            this.labelPrixCatalogue.Text = "Prix catalogue";
            // 
            // textBoxPrix
            // 
            this.textBoxPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrix.Enabled = false;
            this.textBoxPrix.Location = new System.Drawing.Point(860, 413);
            this.textBoxPrix.Name = "textBoxPrix";
            this.textBoxPrix.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrix.TabIndex = 1;
            // 
            // buttonAcheter
            // 
            this.buttonAcheter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAcheter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAcheter.Enabled = false;
            this.buttonAcheter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAcheter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAcheter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAcheter.Location = new System.Drawing.Point(932, 597);
            this.buttonAcheter.Name = "buttonAcheter";
            this.buttonAcheter.Size = new System.Drawing.Size(159, 40);
            this.buttonAcheter.TabIndex = 4;
            this.buttonAcheter.Text = "Acheter";
            this.buttonAcheter.UseVisualStyleBackColor = false;
            this.buttonAcheter.Click += new System.EventHandler(this.buttonAcheter_Click);
            // 
            // labelPackOptions
            // 
            this.labelPackOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPackOptions.AutoSize = true;
            this.labelPackOptions.Font = new System.Drawing.Font("Calibri", 10F);
            this.labelPackOptions.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelPackOptions.Location = new System.Drawing.Point(407, 325);
            this.labelPackOptions.Name = "labelPackOptions";
            this.labelPackOptions.Size = new System.Drawing.Size(168, 17);
            this.labelPackOptions.TabIndex = 141;
            this.labelPackOptions.Text = "Packs compris sur le véhicule";
            // 
            // fichePackOptions1
            // 
            this.fichePackOptions1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.fichePackOptions1.Enabled = false;
            this.fichePackOptions1.Location = new System.Drawing.Point(313, 344);
            this.fichePackOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptions1.Name = "fichePackOptions1";
            this.fichePackOptions1.PackOptionsSelectionnee = null;
            this.fichePackOptions1.Size = new System.Drawing.Size(346, 253);
            this.fichePackOptions1.TabIndex = 140;
            this.fichePackOptions1.TexteFiltrePackOptions = "";
            // 
            // formulaire_Client1
            // 
            this.formulaire_Client1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formulaire_Client1.ClientEnCoursDeTraitement = null;
            this.formulaire_Client1.Enabled = false;
            this.formulaire_Client1.Location = new System.Drawing.Point(686, 30);
            this.formulaire_Client1.Name = "formulaire_Client1";
            this.formulaire_Client1.Size = new System.Drawing.Size(390, 364);
            this.formulaire_Client1.TabIndex = 139;
            this.formulaire_Client1.Load += new System.EventHandler(this.formulaire_Client1_Load);
            // 
            // labelOptions
            // 
            this.labelOptions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelOptions.AutoSize = true;
            this.labelOptions.Font = new System.Drawing.Font("Calibri", 10F);
            this.labelOptions.ForeColor = System.Drawing.SystemColors.WindowText;
            this.labelOptions.Location = new System.Drawing.Point(401, 46);
            this.labelOptions.Name = "labelOptions";
            this.labelOptions.Size = new System.Drawing.Size(192, 17);
            this.labelOptions.TabIndex = 138;
            this.labelOptions.Text = "Options comprises sur le véhicule";
            this.labelOptions.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelOptions.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelOptions.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // ficheOptions1
            // 
            this.ficheOptions1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.ficheOptions1.AutoScroll = true;
            this.ficheOptions1.Enabled = false;
            this.ficheOptions1.FicheAvecFiltre = true;
            this.ficheOptions1.Location = new System.Drawing.Point(316, 65);
            this.ficheOptions1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptions1.Name = "ficheOptions1";
            this.ficheOptions1.OptionsSelectionnee = null;
            this.ficheOptions1.Size = new System.Drawing.Size(346, 239);
            this.ficheOptions1.TabIndex = 137;
            this.ficheOptions1.TexteFiltreOptions = "";
            // 
            // panelSideChoice
            // 
            this.panelSideChoice.AutoScroll = true;
            this.panelSideChoice.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideChoice.Location = new System.Drawing.Point(0, 0);
            this.panelSideChoice.Name = "panelSideChoice";
            this.panelSideChoice.Size = new System.Drawing.Size(250, 650);
            this.panelSideChoice.TabIndex = 136;
            this.panelSideChoice.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panelSideChoice.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panelSideChoice.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 689);
            this.menu1.TabIndex = 9;
            // 
            // Page_Disponibilites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Name = "Page_Disponibilites";
            this.Size = new System.Drawing.Size(1308, 689);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTVA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelDisponibilite;
        private Menu menu1;
        private System.Windows.Forms.Panel panel2;
        private Formulaire_Client formulaire_Client1;
        private System.Windows.Forms.Label labelOptions;
        private FicheOptions ficheOptions1;
        private System.Windows.Forms.Panel panelSideChoice;
        private ListeDeroulanteClientVehicule listeDeroulanteClientVehicule1;
        private System.Windows.Forms.Label labelVehiculeRepris;
        private System.Windows.Forms.Label labelRemise;
        private System.Windows.Forms.TextBox textBoxRemise;
        private System.Windows.Forms.NumericUpDown numericUpDownTVA;
        private System.Windows.Forms.Label labelPourcentageTVA;
        private System.Windows.Forms.Label labelPrixTotal;
        private System.Windows.Forms.TextBox textBoxPrixTotal;
        private System.Windows.Forms.Label labelPrixCatalogue;
        private System.Windows.Forms.TextBox textBoxPrix;
        private System.Windows.Forms.Button buttonAcheter;
        private System.Windows.Forms.Label labelPackOptions;
        private FichePackOptions fichePackOptions1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
    }
}
