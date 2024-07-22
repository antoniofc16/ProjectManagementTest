using FullStackTest.Services.Models;

namespace FullStackTest.Services.ViewModels
{
    public class LoginResponse : ResponseModel
    {
        public User? AuthenticatedUser { get; set; }
        public string? BearerToken { get; set; }
    }
}
