namespace app_tfe_michel_maxime
{
    partial class Page_Employe
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose1 = new app_tfe_michel_maxime.ButtonClose();
            this.labelTitre = new System.Windows.Forms.Label();
            this.labelRechercheEmploye = new System.Windows.Forms.Label();
            this.formulaire_Employe = new app_tfe_michel_maxime.Formulaire_Employe();
            this.listeDeroulanteEmploye1 = new app_tfe_michel_maxime.ListeDeroulanteEmploye();
            this.ficheEmploye1 = new app_tfe_michel_maxime.FicheEmploye();
            this.menu1 = new app_tfe_michel_maxime.Menu();
            this.buttonActiver = new System.Windows.Forms.Button();
            this.buttonDesactiver = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.panel1.Controls.Add(this.buttonClose1);
            this.panel1.Controls.Add(this.labelTitre);
            this.panel1.Location = new System.Drawing.Point(200, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 42);
            this.panel1.TabIndex = 10;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.panel1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // buttonClose1
            // 
            this.buttonClose1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClose1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonClose1.Location = new System.Drawing.Point(789, 1);
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
            this.labelTitre.Location = new System.Drawing.Point(351, 0);
            this.labelTitre.Name = "labelTitre";
            this.labelTitre.Size = new System.Drawing.Size(192, 39);
            this.labelTitre.TabIndex = 0;
            this.labelTitre.Text = "Les employés";
            this.labelTitre.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Page_MouseDown);
            this.labelTitre.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Page_MouseMove);
            this.labelTitre.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Page_MouseUp);
            // 
            // labelRechercheEmploye
            // 
            this.labelRechercheEmploye.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelRechercheEmploye.AutoSize = true;
            this.labelRechercheEmploye.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelRechercheEmploye.Location = new System.Drawing.Point(506, 51);
            this.labelRechercheEmploye.Name = "labelRechercheEmploye";
            this.labelRechercheEmploye.Size = new System.Drawing.Size(134, 15);
            this.labelRechercheEmploye.TabIndex = 200;
            this.labelRechercheEmploye.Text = "Rechercher un employé";
            // 
            // formulaire_Employe
            // 
            this.formulaire_Employe.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.formulaire_Employe.EmployeSelectionne = null;
            this.formulaire_Employe.Location = new System.Drawing.Point(270, 452);
            this.formulaire_Employe.Name = "formulaire_Employe";
            this.formulaire_Employe.Size = new System.Drawing.Size(774, 342);
            this.formulaire_Employe.TabIndex = 4;
            this.formulaire_Employe.Load += new System.EventHandler(this.formulaire_Employe_Load);
            // 
            // listeDeroulanteEmploye1
            // 
            this.listeDeroulanteEmploye1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.listeDeroulanteEmploye1.EmployeSelectionne = null;
            this.listeDeroulanteEmploye1.Location = new System.Drawing.Point(646, 48);
            this.listeDeroulanteEmploye1.Name = "listeDeroulanteEmploye1";
            this.listeDeroulanteEmploye1.Size = new System.Drawing.Size(146, 21);
            this.listeDeroulanteEmploye1.TabIndex = 1;
            // 
            // ficheEmploye1
            // 
            this.ficheEmploye1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ficheEmploye1.EmployeSelectionnee = null;
            this.ficheEmploye1.Location = new System.Drawing.Point(200, 73);
            this.ficheEmploye1.Margin = new System.Windows.Forms.Padding(2);
            this.ficheEmploye1.Name = "ficheEmploye1";
            this.ficheEmploye1.Size = new System.Drawing.Size(900, 332);
            this.ficheEmploye1.TabIndex = 11;
            this.ficheEmploye1.TexteFiltreEmploye = "";
            this.ficheEmploye1.Load += new System.EventHandler(this.ficheEmploye1_Load);
            this.ficheEmploye1.SizeChanged += new System.EventHandler(this.ficheEmploye1_SizeChanged);
            // 
            // menu1
            // 
            this.menu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.menu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menu1.Location = new System.Drawing.Point(0, 0);
            this.menu1.Name = "menu1";
            this.menu1.Size = new System.Drawing.Size(200, 797);
            this.menu1.TabIndex = 9;
            // 
            // buttonActiver
            // 
            this.buttonActiver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonActiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonActiver.Enabled = false;
            this.buttonActiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonActiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonActiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonActiver.Location = new System.Drawing.Point(365, 406);
            this.buttonActiver.Name = "buttonActiver";
            this.buttonActiver.Size = new System.Drawing.Size(258, 40);
            this.buttonActiver.TabIndex = 2;
            this.buttonActiver.Text = "Activer le compte";
            this.buttonActiver.UseVisualStyleBackColor = false;
            this.buttonActiver.Click += new System.EventHandler(this.buttonActiver_Click);
            // 
            // buttonDesactiver
            // 
            this.buttonDesactiver.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonDesactiver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonDesactiver.Enabled = false;
            this.buttonDesactiver.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDesactiver.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDesactiver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonDesactiver.Location = new System.Drawing.Point(712, 406);
            this.buttonDesactiver.Name = "buttonDesactiver";
            this.buttonDesactiver.Size = new System.Drawing.Size(258, 40);
            this.buttonDesactiver.TabIndex = 3;
            this.buttonDesactiver.Text = "Désactiver le compte";
            this.buttonDesactiver.UseVisualStyleBackColor = false;
            this.buttonDesactiver.Click += new System.EventHandler(this.buttonDesactiver_Click);
            // 
            // Page_Employe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonDesactiver);
            this.Controls.Add(this.buttonActiver);
            this.Controls.Add(this.formulaire_Employe);
            this.Controls.Add(this.listeDeroulanteEmploye1);
            this.Controls.Add(this.labelRechercheEmploye);
            this.Controls.Add(this.ficheEmploye1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menu1);
            this.Name = "Page_Employe";
            this.Size = new System.Drawing.Size(1100, 797);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private ButtonClose buttonClose1;
        private System.Windows.Forms.Label labelTitre;
        private Menu menu1;
        private FicheEmploye ficheEmploye1;
        private System.Windows.Forms.Label labelRechercheEmploye;
        private ListeDeroulanteEmploye listeDeroulanteEmploye1;
        private Formulaire_Employe formulaire_Employe;
        private System.Windows.Forms.Button buttonActiver;
        private System.Windows.Forms.Button buttonDesactiver;
    }
}
