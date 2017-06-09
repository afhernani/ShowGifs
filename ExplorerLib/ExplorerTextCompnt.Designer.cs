namespace ExplorerLib
{
    partial class ExplorerTextCompnt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExplorerTextCompnt));
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSaveReg = new System.Windows.Forms.Button();
            this.btnLoadReg = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeView_m
            // 
            this.treeView_m.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView_m.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeView_m.Dock = System.Windows.Forms.DockStyle.None;
            this.treeView_m.LineColor = System.Drawing.Color.Black;
            this.treeView_m.Location = new System.Drawing.Point(3, 27);
            this.treeView_m.Size = new System.Drawing.Size(238, 268);
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPath.Location = new System.Drawing.Point(3, 3);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(201, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Click += new System.EventHandler(this.txtPath_Click);
            // 
            // btnSaveReg
            // 
            this.btnSaveReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveReg.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveReg.Image")));
            this.btnSaveReg.Location = new System.Drawing.Point(206, 3);
            this.btnSaveReg.Name = "btnSaveReg";
            this.btnSaveReg.Size = new System.Drawing.Size(20, 20);
            this.btnSaveReg.TabIndex = 2;
            this.btnSaveReg.UseVisualStyleBackColor = true;
            this.btnSaveReg.Click += new System.EventHandler(this.btnSaveReg_Click);
            // 
            // btnLoadReg
            // 
            this.btnLoadReg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadReg.Image = ((System.Drawing.Image)(resources.GetObject("btnLoadReg.Image")));
            this.btnLoadReg.Location = new System.Drawing.Point(226, 3);
            this.btnLoadReg.Name = "btnLoadReg";
            this.btnLoadReg.Size = new System.Drawing.Size(20, 20);
            this.btnLoadReg.TabIndex = 3;
            this.btnLoadReg.UseVisualStyleBackColor = true;
            this.btnLoadReg.Click += new System.EventHandler(this.btnLoadReg_Click);
            // 
            // ExplorerTextCompnt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.btnLoadReg);
            this.Controls.Add(this.btnSaveReg);
            this.Controls.Add(this.txtPath);
            this.Name = "ExplorerTextCompnt";
            this.Size = new System.Drawing.Size(244, 299);
            this.Controls.SetChildIndex(this.treeView_m, 0);
            this.Controls.SetChildIndex(this.txtPath, 0);
            this.Controls.SetChildIndex(this.btnSaveReg, 0);
            this.Controls.SetChildIndex(this.btnLoadReg, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSaveReg;
        private System.Windows.Forms.Button btnLoadReg;
    }
}
