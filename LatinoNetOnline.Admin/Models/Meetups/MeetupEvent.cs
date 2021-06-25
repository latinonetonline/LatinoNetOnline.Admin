
using System;

namespace LatinoNetOnline.Admin.Models.Meetups
{
    public record MeetupEvent(long Id, string Name, string Local_Time, DateTime Local_Date, Uri Link, string Plain_Text_Description, Uri How_To_Find_Us, MeetupPhoto Featured_Photo);

}
