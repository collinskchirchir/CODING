using System;
using static System.Console;

namespace Exercise04
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Write("Write a number between 0 and 255: ");
            byte firstInput = byte.Parse(ReadLine());

            WriteLine();
            Write("Enter another number between 0 and 255: ");
            byte secondInput = byte.Parse(ReadLine());

            WriteLine($"{firstInput} divided by {secondInput} is {firstInput / secondInput}");
            }
            catch (OverflowException)
            {
                
                WriteLine("The value you entered is too large/small.");
            }
            catch (FormatException)
            {
                
                WriteLine("The value you entered is not valid.");
            }
            
        }
    }
}
