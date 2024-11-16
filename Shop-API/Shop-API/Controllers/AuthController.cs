using api.BusinessLogic.Interfaces;
using api.Models.Auth;
using api.Utils.Security;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _authBl;
        private readonly PasswordHasher _passwordHasher;

        public AuthController(IAuthBL authBl, PasswordHasher passwordHasher)
        {
            _authBl = authBl;
            _passwordHasher = passwordHasher;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] Models.Auth.LoginRequest loginRequest)
        {
            var user = await _authBl.GetUserByEmail(loginRequest.Email);
            if (user != null)
            {
                var passwordResult = _passwordHasher.VerifyHashedPassword(user.Password, loginRequest.Password);
                
                if (passwordResult == PasswordVerificationResult.Success)
                {
                    var token = await _authBl.GenerateToken(user);

                    return Ok(token);
                }
            }

            return Unauthorized("Could not verify Email and password");
        }

        [HttpPost("register")]
        public async Task Register([FromBody] Models.Auth.RegisterRequest registerRequest)
        {
            registerRequest.Password = _passwordHasher.HashPassword(registerRequest.Password);
            await _authBl.Register(registerRequest);
        }
    }
}
