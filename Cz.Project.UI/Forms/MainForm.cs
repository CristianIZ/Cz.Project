using Cz.Project.UI.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cz.Project.UI.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            UIOptions(false);
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLoginForm();
        }

        private void OpenLoginForm()
        {
            var loginForm = new LoginForm();
            loginForm.ShowDialog();

            if (loginForm.response.LoginSuccessfully)
            {
                UIOptions(true);
            }
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var adminUsersForm = new AdminUsersForm();
            var result = adminUsersForm.ShowDialog();
        }

        private void permisosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var licenseForm = new LicenseForm();
            var result = licenseForm.ShowDialog();
        }

        public void UIOptions(bool enable)
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                if (item.Text != "Login")
                    item.Enabled = enable;
            }
        }
    }
}
