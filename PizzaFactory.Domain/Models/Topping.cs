using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Models
{
    public class Topping : BaseEntity
    {
        public int Price { get; set; }
        public List<Order> Orders { get; set; }
    }
}
