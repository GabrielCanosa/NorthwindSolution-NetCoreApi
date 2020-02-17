using Microsoft.AspNetCore.Mvc;
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
        private IUnitOfWork _unitOfWork;
        public TokenController(ITokenProvider tokenProvider, IUnitOfWork unitOfWork)
        {
            _tokenProvider = tokenProvider;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public JsonWebTokens Post([FromBody] User userLogin)
        {
            var user = _unitOfWork.User.ValidateUser(userLogin.Email, userLogin.Password);

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
