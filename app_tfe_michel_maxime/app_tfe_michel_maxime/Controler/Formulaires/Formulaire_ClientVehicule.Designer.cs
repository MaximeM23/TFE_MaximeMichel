namespace app_tfe_michel_maxime
{
    partial class Formulaire_ClientVehicule
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
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.labelRechercheClient = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.labelCivilite = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.labelLocaliteCP = new System.Windows.Forms.Label();
            this.labelVehiculeClient = new System.Windows.Forms.Label();
            this.labelNumeroHabitation = new System.Windows.Forms.Label();
            this.textBoxNumHabitation = new System.Windows.Forms.TextBox();
            this.labelNumTel = new System.Windows.Forms.Label();
            this.textBoxNumTel = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.labelNumChassis = new System.Windows.Forms.Label();
            this.textBoxNumeroChassis = new System.Windows.Forms.TextBox();
            this.labelImmatriculation = new System.Windows.Forms.Label();
            this.textBoxImmatriculation = new System.Windows.Forms.TextBox();
            this.errorProviderClient = new System.Windows.Forms.ErrorProvider(this.components);
            this.dateTimePickerDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.labelDateNaissance = new System.Windows.Forms.Label();
            this.labelVehicule = new System.Windows.Forms.Label();
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.listeDeroulanteModele = new app_tfe_michel_maxime.ListeDeroulanteVehicule();
            this.listeDeroulanteCivilite = new app_tfe_michel_maxime.ListeDeroulanteCivilite();
            this.listeDeroulanteClient = new app_tfe_michel_maxime.ListeDeroulanteClient();
            this.listeDeroulanteLocaliteCP = new app_tfe_michel_maxime.ListeDeroulanteAdresse();
            this.listeDeroulanteClientVehicule = new app_tfe_michel_maxime.ListeDeroulanteClientVehicule();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouter.FlatAppearance.BorderSize = 0;
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouter.ForeColor = System.Drawing.Color.White;
            this.buttonAjouter.Location = new System.Drawing.Point(0, 364);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(150, 35);
            this.buttonAjouter.TabIndex = 16;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.Enabled = false;
            this.buttonModifier.FlatAppearance.BorderSize = 0;
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.White;
            this.buttonModifier.Location = new System.Drawing.Point(191, 364);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(150, 35);
            this.buttonModifier.TabIndex = 17;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrenom.Location = new System.Drawing.Point(158, 53);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(183, 20);
            this.textBoxPrenom.TabIndex = 3;
            // 
            // labelRechercheClient
            // 
            this.labelRechercheClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheClient.AutoSize = true;
            this.labelRechercheClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheClient.Location = new System.Drawing.Point(3, 6);
            this.labelRechercheClient.Name = "labelRechercheClient";
            this.labelRechercheClient.Size = new System.Drawing.Size(119, 15);
            this.labelRechercheClient.TabIndex = 37;
            this.labelRechercheClient.Text = "Rechercher un client";
            // 
            // labelNom
            // 
            this.labelNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(3, 31);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(32, 15);
            this.labelNom.TabIndex = 39;
            this.labelNom.Text = "Nom";
            // 
            // labelPrenom
            // 
            this.labelPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenom.Location = new System.Drawing.Point(3, 55);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(49, 15);
            this.labelPrenom.TabIndex = 41;
            this.labelPrenom.Text = "Prénom";
            // 
            // labelCivilite
            // 
            this.labelCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCivilite.AutoSize = true;
            this.labelCivilite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCivilite.Location = new System.Drawing.Point(3, 102);
            this.labelCivilite.Name = "labelCivilite";
            this.labelCivilite.Size = new System.Drawing.Size(46, 15);
            this.labelCivilite.TabIndex = 42;
            this.labelCivilite.Text = "Civilité";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNom.Location = new System.Drawing.Point(158, 29);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(183, 20);
            this.textBoxNom.TabIndex = 2;
            // 
            // labelAdresse
            // 
            this.labelAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdresse.Location = new System.Drawing.Point(3, 154);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(50, 15);
            this.labelAdresse.TabIndex = 44;
            this.labelAdresse.Text = "Adresse";
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAdresse.Location = new System.Drawing.Point(158, 152);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(183, 20);
            this.textBoxAdresse.TabIndex = 8;
            // 
            // labelLocaliteCP
            // 
            this.labelLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLocaliteCP.AutoSize = true;
            this.labelLocaliteCP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocaliteCP.Location = new System.Drawing.Point(3, 127);
            this.labelLocaliteCP.Name = "labelLocaliteCP";
            this.labelLocaliteCP.Size = new System.Drawing.Size(126, 15);
            this.labelLocaliteCP.TabIndex = 43;
            this.labelLocaliteCP.Text = "Code postal / Localité";
            // 
            // labelVehiculeClient
            // 
            this.labelVehiculeClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVehiculeClient.AutoSize = true;
            this.labelVehiculeClient.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehiculeClient.Location = new System.Drawing.Point(3, 254);
            this.labelVehiculeClient.Name = "labelVehiculeClient";
            this.labelVehiculeClient.Size = new System.Drawing.Size(104, 15);
            this.labelVehiculeClient.TabIndex = 47;
            this.labelVehiculeClient.Text = "Véhicule du client";
            // 
            // labelNumeroHabitation
            // 
            this.labelNumeroHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumeroHabitation.AutoSize = true;
            this.labelNumeroHabitation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumeroHabitation.Location = new System.Drawing.Point(3, 179);
            this.labelNumeroHabitation.Name = "labelNumeroHabitation";
            this.labelNumeroHabitation.Size = new System.Drawing.Size(120, 15);
            this.labelNumeroHabitation.TabIndex = 62;
            this.labelNumeroHabitation.Text = "Numéro d\'habitation";
            // 
            // textBoxNumHabitation
            // 
            this.textBoxNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumHabitation.Location = new System.Drawing.Point(158, 177);
            this.textBoxNumHabitation.Name = "textBoxNumHabitation";
            this.textBoxNumHabitation.Size = new System.Drawing.Size(183, 20);
            this.textBoxNumHabitation.TabIndex = 9;
            // 
            // labelNumTel
            // 
            this.labelNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumTel.AutoSize = true;
            this.labelNumTel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumTel.Location = new System.Drawing.Point(3, 204);
            this.labelNumTel.Name = "labelNumTel";
            this.labelNumTel.Size = new System.Drawing.Size(123, 15);
            this.labelNumTel.TabIndex = 45;
            this.labelNumTel.Text = "Numéro de téléphone";
            // 
            // textBoxNumTel
            // 
            this.textBoxNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumTel.Location = new System.Drawing.Point(158, 202);
            this.textBoxNumTel.Name = "textBoxNumTel";
            this.textBoxNumTel.Size = new System.Drawing.Size(183, 20);
            this.textBoxNumTel.TabIndex = 10;
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(3, 229);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 15);
            this.labelEmail.TabIndex = 46;
            this.labelEmail.Text = "Email";
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEmail.Location = new System.Drawing.Point(158, 227);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(183, 20);
            this.textBoxEmail.TabIndex = 11;
            // 
            // labelNumChassis
            // 
            this.labelNumChassis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumChassis.AutoSize = true;
            this.labelNumChassis.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumChassis.Location = new System.Drawing.Point(3, 304);
            this.labelNumChassis.Name = "labelNumChassis";
            this.labelNumChassis.Size = new System.Drawing.Size(111, 15);
            this.labelNumChassis.TabIndex = 49;
            this.labelNumChassis.Text = "Numéro de châssis";
            // 
            // textBoxNumeroChassis
            // 
            this.textBoxNumeroChassis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumeroChassis.Location = new System.Drawing.Point(158, 302);
            this.textBoxNumeroChassis.Name = "textBoxNumeroChassis";
            this.textBoxNumeroChassis.Size = new System.Drawing.Size(183, 20);
            this.textBoxNumeroChassis.TabIndex = 14;
            // 
            // labelImmatriculation
            // 
            this.labelImmatriculation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelImmatriculation.AutoSize = true;
            this.labelImmatriculation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImmatriculation.Location = new System.Drawing.Point(3, 329);
            this.labelImmatriculation.Name = "labelImmatriculation";
            this.labelImmatriculation.Size = new System.Drawing.Size(96, 15);
            this.labelImmatriculation.TabIndex = 48;
            this.labelImmatriculation.Text = "Immatriculation";
            // 
            // textBoxImmatriculation
            // 
            this.textBoxImmatriculation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxImmatriculation.Location = new System.Drawing.Point(158, 327);
            this.textBoxImmatriculation.Name = "textBoxImmatriculation";
            this.textBoxImmatriculation.Size = new System.Drawing.Size(183, 20);
            this.textBoxImmatriculation.TabIndex = 15;
            // 
            // errorProviderClient
            // 
            this.errorProviderClient.ContainerControl = this;
            // 
            // dateTimePickerDateNaissance
            // 
            this.dateTimePickerDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerDateNaissance.Location = new System.Drawing.Point(158, 76);
            this.dateTimePickerDateNaissance.Name = "dateTimePickerDateNaissance";
            this.dateTimePickerDateNaissance.Size = new System.Drawing.Size(183, 20);
            this.dateTimePickerDateNaissance.TabIndex = 4;
            this.dateTimePickerDateNaissance.Value = new System.DateTime(2001, 1, 1, 0, 0, 0, 0);
            // 
            // labelDateNaissance
            // 
            this.labelDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNaissance.AutoSize = true;
            this.labelDateNaissance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateNaissance.Location = new System.Drawing.Point(3, 79);
            this.labelDateNaissance.Name = "labelDateNaissance";
            this.labelDateNaissance.Size = new System.Drawing.Size(107, 15);
            this.labelDateNaissance.TabIndex = 66;
            this.labelDateNaissance.Text = "Date de naissance";
            // 
            // labelVehicule
            // 
            this.labelVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelVehicule.AutoSize = true;
            this.labelVehicule.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVehicule.Location = new System.Drawing.Point(3, 281);
            this.labelVehicule.Name = "labelVehicule";
            this.labelVehicule.Size = new System.Drawing.Size(51, 15);
            this.labelVehicule.TabIndex = 68;
            this.labelVehicule.Text = "Modèle ";
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // listeDeroulanteModele
            // 
            this.listeDeroulanteModele.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteModele.Location = new System.Drawing.Point(158, 278);
            this.listeDeroulanteModele.Name = "listeDeroulanteModele";
            this.listeDeroulanteModele.Size = new System.Drawing.Size(183, 21);
            this.listeDeroulanteModele.TabIndex = 13;
            this.listeDeroulanteModele.VehiculeSelectionne = null;
            // 
            // listeDeroulanteCivilite
            // 
            this.listeDeroulanteCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteCivilite.CiviliteSelectionne = null;
            this.listeDeroulanteCivilite.Location = new System.Drawing.Point(158, 100);
            this.listeDeroulanteCivilite.Name = "listeDeroulanteCivilite";
            this.listeDeroulanteCivilite.Size = new System.Drawing.Size(183, 21);
            this.listeDeroulanteCivilite.TabIndex = 5;
            // 
            // listeDeroulanteClient
            // 
            this.listeDeroulanteClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteClient.ClientSelectionne = null;
            this.listeDeroulanteClient.Location = new System.Drawing.Point(158, 4);
            this.listeDeroulanteClient.Name = "listeDeroulanteClient";
            this.listeDeroulanteClient.Size = new System.Drawing.Size(183, 21);
            this.listeDeroulanteClient.TabIndex = 1;
            // 
            // listeDeroulanteLocaliteCP
            // 
            this.listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            this.listeDeroulanteLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteLocaliteCP.Location = new System.Drawing.Point(158, 125);
            this.listeDeroulanteLocaliteCP.Name = "listeDeroulanteLocaliteCP";
            this.listeDeroulanteLocaliteCP.Size = new System.Drawing.Size(183, 21);
            this.listeDeroulanteLocaliteCP.TabIndex = 6;
            // 
            // listeDeroulanteClientVehicule
            // 
            this.listeDeroulanteClientVehicule.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteClientVehicule.ClientVehiculeSelectionne = null;
            this.listeDeroulanteClientVehicule.Location = new System.Drawing.Point(158, 252);
            this.listeDeroulanteClientVehicule.Name = "listeDeroulanteClientVehicule";
            this.listeDeroulanteClientVehicule.Size = new System.Drawing.Size(183, 21);
            this.listeDeroulanteClientVehicule.TabIndex = 12;
            // 
            // Formulaire_ClientVehicule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listeDeroulanteModele);
            this.Controls.Add(this.labelVehicule);
            this.Controls.Add(this.labelDateNaissance);
            this.Controls.Add(this.dateTimePickerDateNaissance);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.labelRechercheClient);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.labelCivilite);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.labelAdresse);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.listeDeroulanteCivilite);
            this.Controls.Add(this.listeDeroulanteClient);
            this.Controls.Add(this.labelLocaliteCP);
            this.Controls.Add(this.listeDeroulanteLocaliteCP);
            this.Controls.Add(this.labelVehiculeClient);
            this.Controls.Add(this.labelNumeroHabitation);
            this.Controls.Add(this.textBoxNumHabitation);
            this.Controls.Add(this.labelNumTel);
            this.Controls.Add(this.textBoxNumTel);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.labelNumChassis);
            this.Controls.Add(this.textBoxNumeroChassis);
            this.Controls.Add(this.labelImmatriculation);
            this.Controls.Add(this.textBoxImmatriculation);
            this.Controls.Add(this.listeDeroulanteClientVehicule);
            this.Name = "Formulaire_ClientVehicule";
            this.Size = new System.Drawing.Size(372, 457);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.Label labelRechercheClient;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelCivilite;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private ListeDeroulanteCivilite listeDeroulanteCivilite;
        private ListeDeroulanteClient listeDeroulanteClient;
        private System.Windows.Forms.Label labelLocaliteCP;
        private ListeDeroulanteAdresse listeDeroulanteLocaliteCP;
        private System.Windows.Forms.Label labelVehiculeClient;
        private System.Windows.Forms.Label labelNumeroHabitation;
        private System.Windows.Forms.TextBox textBoxNumHabitation;
        private System.Windows.Forms.Label labelNumTel;
        private System.Windows.Forms.TextBox textBoxNumTel;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.Label labelNumChassis;
        private System.Windows.Forms.TextBox textBoxNumeroChassis;
        private System.Windows.Forms.Label labelImmatriculation;
        private System.Windows.Forms.TextBox textBoxImmatriculation;
        private ListeDeroulanteClientVehicule listeDeroulanteClientVehicule;
        private System.Windows.Forms.ErrorProvider errorProviderClient;
        private System.Windows.Forms.Label labelDateNaissance;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateNaissance;
        private System.Windows.Forms.Label labelVehicule;
        private ListeDeroulanteVehicule listeDeroulanteModele;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
    }
}
