using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceBookingJwt.Repository
{
   public interface IAuthenticationManager
    {
        public string Authenticate(string username, string password);
    }
}
