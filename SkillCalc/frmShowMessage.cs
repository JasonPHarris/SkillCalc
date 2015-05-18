using System;
using System.Drawing;
using System.Windows.Forms;

namespace CustomMessageBox
{
    public partial class frmShowMessage : Form
    {
        public frmShowMessage() { InitializeComponent(); }
        private void close_Click(object sender, EventArgs e) { this.Close(); }
        private void addButton(enumMessageButton MessageButton)
        {
            switch (MessageButton)
            {
                case enumMessageButton.OK:
                    {
                        this.btnOK.Text = "OK";
                        this.btnOK.Visible = true;
                        this.buttonLeft.Visible = false;
                        this.buttonRight.Visible = false;
                        this.btnOK.Enabled = true;
                        this.buttonLeft.Enabled = false;
                        this.buttonLeft.Enabled = false;
                    }
                    break;
                case enumMessageButton.YesNo:
                    {
                        this.buttonLeft.Text = "Yes";
                        this.buttonRight.Text = "No";
                        this.btnOK.Visible = false;
                        this.buttonLeft.Visible = true;
                        this.buttonRight.Visible = true;
                        this.btnOK.Enabled = false;
                        this.buttonLeft.Enabled = true;
                        this.buttonRight.Enabled = true;
                    }
                    break;
                case enumMessageButton.OKCancel:
                    {
                        this.buttonLeft.Text = "Ok";
                        this.buttonRight.Text = "Cancel";
                        this.btnOK.Visible = false;
                        this.buttonLeft.Visible = true;
                        this.buttonRight.Visible = true;
                        this.btnOK.Enabled = false;
                        this.buttonLeft.Enabled = true;
                        this.buttonRight.Enabled = true;
                    }
                    break;
            }
        }
        internal static DialogResult Show(string messageText)
        {
            frmShowMessage frmMessage = new frmShowMessage();
            frmMessage.lblMessageText.Text = messageText;
            frmMessage.addButton(enumMessageButton.OK);
            frmMessage.ShowDialog();
            return frmMessage.DialogResult;
        }
        internal static DialogResult Show(string messageText, string messageTitle)
        {
            frmShowMessage frmMessage = new frmShowMessage();
            frmMessage.Text = messageTitle;
            frmMessage.lblMessageText.Text = messageText;
            frmMessage.addButton(enumMessageButton.OK);
            frmMessage.ShowDialog();
            return frmMessage.DialogResult;
        }
        internal static DialogResult Show(string messageText, string messageTitle, enumMessageButton messageButton)
        {
            frmShowMessage frmMessage = new frmShowMessage();
            frmMessage.lblMessageText.Text = messageText;
            frmMessage.Text = messageTitle;
            frmMessage.addButton(messageButton);
            frmMessage.ShowDialog();
            return frmMessage.DialogResult;
        }
        private void btnOK_Click(object sender, EventArgs e) { this.Close(); }
        public void buttonLeft_Click(object sender, EventArgs e) { this.Close(); }
        private void buttonRight_Click(object sender, EventArgs e) { this.Close(); }
    }
    internal enum enumMessageButton { OK, YesNo, OKCancel }
}