using FoodEx.Application;
using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Domain.Enums;
using FoodEx.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FoodEx.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;
        private IOrderProductRepository _orderProductRepository;
        private IOrderStatusRepository _orderStatusRepository;
        private IProductRepository _productRepository;

        public OrderService(ApplicationContext context)
        {
            _orderRepository = new OrderRepository(context);
            _orderProductRepository = new OrderProductRepository(context);
            _orderStatusRepository = new OrderStatusRepository(context);
            _productRepository = new ProductRepository(context);
        }

        public async Task AddOrder(User user, List<Product> products)
        {
            decimal totalSum = products.Sum(x => x.Price * x.Quantity);
            OrderStatus status = await _orderStatusRepository.FindByName(OrderStatusEnum.Preparing.ToString());
            Order order = new Order(
                user,
                status,
                totalSum,
                DateTime.Now
            );

            await _orderRepository.Insert(order);
            order = await _orderRepository.FindLastOrder();
            foreach (Product product in products)
            {
                Product productFromDb = await _productRepository.FindById(product.Id); 
                OrderProduct op = new OrderProduct(product.Quantity, order, productFromDb);
                await _orderProductRepository.Insert(op);
            }
        }

        public async Task<OrderStatus> AddStatus(OrderStatus status)
        {
            return await _orderStatusRepository.Insert(status);
        }

        public async Task EditOrder(Order order)
        {
            await _orderRepository.Update(order);
        }

        public async Task EditStatus(OrderStatus status)
        {
            await _orderStatusRepository.Update(status);
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.FindAll();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _orderRepository.FindById(id);
        }


        public async Task<IEnumerable<OrderProduct>> GetProductsByOrderId(int orderId)
        {
            return await _orderProductRepository.FindProductsByOrder(orderId);
        }

        public async Task<IEnumerable<OrderProduct>> GetOrderProductsByUser(string userName)
        {
            return await _orderProductRepository.FindOrderProductsByUser(userName);
        }


        public async Task<IEnumerable<Order>> GetOrdersByStatus(string status)
        {
            return await _orderRepository.FindAllByStatus(status);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUser(string userLogin)
        {
            return await _orderRepository.GetAllByUser(userLogin); 
        }

        public async Task<OrderStatus> GetStatusById(int id)
        {
            return await _orderStatusRepository.FindById(id);
        }

        public async Task<OrderStatus> GetStatusByName(string statusName)
        {
            return await _orderStatusRepository.FindByName(statusName);
        }

        public async Task<IEnumerable<Order>> GetUserOrdersByStatus(string userLogin, string statusName)
        {
            return await _orderRepository.FindUserOrdersByStatus(userLogin, statusName); 
        }

        public async Task RemoveOrder(Order order)
        {
            await _orderRepository.Delete(order);
        }

        public async Task RemoveOrderById(int id)
        {
            await _orderRepository.Delete(id);
        }

        public async Task RemoveStatus(OrderStatus status)
        {
            await _orderStatusRepository.Delete(status);
        }

        public async Task RemoveStatusById(int id)
        {
            await _orderStatusRepository.Delete(id);
        }

    }
}
