using api.Models.Auth;
using Microsoft.AspNetCore.Identity.Data;

namespace api.BusinessLogic.Interfaces
{
    public interface IAuthBL
    {
        Task<UserModel> GetUserByEmail(string email);
        Task<UserSession> GenerateToken(UserModel user);
        Task Register(Models.Auth.RegisterRequest registerRequest);
    }
}
