using System;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public class Proposal
    {
        public Guid ProposalId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime CreationTime { get; set; }
        public string AudienceAnswer { get; set; }
        public string KnowledgeAnswer { get; set; }
        public string UseCaseAnswer { get; set; }
        public bool IsActive { get; set; }
    }
}
