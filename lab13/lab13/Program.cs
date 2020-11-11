using System;
using System.IO;
using System.IO.Compression;

namespace lab13
{

    class MAVLog // задание 1
    {
        public static void WriteLog(string name)
        {
            using (StreamWriter st = new StreamWriter(@"MAVlog.txt", true))
            {
                st.WriteLine($"метод -  {name}  , вызван -  {DateTime.Now}");
            }
        }
    }

    static class MAVDiskInfo
    {
        public static void FreeSpace(string DN) // свободное место на диске
        {
            MAVLog.WriteLog("FreeSpace");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if (d.Name == DN)
                {
                    Console.WriteLine($"{ d.Name} - {d.TotalFreeSpace} bytes");
                }
            }
        }
        public static void TypeOfFileSystem(string DN) // информация о файловой системе
        {
            MAVLog.WriteLog("TypeOfFileSystem");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if (d.Name == DN)
                {
                    Console.WriteLine($"{d.Name} - {d.DriveFormat}");
                }
            }
        }
        public static void DrivesInfo()
        {
            MAVLog.WriteLog("DrivesInfo");
            var Driveinfo = DriveInfo.GetDrives();
            foreach (var d in Driveinfo)
            {
                if (d.IsReady) Console.WriteLine($"{d.Name} - {d.TotalFreeSpace} bytes / {d.TotalSize} bytes  -- {d.VolumeLabel}");
            } // имя объем достпуный объем метка тома
        }
    }

    public static class MAVFileInfo // c методами для вывода информации о конкретном файле
    {
        public static void FullPath(string Path)//полный путь
        {
            MAVLog.WriteLog("FullPath");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine(f.DirectoryName);
        }
        public static void FullInfo(string Path) // размер расширение имя
        {
            MAVLog.WriteLog("FullInfo");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine($"{f.Name} - {f.Extension} - {f.Length}");
        }
        public static void TimeOfCreation(string Path)// время создания
        {
            MAVLog.WriteLog("TimeOfCreation");
            FileInfo f = new FileInfo(Path);
            Console.WriteLine(f.CreationTime);
        }
    }

    public static class MAVDirInfo // c методами для вывода информации о конкретной директории

    {
        public static void GetFiles(string Path)// кол-во файлов
        {
            MAVLog.WriteLog("GetFiles");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach (var f in d.GetFiles()) Console.WriteLine(f.FullName);
        }
        public static void GetTime(string Path)// время создания
        {
            MAVLog.WriteLog("GetTime");
            DirectoryInfo d = new DirectoryInfo(Path);
            Console.WriteLine(d.CreationTime);
        }
        public static void GetSubDir(string Path)// кол-во поддиректориев
        {
            MAVLog.WriteLog("GetSubDir");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach (var f in d.GetDirectories()) Console.WriteLine(f.FullName);
        }
        public static void GetParentDir(string Path)// список род директориев
        {
            MAVLog.WriteLog("GetParentDir");
            DirectoryInfo d = new DirectoryInfo(Path);
            foreach (var f in d.Parent.GetDirectories()) Console.WriteLine(f.FullName);
        }
    }
    public static class MAVFileManager
    {
        public static void UltimateMethod(string Path)
        {
            MAVLog.WriteLog("UltimateMethod");
            DirectoryInfo d = new DirectoryInfo(Path);
            MAVDirInfo.GetFiles(Path);//прочитать список файлов
            MAVDirInfo.GetSubDir(Path);// и папок диска
            d.CreateSubdirectory("MAVInspect");// создаем директорию 
            var file = new FileInfo(Path + @"\MAVDirinfo.txt");//созд текстовый файл и сохр туда инфу
            FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
            byte[] arr = System.Text.Encoding.Default.GetBytes("kekekekekek");
            fs.Write(arr, 0, arr.Length);
            fs.Dispose();
            file.CopyTo(Path + @"\lol.txt", true);//созд копию и переименовать
            d.CreateSubdirectory("MAVFiles");//созд опять директорию
            foreach (var f in d.GetFiles())
            {
                if (f.Extension == ".txt" && f.Name != "lol.txt" && f.Name != "MAVLog.txt")// копируем туда все файла с заднным расширением
                    f.MoveTo(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1\MAVFiles" + @"\" + f.Name);
            }
            DirectoryInfo d1 = new DirectoryInfo(Path + @"\MAVFiles");
            d1.MoveTo(Path + @"\MAVInspect\MAVFiles");// удаляем первоначальный файл
            ZipFile.CreateFromDirectory(Path + @"\MAVInspect\MAVFiles", Path + @"\MAVInspect\zip.zip");//делаем архив 
            ZipFile.ExtractToDirectory(Path + @"\MAVInspect\zip.zip", Path);
            string[] s = File.ReadAllLines(Path + @"\MAVLog.txt");
            for (int i = 0; i < s.Length; i++)
            {
                Console.WriteLine(s[i]);
            }
            Console.WriteLine(s.Length + " Записей");//колво записей влогфайле
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i].Contains(DateTime.Now.Day.ToString()) && s[i].Contains("13:48"))
                    Console.WriteLine(s[i]);
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            MAVDiskInfo.FreeSpace("C:\\");
            MAVDiskInfo.TypeOfFileSystem("C:\\");
            MAVDiskInfo.DrivesInfo();
            Console.WriteLine(new string('-', 50));
            MAVFileInfo.FullPath(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1\lol.txt");
            MAVFileInfo.FullInfo(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1\lol.txt");
            MAVFileInfo.TimeOfCreation(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1\lol.txt");
            Console.WriteLine(new string('-', 50));
            MAVDirInfo.GetFiles(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1");
            MAVDirInfo.GetSubDir(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1");
            MAVDirInfo.GetTime(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1");
            MAVDirInfo.GetParentDir(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1");
            Console.WriteLine(new string('-', 50));
            MAVFileManager.UltimateMethod(@"C:\Users\KriSWhitch\OOP-2020Q3-4\lab13\lab13\bin\Debug\netcoreapp3.1");
        }
    }
}
