using FullStackTest.Client.Models;
using System.Text.Json.Serialization;

namespace FullStackTest.Client.ViewModels
{
    public class LoginResponse : ResponseModel
    {
        [JsonPropertyName("authenticatedUser")]
        public User? AuthenticatedUser { get; set; }
        [JsonPropertyName("bearerToken")]
        public string? BearerToken { get; set; }
    }
}
