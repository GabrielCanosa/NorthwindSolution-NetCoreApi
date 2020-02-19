using AutoFixture;
using Moq;
using Northwind.Models;
using Northwind.Repositories;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Northwind.BusinessLogicTest.Mocked
{
    public class OrderRepositoryMocked
    {
        private readonly List<OrderItem> _orders;

        public OrderRepositoryMocked()
        {
            _orders = GetOrders();
        }

        public IUnitOfWork GetInstance()
        {
            var mocked = new Mock<IUnitOfWork>();
            mocked.Setup(u => u.Order).Returns(GetOrderRepository());
            return mocked.Object;
        }

        private IOrderRepository GetOrderRepository()
        {
            var orderMocked = new Mock<IOrderRepository>();

            orderMocked.Setup(c => c.GetList())
                .Returns(_orders);

            return orderMocked.Object;
        }

        public List<OrderItem> GetOrders()
        {
            var fixture = new Fixture();
            var customers = fixture.CreateMany<OrderItem>(50).ToList();
            for (int i = 0; i < 50; i++)
            {
                customers[i].Id = i + 1;
            }
            return customers;
        }
    }
}
