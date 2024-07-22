using FullStackTest.Client.Models;
using FullStackTest.Client.ViewModels;
using System.Text.Json;

namespace FullStackTest.Client.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUser(RegisterRequest user);
        Task<LoginResponse?> AuthenticateUser(LoginRequest login);
    }
    public class UserService(IHttpClientFactory ClientFactory, IConfiguration Configuration) : IUserService
    {
        private string ApiUrl = Configuration.GetValue<string>("ApiUrl")!; 

        public async Task<LoginResponse?> AuthenticateUser(LoginRequest login)
        {
            var client = ClientFactory.CreateClient();
            LoginResponse loginResponse = null;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/Access/Login");
            requestMessage.Content = JsonContent.Create(login);

            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    loginResponse = JsonSerializer.Deserialize<LoginResponse>(response)!;
                }
            }

            return loginResponse;
        }

        public async Task<bool> RegisterUser(RegisterRequest user)
        {
            var client = ClientFactory.CreateClient();
            bool isSuccessful = false;

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/Access/Register");
            requestMessage.Content = JsonContent.Create(user);

            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null) {
                    isSuccessful = JsonSerializer.Deserialize<RegisterResponse>(response)!.IsSuccessful; 
                }
            }

            return isSuccessful;
        }
    }
}
