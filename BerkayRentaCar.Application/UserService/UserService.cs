using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Contract.Response.User;
using BerkayRentaCar.Data.Repositories.Abstract;

namespace BerkayRentaCar.Application.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepsitory userRepository;
        

        public UserService(IUserRepsitory userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task CreateUserAsync(CreateUserCommandRequest request)
        {
             await this.userRepository.CreateUserAsync(request);
            
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