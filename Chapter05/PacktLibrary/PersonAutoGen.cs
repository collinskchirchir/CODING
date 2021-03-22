namespace Packt.Shared
{
   public partial class Person
   {
      //TOPIC: Controlling Access with Properties & Indexers
      //SUB-TOPIC: Defining Read-only Properties
      // a property defined using C# 1 - 5 syntax
      public string Origin 
      {
         get
         {
            return $"{Name} was born on {HomePlanet}";
         }
      }
      //2 Properties defined using C# 6+ Lambda Expression Syntax
      public string Greeting => $"{Name} says 'Hello!'";
      public int Age => System.DateTime.Today.Year - DateOfBirth.Year;

      //Defining Settable Properties
      public string FavouriteIceCream { get; set;} //auto-syntax
      private string favouritePrimaryColor;
      public string FavouritePrimaryColor
      {
         get
         {
            return favouritePrimaryColor;
         }
         set
         {
            switch(value.ToLower())
            {
               case "red":
               case "green":
               case "blue":
                  favouritePrimaryColor = value;
                  break;
               default: 
                  throw new System.ArgumentException($"{value} is not a primary color. " + "Choose from: red, green, blue.");
            }
         }
      }
      //Defining Indexers
      public Person this[int index]
      {
         get {return Children[index];}
         set {Children[index] = value;}
      }
       
   }
}