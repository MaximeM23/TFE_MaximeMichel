namespace app_tfe_michel_maxime
{
    partial class ListeDeroulanteStatutEmploye
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
            this.comboBoxStatutEmploye = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxStatutEmploye
            // 
            this.comboBoxStatutEmploye.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxStatutEmploye.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxStatutEmploye.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxStatutEmploye.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatutEmploye.FormattingEnabled = true;
            this.comboBoxStatutEmploye.Location = new System.Drawing.Point(0, 0);
            this.comboBoxStatutEmploye.Name = "comboBoxStatutEmploye";
            this.comboBoxStatutEmploye.Size = new System.Drawing.Size(150, 21);
            this.comboBoxStatutEmploye.TabIndex = 0;
            // 
            // ListeDeroulanteStatutEmploye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxStatutEmploye);
            this.Name = "ListeDeroulanteStatutEmploye";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxStatutEmploye;
    }
}
