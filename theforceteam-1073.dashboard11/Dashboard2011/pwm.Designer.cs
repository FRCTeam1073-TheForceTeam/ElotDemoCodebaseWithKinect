namespace Dashboard2011
{
    partial class Pwm
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
            this.PWNname = new System.Windows.Forms.Label();
            this.pwmProgress = new System.Windows.Forms.ProgressBar();
            this.PWNReadout = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PWNname
            // 
            this.PWNname.AutoSize = true;
            this.PWNname.Location = new System.Drawing.Point(3, 4);
            this.PWNname.Name = "PWNname";
            this.PWNname.Size = new System.Drawing.Size(35, 13);
            this.PWNname.TabIndex = 0;
            this.PWNname.Text = "label1";
            // 
            // pwmProgress
            // 
            this.pwmProgress.Location = new System.Drawing.Point(44, 0);
            this.pwmProgress.Name = "pwmProgress";
            this.pwmProgress.Size = new System.Drawing.Size(230, 20);
            this.pwmProgress.TabIndex = 1;
            // 
            // PWNReadout
            // 
            this.PWNReadout.AutoSize = true;
            this.PWNReadout.Location = new System.Drawing.Point(281, 4);
            this.PWNReadout.Name = "PWNReadout";
            this.PWNReadout.Size = new System.Drawing.Size(35, 13);
            this.PWNReadout.TabIndex = 2;
            this.PWNReadout.Text = "label1";
            // 
            // pwn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PWNReadout);
            this.Controls.Add(this.pwmProgress);
            this.Controls.Add(this.PWNname);
            this.Name = "pwn";
            this.Size = new System.Drawing.Size(322, 24);
            this.Load += new System.EventHandler(this.pwn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PWNname;
        private System.Windows.Forms.ProgressBar pwmProgress;
        private System.Windows.Forms.Label PWNReadout;
    }
}
