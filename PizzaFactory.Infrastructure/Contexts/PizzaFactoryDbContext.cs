using Microsoft.EntityFrameworkCore;
using PizzaFactory.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaFactory.Infrastructure.Contexts
{
    public class PizzaFactoryDbContext : DbContext
    {
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<Beverage> Beverages { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=PizzaFactory.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
