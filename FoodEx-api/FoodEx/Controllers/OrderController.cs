using FoodEx.Application.IServices;
using FoodEx.Domain;
using FoodEx.Domain.Enums;
using FoodEx.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodEx.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<ActionResult> CreateOrder(List<Product> basket)
        {
            User? user = await _userService.GetUserByLogin(User.Identity.Name);
            if(user == null)
            {
                return Unauthorized();
            }

            await _orderService.AddOrder(user, basket);
            return Ok();
        }

        [HttpGet("getOrders")]
        [Authorize]
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            User? user = await _userService.GetUserByLogin(User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }
            List<Order> orders = (List<Order>) await _orderService.GetOrdersByUser(user.Login);
            return Ok(orders);
        }

        [HttpGet("getOrderProducts")]
        [Authorize]
        public async Task<ActionResult<List<OrderProduct>>> getOrderProducts(int orderId)
        {
            User? user = await _userService.GetUserByLogin(User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }
            List<OrderProduct> orderProducts = (List<OrderProduct>)await _orderService.GetProductsByOrderId(orderId);
            return Ok(orderProducts);
        }

        [HttpGet("getProductsByOrder")]
        [Authorize]
        public async Task<ActionResult<List<OrderProduct>>> getProductsByOrder()
        {
            User? user = await _userService.GetUserByLogin(User.Identity.Name);
            if (user == null)
            {
                return Unauthorized();
            }
            List<OrderProduct> orderProducts = (List<OrderProduct>)await _orderService.GetOrderProductsByUser(user.Login);
            Dictionary<int, List<Product>> productsByOrder = new Dictionary<int, List<Product>>();

            foreach (var item in orderProducts)
            {
                item.Product.Quantity = item.Quantity;
                if (productsByOrder.ContainsKey(item.Order.Id))
                {
                    productsByOrder[item.Order.Id].Add(item.Product);
                }
                else
                {
                    productsByOrder.Add(item.Order.Id, new List<Product>() { item.Product });
                }
            }
            
            return Ok(productsByOrder);
        }
    }
}
