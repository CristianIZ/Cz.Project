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

            FillTreeView(this.inMemoryLicenses.GetTree());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (this.licensesTreeView.SelectedNode == null)
            {
                this.inMemoryLicenses.AddLicense(txtLicenseName.Name, 0);
            }
            else
            {
                var select = (ComponentDto)this.licensesTreeView.SelectedNode.Tag;

                // Type type1 = typeof(ComponentDto);
                // Type type2 = typeof(FamilyLicenseDto);
                // 
                // object result;
                // 
                // if (type1 == select.GetType())
                //     result = (ComponentDto)select;
                // else if (type2 == select.GetType())
                //     result = (FamilyLicenseDto)select;
                // else
                //     throw new Exception("Not valid type for selected item");

                this.inMemoryLicenses.AddLicense(txtLicenseName.Name, select.licenceCode);
            }
        }

        public void FillTreeView(IList<ComponentDto> tree)
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

        public void PopulateTree(ref TreeNode root, IList<ComponentDto> tree)
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
