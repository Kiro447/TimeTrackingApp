namespace TimeTrackingAppDomain.Entities;

public class Hobbies : BaseActivity
{
    public string OtherHobbie { get; set; } = string.Empty;

    public Hobbies()
    {
        ActivityType = Enums.ActivityType.OtherHobbies;
    }
}
