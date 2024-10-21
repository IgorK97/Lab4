using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace Interfaces.Repository
{
    public interface IDbRepos
    {
        IRepository<Pizza> PizzaRepository { get; }
        IRepository<Ingredient> IngredientRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<Client> ClientRepository { get; }
        IRepository<User> UserRepository { get; }
        IRepository<Courier> CourierRepository { get; }
        IRepository<Manager> ManagerRepository { get; }
        IRepository<DelStatus> repositoryDelStatusRepository { get; }
        IRepository<OrderLine> OrderLineRepository { get; }
        IRepository<PizzaSize> PizzaSizeRepository { get; }
        IReportsRepository Reports { get; }
        int Save();
    }
}
