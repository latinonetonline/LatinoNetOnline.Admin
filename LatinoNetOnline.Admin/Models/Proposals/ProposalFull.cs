using System.Collections.Generic;
using System;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public class ProposalFull
    {
        public Proposal Proposal { get; set; }
        public IEnumerable<Speaker> Speakers { get; set; }
    }
}
