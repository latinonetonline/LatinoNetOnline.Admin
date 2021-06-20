namespace LatinoNetOnline.Admin.Models.Notifications
{
    public class SubscriptionDeviceInput
    {
        public string PushEndpoint { get; set; }
        public string PushP256DH { get; set; }
        public string PushAuth { get; set; }
    }
}
