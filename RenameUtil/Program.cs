using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace RenameUtil
{
    class Program
    {
        public static int RenamedFileCounter = 0;

        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;

            Console.WriteLine("Select the folder you wish to run the RenameUtil tool on.");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            if (dialog.SelectedPath != "")
            {
                RenameFiles(dialog.SelectedPath);
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{RenamedFileCounter} files renamed.");
            MessageBox.Show($"{RenamedFileCounter} files renamed.");

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
                    if (File.Exists(file))
                    {
                        var extension = Path.GetExtension(file);
                        if (extension != null)
                        {
                            var originalFileName = Path.GetFileName(file);

                            if (IsImageOrVideoFile(file))
                            {
                                var creationTime = File.GetCreationTime(file);
                                var newName = Path.GetPathRoot(file) + $"MEDIA_{creationTime.Day}-{creationTime.Month}-{creationTime.Day}-T{creationTime.Hour}-{creationTime.Minute}{extension}";
                                if (!File.Exists(newName))
                                {
                                    File.Move(file, newName);
                                    Console.WriteLine($"------ Renaming to {newName}");
                                }
                            } else
                            {
                                Console.WriteLine($"---- Skipping {file}.");
                            }
                        } else
                        {
                            Console.WriteLine($"ERROR - File {file} did not have extension information");
                        }
                    }

                    RenamedFileCounter++;
                }
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex);
            }

        }

        public static bool IsImageOrVideoFile(string path)
        {
            if (File.Exists(path))
            {
                var imageFileTypes = new[] { ".jpg", ".jpeg", ".png", ".gif", ".mp4" };

                var extension = Path.GetExtension(path);

                if (imageFileTypes.Contains<string>(extension.ToLower()))
                {
                    return true;
                }
                else return false;
            }
            else throw new System.IO.FileNotFoundException($"Unable to handle file at path [{path}] since it's missing.");
        }
    }
}
