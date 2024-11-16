using api.Models.Auth;

namespace api.Repositories.Interfaces
{
    public interface IAuthRepository
    {
        Task<UserModel> GetUserByEmail(string email);
        Task Register(RegisterRequest registerRequest);
    }
}
