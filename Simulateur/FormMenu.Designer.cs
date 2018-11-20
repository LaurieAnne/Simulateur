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
            this.SuspendLayout();
            // 
            // cmdRecuperer
            // 
            this.cmdRecuperer.Location = new System.Drawing.Point(277, 185);
            this.cmdRecuperer.Name = "cmdRecuperer";
            this.cmdRecuperer.Size = new System.Drawing.Size(154, 23);
            this.cmdRecuperer.TabIndex = 0;
            this.cmdRecuperer.Text = "Récupérer le scénario";
            this.cmdRecuperer.UseVisualStyleBackColor = true;
            this.cmdRecuperer.Click += new System.EventHandler(this.cmdRecuperer_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 450);
            this.Controls.Add(this.cmdRecuperer);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdRecuperer;
    }
}