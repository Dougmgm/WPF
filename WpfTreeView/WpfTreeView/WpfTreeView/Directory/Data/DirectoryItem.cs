using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTreeView
{

    /// <summary>
    /// Informação sobre um item do diretório como o disco, um arquivo ou uma pasta
    /// </summary>
    public class DirectoryItem
    {
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        //O tipo desse item
        public DirectoryItemType Type { get; set; }

        //O caminho absuluto para o item
        public string FullPath { get; set; } 
        /// <summary>
        /// O nome do item desse diretório
        /// </summary>
    }
}
