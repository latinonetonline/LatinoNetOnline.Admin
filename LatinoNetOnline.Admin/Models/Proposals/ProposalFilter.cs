using System;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public class ProposalFilter
    {
        public string Title { get; set; }
        public DateTime? Date { get; set; }
        public bool? IsActive { get; set; }
        public bool? Oldest { get; set; }
    }
}
