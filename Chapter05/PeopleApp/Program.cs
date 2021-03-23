using System;
using Packt.Shared;
using static System.Console;

namespace PeopleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            WriteLine(format:"{0} was born on {1:dddd,d MMMM yyyy}",
            arg0: bob.Name,
            arg1: bob.DateOfBirth);

            //
            var alice = new Person{
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };
            WriteLine(format: "{0} was born on {1:dd MMM yy}",
            arg0: alice.Name,
            arg1: alice.DateOfBirth);

            bob.FavouriteAncientWonder = WondersOfTheAncientWorld.StatueOfZeusAtOlympia;
            WriteLine(format:"{0}'s favourite wonder is {1}. Its interger is {2}.",
            arg0: bob.Name,
            arg1: bob.FavouriteAncientWonder,
            arg2: (int)bob.FavouriteAncientWonder);

            //bob.BucketList = WondersOfTheAncientWorld.MausoleumAtHalicarnassus | WondersOfTheAncientWorld.HangingGardensOfBabylon;
            bob.BucketList = (WondersOfTheAncientWorld)18;
            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            bob.Children.Add(new Person {Name = "Alfred"});
            bob.Children.Add(new Person{Name = "Zoe"});
            WriteLine($"{bob.Name} has {bob.Children.Count} children.");

            for(int child = 0; child < bob.Children.Count; child++)
            {
                WriteLine($"{bob.Children[child].Name}");
            }
            
            //Making a field static
            BankAccount.InterestRate = 0.012M; //store a shared value
            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;
            WriteLine(format: "{0} earned {1:C} interest",
            arg0: jonesAccount.AccountName,
            arg1: jonesAccount.Balance * BankAccount.InterestRate
            );

            //Making a field constant
            WriteLine($"{bob.Name} is a {Person.Species} and PI constant is {Math.PI}.");

            //Making a field Read-only
            WriteLine($"{bob.Name} was born on {bob.HomePlanet}.");

            //Initializing fields with constructors
            var blankPerson = new Person();
            WriteLine(format:"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: blankPerson.Name,
            arg1: blankPerson.HomePlanet,
            arg2: blankPerson.Instantiated);

            var gunny = new Person("Gunny","Mars");
            WriteLine(format:"{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
            arg0: gunny.Name,
            arg1: gunny.HomePlanet,
            arg2: gunny.Instantiated);

            //Returnig values from methods
            bob.WriteToConsole();
            WriteLine(bob.GetOrigin());

            //call tuple method
            (string, int) fruit = bob.GetFruit();
            WriteLine($"{fruit.Item1}, {fruit.Item2} there are.");

            //Naming fields of a tuple
            var fruitNamed = bob.GetFruit();
            WriteLine($"There are {fruitNamed.Number} {fruitNamed.Name}");

            //infering tuple names
            var things1 = ("Neville",4);
            WriteLine($"{things1.Item1} has {things1.Item2} children");
            var thing2 = (bob.Name, bob.Children.Count);
            WriteLine($"{thing2.Name} has {thing2.Count} children.");

            //Deconstructin tuples
            

            // deconstruct return value into two separate variables
            (string fruitName, int fruitNumber) = bob.GetFruit();
            WriteLine($"Deconstructed: {fruitName}, {fruitNumber}");
            // fruitName
            // fruitNumber

            //Defining and Passing Parameters to methods
            WriteLine(bob.SayHello());
            WriteLine(bob.SayHello("Emily"));

            //Passing Optional Parameters & Naming Arguments
            WriteLine(bob.OptionalParameters(number: 98.33, command: "Alright!"));

            //Controlling how parameters are passed
            int a = 10;
            int b = 20;
            int c = 30;
            WriteLine($"Before: a = {a}, b = {b}, c = {c}");
            bob.PassingParameters(a, ref b, out c);
            WriteLine($"After: a = {a}, b = {b}, c = {c}");

            int d = 10;
            int e = 20;
            WriteLine($"Before: d = {d}, e = {e}, f doesn't exist yet!");
            //simplified C# 7.0 syntax for out parameter
            bob.PassingParameters(d, ref e, out int f);
            WriteLine($"After: d = {d}, e = {e}, f = {f}");

            //Access Control with Properties & Indexers
            var sam = new Person {Name = "Sam", DateOfBirth = new DateTime(1972, 1, 27)};
            WriteLine(sam.Origin);
            WriteLine(sam.Greeting);
            WriteLine(sam.Age);

            //Defining Settable Properties
            sam.FavouriteIceCream = "Chocolate Fudge";
            WriteLine($"Sam's favourite ice-cream floavor is {sam.FavouriteIceCream}.");
            sam.FavouritePrimaryColor = "GREen";
            WriteLine($"Sam's favourite primary color is {sam.FavouritePrimaryColor}");
            
            //Defining Indexers
            sam.Children.Add(new Person {Name = "Charlie"});
            sam.Children.Add(new Person {Name = "Ella"});
            WriteLine($"Sam's first child is {sam.Children[0].Name}");
            WriteLine($"Sam's second child is {sam.Children[1].Name}");

            //Pattern matching with Objects
            object[] passengers = {
                new FirstClassPassenger {AirMiles = 1_419},
                new FirstClassPassenger {AirMiles = 16_562},
                new BusinessClassPassenger(),
                new CoachClassPassenger { CarryOnKG = 25.7},
                new CoachClassPassenger { CarryOnKG = 0}
            };
            foreach ( object passenger in passengers)
            {
                decimal flightCost = passenger switch 
                {
                    /*C# 8 Syntax
                    FirstClassPassenger p when p.AirMiles > 35000 => 1500M,
                    FirstClassPassenger p when p.AirMiles > 15000 => 1750M,
                    FirstClassPassenger _                           =>2000M,*/

                    //C# 9 Syntax
                    FirstClassPassenger p => p.AirMiles switch
                    {
                        > 35000 => 1500M,
                        > 15000 => 1750M,
                        _ => 2000M
                    },
                    BusinessClassPassenger _                        =>1000M,
                    CoachClassPassenger p when p.CarryOnKG < 10.0   => 500M,
                    CoachClassPassenger _                           => 650M,
                    _                                               => 800M
                };
                WriteLine($"Flight Costs {flightCost:C} for {passenger}");
                
                //Records (New Lang feature in C# 9)
                // 1. Init-only properties
                var jeff = new ImmutablePerson { FirstName = "Jeff", LastName = "Winger"};
                jeff.FirstName = "Geoff";
               

                
            }

        }
    }
}
