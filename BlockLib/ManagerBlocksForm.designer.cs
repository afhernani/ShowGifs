/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 13/06/2017
 * Hora: 21:07
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace BlockLib
{
	partial class ManagerBlocksForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.GroupBox groupBoxSelect;
		private System.Windows.Forms.RadioButton radioButtonR;
		private System.Windows.Forms.RadioButton radioButtonC;
		private System.Windows.Forms.RadioButton radioButtonM;
		private System.Windows.Forms.GroupBox groupBoxFiles;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxRename;
		private System.Windows.Forms.TextBox textBoxFile;
		private System.Windows.Forms.Button btnAction;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLookFile;
		private System.Windows.Forms.Button btnLookOther;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBoxSelect = new System.Windows.Forms.GroupBox();
			this.radioButtonR = new System.Windows.Forms.RadioButton();
			this.radioButtonC = new System.Windows.Forms.RadioButton();
			this.radioButtonM = new System.Windows.Forms.RadioButton();
			this.groupBoxFiles = new System.Windows.Forms.GroupBox();
			this.btnLookFile = new System.Windows.Forms.Button();
			this.btnLookOther = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxRename = new System.Windows.Forms.TextBox();
			this.textBoxFile = new System.Windows.Forms.TextBox();
			this.btnAction = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.groupBoxSelect.SuspendLayout();
			this.groupBoxFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxSelect
			// 
			this.groupBoxSelect.Controls.Add(this.radioButtonR);
			this.groupBoxSelect.Controls.Add(this.radioButtonC);
			this.groupBoxSelect.Controls.Add(this.radioButtonM);
			this.groupBoxSelect.Location = new System.Drawing.Point(12, 12);
			this.groupBoxSelect.Name = "groupBoxSelect";
			this.groupBoxSelect.Size = new System.Drawing.Size(281, 62);
			this.groupBoxSelect.TabIndex = 0;
			this.groupBoxSelect.TabStop = false;
			this.groupBoxSelect.Text = "Select Operation";
			// 
			// radioButtonR
			// 
			this.radioButtonR.Location = new System.Drawing.Point(182, 19);
			this.radioButtonR.Name = "radioButtonR";
			this.radioButtonR.Size = new System.Drawing.Size(79, 24);
			this.radioButtonR.TabIndex = 2;
			this.radioButtonR.TabStop = true;
			this.radioButtonR.Text = "Rename";
			this.radioButtonR.UseVisualStyleBackColor = true;
			this.radioButtonR.Click += new System.EventHandler(this.RadioButtonRClick);
			// 
			// radioButtonC
			// 
			this.radioButtonC.Location = new System.Drawing.Point(96, 19);
			this.radioButtonC.Name = "radioButtonC";
			this.radioButtonC.Size = new System.Drawing.Size(70, 24);
			this.radioButtonC.TabIndex = 1;
			this.radioButtonC.TabStop = true;
			this.radioButtonC.Text = "Copy";
			this.radioButtonC.UseVisualStyleBackColor = true;
			this.radioButtonC.Click += new System.EventHandler(this.RadioButtonCClick);
			// 
			// radioButtonM
			// 
			this.radioButtonM.Location = new System.Drawing.Point(13, 19);
			this.radioButtonM.Name = "radioButtonM";
			this.radioButtonM.Size = new System.Drawing.Size(66, 24);
			this.radioButtonM.TabIndex = 0;
			this.radioButtonM.TabStop = true;
			this.radioButtonM.Text = "Move";
			this.radioButtonM.UseVisualStyleBackColor = true;
			this.radioButtonM.Click += new System.EventHandler(this.RadioButtonMClick);
			// 
			// groupBoxFiles
			// 
			this.groupBoxFiles.Controls.Add(this.btnLookFile);
			this.groupBoxFiles.Controls.Add(this.btnLookOther);
			this.groupBoxFiles.Controls.Add(this.label1);
			this.groupBoxFiles.Controls.Add(this.textBoxRename);
			this.groupBoxFiles.Controls.Add(this.textBoxFile);
			this.groupBoxFiles.Location = new System.Drawing.Point(12, 92);
			this.groupBoxFiles.Name = "groupBoxFiles";
			this.groupBoxFiles.Size = new System.Drawing.Size(281, 120);
			this.groupBoxFiles.TabIndex = 1;
			this.groupBoxFiles.TabStop = false;
			this.groupBoxFiles.Text = "select file";
			// 
			// btnLookFile
			// 
			this.btnLookFile.Location = new System.Drawing.Point(233, 26);
			this.btnLookFile.Name = "btnLookFile";
			this.btnLookFile.Size = new System.Drawing.Size(28, 20);
			this.btnLookFile.TabIndex = 4;
			this.btnLookFile.Text = "..";
			this.btnLookFile.UseVisualStyleBackColor = true;
			this.btnLookFile.Click += new System.EventHandler(this.BtnLookFileClick);
			// 
			// btnLookOther
			// 
			this.btnLookOther.Enabled = false;
			this.btnLookOther.Location = new System.Drawing.Point(233, 81);
			this.btnLookOther.Name = "btnLookOther";
			this.btnLookOther.Size = new System.Drawing.Size(28, 20);
			this.btnLookOther.TabIndex = 3;
			this.btnLookOther.Text = "..";
			this.btnLookOther.UseVisualStyleBackColor = true;
			this.btnLookOther.Click += new System.EventHandler(this.BtnLookOtherClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 65);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(94, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Obtion not definit *";
			// 
			// textBoxRename
			// 
			this.textBoxRename.Enabled = false;
			this.textBoxRename.Location = new System.Drawing.Point(13, 81);
			this.textBoxRename.Name = "textBoxRename";
			this.textBoxRename.Size = new System.Drawing.Size(214, 20);
			this.textBoxRename.TabIndex = 1;
			this.textBoxRename.TextChanged += new System.EventHandler(this.TextBoxRenameTextChanged);
			// 
			// textBoxFile
			// 
			this.textBoxFile.Location = new System.Drawing.Point(13, 26);
			this.textBoxFile.Name = "textBoxFile";
			this.textBoxFile.Size = new System.Drawing.Size(214, 20);
			this.textBoxFile.TabIndex = 0;
			// 
			// btnAction
			// 
			this.btnAction.Location = new System.Drawing.Point(205, 218);
			this.btnAction.Name = "btnAction";
			this.btnAction.Size = new System.Drawing.Size(88, 27);
			this.btnAction.TabIndex = 2;
			this.btnAction.Text = "Select Obtions";
			this.btnAction.UseVisualStyleBackColor = true;
			this.btnAction.Click += new System.EventHandler(this.BtnActionClick);
			// 
			// btnCancel
			// 
			this.btnCancel.Location = new System.Drawing.Point(108, 218);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(88, 27);
			this.btnCancel.TabIndex = 0;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.BtnCancelClick);
			// 
			// ManagerBlocksForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(307, 257);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnAction);
			this.Controls.Add(this.groupBoxFiles);
			this.Controls.Add(this.groupBoxSelect);
			this.Name = "ManagerBlocksForm";
			this.Text = "Manager-Dir";
			this.groupBoxSelect.ResumeLayout(false);
			this.groupBoxFiles.ResumeLayout(false);
			this.groupBoxFiles.PerformLayout();
			this.ResumeLayout(false);

		}
	}
}
