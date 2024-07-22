using FullStackTest.Services.Models;
using FullStackTest.Services.Models.DbContexts;
using FullStackTest.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using static FullStackTest.Services.Commons.Utilities;
using static FullStackTest.Services.Commons.ProjectManagementCommons;

namespace FullStackTest.Services.Services
{
    public interface IUserService {
        Task RegisterUser(RegisterRequest user, bool isAdmin = false);
        User? AuthenticateUser(string email,string password);
        Task CreateAdminUser();
    }

    public class UserService(IDbContextFactory<ProjectManagementDbContext> projectManagementDbContext)
        : IUserService
    {
        public User? AuthenticateUser(string email, string password)
        {
            using var context = projectManagementDbContext.CreateDbContext();
            var cryptedPassword = encriptarSHA256(password);
            var user = context.Users
                              .Include(user => user.Role)
                              .FirstOrDefault(user => user.Email == email && user.Password == cryptedPassword && user.Active);
            return user;
        }

        public async Task RegisterUser(RegisterRequest user, bool isAdmin = false)
        {
            using var context = projectManagementDbContext.CreateDbContext();

            User newUser = new();
            newUser.FullName = user.FullName;
            newUser.Email = user.Email;
            newUser.Password = encriptarSHA256(user.Password);
            newUser.RoleId = isAdmin ? UserRoles.Admin : UserRoles.Consumer;
            context.Users.Add(newUser);

            await context.SaveChangesAsync();
        }

        public async Task CreateAdminUser()
        {
            using var context = projectManagementDbContext.CreateDbContext();

            if (!context.Users.Any(e => e.RoleId == UserRoles.Admin))
            {
                var user = new RegisterRequest();
                    user.FullName = "Javier Jimenez";
                    user.Email = "jjimenez@gmail.com";
                    user.Password = "$Test1234";
                    await RegisterUser(user, true);
            }
        }
    }
}
