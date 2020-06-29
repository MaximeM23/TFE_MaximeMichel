namespace app_tfe_michel_maxime
{
    partial class Entretiens
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
            this.textBoxEntretien = new System.Windows.Forms.TextBox();
            this.labelNomEntretien = new System.Windows.Forms.Label();
            this.labelPrix = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.buttonValider = new System.Windows.Forms.Button();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.ValidationProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxEntretien
            // 
            this.textBoxEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBoxEntretien.Location = new System.Drawing.Point(118, 4);
            this.textBoxEntretien.Name = "textBoxEntretien";
            this.textBoxEntretien.Size = new System.Drawing.Size(155, 20);
            this.textBoxEntretien.TabIndex = 23;
            // 
            // labelNomEntretien
            // 
            this.labelNomEntretien.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelNomEntretien.AutoSize = true;
            this.labelNomEntretien.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNomEntretien.Location = new System.Drawing.Point(6, 6);
            this.labelNomEntretien.Name = "labelNomEntretien";
            this.labelNomEntretien.Size = new System.Drawing.Size(106, 15);
            this.labelNomEntretien.TabIndex = 22;
            this.labelNomEntretien.Text = "Nom de l\'entretien";
            // 
            // labelPrix
            // 
            this.labelPrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelPrix.AutoSize = true;
            this.labelPrix.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPrix.Location = new System.Drawing.Point(8, 29);
            this.labelPrix.Name = "labelPrix";
            this.labelPrix.Size = new System.Drawing.Size(103, 15);
            this.labelPrix.TabIndex = 24;
            this.labelPrix.Text = "Prix de l\'entretien";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.numericUpDown1.Location = new System.Drawing.Point(117, 28);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(156, 20);
            this.numericUpDown1.TabIndex = 25;
            // 
            // buttonValider
            // 
            this.buttonValider.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonValider.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonValider.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonValider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.buttonValider.Location = new System.Drawing.Point(80, 54);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(143, 33);
            this.buttonValider.TabIndex = 42;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = false;
            this.buttonValider.Click += new System.EventHandler(this.buttonValider_Click);
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // ValidationProvider
            // 
            this.ValidationProvider.ContainerControl = this;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = global::app_tfe_michel_maxime.Properties.Resources._1rowup;
            this.pictureBox1.Location = new System.Drawing.Point(299, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Entretiens
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonValider);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.labelPrix);
            this.Controls.Add(this.textBoxEntretien);
            this.Controls.Add(this.labelNomEntretien);
            this.Name = "Entretiens";
            this.Size = new System.Drawing.Size(322, 98);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ValidationProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxEntretien;
        private System.Windows.Forms.Label labelNomEntretien;
        private System.Windows.Forms.Label labelPrix;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.ErrorProvider ValidationProvider;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
