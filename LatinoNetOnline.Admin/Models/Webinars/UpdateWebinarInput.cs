using System;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record UpdateWebinarInput(Guid Id, int Number, long MeetupId, DateTime StartDateTime, Uri Streamyard, Uri LiveStreaming, Uri Flyer, WebinarStatus Status);
}
