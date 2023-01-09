using Microsoft.EntityFrameworkCore;
using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Domain.Models;
using PizzaFactory.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PizzaFactoryDbContext _pizzaFactoryDbContext;
        public OrderRepository(PizzaFactoryDbContext pizzaFactoryDbContext)
        {
            _pizzaFactoryDbContext = pizzaFactoryDbContext;
        }

        public void AddOrder(Order order)
        {
            _pizzaFactoryDbContext.Orders.Add(order);
            _pizzaFactoryDbContext.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _pizzaFactoryDbContext.Orders.Include(o=>o.Pizzas).Include(o=>o.Toppings);
            return orders;
        }
    }
}
