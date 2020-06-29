namespace app_tfe_michel_maxime
{
    partial class Formulaire_Employe
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
            this.TextBoxPrenom = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelMotDePasse = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelNumTel = new System.Windows.Forms.Label();
            this.labelNumHabitation = new System.Windows.Forms.Label();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.labelLocaliteCP = new System.Windows.Forms.Label();
            this.labelCivilite = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.TextBoxNomRue = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxNumHabitation = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxEmail = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxMdp = new System.Windows.Forms.MaskedTextBox();
            this.buttonAjouter = new System.Windows.Forms.Button();
            this.buttonModifier = new System.Windows.Forms.Button();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelDateNaissance = new System.Windows.Forms.Label();
            this.dateTimePickerDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.TextBoxConfMdp = new System.Windows.Forms.MaskedTextBox();
            this.labelConfirmationMdp = new System.Windows.Forms.Label();
            this.TextBoxNumTel = new System.Windows.Forms.MaskedTextBox();
            this.listeDeroulanteCivilite = new app_tfe_michel_maxime.ListeDeroulanteCivilite();
            this.listeDeroulanteLocaliteCP = new app_tfe_michel_maxime.ListeDeroulanteAdresse();
            this.listeDeroulanteStatutEmploye1 = new app_tfe_michel_maxime.ListeDeroulanteStatutEmploye();
            this.labelStatut = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // TextBoxPrenom
            // 
            this.TextBoxPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxPrenom.Location = new System.Drawing.Point(209, 128);
            this.TextBoxPrenom.Name = "TextBoxPrenom";
            this.TextBoxPrenom.Size = new System.Drawing.Size(143, 20);
            this.TextBoxPrenom.TabIndex = 2;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNom.Location = new System.Drawing.Point(209, 88);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(143, 20);
            this.textBoxNom.TabIndex = 1;
            // 
            // labelMotDePasse
            // 
            this.labelMotDePasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMotDePasse.AutoSize = true;
            this.labelMotDePasse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotDePasse.Location = new System.Drawing.Point(424, 209);
            this.labelMotDePasse.Name = "labelMotDePasse";
            this.labelMotDePasse.Size = new System.Drawing.Size(80, 15);
            this.labelMotDePasse.TabIndex = 223;
            this.labelMotDePasse.Text = "Mot de passe";
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(103, 250);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 15);
            this.labelEmail.TabIndex = 222;
            this.labelEmail.Text = "Email";
            // 
            // labelNumTel
            // 
            this.labelNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumTel.AutoSize = true;
            this.labelNumTel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumTel.Location = new System.Drawing.Point(67, 210);
            this.labelNumTel.Name = "labelNumTel";
            this.labelNumTel.Size = new System.Drawing.Size(123, 15);
            this.labelNumTel.TabIndex = 221;
            this.labelNumTel.Text = "Numéro de téléphone";
            // 
            // labelNumHabitation
            // 
            this.labelNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumHabitation.AutoSize = true;
            this.labelNumHabitation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumHabitation.Location = new System.Drawing.Point(410, 169);
            this.labelNumHabitation.Name = "labelNumHabitation";
            this.labelNumHabitation.Size = new System.Drawing.Size(120, 15);
            this.labelNumHabitation.TabIndex = 220;
            this.labelNumHabitation.Text = "Numéro d\'habitation";
            // 
            // labelAdresse
            // 
            this.labelAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdresse.Location = new System.Drawing.Point(430, 129);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(69, 15);
            this.labelAdresse.TabIndex = 219;
            this.labelAdresse.Text = "Nom de rue";
            // 
            // labelLocaliteCP
            // 
            this.labelLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLocaliteCP.AutoSize = true;
            this.labelLocaliteCP.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocaliteCP.Location = new System.Drawing.Point(405, 90);
            this.labelLocaliteCP.Name = "labelLocaliteCP";
            this.labelLocaliteCP.Size = new System.Drawing.Size(126, 15);
            this.labelLocaliteCP.TabIndex = 217;
            this.labelLocaliteCP.Text = "Code postal / Localité";
            // 
            // labelCivilite
            // 
            this.labelCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCivilite.AutoSize = true;
            this.labelCivilite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCivilite.Location = new System.Drawing.Point(102, 170);
            this.labelCivilite.Name = "labelCivilite";
            this.labelCivilite.Size = new System.Drawing.Size(46, 15);
            this.labelCivilite.TabIndex = 216;
            this.labelCivilite.Text = "Civilité";
            // 
            // labelPrenom
            // 
            this.labelPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenom.Location = new System.Drawing.Point(98, 130);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(49, 15);
            this.labelPrenom.TabIndex = 215;
            this.labelPrenom.Text = "Prénom";
            // 
            // labelNom
            // 
            this.labelNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(105, 90);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(32, 15);
            this.labelNom.TabIndex = 214;
            this.labelNom.Text = "Nom";
            // 
            // TextBoxNomRue
            // 
            this.TextBoxNomRue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNomRue.Location = new System.Drawing.Point(557, 127);
            this.TextBoxNomRue.Name = "TextBoxNomRue";
            this.TextBoxNomRue.Size = new System.Drawing.Size(143, 20);
            this.TextBoxNomRue.TabIndex = 9;
            // 
            // TextBoxNumHabitation
            // 
            this.TextBoxNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNumHabitation.Location = new System.Drawing.Point(557, 167);
            this.TextBoxNumHabitation.Name = "TextBoxNumHabitation";
            this.TextBoxNumHabitation.Size = new System.Drawing.Size(143, 20);
            this.TextBoxNumHabitation.TabIndex = 10;
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxEmail.Location = new System.Drawing.Point(209, 248);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(143, 20);
            this.TextBoxEmail.TabIndex = 5;
            // 
            // TextBoxMdp
            // 
            this.TextBoxMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxMdp.Location = new System.Drawing.Point(557, 207);
            this.TextBoxMdp.Name = "TextBoxMdp";
            this.TextBoxMdp.PasswordChar = '*';
            this.TextBoxMdp.Size = new System.Drawing.Size(143, 20);
            this.TextBoxMdp.TabIndex = 11;
            // 
            // buttonAjouter
            // 
            this.buttonAjouter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAjouter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAjouter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAjouter.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAjouter.Location = new System.Drawing.Point(126, 293);
            this.buttonAjouter.Name = "buttonAjouter";
            this.buttonAjouter.Size = new System.Drawing.Size(160, 40);
            this.buttonAjouter.TabIndex = 13;
            this.buttonAjouter.Text = "Ajouter";
            this.buttonAjouter.UseVisualStyleBackColor = false;
            this.buttonAjouter.Click += new System.EventHandler(this.buttonAjouter_Click);
            // 
            // buttonModifier
            // 
            this.buttonModifier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonModifier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonModifier.Enabled = false;
            this.buttonModifier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonModifier.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModifier.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonModifier.Location = new System.Drawing.Point(316, 293);
            this.buttonModifier.Name = "buttonModifier";
            this.buttonModifier.Size = new System.Drawing.Size(160, 40);
            this.buttonModifier.TabIndex = 14;
            this.buttonModifier.Text = "Modifier";
            this.buttonModifier.UseVisualStyleBackColor = false;
            this.buttonModifier.Click += new System.EventHandler(this.buttonModifier_Click);
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAnnuler.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAnnuler.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonAnnuler.Location = new System.Drawing.Point(506, 293);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(160, 40);
            this.buttonAnnuler.TabIndex = 15;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = false;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // labelDateNaissance
            // 
            this.labelDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNaissance.AutoSize = true;
            this.labelDateNaissance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateNaissance.Location = new System.Drawing.Point(418, 47);
            this.labelDateNaissance.Name = "labelDateNaissance";
            this.labelDateNaissance.Size = new System.Drawing.Size(107, 15);
            this.labelDateNaissance.TabIndex = 238;
            this.labelDateNaissance.Text = "Date de naissance";
            // 
            // dateTimePickerDateNaissance
            // 
            this.dateTimePickerDateNaissance.Location = new System.Drawing.Point(557, 44);
            this.dateTimePickerDateNaissance.Name = "dateTimePickerDateNaissance";
            this.dateTimePickerDateNaissance.Size = new System.Drawing.Size(143, 20);
            this.dateTimePickerDateNaissance.TabIndex = 6;
            // 
            // TextBoxConfMdp
            // 
            this.TextBoxConfMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxConfMdp.Location = new System.Drawing.Point(557, 248);
            this.TextBoxConfMdp.Name = "TextBoxConfMdp";
            this.TextBoxConfMdp.PasswordChar = '*';
            this.TextBoxConfMdp.Size = new System.Drawing.Size(143, 20);
            this.TextBoxConfMdp.TabIndex = 12;
            // 
            // labelConfirmationMdp
            // 
            this.labelConfirmationMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelConfirmationMdp.AutoSize = true;
            this.labelConfirmationMdp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmationMdp.Location = new System.Drawing.Point(387, 250);
            this.labelConfirmationMdp.Name = "labelConfirmationMdp";
            this.labelConfirmationMdp.Size = new System.Drawing.Size(153, 15);
            this.labelConfirmationMdp.TabIndex = 240;
            this.labelConfirmationMdp.Text = "Confirmation mot de passe";
            // 
            // TextBoxNumTel
            // 
            this.TextBoxNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNumTel.Location = new System.Drawing.Point(209, 208);
            this.TextBoxNumTel.Name = "TextBoxNumTel";
            this.TextBoxNumTel.Size = new System.Drawing.Size(143, 20);
            this.TextBoxNumTel.TabIndex = 4;
            // 
            // listeDeroulanteCivilite
            // 
            this.listeDeroulanteCivilite.CiviliteSelectionne = null;
            this.listeDeroulanteCivilite.Location = new System.Drawing.Point(209, 168);
            this.listeDeroulanteCivilite.Name = "listeDeroulanteCivilite";
            this.listeDeroulanteCivilite.Size = new System.Drawing.Size(143, 21);
            this.listeDeroulanteCivilite.TabIndex = 3;
            // 
            // listeDeroulanteLocaliteCP
            // 
            this.listeDeroulanteLocaliteCP.AdresseSelectionne = null;
            this.listeDeroulanteLocaliteCP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteLocaliteCP.Location = new System.Drawing.Point(557, 86);
            this.listeDeroulanteLocaliteCP.Name = "listeDeroulanteLocaliteCP";
            this.listeDeroulanteLocaliteCP.Size = new System.Drawing.Size(143, 21);
            this.listeDeroulanteLocaliteCP.TabIndex = 7;
            // 
            // listeDeroulanteStatutEmploye1
            // 
            this.listeDeroulanteStatutEmploye1.Location = new System.Drawing.Point(209, 44);
            this.listeDeroulanteStatutEmploye1.Name = "listeDeroulanteStatutEmploye1";
            this.listeDeroulanteStatutEmploye1.Size = new System.Drawing.Size(143, 21);
            this.listeDeroulanteStatutEmploye1.StatutEmployeSelectionne = null;
            this.listeDeroulanteStatutEmploye1.TabIndex = 244;
            // 
            // labelStatut
            // 
            this.labelStatut.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelStatut.AutoSize = true;
            this.labelStatut.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelStatut.Location = new System.Drawing.Point(71, 46);
            this.labelStatut.Name = "labelStatut";
            this.labelStatut.Size = new System.Drawing.Size(111, 15);
            this.labelStatut.TabIndex = 243;
            this.labelStatut.Text = "Statut de l\'employé";
            // 
            // Formulaire_Employe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listeDeroulanteStatutEmploye1);
            this.Controls.Add(this.labelStatut);
            this.Controls.Add(this.TextBoxConfMdp);
            this.Controls.Add(this.labelConfirmationMdp);
            this.Controls.Add(this.dateTimePickerDateNaissance);
            this.Controls.Add(this.labelDateNaissance);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.buttonModifier);
            this.Controls.Add(this.buttonAjouter);
            this.Controls.Add(this.listeDeroulanteCivilite);
            this.Controls.Add(this.listeDeroulanteLocaliteCP);
            this.Controls.Add(this.TextBoxMdp);
            this.Controls.Add(this.TextBoxEmail);
            this.Controls.Add(this.TextBoxNumTel);
            this.Controls.Add(this.TextBoxNumHabitation);
            this.Controls.Add(this.TextBoxNomRue);
            this.Controls.Add(this.TextBoxPrenom);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.labelMotDePasse);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelNumTel);
            this.Controls.Add(this.labelNumHabitation);
            this.Controls.Add(this.labelAdresse);
            this.Controls.Add(this.labelLocaliteCP);
            this.Controls.Add(this.labelCivilite);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.labelNom);
            this.Name = "Formulaire_Employe";
            this.Size = new System.Drawing.Size(774, 342);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox TextBoxPrenom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelMotDePasse;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelNumTel;
        private System.Windows.Forms.Label labelNumHabitation;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.Label labelLocaliteCP;
        private System.Windows.Forms.Label labelCivilite;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.MaskedTextBox TextBoxNomRue;
        private System.Windows.Forms.MaskedTextBox TextBoxNumHabitation;
        private System.Windows.Forms.MaskedTextBox TextBoxEmail;
        private System.Windows.Forms.MaskedTextBox TextBoxMdp;
        private ListeDeroulanteAdresse listeDeroulanteLocaliteCP;
        private ListeDeroulanteCivilite listeDeroulanteCivilite;
        private System.Windows.Forms.Button buttonAjouter;
        private System.Windows.Forms.Button buttonModifier;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.Label labelDateNaissance;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateNaissance;
        private System.Windows.Forms.MaskedTextBox TextBoxConfMdp;
        private System.Windows.Forms.Label labelConfirmationMdp;
        private System.Windows.Forms.MaskedTextBox TextBoxNumTel;
        private ListeDeroulanteStatutEmploye listeDeroulanteStatutEmploye1;
        private System.Windows.Forms.Label labelStatut;
    }
}
