using System;
using static System.Console;

namespace IterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            //WHILE ITERATION STATEMENT
            int x = 0;
            while (x < 10)
            {
                Write($"{x}, ");
                x++;
            }

            //DO WHILE ITERATION STATEMENT
            string password = string.Empty;
            do
            {
                Write("Enter your password: ");
                password = ReadLine();
            }
            while (password != "Pa$$word");
            WriteLine("Correct!");

            //FOR ITERATION STATEMENT
            for (int y = 1; y <= 10; y++)
            {
                Write(y);
            }

            //FOREACH ITERATION STATEMENT
            string[] names = {"Adam", "Barry", "Charlie"};
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }


        }
    }
}
