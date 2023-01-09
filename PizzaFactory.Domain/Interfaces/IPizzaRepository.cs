using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Domain.Interfaces
{
    public interface IPizzaRepository
    {
        IEnumerable<Pizza> GetAll();
        Pizza GetById(int id);
        void EditPizza(Pizza pizza);  
        void DeletePizza(int id);
        void AddPizza(Pizza pizza);
    }
}
