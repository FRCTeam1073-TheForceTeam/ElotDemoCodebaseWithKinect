namespace KinectDemo
{
    partial class MainDemoForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.clawLabel = new System.Windows.Forms.Label();
            this.isForwardLabel = new System.Windows.Forms.Label();
            this.tankDirectionLabel = new System.Windows.Forms.Label();
            this.useLeftHand = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.resetLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(903, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tracking Hand Left";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(406, 584);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(514, 29);
            this.label2.TabIndex = 2;
            this.label2.Text = "X: 0  Y: 0  Frame #: 0  Skeleton #: 0  FPS: 0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(585, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 29);
            this.label3.TabIndex = 3;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VersionLabel.Location = new System.Drawing.Point(9, 9);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(139, 16);
            this.VersionLabel.TabIndex = 4;
            this.VersionLabel.Text = "Release Version 0.3.1";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 38);
            this.progressBar1.Maximum = 6;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(293, 23);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 6;
            // 
            // clawLabel
            // 
            this.clawLabel.AutoSize = true;
            this.clawLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clawLabel.ForeColor = System.Drawing.Color.Red;
            this.clawLabel.Location = new System.Drawing.Point(12, 100);
            this.clawLabel.Name = "clawLabel";
            this.clawLabel.Size = new System.Drawing.Size(134, 29);
            this.clawLabel.TabIndex = 7;
            this.clawLabel.Text = "Clawstate:";
            // 
            // isForwardLabel
            // 
            this.isForwardLabel.AutoSize = true;
            this.isForwardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.isForwardLabel.ForeColor = System.Drawing.Color.Red;
            this.isForwardLabel.Location = new System.Drawing.Point(12, 129);
            this.isForwardLabel.Name = "isForwardLabel";
            this.isForwardLabel.Size = new System.Drawing.Size(137, 29);
            this.isForwardLabel.TabIndex = 8;
            this.isForwardLabel.Text = "Forward? :";
            // 
            // tankDirectionLabel
            // 
            this.tankDirectionLabel.AutoSize = true;
            this.tankDirectionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tankDirectionLabel.ForeColor = System.Drawing.Color.Red;
            this.tankDirectionLabel.Location = new System.Drawing.Point(15, 158);
            this.tankDirectionLabel.Name = "tankDirectionLabel";
            this.tankDirectionLabel.Size = new System.Drawing.Size(78, 29);
            this.tankDirectionLabel.TabIndex = 9;
            this.tankDirectionLabel.Text = "Tank:";
            // 
            // useLeftHand
            // 
            this.useLeftHand.AutoSize = true;
            this.useLeftHand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.useLeftHand.Location = new System.Drawing.Point(11, 80);
            this.useLeftHand.Name = "useLeftHand";
            this.useLeftHand.Size = new System.Drawing.Size(262, 17);
            this.useLeftHand.TabIndex = 11;
            this.useLeftHand.Text = "Left Hand = Checked ||| Right Hand = Unchecked";
            this.useLeftHand.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Hand on head\r\n";
            // 
            // resetLabel
            // 
            this.resetLabel.AutoSize = true;
            this.resetLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetLabel.ForeColor = System.Drawing.Color.Red;
            this.resetLabel.Location = new System.Drawing.Point(15, 187);
            this.resetLabel.Name = "resetLabel";
            this.resetLabel.Size = new System.Drawing.Size(155, 29);
            this.resetLabel.TabIndex = 13;
            this.resetLabel.Text = "Reset State:";
            // 
            // MainDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 309);
            this.Controls.Add(this.resetLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.useLeftHand);
            this.Controls.Add(this.tankDirectionLabel);
            this.Controls.Add(this.isForwardLabel);
            this.Controls.Add(this.clawLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "MainDemoForm";
            this.Text = "Kinect Demo";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label clawLabel;
        private System.Windows.Forms.Label isForwardLabel;
        private System.Windows.Forms.Label tankDirectionLabel;
        private System.Windows.Forms.CheckBox useLeftHand;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label resetLabel;
    }
}

