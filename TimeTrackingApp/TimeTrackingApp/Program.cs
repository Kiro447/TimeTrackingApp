using TimeTrackingAppDomain.Entities;
using TimeTrackingAppDomain.Enums;
using TimeTrackingAppUI.Helpers;
using TimeTrackingAppUI.Interfaces;
using TimeTrackingAppUI.Menus;
using TimeTrackingAppUI.Services;

Menu menus = new Menu();
User currentUser = new User();
IUserService<User> userService = new UserService<User>();
ActivityService<BaseActivity> appServices = new ActivityService<BaseActivity>();
while (true)
{
    int userChoice = menus.LogInMenu();
    Console.Clear();
    switch (userChoice)
    {
        case 1:
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            currentUser = userService.LogIn(username, password);
            break;
        case 2:
            Console.WriteLine("Enter the folowing to register:");

            Console.WriteLine("First name:");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name:");
            string lastName = Console.ReadLine();
            Console.WriteLine("Age:");
            int age = Validators.ParseNumber(Console.ReadLine(), 120);
            Console.WriteLine("Username:");
            string registerUserame = Console.ReadLine();
            Console.WriteLine("Password:");
            string registerPassword = Console.ReadLine();

            var user = new User(firstName, lastName, age, registerUserame, registerPassword);
            userService.Register(user);
            StringHelpers.ColorChanger("You succesfully registered!", ConsoleColor.Green);

            currentUser = user;
            if (currentUser == null) continue;
            break;
        case 3:
            Environment.Exit(0);
            break;
    }
    if (currentUser == null) continue;
    bool isLoggedIn = true;
    while (isLoggedIn)
    {
        Console.WriteLine($"Hi {currentUser.FirstName} choose one of the following?");
        int choice = menus.MainMenu();
        ActivityType currentActivity = (ActivityType)choice;
        Console.Clear();
        switch (choice)
        {
            case 1:
            case 2:
            case 3:
            case 4:
                appServices.TrackingTime(currentActivity, currentUser, userService);
                break;
            case 5:
                if (!Validators.ListEmptyCheck(currentUser.ListOfActivities, "statistics")) continue;
                int statisticsMenu = menus.StatisticsMenu();
                userService.SeeStatistics(currentUser, statisticsMenu);
                break;
            case 6:
                int accountMenu = menus.AccountMenu();
                if (userService.AccountSettings(currentUser.Id, accountMenu, currentUser))
                {
                    isLoggedIn = !isLoggedIn;
                }
                break;
            case 7:
                isLoggedIn = !isLoggedIn;
                break;
            default:
                break;
        }
    }
}


void UserData() 
{ 
    userService.Register(new User("Kiril", " Jordanov", 25, "Test123", "Test123"));
}