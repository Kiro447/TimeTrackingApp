using TimeTrackingAppDomain.Enums;

namespace TimeTrackingAppDomain.Interfaces;

public interface IBaseActivity
{
    DateTime StartTrackingActivity { get; set; }
    DateTime StopTrackingActivity { get; set; }
    TimeSpan TrackedTime { get; set; }
    ActivityType ActivityType { get; set; }
    void TrackTime();
}