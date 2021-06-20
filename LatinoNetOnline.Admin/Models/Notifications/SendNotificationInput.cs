using System;
using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Notifications
{
    class SendNotificationInput
    {
        public IEnumerable<Guid> Devices { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
    }
}
