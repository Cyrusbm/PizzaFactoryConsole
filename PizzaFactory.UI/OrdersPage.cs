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
    public static class OrdersPage
    {
        public static IOrderService OrderService;
        public static IPizzaService PizzaService;
        public static IToppingService ToppingService;

        static Dictionary<ConsoleKey, Func<Menu>> menuItems = new Dictionary<ConsoleKey, Func<Menu>>()
        {
            {ConsoleKey.F1, OrdersPage.AddOrder},
            {ConsoleKey.F2, OrdersPage.ShowOrders},
            { ConsoleKey.F12, MainPage.ShowMainPage}
        };

        public static Menu ShowOrders()
        {
            Console.WriteLine("------------------------  Order Page  -----------------------");

            IEnumerable<Order> orders = OrderService.GetOrders();

            var table = new ConsoleTable("Id", "Pizzas", "Toppings", "Beverages", "Total Price");
            foreach (var o in orders)
            {
                table.AddRow(o.Id, 
                    (o.Pizzas is not null)?string.Join("," , o.Pizzas.Select(p=>p.Title)):"", 
                    (o.Toppings is not null)?string.Join("," , o.Toppings.Select(t=>t.Title)):"", 
                    (o.Beverages is not null) ? string.Join(",", o.Beverages.Select(b => b.Title)) : "", 
                    o.TotalPrice.ToString());
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

        public static Menu AddOrder()
        {
            Console.WriteLine("Add Order");

            Order order = new Order();

            do
            {
                Console.WriteLine("Insert Pizza:");
                int idx = int.Parse(Console.ReadLine());
                var pizza = PizzaService.GetPizza(idx);
                order.Pizzas.Add(pizza);
                Console.WriteLine("Continue: Enter, Exit: Esc");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            do
            {
                Console.WriteLine("Insert Topping:");
                int idx = int.Parse(Console.ReadLine());
                var topping = ToppingService.GetTopping(idx);
                order.Toppings.Add(topping);
                Console.WriteLine("Continue: Enter, Exit: Esc");

            } while (Console.ReadKey().Key != ConsoleKey.Escape);

            order.CreateDateTime = DateTime.Now.ToString();

            OrderService.AddOrder(order);


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
