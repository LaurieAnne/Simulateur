namespace Simulateur
{
    partial class FormSimulateur
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstAeroports = new System.Windows.Forms.ListBox();
            this.lstVehicules = new System.Windows.Forms.ListBox();
            this.lstCl = new System.Windows.Forms.ListBox();
            this.imgCarte = new System.Windows.Forms.PictureBox();
            this.updTemps = new System.Windows.Forms.NumericUpDown();
            this.etqTemps = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imgCarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updTemps)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAeroports
            // 
            this.lstAeroports.FormattingEnabled = true;
            this.lstAeroports.ItemHeight = 16;
            this.lstAeroports.Location = new System.Drawing.Point(12, 3);
            this.lstAeroports.Name = "lstAeroports";
            this.lstAeroports.Size = new System.Drawing.Size(296, 116);
            this.lstAeroports.TabIndex = 0;
            this.lstAeroports.SelectedValueChanged += new System.EventHandler(this.lstAeroports_SelectedValueChanged);
            // 
            // lstVehicules
            // 
            this.lstVehicules.Enabled = false;
            this.lstVehicules.FormattingEnabled = true;
            this.lstVehicules.ItemHeight = 16;
            this.lstVehicules.Location = new System.Drawing.Point(314, 3);
            this.lstVehicules.Name = "lstVehicules";
            this.lstVehicules.Size = new System.Drawing.Size(296, 116);
            this.lstVehicules.TabIndex = 1;
            // 
            // lstCl
            // 
            this.lstCl.Enabled = false;
            this.lstCl.FormattingEnabled = true;
            this.lstCl.ItemHeight = 16;
            this.lstCl.Location = new System.Drawing.Point(616, 3);
            this.lstCl.Name = "lstCl";
            this.lstCl.Size = new System.Drawing.Size(296, 116);
            this.lstCl.TabIndex = 2;
            // 
            // imgCarte
            // 
            this.imgCarte.Image = global::Simulateur.Properties.Resources.map;
            this.imgCarte.Location = new System.Drawing.Point(12, 125);
            this.imgCarte.Name = "imgCarte";
            this.imgCarte.Size = new System.Drawing.Size(900, 528);
            this.imgCarte.TabIndex = 3;
            this.imgCarte.TabStop = false;
            this.imgCarte.Paint += new System.Windows.Forms.PaintEventHandler(this.imgCarte_Paint);
            // 
            // updTemps
            // 
            this.updTemps.Location = new System.Drawing.Point(150, 664);
            this.updTemps.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.updTemps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updTemps.Name = "updTemps";
            this.updTemps.Size = new System.Drawing.Size(158, 23);
            this.updTemps.TabIndex = 6;
            this.updTemps.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.updTemps.ValueChanged += new System.EventHandler(this.updTemps_ValueChanged);
            // 
            // etqTemps
            // 
            this.etqTemps.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.etqTemps.Location = new System.Drawing.Point(12, 656);
            this.etqTemps.Name = "etqTemps";
            this.etqTemps.Size = new System.Drawing.Size(125, 33);
            this.etqTemps.TabIndex = 7;
            this.etqTemps.Text = "Temps";
            this.etqTemps.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormSimulateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(924, 712);
            this.Controls.Add(this.etqTemps);
            this.Controls.Add(this.updTemps);
            this.Controls.Add(this.imgCarte);
            this.Controls.Add(this.lstCl);
            this.Controls.Add(this.lstVehicules);
            this.Controls.Add(this.lstAeroports);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSimulateur";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Simulateur";
            ((System.ComponentModel.ISupportInitialize)(this.imgCarte)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updTemps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAeroports;
        private System.Windows.Forms.ListBox lstVehicules;
        private System.Windows.Forms.ListBox lstCl;
        private System.Windows.Forms.PictureBox imgCarte;
        private System.Windows.Forms.NumericUpDown updTemps;
        private System.Windows.Forms.Label etqTemps;
    }
}

