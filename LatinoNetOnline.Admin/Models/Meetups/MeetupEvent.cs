
using System;

namespace LatinoNetOnline.Admin.Models.Meetups
{
    public record MeetupEvent(string Id, string Name, string Local_Time, DateTime Local_Date, Uri Link, string Plain_Text_Description, Uri How_To_Find_Us, Image Image);

}
