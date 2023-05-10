using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingAppDomain.Enums;

namespace TimeTrackingAppDomain.Entities;

public class Working : BaseActivity
{
    public WorkingType WorkingType { get; set; }

    public Working()
    {
        ActivityType = ActivityType.Working;
    }
}
