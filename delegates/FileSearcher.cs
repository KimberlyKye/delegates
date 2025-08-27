namespace delegates
{
    /// <summary>
    /// Класс для поиска файлов в директориях с использованием событий
    /// </summary>
    public class FileSearcher
    {
        /// <summary>
        /// Событие, возникающее при нахождении каждого файла
        /// </summary>
        public event EventHandler<FileArgs>? FileFound;

        /// <summary>
        /// Выполняет поиск файлов в указанной директории и её поддиректориях
        /// </summary>
        /// <param name="directoryPath">Путь к директории для поиска</param>
        public void SearchFiles(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Console.WriteLine($"Директория {directoryPath} не существует");
                return;
            }

            try
            {
                SearchDirectory(directoryPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при поиске файлов: {ex.Message}");
            }
        }

        /// <summary>
        /// Рекурсивно обходит директорию и её поддиректории
        /// </summary>
        /// <param name="directory">Путь к директории для обхода</param>
        private void SearchDirectory(string directory)
        {
            foreach (var file in Directory.GetFiles(directory))
            {
                var args = new FileArgs(Path.GetFileName(file));
                OnFileFound(args);

                if (args.CancelSearch)
                {
                    Console.WriteLine("Поиск отменен пользователем");
                    return;
                }
            }

            foreach (var subDirectory in Directory.GetDirectories(directory))
            {
                SearchDirectory(subDirectory);
            }
        }

        /// <summary>
        /// Вызывает событие FileFound
        /// </summary>
        /// <param name="args">Аргументы события</param>
        protected virtual void OnFileFound(FileArgs args)
        {
            FileFound?.Invoke(this, args);
        }
    }
}