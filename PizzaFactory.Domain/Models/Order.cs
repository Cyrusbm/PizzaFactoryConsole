using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Models
{
    public class Order : BaseEntity
    {
        public List<Pizza>? Pizzas { get; set; } = new List<Pizza>();
        public List<Topping>? Toppings { get; set; } = new List<Topping>();
        public List<Beverage>? Beverages { get; set; }
        public int? TotalPrice
        {
            get
            {
                return Pizzas.Select(p=>p.Price).Sum() + Toppings.Select(p=>p.Price).Sum();
            }
        }
            

    }
}
