using BerkayRentaCar.Contract.Request.ModelRequest;
using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BerkayRentaCar.Data.Repositories.Abstract
{
    public interface IUserRepsitory
    {
        Task<IReadOnlyList<User>> GetAllUser();

        Task CreateUserAsync(CreateUserCommandRequest request);
        Task<bool> UserLoginAsync(UserQueryRequest request);
    }
}
