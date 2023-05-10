using TimeTrackingAppDomain.Enums;
using TimeTrackingAppDomain.Interfaces;

namespace TimeTrackingAppDomain.Entities;

public class BaseActivity : BaseEntity, IBaseActivity
{
    public ActivityType ActivityType { get; set; }
    public DateTime StartTrackingActivity { get; set; }
    public DateTime StopTrackingActivity { get; set; }
    public TimeSpan TrackedTime { get; set; }

    public void TrackTime()
    {
        StartTrackingActivity = DateTime.Now;
        Console.WriteLine($"Tracking {ActivityType} at {StartTrackingActivity} ");
        Console.WriteLine("To stop hit ENTER");
        ConsoleKeyInfo key = Console.ReadKey();
        if (key.Key == ConsoleKey.Enter)
        {
            StopTrackingActivity = DateTime.Now;
            TrackedTime = StopTrackingActivity - StartTrackingActivity;
            if (TrackedTime.Minutes == 0)
            {
                Console.WriteLine($"You were {ActivityType} for {TrackedTime.Seconds} sec.");
            }
            else
            {
                Console.WriteLine($"You were {ActivityType} for {TrackedTime.Minutes} min {TrackedTime.Seconds} sec.");
            }

        }

    }
}
