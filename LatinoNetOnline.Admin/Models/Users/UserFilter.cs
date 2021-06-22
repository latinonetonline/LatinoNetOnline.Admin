using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Users
{
    public class UserFilter
    {
        public IEnumerable<string> Users { get; set; }
        public string Search { get; set; }
        public string Role { get; set; }
    }
}
