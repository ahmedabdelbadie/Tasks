using Microsoft.AspNetCore.Mvc;
using Task.PersonAddress.BLL.Services.IServices;
using Task.PersonAddress.BLL.Utilities.CustomExceptions;
using Task.PersonAddress.DTO.DTOs;

namespace Task.PersonAddress.API.Controllers.V2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(PersonToLoginDTO userToLoginDTO)
        {
            try
            {
                var user = await _authService.LoginAsync(userToLoginDTO);

                return Ok(user);
            }
            catch (PersonNotFoundException)
            {
                return Unauthorized();
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(PersonToRegisterDTO userToRegisterDTO)
        {
            try
            {
                return Ok(await _authService.RegisterAsync(userToRegisterDTO));
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
