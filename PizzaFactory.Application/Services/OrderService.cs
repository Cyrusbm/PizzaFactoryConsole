using PizzaFactory.Application.Interfaces;
using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Domain.Models;
using PizzaFactory.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public IEnumerable<Order> GetOrders()
        {
            var orders = _orderRepository.GetOrders();
            return orders;
        }
    }
}
