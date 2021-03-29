using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceBookingJwt.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServiceBookingJwt.Models;

namespace ServiceBookingJwt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
       static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(AuthenticationController));
        private readonly IAuthenticationManager manager;
        public AuthenticationController(IAuthenticationManager manager)
        {
            this.manager = manager;
        }
        [HttpGet]
        public string Get()
        {
            return "Hello";
        }

        [AllowAnonymous]
        [HttpPost("AuthenicateUser")]
        public IActionResult AuthenticateUser([FromBody] UserServiceInfo user)
        {
           _log4net.Info(" Http Authentication request Initiated");
            var token = manager.Authenticate(user.Username, user.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }
    }
}
