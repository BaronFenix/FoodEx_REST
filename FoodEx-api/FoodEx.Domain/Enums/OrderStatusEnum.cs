using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodEx.Domain.Enums
{
    public class OrderStatusEnum
    {
        public string Status { get; private set; }

        private OrderStatusEnum(string status) { Status = status; }

        public static OrderStatusEnum Completed { get { return new OrderStatusEnum("Выполнен"); } }
        public static OrderStatusEnum Cancelled { get { return new OrderStatusEnum("Отменен"); } }
        public static OrderStatusEnum Preparing { get { return new OrderStatusEnum("Готовится"); } }

        public override string ToString()
        {
            return Status;
        }
    }
}
