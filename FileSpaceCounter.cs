using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalelRead
{
    public class FileSpaceCounter
    {
        public static async Task<int> CountSpaceInFilesAsync(string[] filePaths)
        {
            if (filePaths.Length != 3)
                throw new ArgumentException($"{Const.ExceptionCountFile}", nameof(filePaths));
            var tasks = filePaths.Select(CountSpaceInFileWithTimeAsync).ToArray();
            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        public static async Task<int> CountSpaceInFolderAsync(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"{Const.ExceptionDPath} {folderPath}");
            var filePaths = Directory.GetFiles(folderPath, Const.Extension);
            if (filePaths.Length == 0)
                return 0;
            var tasks = filePaths.Select(CountSpaceInFileWithTimeAsync).ToArray();
            Console.WriteLine();
            var results = await Task.WhenAll(tasks);
            return results.Sum();
        }

        private static async Task<int> CountSpaceInFileWithTimeAsync(string filePath)
        {
            Console.WriteLine($"{Const.StartRead} {filePath}");
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"{Const.ExceptionFileNotFound}{filePath}");
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var content = await File.ReadAllTextAsync(filePath);
            int spaceCount = content.Count(c => c == ' ');
            stopwatch.Stop();
            Console.WriteLine($"Файл: {Path.GetFileName(filePath)}, Время чтения: {stopwatch.ElapsedMilliseconds} мс, Кол-во пробелов: {spaceCount}");
            return spaceCount;
        }

        public static async Task MeasureTotalTimeAsync(Func<Task> action)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await action();
            stopwatch.Stop();
            Console.Write($"; Общее время выполнения: {stopwatch.ElapsedMilliseconds} мс");
        }
    }
}
