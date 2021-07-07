using System;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record Webinar
    {
        public Guid Id { get; set; }
        public Guid ProposalId { get; set; }
        public DateTime StartDateTime { get; set; }
        public int Number { get; set; }
        public long MeetupId { get; set; }
        public string Streamyard { get; set; }
        public string LiveStreaming { get; set; }
        public string Flyer { get; set; }
        public WebinarStatus Status { get; set; }

    }
}
