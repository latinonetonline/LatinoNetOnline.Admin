using System;

namespace LatinoNetOnline.Admin.Models.Proposals
{
    public record UpdateSpeakerInput(Guid Id, string Name, string LastName, string Email, string Twitter, string Description);
}
