namespace ExplorerLib
{
    partial class Explorer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.treeView_m = new System.Windows.Forms.TreeView();
            this.imageList_m = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // treeView_m
            // 
            this.treeView_m.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_m.ImageIndex = 0;
            this.treeView_m.ImageList = this.imageList_m;
            this.treeView_m.Location = new System.Drawing.Point(0, 0);
            this.treeView_m.Name = "treeView_m";
            this.treeView_m.SelectedImageIndex = 0;
            this.treeView_m.Size = new System.Drawing.Size(133, 158);
            this.treeView_m.TabIndex = 0;
            this.treeView_m.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView_m_NodeMouseClick);
            // 
            // imageList_m
            // 
            this.imageList_m.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList_m.ImageStream")));
            this.imageList_m.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList_m.Images.SetKeyName(0, "Computer-icon.png");
            this.imageList_m.Images.SetKeyName(1, "system.png");
            this.imageList_m.Images.SetKeyName(2, "Folder-Close-icon.png");
            this.imageList_m.Images.SetKeyName(3, "folder.png");
            this.imageList_m.Images.SetKeyName(4, "hard-disk-icon.png");
            this.imageList_m.Images.SetKeyName(5, "drive_cd.png");
            this.imageList_m.Images.SetKeyName(6, "DVD-Drive-icon.png");
            this.imageList_m.Images.SetKeyName(7, "usbpendrive_mount.png");
            this.imageList_m.Images.SetKeyName(8, "hdd_mount.png");
            this.imageList_m.Images.SetKeyName(9, "document_yellow.png");
            this.imageList_m.Images.SetKeyName(10, "Actions-view-refresh-icon.png");
            this.imageList_m.Images.SetKeyName(11, "readme-16_32.png");
            this.imageList_m.Images.SetKeyName(12, "Help-icon.png");
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.Controls.Add(this.treeView_m);
            this.Name = "Explorer";
            this.Size = new System.Drawing.Size(133, 158);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList_m;
        protected System.Windows.Forms.TreeView treeView_m;
    }
}
