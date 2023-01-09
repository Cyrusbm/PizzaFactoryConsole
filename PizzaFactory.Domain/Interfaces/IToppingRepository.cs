using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Interfaces
{
    public interface IToppingRepository
    {
        IEnumerable<Topping> GetToppings();
        void AddTopping(Topping topping);
        Topping GetTopping(int id);
    }
}
