using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface IOrderLogic
    {
        IEnumerable<OrderItem> getPaginatedOrder(int page, int rows);
        OrderItem getOrderById(int orderId);
        bool Delete(OrderItem order);
    }
}
