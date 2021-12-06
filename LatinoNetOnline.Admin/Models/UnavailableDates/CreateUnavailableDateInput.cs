using System;

namespace LatinoNetOnline.Admin.Models.UnavailableDates
{
    public class CreateUnavailableDateInput
    {
        public CreateUnavailableDateInput(DateTime date, string reason)
        {
            Date = date;
            Reason = reason;
        }

        public DateTime Date { get; set; }
        public string Reason { get; set; }
    }
}
