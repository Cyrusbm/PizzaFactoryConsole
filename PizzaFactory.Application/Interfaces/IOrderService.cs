using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders();
        void AddOrder(Order order);
    }
}
