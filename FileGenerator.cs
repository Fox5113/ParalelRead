using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalelRead
{
    internal class FileGenerator
    {
        public static void GenerateTextFilesInDirectory(string path)
        {
            if (!Directory.Exists(path)) Directory.CreateDirectory(path);
            ReplaceTextFile(Path.Combine(path, Const.FirstFileName), Const.FirstCount);
            ReplaceTextFile(Path.Combine(path, Const.SecondFileName), Const.SecondCount);
            ReplaceTextFile(Path.Combine(path, Const.ThirdFileName), Const.ThirdCount);
        }

        public static void ReplaceTextFile(string filePath, int wordCount)
        {
            if (File.Exists(filePath)) File.Delete(filePath);
            StringBuilder contentBuilder = new StringBuilder();
            for (int i = 1; i <= wordCount; i++)
            {
                contentBuilder.Append($"word{i} ");
            }

            File.WriteAllText(filePath, contentBuilder.ToString());
        }

        public static string[] GetAllTxtFilesInDirectory(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                string[] txtFiles = Directory.GetFiles(folderPath, Const.Extension);
                return txtFiles;
            }
            else
                return Array.Empty<string>();
        }

        public static void ClearDirectory(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                foreach (string filePath in Directory.GetFiles(folderPath))
                {
                    File.Delete(filePath);
                }

                foreach (string directory in Directory.GetDirectories(folderPath))
                {
                    Directory.Delete(directory, true);
                }
            }
        }
    }
}
