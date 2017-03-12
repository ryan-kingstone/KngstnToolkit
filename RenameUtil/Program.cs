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
            var title = typeof(Program).Namespace;
            if (title != null) Console.Title = title;

            Console.WriteLine("Select the folder you wish to run the RenameUtil tool on.");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
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
                    if (File.Exists(file))
                    {
                        var extension = Path.GetExtension(file);
                        if (extension != null)
                        {
                            var originalFileName = Path.GetFileName(file);

                            if (IsImageOrVideoFile(file))
                            {
                                if (originalFileName != null && !originalFileName.StartsWith("MEDIA"))
                                {
                                    var creationTime = File.GetCreationTime(file);
                                    var newName = Path.GetDirectoryName(file) + "\\" +
                                                  $"MEDIA_{creationTime.Day.ToString().PadLeft(2, '0')}-{creationTime.Month.ToString().PadLeft(2, '0')}-{creationTime.Year.ToString().PadLeft(2, '0')}_{creationTime.Hour.ToString().PadLeft(2, '0')}-{creationTime.Minute.ToString().PadLeft(2, '0')}-{RandomString(4)}{extension}";
                                    if (!File.Exists(newName))
                                    {
                                        File.Move(file, newName);
                                        Console.WriteLine($"------ Renaming ({file}) to {newName}");

                                        RenamedFileCounter++;
                                    }
                                    else Console.WriteLine($"File (old: {file}) {newName} exists already.");
                                }
                                else
                                {
                                    Console.WriteLine($"Skipping {file} since it seems to follow the format already.");
                                }
                            } else
                            {
                                Console.WriteLine($"---- Skipping {file}.");
                            }
                        } else
                        {
                            Console.WriteLine($"ERROR - File {file} did not have extension information");
                        }
                    } else Console.WriteLine($"ERROR - File exists at {file}.");
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

        public static string RandomString(int length)
        {
            var random = new Random(DateTime.Now.GetHashCode());

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
