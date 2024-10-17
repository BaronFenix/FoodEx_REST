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
    public class OrderStatusRepository : GenericRepository<OrderStatus>, IOrderStatusRepository
    {
        private readonly ApplicationContext _context;
        public OrderStatusRepository(ApplicationContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderStatus> FindByName(string statusName)
        {
            return await _context.OrderStatuses.Where(x => x.Name == statusName).FirstOrDefaultAsync();
        }
    }
}
