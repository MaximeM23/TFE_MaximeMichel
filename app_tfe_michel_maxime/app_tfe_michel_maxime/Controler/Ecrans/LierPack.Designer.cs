namespace app_tfe_michel_maxime
{
    partial class LierPack
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
            this.labelPackExistant = new System.Windows.Forms.Label();
            this.labelFichePack = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBoxRetirerP = new System.Windows.Forms.PictureBox();
            this.pictureBoxAjouterP = new System.Windows.Forms.PictureBox();
            this.fichePackOptionsAChoisir = new app_tfe_michel_maxime.FichePackOptions();
            this.fichePackOptionsLier = new app_tfe_michel_maxime.FichePackOptions();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterP)).BeginInit();
            this.SuspendLayout();
            // 
            // labelPackExistant
            // 
            this.labelPackExistant.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPackExistant.AutoSize = true;
            this.labelPackExistant.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPackExistant.Location = new System.Drawing.Point(640, 21);
            this.labelPackExistant.Name = "labelPackExistant";
            this.labelPackExistant.Size = new System.Drawing.Size(250, 15);
            this.labelPackExistant.TabIndex = 241;
            this.labelPackExistant.Text = "Liste des packs disponibles pour ce véhicule";
            // 
            // labelFichePack
            // 
            this.labelFichePack.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelFichePack.AutoSize = true;
            this.labelFichePack.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFichePack.Location = new System.Drawing.Point(160, 21);
            this.labelFichePack.Name = "labelFichePack";
            this.labelFichePack.Size = new System.Drawing.Size(186, 15);
            this.labelFichePack.TabIndex = 237;
            this.labelFichePack.Text = "Liste des packs liés à ce véhicule";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // pictureBoxRetirerP
            // 
            this.pictureBoxRetirerP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxRetirerP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxRetirerP.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheDroite;
            this.pictureBoxRetirerP.Location = new System.Drawing.Point(477, 175);
            this.pictureBoxRetirerP.Name = "pictureBoxRetirerP";
            this.pictureBoxRetirerP.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxRetirerP.TabIndex = 239;
            this.pictureBoxRetirerP.TabStop = false;
            this.pictureBoxRetirerP.Click += new System.EventHandler(this.pictureBoxRetirerP_Click);
            // 
            // pictureBoxAjouterP
            // 
            this.pictureBoxAjouterP.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBoxAjouterP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAjouterP.Image = global::app_tfe_michel_maxime.Properties.Resources.FlecheGauche;
            this.pictureBoxAjouterP.Location = new System.Drawing.Point(477, 88);
            this.pictureBoxAjouterP.Name = "pictureBoxAjouterP";
            this.pictureBoxAjouterP.Size = new System.Drawing.Size(48, 48);
            this.pictureBoxAjouterP.TabIndex = 238;
            this.pictureBoxAjouterP.TabStop = false;
            this.pictureBoxAjouterP.Click += new System.EventHandler(this.pictureBoxAjouterP_Click);
            // 
            // fichePackOptionsAChoisir
            // 
            this.fichePackOptionsAChoisir.Location = new System.Drawing.Point(573, 38);
            this.fichePackOptionsAChoisir.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptionsAChoisir.Name = "fichePackOptionsAChoisir";
            this.fichePackOptionsAChoisir.PackOptionsSelectionnee = null;
            this.fichePackOptionsAChoisir.Size = new System.Drawing.Size(350, 240);
            this.fichePackOptionsAChoisir.TabIndex = 240;
            this.fichePackOptionsAChoisir.TexteFiltrePackOptions = "";
            // 
            // fichePackOptionsLier
            // 
            this.fichePackOptionsLier.Location = new System.Drawing.Point(77, 38);
            this.fichePackOptionsLier.Margin = new System.Windows.Forms.Padding(2);
            this.fichePackOptionsLier.Name = "fichePackOptionsLier";
            this.fichePackOptionsLier.PackOptionsSelectionnee = null;
            this.fichePackOptionsLier.Size = new System.Drawing.Size(350, 240);
            this.fichePackOptionsLier.TabIndex = 242;
            this.fichePackOptionsLier.TexteFiltrePackOptions = "";
            // 
            // LierPack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fichePackOptionsLier);
            this.Controls.Add(this.labelPackExistant);
            this.Controls.Add(this.fichePackOptionsAChoisir);
            this.Controls.Add(this.pictureBoxRetirerP);
            this.Controls.Add(this.pictureBoxAjouterP);
            this.Controls.Add(this.labelFichePack);
            this.Name = "LierPack";
            this.Size = new System.Drawing.Size(1000, 300);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRetirerP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAjouterP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelPackExistant;
        private System.Windows.Forms.PictureBox pictureBoxRetirerP;
        private System.Windows.Forms.PictureBox pictureBoxAjouterP;
        private System.Windows.Forms.Label labelFichePack;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private FichePackOptions fichePackOptionsLier;
        private FichePackOptions fichePackOptionsAChoisir;
    }
}
