using System;

namespace LatinoNetOnline.Admin.Models.Notifications
{
    record Device(Guid Id, string PushEndpoint, string PushP256DH, string PushAuth, Guid? UserId, string OperativeSystem, string Name);
}
