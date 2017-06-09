/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 09/06/2017
 * Hora: 21:16
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShowGifs
{
	/// <summary>
	/// Description of Explora.
	/// </summary>
	public partial class Explora : Form
	{
        private static Explora _instance = null;
		public Explora()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
        public static Explora GetInstancia()
        {
            if (_instance == null)
            {
                _instance = new Explora();
            }
            return _instance;
        }
    }
}
