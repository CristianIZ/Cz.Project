using Cz.Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cz.Project.Dto;
using Cz.Project.Services.Helpers;

namespace Cz.Project.UI.Forms
{
    public partial class LicenseForm : Form
    {
        InMemoryLicenses inMemoryLicenses;

        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            this.inMemoryLicenses = new InMemoryLicenses();
            RefreshTreeView();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.licensesTreeView.SelectedNode == null)
                {
                    this.inMemoryLicenses.AddLicense(txtLicenseName.Text, 0);
                }
                else
                {
                    var select = (ComponentDto)this.licensesTreeView.SelectedNode.Tag;
                    this.inMemoryLicenses.AddLicense(txtLicenseName.Text, select.licenceCode);
                }

                RefreshTreeView();
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            try
            {
                this.inMemoryLicenses.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void RefreshTreeView()
        {
            this.licensesTreeView.Nodes.Clear();
            FillTreeView(this.inMemoryLicenses.GetTree());
            this.licensesTreeView.ExpandAll();
        }

        private void FillTreeView(IList<ComponentDto> tree)
        {
            foreach (var item in tree)
            {
                var node = new TreeNode()
                {
                    Text = item.Name,
                    Tag = item
                };

                PopulateTree(ref node, ((FamilyLicenseDto)item).GetChilds());
                this.licensesTreeView.Nodes.Add(node);
            }
        }

        private void PopulateTree(ref TreeNode root, IList<ComponentDto> tree)
        {
            foreach (var detail in tree)
            {
                var child = new TreeNode()
                {
                    Text = detail.Name,
                    Tag = detail
                };

                var childs = detail.GetChilds();

                if (childs != null)
                    PopulateTree(ref child, detail.GetChilds());

                root.Nodes.Add(child);
            }
        }
    }
}
