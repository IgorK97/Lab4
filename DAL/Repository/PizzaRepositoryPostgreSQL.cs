﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces.Repository;
using DomainModel;
using DTO;
using DAL;

namespace DAL.Repository
{
    public class PizzaRepositoryPostgreSQL :IRepository<Pizza>
    {
        private PizzaDeliveryContext db;

        public PizzaRepositoryPostgreSQL(PizzaDeliveryContext dbcontext)
        {
            this.db = dbcontext;
        }

        public List<Pizza> GetList()
        {
            return db.Pizzas.ToList();
        }

        public Pizza GetItem(int id)
        {
            return db.Pizzas.Find(id);
        }

        public void Create(Pizza pizza)
        {
            db.Pizzas.Add(pizza);
        }

        public void Update(Pizza pizza)
        {
            db.Entry(pizza).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void Delete(int id)
        {
            Pizza pizza = db.Pizzas.Find(id);
            if (pizza != null)
                db.Pizzas.Remove(pizza);
        }
    }
}
