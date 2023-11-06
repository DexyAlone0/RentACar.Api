using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Data.Repositories.Abstract;
using BerkayRentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TnActivationCore.Repository.Mssql.GenericRepository;

namespace BerkayRentaCar.Data.Repositories.Concrete
{
    public class UserRepository : IUserRepsitory
    {
        private readonly IGenericRepository genericRepository;

        public UserRepository(IGenericRepository genericRepository)
        {
            this.genericRepository = genericRepository;
        }
        public async Task<IReadOnlyList<User>> GetAllUser()
        {
            return await this.genericRepository.GetListAsync<User>();
        }
        public async Task CreateUserAsync(CreateUserCommandRequest request)
        {
            var user = new User
            {
                Name = request.Name,
                Password = request.Password,
                Email = request.Email,
                FullName = request.FullName,
                UserTypeId = 2,
            };
            await this.genericRepository.AddAsync(user);
            await this.genericRepository.SaveChangesAsync();


        }
    }
}
