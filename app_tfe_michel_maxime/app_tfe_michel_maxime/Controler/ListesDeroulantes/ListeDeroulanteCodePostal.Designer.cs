namespace app_tfe_michel_maxime
{
    partial class ListeDeroulanteCodePostal
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
            this.comboBoxCodePostal = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxCodePostal
            // 
            this.comboBoxCodePostal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxCodePostal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxCodePostal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxCodePostal.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCodePostal.FormattingEnabled = true;
            this.comboBoxCodePostal.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCodePostal.Name = "comboBoxCodePostal";
            this.comboBoxCodePostal.Size = new System.Drawing.Size(150, 21);
            this.comboBoxCodePostal.TabIndex = 0;
            // 
            // ListeDeroulanteCodePostal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxCodePostal);
            this.Name = "ListeDeroulanteCodePostal";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCodePostal;
    }
}
