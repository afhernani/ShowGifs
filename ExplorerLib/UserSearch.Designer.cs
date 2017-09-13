/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 02/08/2017
 * Hora: 21:57
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace ExplorerLib
{
	partial class UserSearch
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBoxRoot;
		private System.Windows.Forms.Button btnRoot;
		private System.Windows.Forms.TextBox textBoxString;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxRoot = new System.Windows.Forms.TextBox();
            this.btnRoot = new System.Windows.Forms.Button();
            this.textBoxString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Root:";
            // 
            // textBoxRoot
            // 
            this.textBoxRoot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRoot.Location = new System.Drawing.Point(42, 12);
            this.textBoxRoot.Name = "textBoxRoot";
            this.textBoxRoot.Size = new System.Drawing.Size(207, 20);
            this.textBoxRoot.TabIndex = 1;
            this.textBoxRoot.Click += new System.EventHandler(this.textBoxRoot_Click);
            // 
            // btnRoot
            // 
            this.btnRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoot.Location = new System.Drawing.Point(255, 12);
            this.btnRoot.Name = "btnRoot";
            this.btnRoot.Size = new System.Drawing.Size(34, 20);
            this.btnRoot.TabIndex = 2;
            this.btnRoot.Text = "->";
            this.btnRoot.UseVisualStyleBackColor = true;
            this.btnRoot.Click += new System.EventHandler(this.BtnRootClick);
            // 
            // textBoxString
            // 
            this.textBoxString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxString.Location = new System.Drawing.Point(3, 38);
            this.textBoxString.Name = "textBoxString";
            this.textBoxString.Size = new System.Drawing.Size(286, 20);
            this.textBoxString.TabIndex = 3;
            this.textBoxString.Text = "String to search";
            this.textBoxString.Click += new System.EventHandler(this.textBoxString_Click);
            this.textBoxString.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxString_KeyDown);
            // 
            // UserSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxString);
            this.Controls.Add(this.btnRoot);
            this.Controls.Add(this.textBoxRoot);
            this.Controls.Add(this.label1);
            this.Name = "UserSearch";
            this.Size = new System.Drawing.Size(292, 76);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
