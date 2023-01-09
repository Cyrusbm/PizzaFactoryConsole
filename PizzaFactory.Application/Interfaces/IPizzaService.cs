using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application.Interfaces
{
    public interface IPizzaService
    {
        IEnumerable<Pizza> GetPizzas();
        Pizza GetPizza(int id);
        void AddPizza(Pizza pizza);
        void EditPizza(Pizza pizza);
        void DeletePizza(int id);
    }
}
