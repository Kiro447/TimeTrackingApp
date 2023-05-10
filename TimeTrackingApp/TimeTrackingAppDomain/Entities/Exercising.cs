using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingAppDomain.Enums;

namespace TimeTrackingAppDomain.Entities;

public class Exercising : BaseActivity
{
    public ExercisingType ExercisingType { get; set; }

    public Exercising()
    {
        ActivityType = ActivityType.Exercising;
    }
}