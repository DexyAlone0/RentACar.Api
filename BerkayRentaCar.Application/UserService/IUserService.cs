using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Contract.Response.User;
namespace BerkayRentaCar.Application.UserService
{
    public interface IUserService
    {
        Task<IReadOnlyList<UserQueryResponse>> GetAllAsync();
        Task CreateUserAsync(CreateUserCommandRequest request);
        Task<UserLoginResponse> UserLoginAsync(UserQueryRequest request);
    }
}
