using System;
using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Notifications
{
    public class DeviceFilter
    {
        public IEnumerable<Guid> Users { get; set; }
        public string Name { get; set; }
        public string OperativeSystem { get; set; }
    }
}
