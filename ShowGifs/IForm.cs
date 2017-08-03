using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowGifs
{
    /// <summary>
    /// interfaz interconectividad de ventanas
    /// </summary>
    public interface IForm
    {
        /// <summary>
        /// Cambia el directorio de exploracion.
        /// </summary>
        /// <param name="pathdir"></param>
        void ChangeDirToExplore(string pathdir);
        /// <summary>
        /// Adicionar el fichero encontrado.
        /// </summary>
        /// <param name="file"></param>
        void AddFileFoundedSeached(FileInfo file);
    }
}
