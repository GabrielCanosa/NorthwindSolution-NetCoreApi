using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return _unitOfWork.Order.Delete(order);
        }

        public OrderItem getOrderById(int orderId)
        {
            return _unitOfWork.Order.GetById(orderId);
        }

        public IEnumerable<OrderItem> getPaginatedOrder(int page, int rows)
        {
            return _unitOfWork.Order.getPaginatedOrder(page, rows);
        }

        public int GetProductId(int orderId)
        {
            var list = _unitOfWork.Order.GetList();
            if (!list.Any()) return 0;
            var record = list.FirstOrDefault(x => x.Id == orderId);
            return record.ProductId;
        }
    }
}
