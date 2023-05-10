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
