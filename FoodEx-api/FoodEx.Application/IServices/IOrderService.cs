using FoodEx.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Application.IServices
{
    public interface IOrderService
    {
        public Task AddOrder(User user, List<Product> products);

        public Task EditOrder(Order order);

        public Task RemoveOrder(Order order);

        public Task RemoveOrderById(int id);

        public Task<Order> GetOrderById(int id);

        public Task<IEnumerable<Order>> GetAllOrders();

        public Task<IEnumerable<Order>> GetOrdersByUser(string userLogin);

        public Task<IEnumerable<Order>> GetOrdersByStatus(string status);

        public Task<IEnumerable<Order>> GetUserOrdersByStatus(string userLogin, string statusName);


        public Task<IEnumerable<OrderProduct>> GetProductsByOrderId(int orderId);

        public Task<IEnumerable<OrderProduct>> GetOrderProductsByUser(string userLogin);


        public Task<OrderStatus> AddStatus(OrderStatus status);

        public Task EditStatus(OrderStatus status);

        public Task RemoveStatus(OrderStatus status);

        public Task RemoveStatusById(int id);

        public Task<OrderStatus> GetStatusByName(string statusName);

        public Task<OrderStatus> GetStatusById(int id);
    }
}
