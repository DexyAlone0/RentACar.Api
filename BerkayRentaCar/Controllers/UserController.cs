using BerkayRentaCar.Application.UserService;
using BerkayRentaCar.Contract.Request.UserRequest;
using BerkayRentaCar.Contract.Response.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BerkayRentaCar.Controllers;

public class UserController : ControllerBase
{
    private readonly IUserService userService;

    public UserController(IUserService userService)
    {
        this.userService = userService;
    }
     
    [Route("CreateUser")]
    [HttpPost]
    public async Task CreateModel([FromBody]CreateUserCommandRequest request)
    {
        await this.userService.CreateUserAsync(request);
    }
}