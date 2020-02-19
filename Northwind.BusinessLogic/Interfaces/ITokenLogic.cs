using Northwind.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.BusinessLogic.Interfaces
{
    public interface ITokenLogic
    {
        User ValidateUser(string email, string password);
    }
}
