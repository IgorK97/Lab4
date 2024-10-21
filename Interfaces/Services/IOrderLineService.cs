using DomainModel;
using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces.Services
{
    public interface IOrderLineService
    {
        List<OrderLineDto> GetAllOrderLines(int? OrderId);


        OrderLineDto GetOrderLine(int Id);

        void CreateOrderLine(OrderLineDto p);

        void UpdateOrderLine(OrderLineDto p);

        void DeleteOrderLine(int id);


        bool Save();

        List<PizzaDto> GetPizzas();

        List<PizzaSizesDto> GetPizzaSizes();

        List<DelStatusDto> GetDelStatuses();

        BindingList<IngredientShortDto> GetIngredients(PizzaSize? ps);

        BindingList<IngredientShortDto> GetConcreteIngredients(PizzaSize ps, int ol_id);

        (decimal price, decimal weight) GetBasePriceAndWeight(PizzaSize ps);

        (decimal price, decimal weight) GetConcretePriceAndWeight(int p_id, PizzaSize ps, decimal count);

        (decimal price, decimal weight) PriceAndWeightCalculation(BindingList<IngredientShortDto> allingredients, PizzaSize ps, int p_id, decimal count);

        void ChangeAdditionalItems(BindingList<IngredientShortDto> allingredients, int add_id);
        
    }
}
