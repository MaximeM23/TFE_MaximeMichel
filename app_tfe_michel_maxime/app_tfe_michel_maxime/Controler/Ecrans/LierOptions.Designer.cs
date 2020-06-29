namespace app_tfe_michel_maxime
{
    partial class LierOptions
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
            this.labelListeDesOptionsExistantes = new System.Windows.Forms.Label();
            this.pictureBoxRetirerO = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterO = new System.Windows.Forms.PictureBox();
            this.labelFicheOptions = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ficheOptionsDisponibles = new app_tfe_michel_maxime.FicheOptions();
            this.ficheOptionsLiees = new app_tfe_michel_maxime.FicheOptions();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // labelListeDesOptionsExistantes
            // 
            this.labelListeDesOptionsExistantes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelListeDesOptionsExistantes.AutoSize = true;
            this.labelListeDesOptionsExistantes.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelListeDesOptionsExistantes.Location = new System.Drawing.Point(668, 21);
            this.labelListeDesOptionsExistantes.Name = "labelListeDesOptionsExistantes";
            this.labelListeDesOptionsExistantes.Size = new System.Drawing.Size(157, 15);
            this.labelListeDesOptionsExistantes.TabIndex = 241;
            this.labelListeDesOptionsExistantes.Text = "Liste des options existantes";
            // 
            // pictureBoxRetirerO
            // 
            this.pictureBoxRetirerO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerO.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheDroite;
            this.pictureBoxRetirerO.Location = new System.Drawing.Point(477, 175);
            this.pictureBoxRetirerO.Name = "pictureBoxRetirerO";
            this.pictureBoxRetirerO.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxRetirerO.TabIndex = 239;
            this.pictureBoxRetirerO.TabStop = false;
            this.pictureBoxRetirerO.Click += new System.EventHandler(this.pictureBoxRetirerO_Click);
            // 
            // pictureBoxAjouterO
            // 
            this.pictureBoxAjouterO.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterO.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheGauche;
            this.pictureBoxAjouterO.Location = new System.Drawing.Point(477, 88);
            this.pictureBoxAjouterO.Name = "pictureBoxAjouterO";
            this.pictureBoxAjouterO.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxAjouterO.TabIndex = 238;
            this.pictureBoxAjouterO.TabStop = false;
            this.pictureBoxAjouterO.Click += new System.EventHandler(this.pictureBoxAjouterO_Click);
            // 
            // labelFicheOptions
            // 
            this.labelFicheOptions.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFicheOptions.AutoSize = true;
            this.labelFicheOptions.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFicheOptions.Location = new System.Drawing.Point(154, 21);
            this.labelFicheOptions.Name = "labelFicheOptions";
            this.labelFicheOptions.Size = new System.Drawing.Size(201, 15);
            this.labelFicheOptions.TabIndex = 237;
            this.labelFicheOptions.Text = "Liste des options liées à ce véhicule";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // ficheOptionsDisponibles
            // 
            this.ficheOptionsDisponibles.FicheAvecFiltre = true;
            this.ficheOptionsDisponibles.Location = new System.Drawing.Point(564, 38);
            this.ficheOptionsDisponibles.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsDisponibles.Name = "ficheOptionsDisponibles";
            this.ficheOptionsDisponibles.OptionsSelectionnee = null;
            this.ficheOptionsDisponibles.Size = new System.Drawing.Size(350, 240);
            this.ficheOptionsDisponibles.TabIndex = 242;
            this.ficheOptionsDisponibles.TexteFiltreOptions = "";
            // 
            // ficheOptionsLiees
            // 
            this.ficheOptionsLiees.FicheAvecFiltre = true;
            this.ficheOptionsLiees.Location = new System.Drawing.Point(86, 38);
            this.ficheOptionsLiees.Margin = new System.Windows.Forms.Padding(2);
            this.ficheOptionsLiees.Name = "ficheOptionsLiees";
            this.ficheOptionsLiees.OptionsSelectionnee = null;
            this.ficheOptionsLiees.Size = new System.Drawing.Size(350, 240);
            this.ficheOptionsLiees.TabIndex = 243;
            this.ficheOptionsLiees.TexteFiltreOptions = "";
            // 
            // LierOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ficheOptionsLiees);
            this.Controls.Add(this.ficheOptionsDisponibles);
            this.Controls.Add(this.labelListeDesOptionsExistantes);
            this.Controls.Add(this.pictureBoxRetirerO);
            this.Controls.Add(this.pictureBoxAjouterO);
            this.Controls.Add(this.labelFicheOptions);
            this.Name = "LierOptions";
            this.Size = new System.Drawing.Size(1000, 300);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelListeDesOptionsExistantes;
        private System.Windows.Forms.PictureBox pictureBoxRetirerO;
        private System.Windows.Forms.PictureBox pictureBoxAjouterO;
        private System.Windows.Forms.Label labelFicheOptions;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private FicheOptions ficheOptionsLiees;
        private FicheOptions ficheOptionsDisponibles;
    }
}
