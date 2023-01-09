using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Models
{
    public class Beverage : BaseEntity
    {
        public List<Order> Orders { get; set; }
    }
}
