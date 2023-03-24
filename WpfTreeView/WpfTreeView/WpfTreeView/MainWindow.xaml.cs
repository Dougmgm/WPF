using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace WpfTreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor

        /// <summary>
        /// Construtor padrão
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion


        #region Folder Expanded

        /// <summary>
        /// Quando a pasta é expandida, encontrará as sub pastas/arquivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Folder_Expanded(object sender, RoutedEventArgs e)
        {
            #region Checkagem inicial

            var item = (TreeViewItem)sender;

            // Caso o item contenha apenas dados dummy
            if (item.Items.Count != 1 || item.Items[0] != null)
                return;

            // Limpar dados dummy
            item.Items.Clear();

            // Pegar o caminho completo
            var fullPath = (string)item.Tag;

            #endregion

            #region Pegar Pastas

            // Cria uma lista em branco para diretórios
            var directories = new List<string>();

            // Tenta pegar diretórios das pastas
            // ignorando quaisquer problemas ao fazer (não recomendado)
            try
            {
                var dirs = Directory.GetDirectories(fullPath);

                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch { }

            // Para cada diretório
            directories.ForEach(directoryPath =>
            {
                // Criar um item do diretório
                var subItem = new TreeViewItem()
                {
                    // Definir o header como nome da pasta
                    Header = GetFileFolderName(directoryPath),
                    // E o tag como o caminho completo
                    Tag = directoryPath
                };

                // Adiciona o item dummy para podermos expandir a pasta
                subItem.Items.Add(null);

                // Lida com a expansão 
                subItem.Expanded += Folder_Expanded;

                // Adiciona o item para o parente
                item.Items.Add(subItem);
            });

            #endregion

            #region Pegar Arquivos

            // Cria uma lista em branco para arquivos
            var files = new List<string>();

            // Tenta pegar os arquivos da pasta
            // ignorando quaisquer problemas ao fazer
            try
            {
                var fs = Directory.GetFiles(fullPath);

                if (fs.Length > 0)
                    files.AddRange(fs);
            }
            catch { }

            // Para cada arquivo...
            files.ForEach(filePath =>
            {
                // Create file item Criar um item do arquivo
                var subItem = new TreeViewItem()
                {
                    // Define o header como o nome do arquivo
                    Header = GetFileFolderName(filePath),
                    // Define o tag como o nome do caminho
                    Tag = filePath
                };

                // Adiciona esse item para o parente
                item.Items.Add(subItem);
            });

            #endregion
        }

        #endregion

        
    }
}