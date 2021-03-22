using System;
using System.Collections.Generic;
namespace Packt.Shared
{
   public class ThingsOfDefaults
   {
      public int Population;
      public DateTime When;
      public string Name;
      public List<Person> People;
      public ThingsOfDefaults()
      {
         Population = default;// C# 7.1 and later
         When =default;
         Name = default;
         People = default;         
      }
   }
}