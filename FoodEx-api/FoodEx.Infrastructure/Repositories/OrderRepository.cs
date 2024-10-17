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
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        private readonly ApplicationContext _context;
        public OrderRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Order>> FindAllByStatus(string status)
        {
            return await _context.Orders.Where(x => x.Status.Name == status).Include(x => x.Status).ToListAsync();
        }

        public async Task<List<Order>> GetAllByUser(string userLogin)
        {
            return await _context.Orders
                .Where(x => x.User.Login == userLogin)
                .Include(x => x.User)
                .Include(x => x.Status)
                .ToListAsync();
        }

        public async Task<List<Order>> FindUserOrdersByStatus(string userLogin, string status)
        {
            return await _context.Orders
                .Where(x => x.User.Login == userLogin && x.Status.Name == status)
                .Include(x => x.User)
                .Include(x => x.Status)
                .ToListAsync();
        }

        public async Task<Order> FindLastOrder()
        {
            return await _context.Orders.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
        }
    }
}
