using PizzaFactory.Application.Interfaces;
using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Domain.Models;
using PizzaFactory.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository;

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public void AddPizza(Pizza pizza)
        {
            _pizzaRepository.AddPizza(pizza);
        }

        public void DeletePizza(int id)
        {
            _pizzaRepository.DeletePizza(id);
        }

        public void EditPizza(Pizza pizza)
        {
            _pizzaRepository.EditPizza(pizza);
        }

        public Pizza GetPizza(int id)
        {
            var pizza = _pizzaRepository.GetById(id);
            return  pizza;
        }

        public IEnumerable<Pizza> GetPizzas()
        {
            return _pizzaRepository.GetAll();
        }
    }
}
