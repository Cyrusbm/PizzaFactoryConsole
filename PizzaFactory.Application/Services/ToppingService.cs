using PizzaFactory.Application.Interfaces;
using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Application.Services
{
    public class ToppingService : IToppingService
    {
        private readonly IToppingRepository _toppingRepository;

        public ToppingService(IToppingRepository toppingRepository)
        {
            _toppingRepository = toppingRepository;
        }
        public void AddTopping(Topping topping)
        {
            _toppingRepository.AddTopping(topping);
        }

        public Topping GetTopping(int id)
        {
            return _toppingRepository.GetTopping(id);
        }

        public IEnumerable<Topping> GetToppings()
        {
            return _toppingRepository.GetToppings();
        }
    }
}
