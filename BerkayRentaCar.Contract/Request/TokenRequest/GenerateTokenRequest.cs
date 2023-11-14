using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Contract.Request.TokenRequest
{
    public class GenerateTokenRequest
    {
        public string UserName { get; set; } = string.Empty;
        public int UserTypeId { get; set; }
    }
}
