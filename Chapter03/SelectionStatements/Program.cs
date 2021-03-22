using System;
using System.IO;
using static System.Console;

namespace SelectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\ENVY\Documents\Data _ Cross Platform Apps\Chapter03";
            Write("Press R for readonly or W for Write: ");
            ConsoleKeyInfo key = ReadKey();
            WriteLine();

            Stream s = null;

            if (key.Key == ConsoleKey.R)
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Read);
            }
            else
            {
                s = File.Open(
                    Path.Combine(path, "file.txt"),
                    FileMode.OpenOrCreate,
                    FileAccess.Write);
            }

            string message = string.Empty;

            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                => "The stream is a file that I can write to.",
                FileStream readOnlyFile
                => "The stream is a read-only file.",
                MemoryStream ms
                => "The stream is a memory address.",
                null
                => "The stream is null.",
                _
                => "The stream is some other type."
            };
            
            WriteLine(message);


        }
    }
}
