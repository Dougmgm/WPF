using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WpfTreeView
{ 

    /// <summary>
    /// Uma classe de ajudar para buscar informações sobre os diretórios
    /// </summary>
    public class DirectoryStructure
    {
        public static List<DirectoryItem> GetLogicalDrives()
        {
            // Pegar todos discos lógicos do computador
            return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive }).ToList();
        }

        /// <summary>
        /// Pega os conteudos do topo do diretório
        /// </summary>
        /// <param name="fullPath">O caminho completo para o diretório</param>
        /// <returns></returns>
        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            // Cria uma lista vazia
            var items = new List<DirectoryItem>();

            #region Get Folders

            // Tenta pegar os diretórios da pasta
            // ignorando quaisquer problemas
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder }));
            }
            catch { }

            #endregion

            #region Get Files

            // Tenta pegar os diretórios da pasta
            // ignorando quaisquer problemas
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem { FullPath = file, Type = DirectoryItemType.File }));
            }
            catch { }

            #endregion

            return items;
        }

        #region Helpers

        /// <summary>
        /// Encontrar o arquivo ou o nome da pasta de um caminho completo
        /// </summary>
        /// <param name="path">The full path</param>
        /// <returns></returns>
        public static string GetFileFolderName(string path)
        {
            //  Se tiver nenhum caminho, retorna vazio
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            // Muda a direção das barrinhas da direita para a esquerda
            var normalizedPath = path.Replace('/', '\\');

            // Encontra a ultima barrinha a esquerda no caminho
            var lastIndex = normalizedPath.LastIndexOf('\\');

            // Se não encontrar a barrinha irá retornar o próprio caminho
            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }

        #endregion
    }
}
