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