namespace app_tfe_michel_maxime
{
    partial class Page_Connexion
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
            this.errorProviderConnexion = new System.Windows.Forms.ErrorProvider(this.components);
            this.labelTitre = new System.Windows.Forms.Label();
            this.buttonSeConnecter = new System.Windows.Forms.Button();
            this.pictureBoxReduce = new System.Windows.Forms.PictureBox();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelMdp = new System.Windows.Forms.Label();
            this.textBoxAvecTextInvisibleMdp = new app_tfe_michel_maxime.TextBoxAvecTextInvisible();
            this.textBoxAvecTextInvisibleEmail = new app_tfe_michel_maxime.TextBoxAvecTextInvisible();
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConnexion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProviderConnexion
            // 
            this.errorProviderConnexion.ContainerControl = this;
            // 
            // labelTitre
            // 
            this.labelTitre.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelTitre.AutoSize = true;
            this.labelTitre.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitre.Location = new System.Drawing.Point(815, 68);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(201, 42);
            this.labelTitre.TabIndex = 1;
            this.labelTitre.Text = "Se connecter";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonSeConnecter
            // 
            this.buttonSeConnecter.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSeConnecter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonSeConnecter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSeConnecter.FlatAppearance.BorderSize = 0;
            this.buttonSeConnecter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSeConnecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSeConnecter.ForeColor = System.Drawing.Color.White;
            this.buttonSeConnecter.Location = new System.Drawing.Point(818, 262);
            this.buttonSeConnecter.Name = "buttonSeConnecter";
            this.buttonSeConnecter.Size = new System.Drawing.Size(194, 38);
            this.buttonSeConnecter.TabIndex = 6;
            this.buttonSeConnecter.Text = "Connexion";
            this.buttonSeConnecter.UseVisualStyleBackColor = false;
            this.buttonSeConnecter.Click += new System.EventHandler(this.buttonSeConnecter_Click);
            // 
            // pictureBoxReduce
            // 
            this.pictureBoxReduce.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxReduce.Image = global::app_tfe_michel_maxime.Properties.Resources.ReduceLogoNoir;
            this.pictureBoxReduce.Location = new System.Drawing.Point(1127, 3);
            this.pictureBoxReduce.Name = "pictureBoxReduce";
            this.pictureBoxReduce.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxReduce.TabIndex = 8;
            this.pictureBoxReduce.TabStop = false;
            this.pictureBoxReduce.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxClose.Image = global::app_tfe_michel_maxime.Properties.Resources.CroixFermetureNoire;
            this.pictureBoxClose.Location = new System.Drawing.Point(1165, 3);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxClose.TabIndex = 7;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click_1);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::app_tfe_michel_maxime.Properties.Resources.BMW_Connexion;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(600, 400);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            // 
            // labelEmail
            // 
            this.labelEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelEmail.AutoSize = true;
            this.labelEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(819, 136);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(38, 15);
            this.labelEmail.TabIndex = 221;
            this.labelEmail.Text = "Email";
            this.labelEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelEmail.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelEmail.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelMdp
            // 
            this.labelMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelMdp.AutoSize = true;
            this.labelMdp.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMdp.Location = new System.Drawing.Point(819, 198);
            this.labelMdp.Name = "labelMdp";
            this.labelMdp.Size = new System.Drawing.Size(80, 15);
            this.labelMdp.TabIndex = 222;
            this.labelMdp.Text = "Mot de passe";
            this.labelMdp.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelMdp.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelMdp.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // textBoxAvecTextInvisibleMdp
            // 
            this.textBoxAvecTextInvisibleMdp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAvecTextInvisibleMdp.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBoxAvecTextInvisibleMdp.Location = new System.Drawing.Point(818, 213);
            this.textBoxAvecTextInvisibleMdp.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAvecTextInvisibleMdp.MotDePasseCache = true;
            this.textBoxAvecTextInvisibleMdp.Name = "textBoxAvecTextInvisibleMdp";
            this.textBoxAvecTextInvisibleMdp.PlaceHolder = "Mot de passe";
            this.textBoxAvecTextInvisibleMdp.Size = new System.Drawing.Size(194, 18);
            this.textBoxAvecTextInvisibleMdp.TabIndex = 5;
            // 
            // textBoxAvecTextInvisibleEmail
            // 
            this.textBoxAvecTextInvisibleEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxAvecTextInvisibleEmail.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.textBoxAvecTextInvisibleEmail.Location = new System.Drawing.Point(818, 151);
            this.textBoxAvecTextInvisibleEmail.Margin = new System.Windows.Forms.Padding(0);
            this.textBoxAvecTextInvisibleEmail.MotDePasseCache = false;
            this.textBoxAvecTextInvisibleEmail.Name = "textBoxAvecTextInvisibleEmail";
            this.textBoxAvecTextInvisibleEmail.PlaceHolder = "Email@exemple.com";
            this.textBoxAvecTextInvisibleEmail.Size = new System.Drawing.Size(194, 18);
            this.textBoxAvecTextInvisibleEmail.TabIndex = 4;
            // 
            // Page_Connexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.labelMdp);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.pictureBoxReduce);
            this.Controls.Add(this.pictureBoxClose);
            this.Controls.Add(this.buttonSeConnecter);
            this.Controls.Add(this.textBoxAvecTextInvisibleMdp);
            this.Controls.Add(this.textBoxAvecTextInvisibleEmail);
            this.Controls.Add(this.labelTitre);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Page_Connexion";
            this.Size = new System.Drawing.Size(1200, 400);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.errorProviderConnexion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReduce)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProviderConnexion;
        private System.Windows.Forms.Button buttonSeConnecter;
        private TextBoxAvecTextInvisible textBoxAvecTextInvisibleMdp;
        private TextBoxAvecTextInvisible textBoxAvecTextInvisibleEmail;
        private System.Windows.Forms.Label labelTitre;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxReduce;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label labelMdp;
        private System.Windows.Forms.Label labelEmail;
    }
}
