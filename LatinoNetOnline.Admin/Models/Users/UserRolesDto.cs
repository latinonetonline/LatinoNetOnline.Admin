using System;

namespace LatinoNetOnline.Admin.Models.Users
{
    public class UserRolesDto
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Role { get; set; }
    }
}
