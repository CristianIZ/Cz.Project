using Cz.Project.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Cz.Project.Dto;

namespace Cz.Project.UI.Forms
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();
        }

        private void LicenseForm_Load(object sender, EventArgs e)
        {
            var licService = new LicenseService();
            var licenses = licService.GetLicenseTree();
            FillTreeView(licenses);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

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
