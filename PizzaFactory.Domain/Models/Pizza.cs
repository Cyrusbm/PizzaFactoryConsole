using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Models
{
    public class Pizza : BaseEntity
    {
        public int Price { get; set; }
        public PizzaKind? Kind { get; set; }

        public List<Order>? Orders { get; set; }
    }

    public enum PizzaKind
    {
        Small,
        Medium,
        Large
    }
}
