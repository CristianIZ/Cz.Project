using Cz.Project.Dto.Exceptions;
using Cz.Project.Services;
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
    public partial class LoginForm : Form
    {
        public static LicenseForm licenseForm = new LicenseForm();
        public UserService userService = new UserService();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new Dto.AdminUserDto()
                {
                    Name = txtUserName.Text,
                    Password = txtUserPassword.Text,
                };

                var userResponse = userService.Login(user);

                if (userResponse != null)
                {
                    Variables.IsLoggedIn = true;
                    MessageBox.Show("Logueado correctamente");
                    this.Hide();
                }
            }
            catch (InvalidAdminUsersException ex)
            {
                MessageBox.Show("Usuario no encontrado");
            }
            catch (IncorrectAdminUsersPasswordException ex)
            {
                MessageBox.Show("Contraseña incorrecta");
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void ClearAll()
        {
            txtUserName.Clear();
            txtUserPassword.Clear();
        }
    }
}
