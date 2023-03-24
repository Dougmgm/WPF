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
