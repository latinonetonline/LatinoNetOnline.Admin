using LatinoNetOnline.Admin.Models.Proposals;

using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record WebinarFull(Webinar Webinar, Proposal Proposal, IEnumerable<Speaker> Speakers);
}
