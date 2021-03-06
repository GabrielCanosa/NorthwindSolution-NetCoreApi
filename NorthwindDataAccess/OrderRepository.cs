﻿using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Northwind.DataAccess
{
    public class OrderRepository : Repository<OrderItem>, IOrderRepository
    {
        public OrderRepository(string connectionString) : base(connectionString) { }

        public IEnumerable<OrderItem> getPaginatedOrder(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<OrderItem>("dbo.OrderPagedList"
                                                   , parameters
                                                   , commandType: CommandType.StoredProcedure);
            }
        }
    }
}
