using Azure;
using FullStackTest.Services.Models;
using FullStackTest.Services.Services;
using FullStackTest.Services.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FullStackTest.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccessController (IUserService UserService, IJWTTokenService TokenService) 
        : ControllerBase
    {
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            RegisterResponse response = new();

            try
            {
                await UserService.RegisterUser(registerRequest);

                response.Status = "Ok";
                response.Message = "Registro exitoso!";
                response.IsSuccessful = true;

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            LoginResponse response = new();

            try
            {
                var user = UserService.AuthenticateUser(loginRequest.Email, loginRequest.Password);

                if (user is null)
                {
                    response.Status = "Warning";
                    response.Message = "Email o contraseña incorrectos!";
                    return BadRequest(response);
                }

                response.Status = "Ok";
                response.Message = "Inicio de sesión exitoso!";
                response.AuthenticatedUser = user;
                response.BearerToken = TokenService.GetJwtSecurityToken(user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                response.Status = "Error";
                response.Message = $"Ocurrio un error inesperado: {ex.Message}";
                return BadRequest(response);
            }
        }
    }
}
