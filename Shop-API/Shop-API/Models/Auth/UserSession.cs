using api.Enums;

namespace api.Models.Auth
{
    public class UserSession
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public UserRoleEnum RoleId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
