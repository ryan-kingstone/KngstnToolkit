using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RenameUtil
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Title = typeof(Program).Namespace;

            Console.WriteLine("Select the folder you wish to run the RenameUtil tool on.");

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();
            RenameFiles(dialog.SelectedPath);
            Console.ReadLine();
        }

        public static void RenameFiles(string path)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(path);

                var folders = System.IO.Directory.EnumerateDirectories(path);

                foreach (var folder in folders)
                {
                    RenameFiles(folder);
                }

                var files = System.IO.Directory.EnumerateFiles(path);

                int counter = 0;

                Console.ForegroundColor = ConsoleColor.White;

                foreach (var file in files)
                {
                    Console.WriteLine($"---------> {file}.");

                    counter++;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{counter} files renamed.");
                MessageBox.Show($"{counter} files renamed.");
            } catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(ex);
            }

        }
    }
}
