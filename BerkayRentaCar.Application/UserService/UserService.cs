using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Contract.Response.User;
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using BerkayRentaCar.Contract.Request.TokenRequest;
using BerkayRentaCar.Application.TokenService;
using System.Xml.Linq;

namespace BerkayRentaCar.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepsitory userRepository;
        private readonly ITokenService tokenService;

        public UserService(IUserRepsitory userRepository , ITokenService tokenService)
        {
            this.userRepository = userRepository;
            this.tokenService = tokenService;
        }

        public async Task CreateUserAsync(CreateUserCommandRequest request)
        {
             await this.userRepository.CreateUserAsync(request);
            
        }

        public async Task<UserLoginResponse> UserLoginAsync(UserQueryRequest request)
        {
            var userInfo = await this.userRepository.UserLoginAsync(request);
            if (userInfo == null)
            {
                return new UserLoginResponse
                {
                    AuthenticateResult = false,
                };
            }
            var tokenResponse = await this.tokenService.GenerateTokenAsync(new GenerateTokenRequest
            {
                UserName = userInfo!.Name,
                UserTypeId = userInfo!.UserTypeId,
            });

            return new UserLoginResponse
            {
                AccessTokenExpireDate = tokenResponse.TokenExpireDate,
                AuthenticateResult = true,
                AuthToken = tokenResponse.Token,

            };
            
        }

        public async Task<IReadOnlyList<UserQueryResponse>> GetAllAsync()
        {
            var userList = await userRepository.GetAllUser();
            return userList.Select(b => new UserQueryResponse
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
        }
    }
}