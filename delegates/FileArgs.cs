using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace delegates
{

    /// <summary>
    /// Аргументы события нахождения файла, содержащие информацию о файле
    /// </summary>
    public class FileArgs : EventArgs
    {
        /// <summary>
        /// Имя найденного файла
        /// </summary>
        public string FileName { get; }

        /// <summary>
        /// Флаг отмены дальнейшего поиска файлов
        /// </summary>
        public bool CancelSearch { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса FileArgs
        /// </summary>
        /// <param name="fileName">Имя файла</param>
        public FileArgs(string fileName)
        {
            FileName = fileName;
            CancelSearch = false;
        }

    }
}