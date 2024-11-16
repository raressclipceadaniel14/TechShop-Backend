using api.Models.Auth;
using api.Repositories.Interfaces;
using Dapper;
using System.Data;

namespace api.Repositories.Implementations
{
    public class AuthRepository: BaseRepository, IAuthRepository
    {
        private const string GetUserByEmailSP = "Auth_GetUserByEmail";
        private const string SaveUserSP = "Auth_SaveUser";

        public AuthRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<UserModel> GetUserByEmail(string email)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                return await connection.QueryFirstOrDefaultAsync<UserModel>(GetUserByEmailSP,
                    param: new
                    {
                        Email = email
                    },
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task Register(RegisterRequest registerRequest)
        {
            using (var connection = ConnectionFactory(_configuration))
            {
                await connection.ExecuteAsync(SaveUserSP,
                param: new
                {
                    registerRequest.Email,
                    registerRequest.Password,
                    registerRequest.FirstName,
                    registerRequest.LastName
                },
                commandType: CommandType.StoredProcedure);
            }
        }
    }
}
