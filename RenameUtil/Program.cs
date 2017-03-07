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
            Console.WriteLine(dialog.SelectedPath);
            Console.ReadLine();
        }

        public void RenameFiles(string path)
        {
            try
            {
                var files = System.IO.Directory.EnumerateFiles(path);

                int counter = 0;

                foreach(var file in files)
                {
                    Console.WriteLine("File: {file} - renaming.");

                    counter++;
                }
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
