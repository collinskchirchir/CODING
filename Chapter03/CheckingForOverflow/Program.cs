using System;
using static System.Console;

namespace CheckingForOverflow
{
    class Program
    {
        static void Main(string[] args)
        {
           
           for (int a = 0; a < 100; a++)
            {
               if(a % 3 == 0 & a % 5 == 0)
               {
                   Write("fizzbuzz");
               }
               else if(a % 5 == 0)
               {
                   Write("buzz");
               }
               else if(a % 3 == 0)
               {
                   Write("fizz");
               }
               else
               {
                    Write($"{a} ");  
               }
               // put a comma and space after every number except 100
                if (a < 100) Write(", ");

                if (a%10 == 0) WriteLine();
        
           }
        }
    }
}
