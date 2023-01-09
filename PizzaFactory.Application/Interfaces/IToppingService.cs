using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application.Interfaces
{
    public interface IToppingService
    {
        IEnumerable<Topping> GetToppings();
        Topping GetTopping(int id);
        void AddTopping(Topping topping); 
    }
}
