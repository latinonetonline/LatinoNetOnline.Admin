using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LatinoNetOnline.Admin.Models
{
    public class NotificationSubscription
    {
        public string PushEndpoint { get; set; }
        public string PushP256DH { get; set; }
        public string PushAuth { get; set; }
        public Guid? UserId { get; set; }
    }
}
