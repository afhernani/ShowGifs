/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 02/08/2017
 * Hora: 23:03
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace ShowGifs
{
	/// <summary>
	/// Description of Busca.
	/// </summary>
	public partial class Busca : Form
	{
		public Busca()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
		    //
		    // TODO: Add constructor code after the InitializeComponent() call.
		    //
		    this.KeyPreview = true;
		}

        private void userSearch1_FileFounderEvent(System.IO.FileInfo file)
        {
            Debug.WriteLine($"_fileFounderEvent");
            if (InvokeRequired)
                Invoke(new Action(() =>
                {
                    IForm forminterfas = this.Owner as IForm;
                        forminterfas?.AddFileFoundedSeached(file);
                }));
            if(InvokeRequired)
                Invoke(new Action(() => { this.Text = userSearch1.StrSearch; }));       
        }

        private void Busca_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                //todo: aqui vamos a establecer el escape de busqueda.
                Debug.WriteLine("busca_KeyDown() <Escape>");
                userSearch1.Cs?.Cancel();
            }
        }
    }
}
