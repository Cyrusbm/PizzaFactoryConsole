using ConsoleTables;
using PizzaFactory.Application.Interfaces;
using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaFactory.UI.Program;

namespace PizzaFactory.UI
{
    public static class ToppingPage
    {
        public static IToppingService ToppingService;
        static Dictionary<ConsoleKey, Func<Menu>> menuItems = new Dictionary<ConsoleKey, Func<Menu>>()
            {
                { ConsoleKey.F1, ShowToppings},
                { ConsoleKey.F2, AddTopping},
                { ConsoleKey.F3, EditTopping},
                { ConsoleKey.F4, DeleteTopping},
                {ConsoleKey.F12,MainPage.ShowMainPage}
           };

        public static Menu ShowToppings()
        {
            Console.WriteLine("------------------------  Topping Page  -----------------------");

            IEnumerable<Topping> toppings = ToppingService.GetToppings();

            var table = new ConsoleTable("Id", "Name", "Price");
            foreach (var t in toppings)
            {
                table.AddRow(t.Id, t.Title, t.Price);
            }
            table.Write();


            ShowMenuItems();


            var key = Console.ReadKey().Key;

            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static void ShowMenuItems()
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------     Menu    -----------------------");
            Console.WriteLine("");
            foreach (var item in menuItems)
            {
                Console.WriteLine(item.Key.ToString() + ": " + item.Value.Method.Name);
            }
        }
        public static Menu AddTopping()
        {
            Console.WriteLine("Add Topping");

            Topping topping = new Topping();

            Console.WriteLine("Insert Name:");
            topping.Title = Console.ReadLine();
            Console.WriteLine("Insert Price:");
            topping.Price = int.Parse(Console.ReadLine());

            ToppingService.AddTopping(topping);


            ShowMenuItems();

            var key = Console.ReadKey().Key;

            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static Menu DeleteTopping()
        {
            Console.WriteLine("Delete Pizza");

            Console.WriteLine("Insert Pizza Index:");
            int idx = int.Parse(Console.ReadLine());
            

            ShowMenuItems();

            var key = Console.ReadKey().Key;

            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static Menu EditTopping()
        {
            Console.WriteLine("Edit Toppings");

            Console.WriteLine("Insert Topping Index:");
            int idx = int.Parse(Console.ReadLine());
            Topping topping = ToppingService.GetTopping(idx);

            Console.WriteLine($"Old Title: {topping.Title}");
            Console.Write("New Title: ");
            topping.Title = Console.ReadLine();
            Console.WriteLine($"Old Price: {topping.Price}");
            Console.Write("New Price: ");
            topping.Price = int.Parse(Console.ReadLine());

            

            ShowMenuItems();
            var key = Console.ReadKey().Key;
            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }

    }
}
