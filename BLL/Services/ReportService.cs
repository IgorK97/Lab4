using Npgsql;
using DAL;
using DomainModel;
using Interfaces.DTO;
using Interfaces.Services;
using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Interfaces.Repository;


namespace BLL.Services
{
    public class ReportService : IReportService
    {
        private IDbRepos db;
        public ReportService(IDbRepos repos)
        {
            db = repos;
        }

        public List<OrdersByMonth> ExecuteSP(int month, int year, int ClientId)
        {

            PizzaDeliveryContext dbContext = new PizzaDeliveryContext();
            NpgsqlParameter param1 = new NpgsqlParameter("month", NpgsqlTypes.NpgsqlDbType.Integer);
            NpgsqlParameter param2 = new NpgsqlParameter("year", NpgsqlTypes.NpgsqlDbType.Integer);
            param1.Value = month;
            param2.Value = year;

            //var result = dbContext.Database.SqlQuery<ParResult>("select * from _GetOrdersByMonthYear(@month, @year)", new object[] { param1, param2 }).ToList();
            //var result = dbContext.Database.SqlQuery<int>($"select * from _GetOrdersByMonthYear(@month={param1}, @year={param2})").ToList();

            var result = dbContext.Orders.FromSql($"select * from getordersbymonthandyearnew({param1}, {param2})").ToList();

            var data = result.Where(i => i.ClientId == ClientId && i.CourierId!=null).Select(j =>
            new OrdersByMonth { order_id = j.Id, courier_id = dbContext.Couriers.Where(c =>
            c.Id==j.CourierId).Select(c => new
            {
                fname = c.FirstName + " " + c.LastName + " " + c.Surname
            }).FirstOrDefault().fname, Date = j.Ordertime }).OrderByDescending(c => c.Date).ToList();

            return data;
            //List<OrdersByMonth> r = new List<OrdersByMonth>();
            //return r;

        }


        public List<ReportData> ReportPizzas(int? ingredientId)
        {

            PizzaDeliveryContext dbContext = new PizzaDeliveryContext();
            if (ingredientId != null)
            {
                var request = dbContext.Pizzas.Where(p => p.Ingredients.Any(i => i.Id == ingredientId))
                .Select(p => new ReportData
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description

                }).ToList();
                return request;
            }
            var request1 = dbContext.Pizzas.Select(p => new ReportData
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description

                }).ToList();
            return request1;
        }
    }
}
