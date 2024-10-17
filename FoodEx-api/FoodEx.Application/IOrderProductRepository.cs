using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application
{
    public interface IOrderProductRepository : IGenericRepository<OrderProduct>
    {
        Task<IEnumerable<OrderProduct>> FindProductsByOrder(int orderId);
        public Task<IEnumerable<OrderProduct>> FindOrderProductsByUser(string userLogin);
    }
}
