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
        LoginForm loginForm;
        AdminUsersForm adminUsersForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenLoginForm();
        }

        private void OpenLoginForm()
        {
            loginForm = new LoginForm();
            loginForm.Show();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminUsersForm = new AdminUsersForm();
            adminUsersForm.Show();
        }
    }
}
