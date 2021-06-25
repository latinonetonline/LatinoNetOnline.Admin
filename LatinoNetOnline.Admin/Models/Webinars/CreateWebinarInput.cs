using System;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record CreateWebinarInput(Guid ProposalId, long MeetupId);
}
