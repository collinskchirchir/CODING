using System;
using static System.Console;

namespace WritingFunctions
{
    class Program
    {   
        static decimal CalculateTax(decimal amount, string twoLetterRegionCode)
        {
            decimal rate = 0.0M;
            switch (twoLetterRegionCode)
            {
                case "CH":
                    rate = 0.08M;
                    break;
                case "DK":
                case "NO":
                    rate = 0.25M;
                    break;
                case "GB":
                case "FR":
                    rate = 0.2M;
                    break;
                case "HU":
                    rate = 0.27M;
                    break;
                case "OR":
                case "AK":
                case "MT":
                    rate = 0.0M;
                    break;
                case "ND":
                case "WI":
                case "ME":
                case "VA":
                    rate = 0.05M;
                    break;
                case "CA":
                    rate = 0.0825M;
                    break;
                default: //most of US States
                    rate = 0.06M;
                    break;
            }
            return amount * rate;
        }
        
        static void RunCalculateTax()
        {
            //prompts user to input amt and region code, then calls CalculateTax function & outputs results
            Write("Enter an amount: ");
            string amountInText = ReadLine();
            Write("Enter a two-letter region code: ");
            string region  = ReadLine();
            if (decimal.TryParse(amountInText, out decimal amount))
            {
                decimal taxToPay = CalculateTax(amount, region);
                WriteLine($"You must pay {taxToPay} in sales tax.");
            }
            else
            {
                WriteLine("You didnt enter a valid amount!");
            }

        }
        /// <summary>
        /// Pass a 32-bit integer and it will be converted into its ordinal equivalent.
        /// </summary>
        /// <param name="number">Number is a cardinal value e.g. 1, 2, 3, and so on.</param>
        /// <returns>Number as an ordinal value e.g. 1st, 2nd, 3rd, and so on.</returns>
        static string CardinalToOrdinal(int number)
        {
          switch(number)
          {
              case 11: //special cases for 11th and 13th
              case 12:
              case 13:
                return $"{number}th";
              default:
              int lastDigit = number % 10;
              string suffix = lastDigit switch{
                  1 => "st",
                  2 => "nd",
                  3 => "rd",
                  _ => "th"
              };
                return $"{number}{suffix}";
            }  
        }
        static void RunCardinalToOrdinal()
        {
            for (int number = 1; number <= 40; number++)
            {
                Write($"{CardinalToOrdinal(number)}");
                if(number <40) {Write(", ");}
            }
            WriteLine();
        }
        static long Factorial (long number)
        {
            if (number < 1)
            {
                return 0;
            }
            else if (number == 1)
            {
                return 1;
            }
            else
            {
                checked
                {
                    return number * Factorial(number - 1);
                }
            }
        }
        static void RunFactorial ()
        {
            for (long i = 1; i < 15; i++)
            {
                WriteLine($"{i}! = {Factorial(i):N0}");
            }
        }
        /// <summary>
        /// Declarative Function used calculate the Fibonacci Sequence for numbers provided
        /// </summary>
        /// <param name="term">int values e.g 1, 2, 3, etc</param>
        /// <returns>An int value as Fibonacci sequence</returns>
        static int FibImperative (int term)
        {
            if (term == 1)
            {
                return 0;
            }
            else if (term ==2)
            {
                return 1;
            }
            else
            {
                return FibImperative(term -1) + FibImperative(term-2);
            }
        }
          static int FibFunctional (int term) =>
            term switch
            {
                1 => 0,
                2 => 1,
                _ => FibFunctional(term -1) + FibFunctional(term -2)
            };
        static void RunFibImperative()
        {
            for(int i = 1; i <=30; i++)
            {
                WriteLine("The {0} term of the Fibonacci sequence is {1:N0}.",
                arg0: CardinalToOrdinal(i),
                arg1: FibFunctional(i));
            }
        }
      
        static void Main(string[] args)
        {
         //RunCardinalToOrdinal();  
         RunFibImperative();
        }
    }
}
