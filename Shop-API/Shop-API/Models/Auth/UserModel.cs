﻿using api.Enums;

namespace api.Models.Auth
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRoleEnum RoleId { get; set; }
    }
}
