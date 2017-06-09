using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplorerLib
{
    public partial class ExplorerTextCompnt : Explorer
    {
        public ExplorerTextCompnt()
        {
            InitializeComponent();
        }

        public ExplorerTextCompnt(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void treeView_m_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            base.treeView_m_NodeMouseClick(sender, e);
            txtPath.Text = ((DirectoryInfo)e.Node.Tag).FullName;
        }
        
        protected override void treeView_m_selectNode(TreeNodeMouseClickEventArgs e)
        {
            base.treeView_m_selectNode(e);
            txtPath.Text = ((DirectoryInfo)e.Node.Tag).FullName;
        }

        private void txtPath_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPath.Text))
            {
                txtPath.SelectionStart = 0;
                txtPath.SelectionLength = txtPath.Text.Length;
            }
        }

        private void btnSaveReg_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtPath.Text) && Path.IsPathRooted(txtPath.Text))
            {
                base.TrackPath = txtPath.Text;
            }
        }

        private void btnLoadReg_Click(object sender, EventArgs e)
        {
            base.Tracker();
            txtPath.Text = base.TrackPath;
        }

    }
}
