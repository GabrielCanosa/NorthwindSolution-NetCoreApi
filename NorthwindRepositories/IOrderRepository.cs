using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.Repositories
{
    public interface IOrderRepository : IRepository<OrderItem>
    {
        IEnumerable<OrderItem> getPaginatedOrder(int page, int rows);
    }
}
