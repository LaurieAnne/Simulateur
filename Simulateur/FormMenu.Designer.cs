namespace Simulateur
{
    partial class FormMenu
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
            this.cmdRecuperer = new System.Windows.Forms.Button();
            this.txtRecuperer = new System.Windows.Forms.TextBox();
            this.imgMenu = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.imgMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdRecuperer
            // 
            this.cmdRecuperer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRecuperer.Location = new System.Drawing.Point(12, 249);
            this.cmdRecuperer.Name = "cmdRecuperer";
            this.cmdRecuperer.Size = new System.Drawing.Size(360, 25);
            this.cmdRecuperer.TabIndex = 0;
            this.cmdRecuperer.Text = "Récupérer le scénario";
            this.cmdRecuperer.UseVisualStyleBackColor = true;
            this.cmdRecuperer.Click += new System.EventHandler(this.cmdRecuperer_Click);
            // 
            // txtRecuperer
            // 
            this.txtRecuperer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRecuperer.Location = new System.Drawing.Point(12, 223);
            this.txtRecuperer.Name = "txtRecuperer";
            this.txtRecuperer.Size = new System.Drawing.Size(360, 20);
            this.txtRecuperer.TabIndex = 1;
            // 
            // imgMenu
            // 
            this.imgMenu.Image = global::Simulateur.Properties.Resources.map2;
            this.imgMenu.Location = new System.Drawing.Point(-8, 0);
            this.imgMenu.Name = "imgMenu";
            this.imgMenu.Size = new System.Drawing.Size(400, 217);
            this.imgMenu.TabIndex = 2;
            this.imgMenu.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(384, 286);
            this.Controls.Add(this.imgMenu);
            this.Controls.Add(this.txtRecuperer);
            this.Controls.Add(this.cmdRecuperer);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormMenu";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.imgMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdRecuperer;
        private System.Windows.Forms.TextBox txtRecuperer;
        private System.Windows.Forms.PictureBox imgMenu;
    }
}