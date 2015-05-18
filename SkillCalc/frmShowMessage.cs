/*
SkillCalc Copyright (c) 2015 sstheno@gmail.com

This file is part of SkillCalc.

    SkillCalc is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    SkillCalc is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with SkillCalc.  If not, see <http://www.gnu.org/licenses/>.
*/

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