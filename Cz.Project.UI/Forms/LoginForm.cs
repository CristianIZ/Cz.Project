using Cz.Project.Dto.Exceptions;
using Cz.Project.Services;
using Cz.Project.UI.Forms.FormResponses;
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
        public LoginFormResponse response = new LoginFormResponse();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var userService = new UserService();
            if (userService.IsLoggedIn())
            {
                MessageBox.Show("Ya se encuentra un usuario logueado");
                this.Close();
            }

            txtUserName.Text = "Admin";
            txtUserPassword.Text = "123456789";

            this.response = new LoginFormResponse()
            {
                LoginSuccessfully = false
            };
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
                
                var userService = new UserService();
                var userResponse = userService.Login(user);

                if (userResponse != null)
                {
                    this.response = new LoginFormResponse()
                    {
                        LoginSuccessfully = true
                    };

                    this.Close();
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
