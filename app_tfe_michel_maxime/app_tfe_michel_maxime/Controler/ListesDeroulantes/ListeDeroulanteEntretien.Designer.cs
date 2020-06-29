namespace app_tfe_michel_maxime
{
    partial class ListeDeroulanteEntretien
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
            this.comboBoxEntretien = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // comboBoxEntretien
            // 
            this.comboBoxEntretien.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.comboBoxEntretien.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxEntretien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxEntretien.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxEntretien.FormattingEnabled = true;
            this.comboBoxEntretien.Location = new System.Drawing.Point(0, 0);
            this.comboBoxEntretien.Name = "comboBoxEntretien";
            this.comboBoxEntretien.Size = new System.Drawing.Size(150, 21);
            this.comboBoxEntretien.TabIndex = 0;
            // 
            // ListeDeroulanteEntretien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.comboBoxEntretien);
            this.Name = "ListeDeroulanteEntretien";
            this.Size = new System.Drawing.Size(150, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxEntretien;
    }
}
