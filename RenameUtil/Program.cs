using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using ExifLib;

namespace RenameUtil
{
    class Program
    {
        public static int RenamedFileCounter = 0;

        [STAThread]
        static void Main(string[] args)
        {
            var title = typeof(Program).Namespace;
            if (title != null) Console.Title = title;

            Console.WriteLine("Select the folder you wish to run the RenameUtil tool on.");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.RootFolder = Environment.SpecialFolder.MyComputer;
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                RenameFiles(dialog.SelectedPath);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{RenamedFileCounter} files renamed.");
                MessageBox.Show($"{RenamedFileCounter} files renamed.");
            } else Console.WriteLine("No folder selected.");

            Console.ReadLine();
        }

        public static void RenameFiles(string path)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(path);

                var folders = Directory.EnumerateDirectories(path);

                foreach (var folder in folders)
                {
                    RenameFiles(folder);
                }

                var files = Directory.EnumerateFiles(path);

                Console.ForegroundColor = ConsoleColor.White;

                foreach (var file in files)
                {
                    Console.WriteLine($"---------> {file}.");

                    var extension = Path.GetExtension(file);
                    if (extension != null)
                    {
                        var originalFileName = Path.GetFileName(file);

                        if (originalFileName != null && !originalFileName.StartsWith("MEDIA"))
                        {
                            HandleFile(file);
                        }
                        else
                        {
                            Console.WriteLine($"Skipping {file} since it seems to follow the format already.");
                        }
                    } else
                    {
                        Console.WriteLine($"ERROR - File {file} did not have extension information");
                    }
                }
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex);
            }

        }

        public static void HandleFile(string path)
        {
            var extension = Path.GetExtension(path);
            var originalFileName = Path.GetFileName(path);

            if (!File.Exists(path))
            {
                Console.WriteLine($"[Error] File doesn't exist at {path}");
                return;
            }

            if (extension == null)
            {
                Console.WriteLine($"[Error] Extension at {path} was invalid.");
                return;
            }

            if (GetFileType(path) == FileType.NonRecognized)
            {
                Console.WriteLine($"[Error] File at {path} is not a recognized image or format.");
                return;
            }

            DateTime createDateTime;

            createDateTime = GetDateTime(path);

            if (createDateTime != default(DateTime))
            {

                var newName = Path.GetDirectoryName(path) + "\\" +
              $"MEDIA_{createDateTime.Day.ToString().PadLeft(2, '0')}-{createDateTime.Month.ToString().PadLeft(2, '0')}-{createDateTime.Year.ToString().PadLeft(2, '0')}_{createDateTime.Hour.ToString().PadLeft(2, '0')}-{createDateTime.Minute.ToString().PadLeft(2, '0')}-{RandomString(4)}{extension}";
                if (!File.Exists(newName))
                {
                    if (path != newName)
                    {
                        FileInfo fileInfo = new FileInfo(path);

                        if (fileInfo.Exists)
                        {
                            File.Move(path, newName);
                            Console.WriteLine($"------ Renaming ({path}) to {newName}");

                            RenamedFileCounter++;
                        }
                        else Console.WriteLine($"File (old: {path}) {newName} exists already.");
                    }
                }

            }
            else
            {
                // Use the default date
                Console.WriteLine($"[Error] File at {path} does not have a valid EXIF datetime.");
                return;
            }

        }

        public static DateTime GetDateTime(string path)
        {
            DateTime photoDateTime = new DateTime();
            var extension = GetFileType(path);

            switch (extension)
            {
                    case FileType.ImageWithExif:
                    photoDateTime = GetJpgDateTime(path);
                    break;

                    case FileType.Image:
                    case FileType.Video:
                    case FileType.Audio:
                    photoDateTime = File.GetCreationTime(path);
                    break;
            }

            return photoDateTime;
        }

        public static DateTime GetJpgDateTime(string path)
        {
            DateTime datePictureTaken;
            datePictureTaken = DateTime.Now;
            try
            {
                using (ExifReader reader = new ExifReader(path))
                {

                    reader.GetTagValue(ExifTags.DateTimeDigitized, out datePictureTaken);

                    return datePictureTaken;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Error] File at {path} does not carry the DateTime EXIF data. / USING WRONG DATE!");
                Console.WriteLine(ex);
                return datePictureTaken;
            }
        }

        public static bool IsImage(string path)
        {
            if (File.Exists(path))
            {
                var imageFileTypes = new[] { ".jpg", ".jpeg", ".png" };

                var extension = Path.GetExtension(path);
                if (extension != null)
                {
                    if (imageFileTypes.Contains(extension.ToLower()))
                    {
                        return true;
                    }
                    return false;
                }
                return false;
            }
            else throw new FileNotFoundException($"Unable to handle file at path [{path}] since it's missing.");
        }

        public static FileType GetFileType(string path)
        {
            var extension = Path.GetExtension(path);
            var imageFileTypesNoExif = new[] { ".png" };
            var imageFileTypes = new[] { ".jpg", ".jpeg" };
            var videoFileTypes = new[] { ".mp4", ".gif", ".mov", ".webm" };
            var audioFileTypes = new[] { ".mp3", ".wav" };

            if (extension != null)
            {
                if (imageFileTypesNoExif.Contains(extension.ToLower()))
                {
                    return FileType.Image;
                }

                if (imageFileTypes.Contains(extension.ToLower()))
                {
                    return FileType.ImageWithExif;
                }

                if (videoFileTypes.Contains(extension.ToLower()))
                {
                    return FileType.Video;
                }

                if (audioFileTypes.Contains(extension.ToLower()))
                {
                    return FileType.Audio;
                }
            }

            return FileType.NonRecognized;
        }

        public static string RandomString(int length)
        {
            var random = new Random(DateTime.Now.GetHashCode());

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }

    public enum FileType
    {
        NonRecognized,
        ImageWithExif,
        Image,
        Video,
        Audio
    }
}
