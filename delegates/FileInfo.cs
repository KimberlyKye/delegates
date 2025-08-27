using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace delegates
{

    /// <summary>
    /// Вспомогательный класс для демонстрации, представляющий информацию о файле
    /// </summary>
    public class FileInfo
    {
        /// <summary>
        /// Имя файла
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Размер файла в байтах
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Инициализирует новый экземпляр класса FileInfo
        /// </summary>
        /// <param name="name">Имя файла</param>
        public FileInfo(string name)
        {
            Name = name;
        }
    }
}