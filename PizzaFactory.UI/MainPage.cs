using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PizzaFactory.UI.Program;

namespace PizzaFactory.UI
{
    public static class MainPage
    {
        static Dictionary<ConsoleKey, Func<Menu>> menuItems =  new Dictionary<ConsoleKey, Func<Menu>>()
            {
                { ConsoleKey.F1, OrdersPage.ShowOrders},
                { ConsoleKey.F2, ProductsPage.ShowProducts},
            };


        public static Menu ShowMainPage()
        {
            Console.WriteLine("------------------------  Main Page  -----------------------");

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
