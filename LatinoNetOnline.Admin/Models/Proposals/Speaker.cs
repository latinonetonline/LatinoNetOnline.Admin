using System;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public class Speaker
    {
        public Guid SpeakerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Twitter { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
