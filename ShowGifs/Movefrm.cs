using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ShowGifs
{
    public partial class Movefrm : Form
    {
        private static Movefrm Instancia = null;
        private Movefrm()
        {
            InitializeComponent();
        }

        public string MoveToPaht { get; set; } = null;

        public void InitializeInstancia()
        {
            FileLibrary.FileEndHandler += EndFileWorkHandler;
            lbFilePathGifToMove.Text = FileGifPath;
            {
                string moviefilename = FileMoviePaht; //por ahora solo conosemos el nombre pero no la dirección.
                string dir = Path.GetDirectoryName(FileGifPath);
                string movepath = Path.Combine(dir, moviefilename);
                if (File.Exists(movepath))
                {
                    this.FileMoviePaht = movepath;
                    lbFilePathMovieToMove.Text = FileMoviePaht;
                }
                else //si no tenemos que buscarlo.
                {
                    Search control = new Search()
                    {
                        SearchString = moviefilename,
                        AutoProcess = false
                    };
                    control.SearchedFileFound += HandlerSearchedFile;
                    control.Start();
                    lbFilePathMovieToMove.Text ="Estamos trabajando ...";
                }
            }//buscar el movie asociado
            
        }

        private void EndFileWorkHandler(string res)
        {
            if (this.InvokeRequired)
            {
                FileLibrary.FileHandler call = 
                    new FileLibrary.FileHandler(EndFileWorkHandler);
                this.Invoke(call, new object[] {res});
            }
            else
            {
                btnOK.Enabled = true;
                lbRes.Text = res;
            }
        }

        void HandlerSearchedFile(string res)
        {
            if (this.InvokeRequired)
            {
                Search.SearchedHandler call =
                    new Search.SearchedHandler(HandlerSearchedFile);
                this.Invoke(call, new object[] { res });
            }
            else
            {
                if (res.Equals("NOT"))
                {
                    //no lo encontro
                    lbFilePathMovieToMove.Text = "No fue encontrado el fichero";
                    FileMoviePaht = "NOT";
                }
                else
                {
                    //lo encontro
                    lbFilePathMovieToMove.Text = FileMoviePaht= res;
                }
            }
        }

        public static Movefrm GetInstancia()
        {
            if (Instancia == null)
            {
                Instancia = new Movefrm();
            }
            return Instancia;
        }

        public string FileGifPath { get; set; } = null;
        public string FileMoviePaht { get; set; } = null;
        #region actions

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog setDirectory = new FolderBrowserDialog()
            {
                RootFolder = Environment.SpecialFolder.MyComputer,
            };
            DialogResult result = setDirectory.ShowDialog();
            if (result == DialogResult.OK)
            {
                MoveToPaht = setDirectory.SelectedPath;
                textPathToMove.Text = MoveToPaht;
                //aqui iniciamos la carga de todos los ficheros de imagen
                //contenidos en el directorio.
                //PathsToLoadForApply = setDirectory.SelectedPath;
                btnOK.Enabled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //aqui iniciamos las operaciones de mover ambos ficheros
            btnOK.Enabled = false;
            lbRes.Text = "Estamos trabajando ...";
            FileLibrary.MoveFile(FileGifPath, MoveToPaht, true);
            FileLibrary.MoveFile(FileMoviePaht, MoveToPaht,true);
        }

        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
