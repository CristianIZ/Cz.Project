using Cz.Project.Dto;
using Cz.Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cz.Project.Dto.Exceptions;

namespace Cz.Project.UI.Forms
{
    public partial class AdminUsersForm : Form
    {
        public AdminUsersForm()
        {
            InitializeComponent();
        }

        private void AdminUsersForm_Load(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var adminUserDto = new AdminUserDto()
                {
                    Name = txtName.Text,
                    Password = txtPassword.Text
                };

                var sqlUserContext = new UserService();
                sqlUserContext.Add(adminUserDto);

                RefreshList();
                MessageBox.Show("Usuario creado correctamente");
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fallo la crecion de usuario, intentelo nuevamente");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstUsers.SelectedItem == null)
                    throw new CustomException("No hay items seleccionados");

                var selectedUser = (AdminUserDto)lstUsers.SelectedItems[0];

                var sqlUserContext = new UserService();
                sqlUserContext.Delete(selectedUser);

                RefreshList();
                MessageBox.Show("Usuario eliminado correctamente");
            }
            catch (CustomException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fallo la crecion de usuario, intentelo nuevamente");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstUsers.SelectedItem == null)
                    throw new CustomException("No hay items seleccionados");

                var selectedUser = (AdminUserDto)lstUsers.SelectedItems[0];


                var newUserValues = new AdminUserDto()
                {
                    Name = txtName.Text,
                    Password = txtPassword.Text
                };

                var sqlUserContext = new UserService();
                sqlUserContext.Update(selectedUser, newUserValues);

                RefreshList();
                MessageBox.Show("Usuario creado correctamente");
            }
            catch (CustomException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            catch (Exception)
            {
                MessageBox.Show($"Fallo la crecion de usuario, intentelo nuevamente");
            }
        }

        private void RefreshList()
        {
            try
            {
                lstUsers.Items.Clear();

                var userService = new UserService();
                var users = userService.GetAll();

                foreach (var user in users)
                {
                    lstUsers.Items.Add(user);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
        }
    }
}
