using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Contract.Response.User
{
    public class UserLoginResponse
    {
        public bool AuthenticateResult { get; set; }
        public string AuthToken { get; set; }  = string.Empty;
        public DateTime AccessTokenExpireDate { get; set; }
    }
}
