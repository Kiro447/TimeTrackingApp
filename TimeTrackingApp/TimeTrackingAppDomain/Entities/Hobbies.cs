using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTrackingAppDomain.Entities;

public class Hobbies : BaseActivity
{
    public string OtherHobbie { get; set; } = string.Empty;

    public Hobbies()
    {
        ActivityType = Enums.ActivityType.OtherHobbies;
    }
}
