
using PizzaFactory.Application;
using PizzaFactory.Domain.Models;
using PizzaFactory.Infrastructure.Contexts;
using ConsoleTables;
using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Infrastructure.Repositories;
using PizzaFactory.Application.Interfaces;
using PizzaFactory.Application.Services;

namespace PizzaFactory.UI;

public static class Program
{
    static PizzaFactoryDbContext dbContext = new PizzaFactoryDbContext();
    
    static IPizzaRepository pizzaRepository = new PizzaRepository(dbContext);
    static IPizzaService pizzaService = new PizzaService(pizzaRepository);

    static IOrderRepository orderRepository = new OrderRepository(dbContext);
    static IOrderService orderService = new OrderService(orderRepository);

    static IToppingRepository toppingRepository = new ToppingRepository(dbContext);
    static IToppingService toppingService = new ToppingService(toppingRepository);


    static Menu menu1;

    public static void Main()
    {

        dbContext.Database.EnsureCreated();
        
        PizzaPage.PizzaService = pizzaService;
        
        OrdersPage.OrderService = orderService;
        OrdersPage.PizzaService = pizzaService;
        OrdersPage.ToppingService = toppingService;

        ToppingPage.ToppingService = toppingService;



        menu1 = new Menu()
        {
            selectedKey = ConsoleKey.F1,
            items = new Dictionary<ConsoleKey, Func<Menu>>()
            {
                { ConsoleKey.F1, MainPage.ShowMainPage}
            }
        };

        do
        {
            menu1 = ShowPage(menu1);
        }
        while (menu1.selectedKey != ConsoleKey.Escape);



    }


    public static Menu ShowPage(Menu menu)
    {
        Console.Clear();
        Console.WriteLine("------------------------Pizza Factory-----------------------");
        Console.WriteLine("");
        Console.WriteLine("");

        if (menu.items.ContainsKey(menu.selectedKey))
            return menu.items[menu.selectedKey].Invoke();
        else
        {
            Console.WriteLine("Invalid Input");
            return new Menu()
            {
                selectedKey = ConsoleKey.F1,
                items = new Dictionary<ConsoleKey, Func<Menu>>()
            {
                { ConsoleKey.F1, MainPage.ShowMainPage}
            }
            };
        }

    }

    public class Menu
    {
        public ConsoleKey selectedKey { get; set; }
        public Dictionary<ConsoleKey, Func<Menu>> items;
    }

}

