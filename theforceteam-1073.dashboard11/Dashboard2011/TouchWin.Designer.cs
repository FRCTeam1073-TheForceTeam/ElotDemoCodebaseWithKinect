namespace Dashboard2011
{
    partial class TouchWin
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
            this.components = new System.ComponentModel.Container();
            this.NoAuto = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ImgBox = new System.Windows.Forms.PictureBox();
            this.PegsBox = new System.Windows.Forms.PictureBox();
            this.SetPincher = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PegsBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NoAuto
            // 
            this.NoAuto.Location = new System.Drawing.Point(12, 663);
            this.NoAuto.Name = "NoAuto";
            this.NoAuto.Size = new System.Drawing.Size(189, 55);
            this.NoAuto.TabIndex = 1;
            this.NoAuto.Text = "Don\'t Automate";
            this.NoAuto.UseVisualStyleBackColor = true;
            this.NoAuto.Click += new System.EventHandler(this.NoAuto_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.Tick);
            // 
            // ImgBox
            // 
            this.ImgBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImgBox.Location = new System.Drawing.Point(12, 12);
            this.ImgBox.Name = "ImgBox";
            this.ImgBox.Size = new System.Drawing.Size(455, 304);
            this.ImgBox.TabIndex = 3;
            this.ImgBox.TabStop = false;
            this.ImgBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.CamBox_click);
            // 
            // PegsBox
            // 
            this.PegsBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PegsBox.Location = new System.Drawing.Point(12, 356);
            this.PegsBox.Name = "PegsBox";
            this.PegsBox.Size = new System.Drawing.Size(455, 301);
            this.PegsBox.TabIndex = 4;
            this.PegsBox.TabStop = false;
            this.PegsBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PegsBox_click);
            // 
            // SetPincher
            // 
            this.SetPincher.Location = new System.Drawing.Point(207, 663);
            this.SetPincher.Name = "SetPincher";
            this.SetPincher.Size = new System.Drawing.Size(138, 55);
            this.SetPincher.TabIndex = 5;
            this.SetPincher.Text = "Pincher";
            this.SetPincher.UseVisualStyleBackColor = true;
            this.SetPincher.Click += new System.EventHandler(this.SetPincher_Click);
            // 
            // TouchWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 730);
            this.Controls.Add(this.SetPincher);
            this.Controls.Add(this.PegsBox);
            this.Controls.Add(this.ImgBox);
            this.Controls.Add(this.NoAuto);
            this.Name = "TouchWin";
            this.Text = "Touch Screen Window";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Loaded);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mdblclick);
            ((System.ComponentModel.ISupportInitialize)(this.ImgBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PegsBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NoAuto;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox ImgBox;
        private System.Windows.Forms.PictureBox PegsBox;
        private System.Windows.Forms.Button SetPincher;
    }
}