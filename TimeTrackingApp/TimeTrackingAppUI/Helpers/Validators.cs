using TimeTrackingAppDomain.Entities;

namespace TimeTrackingAppUI.Helpers;

public static class Validators
{
    public static bool ValidateUserCredentials(string username, string password)
    {
        if (username.Length >= 5 && password.Length >= 6 && password.Any(char.IsNumber) && password.Any(char.IsUpper))
        {
            return true;
        }
        return false;
    }
    public static bool ValidatePassword(string pw)
    {
        if (pw.Length >= 6 && pw.Any(char.IsNumber) && pw.Any(char.IsUpper))
        {
            return true;
        }
        return false;
    }
    public static bool ValidateUser(string firstName, string lastName, int age)
    {
        if (firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit) || firstName.Length < 2 || lastName.Length < 2 || age < 18 || age > 120)
        {
            return false;
        }
        return true;
    }
    public static bool ValidateUser(string firstName, string lastName)
    {
        if (firstName.Any(char.IsDigit) || lastName.Any(char.IsDigit) || firstName.Length < 2 || lastName.Length < 2)
        {
            return false;
        }
        return true;
    }
    public static int ParseNumber(string number, int range)
    {
        int parsedNum = 0;
        bool IsNumParsed = int.TryParse(number, out parsedNum);

        if (!IsNumParsed)
        {
            return -1;
        }
        if (parsedNum <= 0 || parsedNum > range)
        {
            return -1;
        }
        return parsedNum;
    }
    public static int GetFavouriteType<T>(T type, List<T> listOfactivities) where T : BaseActivity
    {
        int count = listOfactivities.Where(x => x.Equals(type)).Count();

        return count;
    }

    public static bool ListEmptyCheck<T>(List<T> list, string activity)
    {
        if (list.Count == 0)
        {
            StringHelpers.ColorChanger($"Sorry your {activity} are is empty.!", ConsoleColor.Red);
            return false;
        }
        return true;


    }
}
