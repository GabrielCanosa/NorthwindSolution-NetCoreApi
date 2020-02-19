using FluentAssertions;
using Northwind.BusinessLogic.Implementations;
using Northwind.BusinessLogic.Interfaces;
using Northwind.BusinessLogicTest.Mocked;
using Northwind.Models;
using Northwind.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Northwind.BusinessLogicTest
{
    public class CustomerLogicTest
    {
        private readonly IUnitOfWork _unitMocked;
        private readonly ICustomerLogic _customerLogic;
        public CustomerLogicTest()
        {
            var unitMocked = new CustomerRepositoryMocked();
            _unitMocked = unitMocked.GetInstance();
            _customerLogic = new CustomerLogic(_unitMocked);
        }

        [Fact]
        public void GetById_Customer_Test()
        {
            var result = _customerLogic.GetById(1);
            result.Should().NotBeNull();
            result.Id.Should().BeGreaterThan(0);
        }

        [Fact(DisplayName = "[CustomerLogic] Insert")]
        public void Insert_Customer_Test()
        {
            var customer = new Customer
            {
                Id = 101,
                City = "Zaragoza",
                Country = "Spain",
                FirstName = "Jose",
                LastName = "Perez",
                Phone = "1234 1234"
            };

            var result = _customerLogic.Insert(customer);
            result.Should().Be(101);
        }

        [Fact(DisplayName = "[CustomerLogic] Update")]
        public void Update_Customer_Test()
        {
            var customer = _customerLogic.GetById(1);
            customer.FirstName = "updated firstname";
            customer.LastName = "updated lastname";

            var result = _customerLogic.Update(customer);
            var updatedCustomer = _customerLogic.GetById(1);
            updatedCustomer.Should().NotBeNull();
            updatedCustomer.Id.Should().Be(customer.Id);
            updatedCustomer.City.Should().Be(customer.City);
            updatedCustomer.Country.Should().Be(customer.Country);
            updatedCustomer.FirstName.Should().Be(customer.FirstName);
            updatedCustomer.LastName.Should().Be(customer.LastName);
            updatedCustomer.Phone.Should().Be(customer.Phone);
        }
    }
}
