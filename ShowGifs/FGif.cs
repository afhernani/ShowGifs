/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 20/10/2016
 * Hora: 1:27
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ShowGifs
{
	/// <summary>
	/// Description of FGif.
	/// </summary>
	public partial class FGif : Form
	{
		public FGif()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		public Image ImageToView
		{
			set
			{
				this.pictureBox1.Image=value;
			}
		}
		
		private void PictureBox1_MouseClick(object sender, MouseEventArgs e)
		{
			PictureBox sprite = (PictureBox)sender;
        	string filesearch = GetFileNameFromString(this.Tag.ToString());
        	Debug.WriteLine("Nombre -> "+ this.Tag.ToString());
        	
        	if (e.Button == MouseButtons.Right)
        	{
        		Debug.Write(this.Text + "-> Mouseclick_right");
            }
            if (e.Button == MouseButtons.Left)
            {
            	Debug.WriteLine(this.Text +"-> Mouseclick_left");
            	
                if (Form.ModifierKeys == Keys.Control)
                {              	
                    Debug.WriteLine(this.Text +"-> MouseClick_left + Key-Control: presed");
                }
                if (Form.ModifierKeys == Keys.Alt)
                {
                	if(Path.GetExtension(filesearch).Equals(".gif")) {MessageBox.Show("OOOfff"); return;}
                    Search control = new Search()
                    {
                        SearchString = filesearch,
                        AutoProcess = true
                    };
                    control.Start();
                    Debug.WriteLine(this.Text + "-> MouseClick_left + Key-Alt: process");
                }
                if (Form.ModifierKeys == Keys.Shift)
                {
                    Debug.WriteLine(this.Text +"-> MouseClick_left + Key -> Shift:");
                }
                
            }
	
		}
		
		public static string GetFileNameFromString(string name)
        {
            int pos = name.IndexOf(@"_thumbs_", StringComparison.Ordinal);
            if(pos==-1) return name;
            name = name.Substring(0, pos);
            return Path.GetFileName(name);
        }
		
		void FGif_Load(object sender, EventArgs e)
		{
			if (this.Tag!=null)
			{
				this.Text=Path.GetFileName(this.Tag.ToString());
			}
		}
	}
}
