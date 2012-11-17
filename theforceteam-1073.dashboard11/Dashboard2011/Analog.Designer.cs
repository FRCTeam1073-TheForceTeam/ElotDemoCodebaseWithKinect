namespace Dashboard2011
{
    partial class Analog
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.analogProgB = new System.Windows.Forms.ProgressBar();
            this.analogLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // analogProgB
            // 
            this.analogProgB.Location = new System.Drawing.Point(3, 0);
            this.analogProgB.Name = "analogProgB";
            this.analogProgB.Size = new System.Drawing.Size(149, 26);
            this.analogProgB.TabIndex = 0;
            // 
            // analogLabel
            // 
            this.analogLabel.AutoSize = true;
            this.analogLabel.Location = new System.Drawing.Point(158, 0);
            this.analogLabel.Name = "analogLabel";
            this.analogLabel.Size = new System.Drawing.Size(35, 13);
            this.analogLabel.TabIndex = 1;
            this.analogLabel.Text = "label1";
            // 
            // Analog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.analogLabel);
            this.Controls.Add(this.analogProgB);
            this.Name = "Analog";
            this.Size = new System.Drawing.Size(289, 32);
            this.Load += new System.EventHandler(this.load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        public System.Windows.Forms.ProgressBar analogProgB;
        private System.Windows.Forms.Label analogLabel;
    }
}
