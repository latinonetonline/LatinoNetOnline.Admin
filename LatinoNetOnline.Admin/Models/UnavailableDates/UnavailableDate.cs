using System;

namespace LatinoNetOnline.Admin.Models.UnavailableDates
{
    public class UnavailableDate
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
