using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders();
        void AddOrder(Order order);
    }
}
