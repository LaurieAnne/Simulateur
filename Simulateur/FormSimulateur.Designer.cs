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
            this.SuspendLayout();
            // 
            // lstAeroports
            // 
            this.lstAeroports.FormattingEnabled = true;
            this.lstAeroports.Location = new System.Drawing.Point(43, 75);
            this.lstAeroports.Name = "lstAeroports";
            this.lstAeroports.Size = new System.Drawing.Size(300, 238);
            this.lstAeroports.TabIndex = 0;
            this.lstAeroports.SelectedValueChanged += new System.EventHandler(this.lstAeroports_SelectedValueChanged);
            // 
            // lstVehicules
            // 
            this.lstVehicules.FormattingEnabled = true;
            this.lstVehicules.Location = new System.Drawing.Point(367, 75);
            this.lstVehicules.Name = "lstVehicules";
            this.lstVehicules.Size = new System.Drawing.Size(338, 238);
            this.lstVehicules.TabIndex = 1;
            // 
            // FormSimulateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstVehicules);
            this.Controls.Add(this.lstAeroports);
            this.Name = "FormSimulateur";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAeroports;
        private System.Windows.Forms.ListBox lstVehicules;
    }
}

