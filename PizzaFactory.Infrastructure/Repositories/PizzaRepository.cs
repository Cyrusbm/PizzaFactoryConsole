using Microsoft.EntityFrameworkCore;
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
    public class PizzaRepository : IPizzaRepository
    {
        PizzaFactoryDbContext _context;
        
        
        public PizzaRepository(PizzaFactoryDbContext pizzaFactoryDbContext)
        {
            _context = pizzaFactoryDbContext;
            
        }

        public void AddPizza(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public void DeletePizza(int id)
        {
            _context.Pizzas.Remove(GetById(id));
            _context.SaveChanges();
        }

        public void EditPizza(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            _context.SaveChanges();
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
        }

        public Pizza GetById(int id)
        {
            var pizza = _context.Pizzas.FirstOrDefault(p => p.Id == id);
            return pizza;
        }
    }
}
