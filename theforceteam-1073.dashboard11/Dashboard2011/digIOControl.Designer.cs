namespace Dashboard2011
{
    partial class DigIO
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
            this.PortNB = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.direction = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PortNB
            // 
            this.PortNB.AutoSize = true;
            this.PortNB.Location = new System.Drawing.Point(3, 0);
            this.PortNB.Name = "PortNB";
            this.PortNB.Size = new System.Drawing.Size(35, 13);
            this.PortNB.TabIndex = 0;
            this.PortNB.Text = "label1";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Location = new System.Drawing.Point(60, 0);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(35, 13);
            this.status.TabIndex = 1;
            this.status.Text = "label1";
            // 
            // direction
            // 
            this.direction.AutoSize = true;
            this.direction.Location = new System.Drawing.Point(103, -1);
            this.direction.Name = "direction";
            this.direction.Size = new System.Drawing.Size(35, 13);
            this.direction.TabIndex = 2;
            this.direction.Text = "label1";
            // 
            // digIOControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.direction);
            this.Controls.Add(this.status);
            this.Controls.Add(this.PortNB);
            this.Name = "digIOControl";
            this.Size = new System.Drawing.Size(148, 25);
            this.Load += new System.EventHandler(this.digIOControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label PortNB;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Label direction;
    }
}
