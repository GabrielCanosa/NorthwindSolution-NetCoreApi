using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Implementations
{
    public class OrderLogic : IOrderLogic
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderLogic(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public bool Delete(OrderItem order)
        {
            throw new NotImplementedException();
        }

        public OrderItem getOrderById(int orderId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItem> getPaginatedOrder(int page, int rows)
        {
            throw new NotImplementedException();
        }
    }
}
