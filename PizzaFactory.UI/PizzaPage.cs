using ConsoleTables;
using PizzaFactory.Application;
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
    public static class PizzaPage
    {
        public static IPizzaService PizzaService;
        static Dictionary<ConsoleKey, Func<Menu>> menuItems = new Dictionary<ConsoleKey, Func<Menu>>()
            {
                { ConsoleKey.F1, ShowPizzas},
                { ConsoleKey.F2, AddPizza},
                { ConsoleKey.F3, EditPizza},
                { ConsoleKey.F4, DeletePizza},
                {ConsoleKey.F12,MainPage.ShowMainPage}
           };


        public static Menu AddPizza()
        {
            Console.WriteLine("Add Pizza");

            Pizza pizza = new Pizza();

            Console.WriteLine("Insert Name:");
            pizza.Title = Console.ReadLine();
            Console.WriteLine("Insert Price:");
            pizza.Price = int.Parse(Console.ReadLine());

            PizzaService.AddPizza(pizza);
            
            
            ShowMenuItems();

            var key = Console.ReadKey().Key;

            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static Menu DeletePizza()
        {
            Console.WriteLine("Delete Pizza");

            Console.WriteLine("Insert Pizza Index:");
            int idx = int.Parse(Console.ReadLine());
            PizzaService.DeletePizza(idx);

            ShowMenuItems();

            var key = Console.ReadKey().Key;

            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static Menu EditPizza()
        {
            Console.WriteLine("Edit Pizza");

            Console.WriteLine("Insert Pizza Index:");
            int idx = int.Parse(Console.ReadLine());
            Pizza pizza = PizzaService.GetPizza(idx);

            Console.WriteLine($"Old Title: {pizza.Title}");
            Console.Write("New Title: ");
            pizza.Title = Console.ReadLine();
            Console.WriteLine($"Old Price: {pizza.Price}");
            Console.Write("New Price: ");
            pizza.Price = int.Parse(Console.ReadLine());

            PizzaService.EditPizza(pizza);

            ShowMenuItems();
            var key = Console.ReadKey().Key;
            return new Menu()
            {
                selectedKey = key,
                items = menuItems
            };
        }
        public static Menu ShowPizzas()
        {
            Console.WriteLine("------------------------  Pizza Page  -----------------------");

            IEnumerable<Pizza> pizzas = PizzaService.GetPizzas();

            var table = new ConsoleTable("Id", "Name", "Price");
            foreach (var p in pizzas)
            {
                table.AddRow(p.Id, p.Title, p.Price);
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
    }
}
