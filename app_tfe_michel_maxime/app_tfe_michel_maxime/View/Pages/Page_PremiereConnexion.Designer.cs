namespace app_tfe_michel_maxime
{
    partial class Page_PremiereConnexion
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
            this.buttonConfirmer = new System.Windows.Forms.Button();
            this.TextBoxConfMdp = new System.Windows.Forms.MaskedTextBox();
            this.labelConfirmationMdp = new System.Windows.Forms.Label();
            this.dateTimePickerDateNaissance = new System.Windows.Forms.DateTimePicker();
            this.labelDateNaissance = new System.Windows.Forms.Label();
            this.TextBoxMdp = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxEmail = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxNumTel = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxNumHabitation = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxNomRue = new System.Windows.Forms.MaskedTextBox();
            this.TextBoxPrenom = new System.Windows.Forms.MaskedTextBox();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.labelMotDePasse = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelNumTel = new System.Windows.Forms.Label();
            this.labelNumHabitation = new System.Windows.Forms.Label();
            this.labelAdresse = new System.Windows.Forms.Label();
            this.labelCodePostal = new System.Windows.Forms.Label();
            this.labelCivilite = new System.Windows.Forms.Label();
            this.labelPrenom = new System.Windows.Forms.Label();
            this.labelNom = new System.Windows.Forms.Label();
            this.labelInfo = new System.Windows.Forms.Label();
            this.labelBienvenue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.buttonQuitter = new System.Windows.Forms.Button();
            this.listeDeroulanteCivilite = new app_tfe_michel_maxime.ListeDeroulanteCivilite();
            this.listeDeroulanteCodePostalLoc = new app_tfe_michel_maxime.ListeDeroulanteCodePostal();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonConfirmer
            // 
            this.buttonConfirmer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonConfirmer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirmer.FlatAppearance.BorderSize = 0;
            this.buttonConfirmer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirmer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonConfirmer.ForeColor = System.Drawing.Color.White;
            this.buttonConfirmer.Location = new System.Drawing.Point(211, 424);
            this.buttonConfirmer.Name = "buttonConfirmer";
            this.buttonConfirmer.Size = new System.Drawing.Size(194, 38);
            this.buttonConfirmer.TabIndex = 293;
            this.buttonConfirmer.Text = "Confirmer";
            this.buttonConfirmer.UseVisualStyleBackColor = false;
            this.buttonConfirmer.Click += new System.EventHandler(this.buttonConfirmer_Click);
            // 
            // TextBoxConfMdp
            // 
            this.TextBoxConfMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxConfMdp.Location = new System.Drawing.Point(583, 384);
            this.TextBoxConfMdp.Name = "TextBoxConfMdp";
            this.TextBoxConfMdp.PasswordChar = '*';
            this.TextBoxConfMdp.Size = new System.Drawing.Size(180, 20);
            this.TextBoxConfMdp.TabIndex = 12;
            // 
            // labelConfirmationMdp
            // 
            this.labelConfirmationMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelConfirmationMdp.AutoSize = true;
            this.labelConfirmationMdp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfirmationMdp.Location = new System.Drawing.Point(413, 386);
            this.labelConfirmationMdp.Name = "labelConfirmationMdp";
            this.labelConfirmationMdp.Size = new System.Drawing.Size(153, 15);
            this.labelConfirmationMdp.TabIndex = 292;
            this.labelConfirmationMdp.Text = "Confirmation mot de passe";
            this.labelConfirmationMdp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelConfirmationMdp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelConfirmationMdp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // dateTimePickerDateNaissance
            // 
            this.dateTimePickerDateNaissance.Location = new System.Drawing.Point(215, 381);
            this.dateTimePickerDateNaissance.Name = "dateTimePickerDateNaissance";
            this.dateTimePickerDateNaissance.Size = new System.Drawing.Size(180, 20);
            this.dateTimePickerDateNaissance.TabIndex = 6;
            // 
            // labelDateNaissance
            // 
            this.labelDateNaissance.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelDateNaissance.AutoSize = true;
            this.labelDateNaissance.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDateNaissance.Location = new System.Drawing.Point(80, 384);
            this.labelDateNaissance.Name = "labelDateNaissance";
            this.labelDateNaissance.Size = new System.Drawing.Size(107, 15);
            this.labelDateNaissance.TabIndex = 291;
            this.labelDateNaissance.Text = "Date de naissance";
            this.labelDateNaissance.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelDateNaissance.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelDateNaissance.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // TextBoxMdp
            // 
            this.TextBoxMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxMdp.Location = new System.Drawing.Point(583, 343);
            this.TextBoxMdp.Name = "TextBoxMdp";
            this.TextBoxMdp.PasswordChar = '*';
            this.TextBoxMdp.Size = new System.Drawing.Size(180, 20);
            this.TextBoxMdp.TabIndex = 11;
            // 
            // TextBoxEmail
            // 
            this.TextBoxEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxEmail.Location = new System.Drawing.Point(361, 181);
            this.TextBoxEmail.Name = "TextBoxEmail";
            this.TextBoxEmail.Size = new System.Drawing.Size(180, 20);
            this.TextBoxEmail.TabIndex = 1;
            // 
            // TextBoxNumTel
            // 
            this.TextBoxNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNumTel.Location = new System.Drawing.Point(215, 343);
            this.TextBoxNumTel.Name = "TextBoxNumTel";
            this.TextBoxNumTel.Size = new System.Drawing.Size(180, 20);
            this.TextBoxNumTel.TabIndex = 5;
            // 
            // TextBoxNumHabitation
            // 
            this.TextBoxNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNumHabitation.Location = new System.Drawing.Point(583, 303);
            this.TextBoxNumHabitation.Name = "TextBoxNumHabitation";
            this.TextBoxNumHabitation.Size = new System.Drawing.Size(180, 20);
            this.TextBoxNumHabitation.TabIndex = 10;
            // 
            // TextBoxNomRue
            // 
            this.TextBoxNomRue.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxNomRue.Location = new System.Drawing.Point(583, 263);
            this.TextBoxNomRue.Name = "TextBoxNomRue";
            this.TextBoxNomRue.Size = new System.Drawing.Size(180, 20);
            this.TextBoxNomRue.TabIndex = 9;
            // 
            // TextBoxPrenom
            // 
            this.TextBoxPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextBoxPrenom.Location = new System.Drawing.Point(215, 263);
            this.TextBoxPrenom.Name = "TextBoxPrenom";
            this.TextBoxPrenom.Size = new System.Drawing.Size(180, 20);
            this.TextBoxPrenom.TabIndex = 3;
            // 
            // textBoxNom
            // 
            this.textBoxNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxNom.Location = new System.Drawing.Point(215, 223);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(180, 20);
            this.textBoxNom.TabIndex = 2;
            // 
            // labelMotDePasse
            // 
            this.labelMotDePasse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMotDePasse.AutoSize = true;
            this.labelMotDePasse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMotDePasse.Location = new System.Drawing.Point(450, 345);
            this.labelMotDePasse.Name = "labelMotDePasse";
            this.labelMotDePasse.Size = new System.Drawing.Size(80, 15);
            this.labelMotDePasse.TabIndex = 290;
            this.labelMotDePasse.Text = "Mot de passe";
            this.labelMotDePasse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelMotDePasse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelMotDePasse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(313, 186);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 15);
            this.labelEmail.TabIndex = 289;
            this.labelEmail.Text = "Email";
            this.labelEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelEmail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelEmail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelNumTel
            // 
            this.labelNumTel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumTel.AutoSize = true;
            this.labelNumTel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumTel.Location = new System.Drawing.Point(73, 345);
            this.labelNumTel.Name = "labelNumTel";
            this.labelNumTel.Size = new System.Drawing.Size(123, 15);
            this.labelNumTel.TabIndex = 288;
            this.labelNumTel.Text = "Numéro de téléphone";
            this.labelNumTel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelNumTel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelNumTel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelNumHabitation
            // 
            this.labelNumHabitation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNumHabitation.AutoSize = true;
            this.labelNumHabitation.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNumHabitation.Location = new System.Drawing.Point(436, 305);
            this.labelNumHabitation.Name = "labelNumHabitation";
            this.labelNumHabitation.Size = new System.Drawing.Size(120, 15);
            this.labelNumHabitation.TabIndex = 287;
            this.labelNumHabitation.Text = "Numéro d\'habitation";
            this.labelNumHabitation.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelNumHabitation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelNumHabitation.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelAdresse
            // 
            this.labelAdresse.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelAdresse.AutoSize = true;
            this.labelAdresse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAdresse.Location = new System.Drawing.Point(456, 265);
            this.labelAdresse.Name = "labelAdresse";
            this.labelAdresse.Size = new System.Drawing.Size(69, 15);
            this.labelAdresse.TabIndex = 286;
            this.labelAdresse.Text = "Nom de rue";
            this.labelAdresse.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelAdresse.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelAdresse.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelCodePostal
            // 
            this.labelCodePostal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCodePostal.AutoSize = true;
            this.labelCodePostal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCodePostal.Location = new System.Drawing.Point(433, 225);
            this.labelCodePostal.Name = "labelCodePostal";
            this.labelCodePostal.Size = new System.Drawing.Size(126, 15);
            this.labelCodePostal.TabIndex = 285;
            this.labelCodePostal.Text = "Code postal / Localité";
            this.labelCodePostal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelCodePostal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelCodePostal.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelCivilite
            // 
            this.labelCivilite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelCivilite.AutoSize = true;
            this.labelCivilite.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCivilite.Location = new System.Drawing.Point(108, 305);
            this.labelCivilite.Name = "labelCivilite";
            this.labelCivilite.Size = new System.Drawing.Size(46, 15);
            this.labelCivilite.TabIndex = 283;
            this.labelCivilite.Text = "Civilité";
            this.labelCivilite.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelCivilite.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelCivilite.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelPrenom
            // 
            this.labelPrenom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrenom.AutoSize = true;
            this.labelPrenom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrenom.Location = new System.Drawing.Point(104, 265);
            this.labelPrenom.Name = "labelPrenom";
            this.labelPrenom.Size = new System.Drawing.Size(49, 15);
            this.labelPrenom.TabIndex = 282;
            this.labelPrenom.Text = "Prénom";
            this.labelPrenom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelPrenom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelPrenom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelNom
            // 
            this.labelNom.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNom.AutoSize = true;
            this.labelNom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNom.Location = new System.Drawing.Point(111, 225);
            this.labelNom.Name = "labelNom";
            this.labelNom.Size = new System.Drawing.Size(32, 15);
            this.labelNom.TabIndex = 281;
            this.labelNom.Text = "Nom";
            this.labelNom.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelNom.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelNom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelInfo
            // 
            this.labelInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelInfo.AutoSize = true;
            this.labelInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInfo.Location = new System.Drawing.Point(209, 148);
            this.labelInfo.Name = "labelInfo";
            this.labelInfo.Size = new System.Drawing.Size(397, 15);
            this.labelInfo.TabIndex = 268;
            this.labelInfo.Text = "Pour votre première connexion, veuillez créer le compte administrateur";
            this.labelInfo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelInfo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelInfo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelBienvenue
            // 
            this.labelBienvenue.AutoSize = true;
            this.labelBienvenue.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBienvenue.Location = new System.Drawing.Point(331, 106);
            this.labelBienvenue.Name = "labelBienvenue";
            this.labelBienvenue.Size = new System.Drawing.Size(165, 42);
            this.labelBienvenue.TabIndex = 267;
            this.labelBienvenue.Text = "Bienvenue";
            this.labelBienvenue.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelBienvenue.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelBienvenue.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::app_tfe_michel_maxime.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(361, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.TabIndex = 266;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // buttonQuitter
            // 
            this.buttonQuitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonQuitter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonQuitter.FlatAppearance.BorderSize = 0;
            this.buttonQuitter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonQuitter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonQuitter.ForeColor = System.Drawing.Color.White;
            this.buttonQuitter.Location = new System.Drawing.Point(411, 424);
            this.buttonQuitter.Name = "buttonQuitter";
            this.buttonQuitter.Size = new System.Drawing.Size(194, 38);
            this.buttonQuitter.TabIndex = 294;
            this.buttonQuitter.Text = "Quitter";
            this.buttonQuitter.UseVisualStyleBackColor = false;
            this.buttonQuitter.Click += new System.EventHandler(this.buttonQuitter_Click);
            // 
            // listeDeroulanteCivilite
            // 
            this.listeDeroulanteCivilite.CiviliteSelectionne = null;
            this.listeDeroulanteCivilite.Location = new System.Drawing.Point(215, 303);
            this.listeDeroulanteCivilite.Name = "listeDeroulanteCivilite";
            this.listeDeroulanteCivilite.Size = new System.Drawing.Size(180, 21);
            this.listeDeroulanteCivilite.TabIndex = 4;
            // 
            // listeDeroulanteCodePostalLoc
            // 
            this.listeDeroulanteCodePostalLoc.CodePostalSelectionne = null;
            this.listeDeroulanteCodePostalLoc.Location = new System.Drawing.Point(583, 223);
            this.listeDeroulanteCodePostalLoc.Name = "listeDeroulanteCodePostalLoc";
            this.listeDeroulanteCodePostalLoc.Size = new System.Drawing.Size(180, 21);
            this.listeDeroulanteCodePostalLoc.TabIndex = 8;
            // 
            // Page_PremiereConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonQuitter);
            this.Controls.Add(this.buttonConfirmer);
            this.Controls.Add(this.TextBoxConfMdp);
            this.Controls.Add(this.labelConfirmationMdp);
            this.Controls.Add(this.dateTimePickerDateNaissance);
            this.Controls.Add(this.labelDateNaissance);
            this.Controls.Add(this.listeDeroulanteCivilite);
            this.Controls.Add(this.listeDeroulanteCodePostalLoc);
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
            this.Controls.Add(this.labelCodePostal);
            this.Controls.Add(this.labelCivilite);
            this.Controls.Add(this.labelPrenom);
            this.Controls.Add(this.labelNom);
            this.Controls.Add(this.labelInfo);
            this.Controls.Add(this.labelBienvenue);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Page_PremiereConnexion";
            this.Size = new System.Drawing.Size(810, 476);
            this.Load += new System.EventHandler(this.Page_PremiereConnexion_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonConfirmer;
        private System.Windows.Forms.MaskedTextBox TextBoxConfMdp;
        private System.Windows.Forms.Label labelConfirmationMdp;
        private System.Windows.Forms.DateTimePicker dateTimePickerDateNaissance;
        private System.Windows.Forms.Label labelDateNaissance;
        private ListeDeroulanteCivilite listeDeroulanteCivilite;
        private ListeDeroulanteCodePostal listeDeroulanteCodePostalLoc;
        private System.Windows.Forms.MaskedTextBox TextBoxMdp;
        private System.Windows.Forms.MaskedTextBox TextBoxEmail;
        private System.Windows.Forms.MaskedTextBox TextBoxNumTel;
        private System.Windows.Forms.MaskedTextBox TextBoxNumHabitation;
        private System.Windows.Forms.MaskedTextBox TextBoxNomRue;
        private System.Windows.Forms.MaskedTextBox TextBoxPrenom;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.Label labelMotDePasse;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelNumTel;
        private System.Windows.Forms.Label labelNumHabitation;
        private System.Windows.Forms.Label labelAdresse;
        private System.Windows.Forms.Label labelCodePostal;
        private System.Windows.Forms.Label labelCivilite;
        private System.Windows.Forms.Label labelPrenom;
        private System.Windows.Forms.Label labelNom;
        private System.Windows.Forms.Label labelInfo;
        private System.Windows.Forms.Label labelBienvenue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Button buttonQuitter;
    }
}
