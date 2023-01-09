using PizzaFactory.Domain.Interfaces;
using PizzaFactory.Domain.Models;
using PizzaFactory.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Infrastructure.Repositories
{
    public class ToppingRepository : IToppingRepository
    {
        private readonly PizzaFactoryDbContext _pizzaFactoryDbContext;

        public ToppingRepository(PizzaFactoryDbContext pizzaFactoryDbContext)
        {
            _pizzaFactoryDbContext = pizzaFactoryDbContext;
        }
        public void AddTopping(Topping topping)
        {
            _pizzaFactoryDbContext.Toppings.Add(topping);
            _pizzaFactoryDbContext.SaveChanges();
        }

        public Topping GetTopping(int id)
        {
            return _pizzaFactoryDbContext.Toppings.FirstOrDefault(t=>t.Id == id);
        }

        public IEnumerable<Topping> GetToppings()
        {
            return _pizzaFactoryDbContext.Toppings;
        }
    }
}
