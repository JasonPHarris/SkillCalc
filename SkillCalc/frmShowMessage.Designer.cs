namespace CustomMessageBox
{
    partial class frmShowMessage
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
            this.lblMessageText = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.close = new System.Windows.Forms.Label();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblMessageText
            // 
            this.lblMessageText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(78)))));
            this.lblMessageText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(244)))), ((int)(((byte)(252)))));
            this.lblMessageText.Location = new System.Drawing.Point(3, 40);
            this.lblMessageText.Name = "lblMessageText";
            this.lblMessageText.Size = new System.Drawing.Size(245, 13);
            this.lblMessageText.TabIndex = 1;
            this.lblMessageText.Text = "label1";
            this.lblMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.Enabled = false;
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.btnOK.Location = new System.Drawing.Point(87, 70);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 19);
            this.btnOK.TabIndex = 0;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // close
            // 
            this.close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(211)))), ((int)(((byte)(251)))));
            this.close.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.close.Location = new System.Drawing.Point(239, 9);
            this.close.Margin = new System.Windows.Forms.Padding(0, 0, 0, 5);
            this.close.Name = "close";
            this.close.Size = new System.Drawing.Size(9, 10);
            this.close.TabIndex = 169;
            this.close.Text = "X";
            this.close.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.close.Click += new System.EventHandler(this.close_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.BackgroundImage = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonRight.Enabled = false;
            this.buttonRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.buttonRight.Location = new System.Drawing.Point(154, 70);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(84, 19);
            this.buttonRight.TabIndex = 170;
            this.buttonRight.Visible = false;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.BackgroundImage = global::SkillCalc.Properties.Resources.tabs_unselect;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonLeft.Enabled = false;
            this.buttonLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.buttonLeft.Location = new System.Drawing.Point(12, 70);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(84, 19);
            this.buttonLeft.TabIndex = 171;
            this.buttonLeft.Visible = false;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // frmShowMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(65)))), ((int)(((byte)(78)))));
            this.BackgroundImage = global::SkillCalc.Properties.Resources.error_br;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(250, 100);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.close);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMessageText);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmShowMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmShowMessage";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnOK_Click);
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Label lblMessageText;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
    }
}