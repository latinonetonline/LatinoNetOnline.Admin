using System;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record Webinar(Guid Id, Guid ProposalId, long MeetupId, Uri LiveStreaming, Uri Flyer);
}
