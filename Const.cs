using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParalelRead
{
    public class Const
    {
        public static readonly string Title = "Параллельное считывание файлов";
        public static readonly string Menu = "Меню";
        public static readonly string GenMenuItem = "Генерация в папке тестовых данных";
        public static readonly string ReadFilesMenuItem = "Прочитать файлы из папки";
        public static readonly string Exit = "Выход";
        public static readonly string GenComplited = "Файлы сгенерированы";
        public static readonly string CountSpace =  "Количество пробелов во всех файлах папки:";
        public static readonly string ExceptionCountFile = "Необходимо передать три файла.";
        public static readonly string ExceptionDPath = "Директория не найдена:";
        public static readonly string StartRead = "Начато чтение:";
        public static readonly string ExceptionFileNotFound = "Файл не найден: ";

        public static readonly string FirstFileName = "First.txt";
        public static readonly string SecondFileName = "Second.txt";
        public static readonly string ThirdFileName = "Third.txt";

        public static readonly int FirstCount = 1000;
        public static readonly int SecondCount = 100000;
        public static readonly int ThirdCount = 10000000;

        public static readonly string Extension = "*.txt";

    }
}
