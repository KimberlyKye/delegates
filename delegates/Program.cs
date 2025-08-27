using delegates;
using FileInfo = delegates.FileInfo;

/// <summary>
/// Главный класс программы для демонстрации работы делегатов и событий
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в приложение
    /// </summary>
    /// <param name="args">Аргументы командной строки</param>
    static void Main(string[] args)
    {
        Console.WriteLine("=== Демонстрация функции расширения GetMax ===");
        DemoGetMaxExtension();

        Console.WriteLine("\n=== Демонстрация поиска файлов с событиями ===");
        DemoFileSearch();
    }

    /// <summary>
    /// Демонстрирует работу функции расширения GetMax
    /// </summary>
    static void DemoGetMaxExtension()
    {
        // Создаем коллекцию файлов с информацией о размере
        var files = new List<FileInfo>
        {
            new FileInfo("file1.txt") { Length = 1024 },
            new FileInfo("file2.txt") { Length = 2048 },
            new FileInfo("file3.txt") { Length = 512 },
            new FileInfo("file4.txt") { Length = 4096 }
        };

        // Используем нашу функцию расширения
        var largestFile = files.GetMax(f => f.Length);

        Console.WriteLine($"Самый большой файл: {largestFile?.Name}, размер: {largestFile?.Length} байт");

        // Другой пример - поиск самой длинной строки
        var strings = new List<string> { "короткая", "средняя строка", "очень длинная строка", "средняя" };
        var longestString = strings.GetMax(s => s.Length);

        Console.WriteLine($"Самая длинная строка: '{longestString}' (длина: {longestString?.Length})");
    }

    /// <summary>
    /// Демонстрирует работу поиска файлов с использованием событий
    /// </summary>
    static void DemoFileSearch()
    {
        var searcher = new FileSearcher();

        // Подписываемся на событие
        searcher.FileFound += (sender, e) =>
        {
            Console.WriteLine($"Найден файл: {e.FileName}");

            // Пример условия для отмены поиска
            if (e.FileName.EndsWith(".txt"))
            {
                Console.WriteLine("Найден txt файл - отменяем поиск");
                e.CancelSearch = true;
            }
        };

        // Запускаем поиск в текущей директории
        string currentDirectory = Directory.GetCurrentDirectory();
        Console.WriteLine($"Поиск файлов в: {currentDirectory}");

        searcher.SearchFiles(currentDirectory);
    }
}
