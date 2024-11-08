extern alias Tools;
using Tools::DelegatesAndEvents;

namespace ParalelRead
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseConsoleActions.PrepareConsole(Const.Title);

            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            ConsoleMenu menu = new ConsoleMenu(Const.Menu)
            {
                MenuItems =
                {
                    new ConsoleMenuItem(Const.GenMenuItem, 0, (s, e) => { FilesGenerator(); }),
                    new ConsoleMenuItem(Const.ReadFilesMenuItem, 0, (s, e) => { CheckFileLoadByFolder(); }),
                    new ConsoleMenuItem(Const.Exit, 0, (s, e) => { Environment.Exit(0); }),
                }
            };
            menu.OnItemAdded += (sender, e) =>
            {
                menu.DisplayMenu();
            };
            menu.DisplayMenu();
        }

        private  static void FilesGenerator(string folderPath = "")
        {
            Console.Clear();
            folderPath = string.IsNullOrEmpty(folderPath) ? BaseConsoleActions.AskForValidDirectoryPath() : folderPath;
            FileGenerator.ClearDirectory(folderPath);
            FileGenerator.GenerateTextFilesInDirectory(folderPath);

            var filePaths = FileGenerator.GetAllTxtFilesInDirectory(folderPath);
            Console.WriteLine(Const.GenComplited);
            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }

        private async static void CheckFileLoadByFolder(string folderPath = "")
        {
            Console.Clear();
            folderPath = string.IsNullOrEmpty(folderPath) ? BaseConsoleActions.AskForValidDirectoryPath() : folderPath;

            await FileSpaceCounter.MeasureTotalTimeAsync(async () =>
            {
                int spacesInFolder = await FileSpaceCounter.CountSpaceInFolderAsync(folderPath);
                Console.WriteLine();
                Console.Write($"{Const.CountSpace} {spacesInFolder}");
            });

            BaseConsoleActions.PressAnyToContinue(ShowMainMenu);
        }
    }
}
