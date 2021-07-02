using Bier.Models;
using Bier.ServicesAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bier.Terminal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            DrinkRepository repo = new DrinkRepository();

            Drink drink = new Drink() { Name = "Chimay", AlcoholIntensity = 8, Color = DrinkColors.Brown, Type = DrinkTypes.Trappist, BrewerId = 1 };
            drink = repo.Insert(drink);

            Console.WriteLine(drink.Id);

            IEnumerable<Drink> drinks = repo.Get();
            foreach (Drink d in drinks)
            {
                Console.WriteLine(d.Name);
            }
        }
    }
}
