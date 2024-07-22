using Blazored.SessionStorage;
using FullStackTest.Client.Components.Pages;
using FullStackTest.Client.Configuration;
using FullStackTest.Client.Models;
using FullStackTest.Client.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Text.Json;

namespace FullStackTest.Client.Services
{
    public interface IProjectService
    {
        Task<List<Models.TaskStatus>> GetTaskStatuses();
        Task<SaveProjectResponse> SaveProject(SaveProjectRequest project);
        Task<ProjectsResponse> GetProjects();
        Task<SaveTaskResponse> SaveTask(SaveTaskRequest projectTask);
        Task<TasksResponse> GetTasksByProjectId(Guid projectId);
    }

    public class ProjectService(IJWTTokenService TokenService, IHttpClientFactory ClientFactory, IConfiguration Configuration, AuthenticatedUser AuthenticatedUser, ISessionStorageService SessionStorageService) : IProjectService
    {
        private string ApiUrl = Configuration.GetValue<string>("ApiUrl")!;

        public async Task<List<Models.TaskStatus>> GetTaskStatuses()
        {
            var client = ClientFactory.CreateClient();
            var token = await SessionStorageService.GetItemAsync<string>("token");
            if (DateTime.UtcNow > new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo)
            {
                token = TokenService.GetJwtSecurityToken(AuthenticatedUser.User);
                await SessionStorageService.SetItemAsync("token", token);
            }

            List<Models.TaskStatus> taskStatuses = [];

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/Project/GetTaskStatuses");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    taskStatuses = JsonSerializer.Deserialize<List<Models.TaskStatus>>(response)!;
                }
            }

            return taskStatuses;
        }

        public async Task<ProjectsResponse> GetProjects()
        {
            var client = ClientFactory.CreateClient();
            var token = await SessionStorageService.GetItemAsync<string>("token");
            if (DateTime.UtcNow > new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo)
            {
                token = TokenService.GetJwtSecurityToken(AuthenticatedUser.User);
                await SessionStorageService.SetItemAsync("token", token);
            }

            ProjectsResponse projectsResponse = new();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/Project/GetProjects");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    projectsResponse = JsonSerializer.Deserialize<ProjectsResponse>(response)!;
                }
            }

            return projectsResponse;
        }

        public async Task<TasksResponse> GetTasksByProjectId(Guid projectId)
        {
            var client = ClientFactory.CreateClient();
            var token = await SessionStorageService.GetItemAsync<string>("token");
            if (DateTime.UtcNow > new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo)
            {
                token = TokenService.GetJwtSecurityToken(AuthenticatedUser.User);
                await SessionStorageService.SetItemAsync("token", token);
            }

            TasksResponse tasksResponse = new();

            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{ApiUrl}/Project/GetTasksByProjectId/{projectId}");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    tasksResponse = JsonSerializer.Deserialize<TasksResponse>(response)!;
                }
            }

            return tasksResponse;
        }

        public async Task<SaveProjectResponse> SaveProject(SaveProjectRequest project)
        {
            var client = ClientFactory.CreateClient();
            var token = await SessionStorageService.GetItemAsync<string>("token");
            if (DateTime.UtcNow > new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo)
            {
                token = TokenService.GetJwtSecurityToken(AuthenticatedUser.User);
                await SessionStorageService.SetItemAsync("token", token);
            }

            SaveProjectResponse projectsResponse = new();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/Project/SaveProject");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = JsonContent.Create(project);
            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    projectsResponse = JsonSerializer.Deserialize<SaveProjectResponse>(response)!;
                }
            }

            return projectsResponse;
        }

        public async Task<SaveTaskResponse> SaveTask(SaveTaskRequest projectTask)
        {
            var client = ClientFactory.CreateClient();
            var token = await SessionStorageService.GetItemAsync<string>("token");
            if (DateTime.UtcNow > new JwtSecurityTokenHandler().ReadJwtToken(token).ValidTo)
            {
                token = TokenService.GetJwtSecurityToken(AuthenticatedUser.User);
                await SessionStorageService.SetItemAsync("token", token);
            }

            SaveTaskResponse tasksResponse = new();

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{ApiUrl}/Project/SaveTask");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            requestMessage.Content = JsonContent.Create(projectTask);
            var httpResponse = await client.SendAsync(requestMessage);

            if (httpResponse.IsSuccessStatusCode)
            {
                var response = await httpResponse.Content.ReadAsStringAsync();
                if (response != null)
                {
                    tasksResponse = JsonSerializer.Deserialize<SaveTaskResponse>(response)!;
                }
            }

            return tasksResponse;
        }
    }
}
