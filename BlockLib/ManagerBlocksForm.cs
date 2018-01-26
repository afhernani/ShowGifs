/*
 * Creado por SharpDevelop.
 * Usuario: hernani
 * Fecha: 13/06/2017
 * Hora: 21:07
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using FileLib;

namespace BlockLib
{
	/// <summary>
	/// Description of ManagerBlocksForm.
	/// </summary>
	public partial class ManagerBlocksForm : Form
	{
		public ManagerBlocksForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		/// <summary>
		/// Select button move.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RadioButtonMClick(object sender, EventArgs e)
		{
			if (radioButtonM.Checked) {
				
				label1.Text = "Path to move file:";
				textBoxRename.Enabled = true;
				btnAction.Text = "Move";
				btnLookOther.Enabled = true;
                textBoxRename.Text = NewPath;
			}
			
		}
		/// <summary>
		/// select button Copy
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RadioButtonCClick(object sender, EventArgs e)
		{
			if (radioButtonC.Checked) {
				//MessageBox.Show("Cancel");
				label1.Text = "Path to Copy file:";
				textBoxRename.Enabled = true;
				btnAction.Text = "Copy";
				btnLookOther.Enabled = true;
                textBoxRename.Text = NewPath;
            }
		}
		/// <summary>
		/// select button Rename
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		void RadioButtonRClick(object sender, EventArgs e)
		{
			if (radioButtonR.Checked) {
				//MessageBox.Show("Rename");
				label1.Text = "Nuevo nombre del fichero:";
				textBoxRename.Enabled = true;
				btnAction.Text = "Rename";
				btnLookOther.Enabled = false;
                textBoxRename.Text = FileName;

            }
		}
        #region properties
        /// <summary>
        /// AnyAction yes==true, no == false
        /// </summary>
        public bool isAnyAction { get; set; } = false;
		/// <summary>
		/// Route o path of the dir for copy or move.
		/// </summary>
		public string NewPath{ get; set; }
		/// <summary>
		/// Name file and extension
		/// </summary>
		public string FileName{ get; set; }
		
		/// <summary>
		/// complet name included path of the file
		/// </summary>
		public string FullName{
			get{
				return m_fullname;
			}
			set{ 
				m_fullname = value;
				FileName = Path.GetFileName(value);
				textBoxFile.Text = value;
			}
		}
		private string m_fullname = String.Empty;
		#endregion
		#region filebrowser
		void BtnLookOtherClick(object sender, EventArgs e)
		{
            
            FolderBrowserDialog dialog = new FolderBrowserDialog() {
				
			};
			if(!String.IsNullOrEmpty(FullName)){
				dialog.SelectedPath = Path.GetDirectoryName(FullName);
			}
			if (dialog.ShowDialog()==DialogResult.OK) {
				NewPath =textBoxRename.Text = dialog.SelectedPath;
            }
	
		}
		void BtnLookFileClick(object sender, EventArgs e)
		{
			OpenFileDialog openfile = new OpenFileDialog(){
				
			};
			if(!String.IsNullOrEmpty(FullName)){
				openfile.InitialDirectory = Path.GetFullPath(FullName);
			}
			if (openfile.ShowDialog()==DialogResult.OK) {
				
				FullName = textBoxFile.Text = openfile.FileName;
			}
		}
		void BtnCancelClick(object sender, EventArgs e)
		{
            isAnyAction = false;
			this.Close();
		}
		void BtnActionClick(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(NewPath))
				return;
			if (radioButtonM.Checked){
				Console.WriteLine("Move ..");
				Block block = new Block(FullName);
				if(block.Asociate){
					block.Move(NewPath);
				}
                isAnyAction = true;
            }
			if (radioButtonC.Checked){
				Console.WriteLine("Copy ..");
				Block block = new Block(FullName);
				if(block.Asociate){
					block.Copy(NewPath);
				}
                isAnyAction = true;
            }
			if (radioButtonR.Checked){
				Console.WriteLine("Rename ..");
				Block block = new Block(FullName);
				if(block.Asociate){
					block.Rename(NewPath);
				}
                isAnyAction = true;
            }
            this.Close();
			
		}
		void TextBoxRenameTextChanged(object sender, EventArgs e)
		{
			NewPath = textBoxRename.Text;
		}
        #endregion
        Form showpaths;
        private void btnLookOther_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    FolderBrowserDialog dialog = new FolderBrowserDialog()
                    {

                    };
                    if (!String.IsNullOrEmpty(FullName))
                    {
                        dialog.SelectedPath = Path.GetDirectoryName(FullName);
                    }
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        NewPath = textBoxRename.Text = dialog.SelectedPath;
                        SettingsBlockLib.Default.lastfourpath = NewPath + "|" + SettingsBlockLib.Default.lastfourpath;
                        SettingsBlockLib.Default.Save();
                        //do: comprobar que no está repetido para añadir
                    }
                    break;
                case MouseButtons.None:
                    break;
                case MouseButtons.Right:
                    //crear un formulario
                    Point point = this.PointToScreen(btnLookOther.Location);//Control.MousePosition);
                    showpaths = new Form()
                    {
                        //Parent = this,
                        Text = "Old paths",
                        Height = 100,
                        Width = 250,
                        FormBorderStyle = FormBorderStyle.None,
                        StartPosition = FormStartPosition.Manual,
                        Location = point,
                    };
                    
                    ListBox listapaths = new ListBox()
                    {
                        Dock = DockStyle.Fill,
                        HorizontalScrollbar = true,
                    };
                    listapaths.SelectedIndexChanged += SelectedIndexChangePath;
                    string[] korz = SettingsBlockLib.Default.lastfourpath.Split('|');
                    int n = 0;//reseteo a cero
                    int max = SettingsBlockLib.Default.MaxiEnters;//maximo de valores
                    string gesund = null;
                    foreach (var schon in korz)
                    {
                        if (n < max)
                        {
                            listapaths.Items.Add(schon);
                            gesund += schon + "|";
                        }
                        n++;
                    }
                    SettingsBlockLib.Default.lastfourpath = gesund;
                    SettingsBlockLib.Default.Save();
                    showpaths.Controls.Add(listapaths);
                    showpaths.ShowDialog();
                    break;
                case MouseButtons.Middle:
                    break;
                case MouseButtons.XButton1:
                    break;
                case MouseButtons.XButton2:
                    break;
                default:
                    break;
            }
        }

        private void showpathsFormClosed()
        {
            showpaths.Close();
        }

        private void SelectedIndexChangePath(object sender, EventArgs e)
        {
            ListBox over = (ListBox)(sender);
            if (over.SelectedIndex != -1)
            {
                NewPath = textBoxRename.Text = (string)over.SelectedItem;
                showpathsFormClosed();
            }
        }
    }
}
