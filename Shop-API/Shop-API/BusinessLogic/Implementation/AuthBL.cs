using System.IdentityModel.Tokens.Jwt;
using api.BusinessLogic.Interfaces;
using api.Models;
using api.Models.Auth;
using api.Repositories.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;

namespace api.BusinessLogic.Implementations
{
    public class AuthBL: IAuthBL
    {
        private readonly IAuthRepository _authRepository;
        private readonly ConfigSettings _configSettings;

        public AuthBL(IAuthRepository authRepository, IOptions<ConfigSettings> options)
        {
            _authRepository = authRepository;
            _configSettings = options.Value;
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            var result = await _authRepository.GetUserByEmail(email);
            return result;
        }

        public async Task<UserSession> GenerateToken(UserModel user)
        {
            var userclaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.FirstName),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configSettings.TokenSecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configSettings.Issuer,
                audience: _configSettings.Audience,
                claims: userclaim,
                expires: DateTime.Now.AddHours(_configSettings.TokenExpiration),
                signingCredentials: creds
            );

            return new UserSession()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Id = user.Id,
                RoleId = user.RoleId,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
            };
        }

        public async Task Register(RegisterRequest registerRequest)
        {
            await _authRepository.Register(registerRequest);
        }
    }
}
