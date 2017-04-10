namespace ShowGifs
{
    partial class CtrlSearch
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
            _instance = null;
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CtrlSearch));
        	this.listBoxDir = new System.Windows.Forms.ListBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.btnAdd = new System.Windows.Forms.Button();
        	this.btnDelete = new System.Windows.Forms.Button();
        	this.btnSetting = new System.Windows.Forms.Button();
        	this.textBoxNewDir = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.textBoxStringSearch = new System.Windows.Forms.TextBox();
        	this.btnOK = new System.Windows.Forms.Button();
        	this.btnCancel = new System.Windows.Forms.Button();
        	this.lbResque = new System.Windows.Forms.Label();
        	this.btnProcess = new System.Windows.Forms.Button();
        	this.btnUp = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// listBoxDir
        	// 
        	this.listBoxDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.listBoxDir.FormattingEnabled = true;
        	this.listBoxDir.HorizontalScrollbar = true;
        	this.listBoxDir.ItemHeight = 15;
        	this.listBoxDir.Location = new System.Drawing.Point(5, 20);
        	this.listBoxDir.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.listBoxDir.Name = "listBoxDir";
        	this.listBoxDir.Size = new System.Drawing.Size(236, 139);
        	this.listBoxDir.TabIndex = 0;
        	this.listBoxDir.SelectedIndexChanged += new System.EventHandler(this.listBoxDir_SelectedIndexChanged);
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(5, 1);
        	this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(150, 15);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "List of directorys to search:";
        	// 
        	// btnAdd
        	// 
        	this.btnAdd.Location = new System.Drawing.Point(5, 163);
        	this.btnAdd.Margin = new System.Windows.Forms.Padding(2);
        	this.btnAdd.Name = "btnAdd";
        	this.btnAdd.Size = new System.Drawing.Size(63, 24);
        	this.btnAdd.TabIndex = 2;
        	this.btnAdd.Text = "Add";
        	this.btnAdd.UseVisualStyleBackColor = true;
        	this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
        	// 
        	// btnDelete
        	// 
        	this.btnDelete.Location = new System.Drawing.Point(72, 163);
        	this.btnDelete.Margin = new System.Windows.Forms.Padding(2);
        	this.btnDelete.Name = "btnDelete";
        	this.btnDelete.Size = new System.Drawing.Size(63, 24);
        	this.btnDelete.TabIndex = 3;
        	this.btnDelete.Text = "Delete";
        	this.btnDelete.UseVisualStyleBackColor = true;
        	this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
        	// 
        	// btnSetting
        	// 
        	this.btnSetting.Location = new System.Drawing.Point(139, 163);
        	this.btnSetting.Margin = new System.Windows.Forms.Padding(2);
        	this.btnSetting.Name = "btnSetting";
        	this.btnSetting.Size = new System.Drawing.Size(63, 24);
        	this.btnSetting.TabIndex = 4;
        	this.btnSetting.Text = "Setting";
        	this.btnSetting.UseVisualStyleBackColor = true;
        	this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
        	// 
        	// textBoxNewDir
        	// 
        	this.textBoxNewDir.Location = new System.Drawing.Point(5, 208);
        	this.textBoxNewDir.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxNewDir.Name = "textBoxNewDir";
        	this.textBoxNewDir.Size = new System.Drawing.Size(236, 21);
        	this.textBoxNewDir.TabIndex = 5;
        	this.textBoxNewDir.Click += new System.EventHandler(this.textBoxNewDir_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(5, 189);
        	this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(121, 15);
        	this.label2.TabIndex = 6;
        	this.label2.Text = "New directory to add:";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(5, 230);
        	this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(97, 15);
        	this.label3.TabIndex = 8;
        	this.label3.Text = "String to Search:";
        	// 
        	// textBoxStringSearch
        	// 
        	this.textBoxStringSearch.Location = new System.Drawing.Point(5, 249);
        	this.textBoxStringSearch.Margin = new System.Windows.Forms.Padding(2);
        	this.textBoxStringSearch.Name = "textBoxStringSearch";
        	this.textBoxStringSearch.Size = new System.Drawing.Size(237, 21);
        	this.textBoxStringSearch.TabIndex = 7;
        	// 
        	// btnOK
        	// 
        	this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
        	this.btnOK.Location = new System.Drawing.Point(177, 364);
        	this.btnOK.Margin = new System.Windows.Forms.Padding(2);
        	this.btnOK.Name = "btnOK";
        	this.btnOK.Size = new System.Drawing.Size(63, 22);
        	this.btnOK.TabIndex = 9;
        	this.btnOK.Text = "OK";
        	this.btnOK.UseVisualStyleBackColor = true;
        	this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        	// 
        	// btnCancel
        	// 
        	this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.btnCancel.Location = new System.Drawing.Point(43, 364);
        	this.btnCancel.Margin = new System.Windows.Forms.Padding(2);
        	this.btnCancel.Name = "btnCancel";
        	this.btnCancel.Size = new System.Drawing.Size(63, 22);
        	this.btnCancel.TabIndex = 10;
        	this.btnCancel.Text = "Cancel";
        	this.btnCancel.UseVisualStyleBackColor = true;
        	this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
        	// 
        	// lbResque
        	// 
        	this.lbResque.ForeColor = System.Drawing.Color.Red;
        	this.lbResque.Location = new System.Drawing.Point(5, 272);
        	this.lbResque.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
        	this.lbResque.Name = "lbResque";
        	this.lbResque.Size = new System.Drawing.Size(233, 85);
        	this.lbResque.TabIndex = 11;
        	this.lbResque.Text = "On_Hold:";
        	// 
        	// btnProcess
        	// 
        	this.btnProcess.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        	this.btnProcess.Location = new System.Drawing.Point(110, 364);
        	this.btnProcess.Margin = new System.Windows.Forms.Padding(2);
        	this.btnProcess.Name = "btnProcess";
        	this.btnProcess.Size = new System.Drawing.Size(63, 22);
        	this.btnProcess.TabIndex = 12;
        	this.btnProcess.Text = "Process";
        	this.btnProcess.UseVisualStyleBackColor = true;
        	this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
        	// 
        	// btnUp
        	// 
        	this.btnUp.Image = ((System.Drawing.Image)(resources.GetObject("btnUp.Image")));
        	this.btnUp.Location = new System.Drawing.Point(206, 163);
        	this.btnUp.Margin = new System.Windows.Forms.Padding(2);
        	this.btnUp.Name = "btnUp";
        	this.btnUp.Size = new System.Drawing.Size(18, 24);
        	this.btnUp.TabIndex = 13;
        	this.btnUp.UseVisualStyleBackColor = true;
        	this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
        	// 
        	// CtrlSearch
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(246, 397);
        	this.Controls.Add(this.btnUp);
        	this.Controls.Add(this.btnProcess);
        	this.Controls.Add(this.lbResque);
        	this.Controls.Add(this.btnCancel);
        	this.Controls.Add(this.btnOK);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.textBoxStringSearch);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.textBoxNewDir);
        	this.Controls.Add(this.btnSetting);
        	this.Controls.Add(this.btnDelete);
        	this.Controls.Add(this.btnAdd);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.listBoxDir);
        	this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
        	this.Name = "CtrlSearch";
        	this.Text = "Search";
        	this.ResumeLayout(false);
        	this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.TextBox textBoxNewDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxStringSearch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbResque;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnUp;
    }
}
