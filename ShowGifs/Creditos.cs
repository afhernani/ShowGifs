/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 23/10/2016
 * Hora: 19:20
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ScanGifDir
{
	/// <summary>
	/// Description of Creditos.
	/// </summary>
	public partial class Creditos : Form
	{
		private static Creditos _instance = null;
		
		protected Creditos()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
            //
		}
		
		public static Creditos GetCreditos()
		{
			if (_instance == null)
			{
				_instance = new Creditos();
			}
			return _instance;
		}

        private void Creditos_MouseClick(object sender, MouseEventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Creditos_MouseClick(sender, e);
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            Creditos_MouseClick(sender, e);
        }

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            Creditos_MouseClick(sender, e);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                timer1.Stop();
            }
        }
    }
}
