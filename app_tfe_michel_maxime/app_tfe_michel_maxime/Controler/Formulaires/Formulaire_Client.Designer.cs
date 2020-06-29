namespace app_tfe_michel_maxime
{
    partial class Formulaire_Client
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
            this.errorProviderClient = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.textBoxNumHabitation = new System.Windows.Forms.TextBox();
            this.labelNumHabitation = new System.Windows.Forms.Label();
            this.dateTimePickerDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.labelDateNaissance = new System.Windows.Forms.Label();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.textBoxNumTel = new System.Windows.Forms.TextBox();
            this.textBoxAdresse = new System.Windows.Forms.TextBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelNumTel = new System.Windows.Forms.Label();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.labelLocaliteCP = new System.Windows.Forms.Label();
            this.textBoxPrenom = new System.Windows.Forms.TextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelCivilite = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelRechercherClient = new System.Windows.Forms.Label();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.listeDeroulanteLocaliteCP = new app_tfe_michel_maxime.ListeDeroulanteAdresse();
            this.listeDeroulanteCivilite = new app_tfe_michel_maxime.ListeDeroulanteCivilite();
            this.listeDeroulanteClient = new app_tfe_michel_maxime.ListeDeroulanteClient();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderClient
            // 
            this.errorProviderClient.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // textBoxNumHabitation
            // 
            this.textBoxNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumHabitation.Location = new System.Drawing.Point(175, 206);
            this.textBoxNumHabitation.Name = "textBoxNumHabitation";
            this.textBoxNumHabitation.Size = new System.Drawing.Size(181, 20);
            this.textBoxNumHabitation.TabIndex = 9;
            // 
            // labelNumHabitation
            // 
            this.labelNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumHabitation.AutoSize = true;
            this.labelNumHabitation.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumHabitation.Location = new System.Drawing.Point(12, 209);
            this.labelNumHabitation.Name = "labelNumHabitation";
            this.labelNumHabitation.Size = new System.Drawing.Size(120, 14);
            this.labelNumHabitation.TabIndex = 148;
            this.labelNumHabitation.Text = "Numéro d\'habitation";
            // 
            // dateTimePickerDateNaissance
            // 
            this.dateTimePickerDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dateTimePickerDateNaissance.Location = new System.Drawing.Point(175, 128);
            this.dateTimePickerDateNaissance.Name = "dateTimePickerDateNaissance";
            this.dateTimePickerDateNaissance.Size = new System.Drawing.Size(181, 20);
            this.dateTimePickerDateNaissance.TabIndex = 5;
            // 
            // labelDateNaissance
            // 
            this.labelDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNaissance.AutoSize = true;
            this.labelDateNaissance.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateNaissance.Location = new System.Drawing.Point(12, 131);
            this.labelDateNaissance.Name = "labelDateNaissance";
            this.labelDateNaissance.Size = new System.Drawing.Size(109, 14);
            this.labelDateNaissance.TabIndex = 146;
            this.labelDateNaissance.Text = "Date de naissance";
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifier.Location = new System.Drawing.Point(128, 286);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(110, 40);
            this.buttonModifier.TabIndex = 13;
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
            this.buttonAjouter.Location = new System.Drawing.Point(11, 286);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(110, 40);
            this.buttonAjouter.TabIndex = 12;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEmail.Location = new System.Drawing.Point(175, 260);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(181, 20);
            this.textBoxEmail.TabIndex = 11;
            // 
            // textBoxNumTel
            // 
            this.textBoxNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNumTel.Location = new System.Drawing.Point(175, 233);
            this.textBoxNumTel.Name = "textBoxNumTel";
            this.textBoxNumTel.Size = new System.Drawing.Size(181, 20);
            this.textBoxNumTel.TabIndex = 10;
            // 
            // textBoxAdresse
            // 
            this.textBoxAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAdresse.Location = new System.Drawing.Point(175, 180);
            this.textBoxAdresse.Name = "textBoxAdresse";
            this.textBoxAdresse.Size = new System.Drawing.Size(181, 20);
            this.textBoxAdresse.TabIndex = 8;
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(12, 263);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 14);
            this.labelEmail.TabIndex = 138;
            this.labelEmail.Text = "Email";
            // 
            // labelNumTel
            // 
            this.labelNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumTel.AutoSize = true;
            this.labelNumTel.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumTel.Location = new System.Drawing.Point(12, 236);
            this.labelNumTel.Name = "labelNumTel";
            this.labelNumTel.Size = new System.Drawing.Size(127, 14);
            this.labelNumTel.TabIndex = 137;
            this.labelNumTel.Text = "Numéro de téléphone";
            // 
            // labelAdresse
            // 
            this.labelAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdresse.Location = new System.Drawing.Point(12, 183);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(51, 14);
            this.labelAdresse.TabIndex = 136;
            this.labelAdresse.Text = "Adresse";
            // 
            // labelLocaliteCP
            // 
            this.labelLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLocaliteCP.AutoSize = true;
            this.labelLocaliteCP.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocaliteCP.Location = new System.Drawing.Point(12, 156);
            this.labelLocaliteCP.Name = "labelLocaliteCP";
            this.labelLocaliteCP.Size = new System.Drawing.Size(126, 14);
            this.labelLocaliteCP.TabIndex = 134;
            this.labelLocaliteCP.Text = "Code postal / Localité";
            // 
            // textBoxPrenom
            // 
            this.textBoxPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxPrenom.Location = new System.Drawing.Point(175, 76);
            this.textBoxPrenom.Name = "textBoxPrenom";
            this.textBoxPrenom.Size = new System.Drawing.Size(181, 20);
            this.textBoxPrenom.TabIndex = 3;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNom.Location = new System.Drawing.Point(175, 50);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(181, 20);
            this.textBoxNom.TabIndex = 2;
            // 
            // labelCivilite
            // 
            this.labelCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCivilite.AutoSize = true;
            this.labelCivilite.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCivilite.Location = new System.Drawing.Point(12, 104);
            this.labelCivilite.Name = "labelCivilite";
            this.labelCivilite.Size = new System.Drawing.Size(45, 14);
            this.labelCivilite.TabIndex = 129;
            this.labelCivilite.Text = "Civilité";
            // 
            // labelPrenom
            // 
            this.labelPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenom.Location = new System.Drawing.Point(12, 79);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(48, 14);
            this.labelPrenom.TabIndex = 128;
            this.labelPrenom.Text = "Prénom";
            // 
            // labelNom
            // 
            this.labelNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(12, 53);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(32, 14);
            this.labelNom.TabIndex = 127;
            this.labelNom.Text = "Nom";
            // 
            // labelRechercherClient
            // 
            this.labelRechercherClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercherClient.AutoSize = true;
            this.labelRechercherClient.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercherClient.Location = new System.Drawing.Point(12, 16);
            this.labelRechercherClient.Name = "labelRechercherClient";
            this.labelRechercherClient.Size = new System.Drawing.Size(118, 14);
            this.labelRechercherClient.TabIndex = 126;
            this.labelRechercherClient.Text = "Rechercher un client";
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnuler.Location = new System.Drawing.Point(246, 286);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(110, 40);
            this.buttonAnnuler.TabIndex = 14;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = false;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click_1);
            // 
            // listeDeroulanteLocaliteCP
            // 
            this.listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            this.listeDeroulanteLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteLocaliteCP.Location = new System.Drawing.Point(175, 153);
            this.listeDeroulanteLocaliteCP.Name = "listeDeroulanteLocaliteCP";
            this.listeDeroulanteLocaliteCP.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteLocaliteCP.TabIndex = 6;
            // 
            // listeDeroulanteCivilite
            // 
            this.listeDeroulanteCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteCivilite.CiviliteSelectionne = null;
            this.listeDeroulanteCivilite.Location = new System.Drawing.Point(175, 101);
            this.listeDeroulanteCivilite.Name = "listeDeroulanteCivilite";
            this.listeDeroulanteCivilite.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteCivilite.TabIndex = 4;
            // 
            // listeDeroulanteClient
            // 
            this.listeDeroulanteClient.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteClient.ClientSelectionne = null;
            this.listeDeroulanteClient.Location = new System.Drawing.Point(175, 12);
            this.listeDeroulanteClient.Name = "listeDeroulanteClient";
            this.listeDeroulanteClient.Size = new System.Drawing.Size(181, 21);
            this.listeDeroulanteClient.TabIndex = 1;
            // 
            // Formulaire_Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.textBoxNumHabitation);
            this.Controls.Add(this.labelNumHabitation);
            this.Controls.Add(this.dateTimePickerDateNaissance);
            this.Controls.Add(this.labelDateNaissance);
            this.Controls.Add(this.listeDeroulanteLocaliteCP);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxNumTel);
            this.Controls.Add(this.textBoxAdresse);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelNumTel);
            this.Controls.Add(this.labelAdresse);
            this.Controls.Add(this.labelLocaliteCP);
            this.Controls.Add(this.listeDeroulanteCivilite);
            this.Controls.Add(this.textBoxPrenom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.listeDeroulanteClient);
            this.Controls.Add(this.labelCivilite);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelRechercherClient);
            this.Name = "Formulaire_Client";
            this.Size = new System.Drawing.Size(390, 364);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderClient;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.TextBox textBoxNumHabitation;
        private System.Windows.Forms.Label labelNumHabitation;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateNaissance;
        private System.Windows.Forms.Label labelDateNaissance;
        private ListeDeroulanteAdresse listeDeroulanteLocaliteCP;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.TextBox textBoxEmail;
        private System.Windows.Forms.TextBox textBoxNumTel;
        private System.Windows.Forms.TextBox textBoxAdresse;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelNumTel;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.Label labelLocaliteCP;
        private ListeDeroulanteCivilite listeDeroulanteCivilite;
        private System.Windows.Forms.TextBox textBoxPrenom;
        private System.Windows.Forms.TextBox textBoxNom;
        private ListeDeroulanteClient listeDeroulanteClient;
        private System.Windows.Forms.Label labelCivilite;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelRechercherClient;
        private System.Windows.Forms.Button buttonAnnuler;
    }
}
