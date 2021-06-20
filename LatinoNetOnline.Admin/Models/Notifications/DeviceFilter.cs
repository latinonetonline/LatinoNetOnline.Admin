using System;

namespace LatinoNetOnline.Admin.Models.Notifications
{
    public class DeviceFilter
    {
        public Guid? UserId { get; set; }
        public string Name { get; set; }
        public string OperativeSystem { get; set; }
    }
}
