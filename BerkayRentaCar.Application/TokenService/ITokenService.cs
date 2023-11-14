using BerkayRentaCar.Contract.Request.TokenRequest;
using BerkayRentaCar.Contract.Response.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Application.TokenService
{
    public interface ITokenService
    {
        public Task<GenerateTokenResponse> GenerateTokenAsync(GenerateTokenRequest request);

    }
}
