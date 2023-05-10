namespace TimeTrackingAppDomain.Entities;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public List<Reading> ReadingActivities { get; set; }
    public List<Working> WorkingActivities { get; set; }
    public List<Exercising> ExercisingActivities { get; set; }
    public List<Hobbies> OtherHobbiesActivities { get; set; }
    public List<BaseActivity> ListOfActivities { get; set; }

    public User(string firstName, string lastName, int age, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Username = username;
        Password = password;
        ListOfActivities = new List<BaseActivity>();
        ReadingActivities = new List<Reading>();
        WorkingActivities = new List<Working>();
        ExercisingActivities = new List<Exercising>();
        OtherHobbiesActivities = new List<Hobbies>();
        IsActive = true;
    }

    public User()
    {
        IsActive = true;
        ListOfActivities = new List<BaseActivity>();
        ReadingActivities = new List<Reading>();
        WorkingActivities = new List<Working>();
        ExercisingActivities = new List<Exercising>();
        OtherHobbiesActivities = new List<Hobbies>();
    }
}

