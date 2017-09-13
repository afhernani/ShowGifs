using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShowGifs
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            //todo: realiza todas las comprobaciones aqui.
            SaveDataSettings();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //salimos sin hacer nada
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            //lo que carga
            if (Inicio.Default.SpriteSize.Height != 0 && Inicio.Default.SpriteSize.Width != 0)
            {
                numericUpDownWidth.Value = Inicio.Default.SpriteSize.Width;
                numericUpDownHeight.Value = Inicio.Default.SpriteSize.Height;
            }
            checkBoxThreadFiles.Checked = Inicio.Default.isSearch;
        }
        private void SaveDataSettings()
        {
            Inicio.Default.SpriteSize = new Size((int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value);
            Inicio.Default.isSearch = checkBoxThreadFiles.Checked;
            Inicio.Default.Save(); //guardamos los cambios.
        }
    }
}
