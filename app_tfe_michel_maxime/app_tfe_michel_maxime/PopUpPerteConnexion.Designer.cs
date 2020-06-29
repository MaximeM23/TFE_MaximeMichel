namespace app_tfe_michel_maxime
{
    partial class PopUpPerteConnexion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopUpPerteConnexion));
            this.buttonFermer = new System.Windows.Forms.Button();
            this.buttonContinuer = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFermer
            // 
            this.buttonFermer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonFermer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFermer.FlatAppearance.BorderSize = 0;
            this.buttonFermer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFermer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonFermer.ForeColor = System.Drawing.Color.White;
            this.buttonFermer.Location = new System.Drawing.Point(293, 130);
            this.buttonFermer.Name = "buttonFermer";
            this.buttonFermer.Size = new System.Drawing.Size(152, 38);
            this.buttonFermer.TabIndex = 107;
            this.buttonFermer.Text = "Fermer";
            this.buttonFermer.UseVisualStyleBackColor = false;
            this.buttonFermer.Click += new System.EventHandler(this.buttonFermer_Click);
            // 
            // buttonContinuer
            // 
            this.buttonContinuer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(130)))), ((int)(((byte)(172)))));
            this.buttonContinuer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonContinuer.FlatAppearance.BorderSize = 0;
            this.buttonContinuer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonContinuer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonContinuer.ForeColor = System.Drawing.Color.White;
            this.buttonContinuer.Location = new System.Drawing.Point(102, 130);
            this.buttonContinuer.Name = "buttonContinuer";
            this.buttonContinuer.Size = new System.Drawing.Size(152, 38);
            this.buttonContinuer.TabIndex = 106;
            this.buttonContinuer.Text = "Continuer";
            this.buttonContinuer.UseVisualStyleBackColor = false;
            this.buttonContinuer.Click += new System.EventHandler(this.buttonContinuer_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(85, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(428, 68);
            this.label1.TabIndex = 105;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::app_tfe_michel_maxime.Properties.Resources.point_exclamation;
            this.pictureBox1.Location = new System.Drawing.Point(31, 49);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 104;
            this.pictureBox1.TabStop = false;
            // 
            // PopUpPerteConnexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 205);
            this.Controls.Add(this.buttonFermer);
            this.Controls.Add(this.buttonContinuer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PopUpPerteConnexion";
            this.Text = "PopUpPerteConnexion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFermer;
        private System.Windows.Forms.Button buttonContinuer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}