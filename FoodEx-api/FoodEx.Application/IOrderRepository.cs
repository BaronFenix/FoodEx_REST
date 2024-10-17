using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<List<Order>> FindAllByStatus(string status);
        Task<List<Order>> GetAllByUser(string userLogin);
        Task<List<Order>> FindUserOrdersByStatus(string userLogin, string status);
        Task<Order> FindLastOrder();


    }
}
