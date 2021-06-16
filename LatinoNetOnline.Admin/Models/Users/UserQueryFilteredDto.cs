using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Users
{
    public class UserQueryFilteredDto
    {
        public int Size { get; set; }
        public IList<UserRolesDto> Items { get; set; }
    }
}
