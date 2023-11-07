namespace BerkayRentaCar.Contract.Request.UserRequest
{
    public class CreateUserCommandRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
    }
}