using FoodEx.Application;
using FoodEx.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Infrastructure.Repositories
{
    public class OrderProductRepository : GenericRepository<OrderProduct>, IOrderProductRepository
    {
        private readonly ApplicationContext _context;
        public OrderProductRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OrderProduct>> FindProductsByOrder(int orderId)
        {
            return await _context.OrderProducts
                .Where(x => x.Order.Id == orderId)
                .Include(x => x.Order)
                .Include(x => x.Product)
                .ToListAsync();
        }

        public async Task<IEnumerable<OrderProduct>> FindOrderProductsByUser(string userLogin)
        {
            return await _context.OrderProducts
                .Where(x => x.Order.User.Login == userLogin)
                .Include(x => x.Order)
                .Include(x => x.Order.User)
                .Include(x => x.Product)
                .ToListAsync();
        }
    }
}
