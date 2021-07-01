using System;
using System.Collections.Generic;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public record UpdateProposalInput(Guid Id, string Title, string Description, DateTime Date, string AudienceAnswer, string KnowledgeAnswer, string UseCaseAnswer, IEnumerable<UpdateSpeakerInput> Speakers);
}
