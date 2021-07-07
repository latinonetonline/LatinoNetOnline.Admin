using Microsoft.AspNetCore.Components.Forms;

using System;
using System.IO;

namespace LatinoNetOnline.Admin.Models.Webinars
{
    public record ConfirmWebinarInput(Guid Id, Uri Streamyard, Uri LiveStreaming, Stream Image);
}
