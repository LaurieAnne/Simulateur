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
            this.components = new System.ComponentModel.Container();
            this.lstAeroports = new System.Windows.Forms.ListBox();
            this.lstVehicules = new System.Windows.Forms.ListBox();
            this.lstCl = new System.Windows.Forms.ListBox();
            this.imgCarte = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.UpDown_temps = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imgCarte)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_temps)).BeginInit();
            this.SuspendLayout();
            // 
            // lstAeroports
            // 
            this.lstAeroports.FormattingEnabled = true;
            this.lstAeroports.ItemHeight = 14;
            this.lstAeroports.Location = new System.Drawing.Point(12, 3);
            this.lstAeroports.Name = "lstAeroports";
            this.lstAeroports.Size = new System.Drawing.Size(296, 116);
            this.lstAeroports.TabIndex = 0;
            this.lstAeroports.SelectedValueChanged += new System.EventHandler(this.lstAeroports_SelectedValueChanged);
            // 
            // lstVehicules
            // 
            this.lstVehicules.FormattingEnabled = true;
            this.lstVehicules.ItemHeight = 14;
            this.lstVehicules.Location = new System.Drawing.Point(314, 3);
            this.lstVehicules.Name = "lstVehicules";
            this.lstVehicules.Size = new System.Drawing.Size(296, 116);
            this.lstVehicules.TabIndex = 1;
            // 
            // lstCl
            // 
            this.lstCl.FormattingEnabled = true;
            this.lstCl.ItemHeight = 14;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(498, 659);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(315, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Creer au X secondes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(498, 688);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(315, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Go";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // UpDown_temps
            // 
            this.UpDown_temps.Location = new System.Drawing.Point(372, 688);
            this.UpDown_temps.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.UpDown_temps.Name = "UpDown_temps";
            this.UpDown_temps.Size = new System.Drawing.Size(120, 20);
            this.UpDown_temps.TabIndex = 6;
            this.UpDown_temps.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(165, 659);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // FormSimulateur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SkyBlue;
            this.ClientSize = new System.Drawing.Size(924, 712);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.UpDown_temps);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
            ((System.ComponentModel.ISupportInitialize)(this.UpDown_temps)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstAeroports;
        private System.Windows.Forms.ListBox lstVehicules;
        private System.Windows.Forms.ListBox lstCl;
        private System.Windows.Forms.PictureBox imgCarte;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.NumericUpDown UpDown_temps;
        private System.Windows.Forms.Button button3;
    }
}

