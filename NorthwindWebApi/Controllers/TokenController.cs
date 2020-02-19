using Microsoft.AspNetCore.Mvc;
using Northwind.BusinessLogic.Interfaces;
using Northwind.Models;
using Northwind.UnitOfWork;
using NorthwindWebApi.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        private ITokenProvider _tokenProvider;
        private ITokenLogic _tokenLogic;
        public TokenController(ITokenProvider tokenProvider, ITokenLogic tokenLogic)
        {
            _tokenProvider = tokenProvider;
            _tokenLogic = tokenLogic;
        }

        [HttpPost]
        public JsonWebTokens Post([FromBody] User userLogin)
        {
            var user = _tokenLogic.ValidateUser(userLogin.Email, userLogin.Password);

            if (user == null)
                throw new UnauthorizedAccessException();

            var token = new JsonWebTokens
            {
                Acces_Token = _tokenProvider.CreateToken(user, DateTime.UtcNow.AddHours(8)),
                Expires_in = 480
            };

            return token;
        }
    }
}
