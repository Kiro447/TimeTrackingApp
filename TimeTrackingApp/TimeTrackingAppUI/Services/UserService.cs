using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTrackingAppDataAccess;
using TimeTrackingAppDataAccess.Interfaces;
using TimeTrackingAppDomain.Entities;
using TimeTrackingAppUI.Helpers;
using TimeTrackingAppUI.Interfaces;

namespace TimeTrackingAppUI.Services;

public class UserService<T> : IUserService<T> where T : User
{
    private IDataAccess<User> db;
    private ActivityService<BaseActivity> activityServices = new ActivityService<BaseActivity>();
    public UserService()
    {
        db = new DataAccess<User>();
    }

    public bool AccountSettings(int id, int choice, User user)
    {
        switch (choice)
        {
            case 1:
                Console.WriteLine("Enter your new first and last name!");
                string firstName = StringHelpers.GetInput("Enter your first name: ");
                string lastName = StringHelpers.GetInput("Enter your last name: ");
                ChangeInfo(id, firstName, lastName);
                break;
            case 2:
                Console.WriteLine("Enter your old password");
                Console.Write("Old password: ");
                string oldPassword = Console.ReadLine();
                Console.WriteLine("Enter your new password");
                Console.Write("New password: ");
                string newPassword = Console.ReadLine();
                ChangePassword(id, oldPassword, newPassword);
                break;
            case 3:
                if (DeactivateAccount(user))
                {
                    return true;
                }
                break;
            case 4:
                break;
        }
        return false;
    }

    public void AddActivity<T1>(User user, T1 activity, List<T1> list) where T1 : BaseActivity
    {
        list.Add(activity);
        db.UpdateUser(user);
    }

    public void ChangeInfo(int userId, string firstName, string lastName)
    {
        var user = db.GetUserById(userId);

        if (!Validators.ValidateUser(firstName, lastName))
        {
            StringHelpers.ColorChanger("FirstName and Last name must be longer than 2 chars and should not contain numbers", ConsoleColor.Red);
            return;

        }
        user.FirstName = firstName;
        user.LastName = lastName;
        db.UpdateUser(user);
        StringHelpers.ColorChanger("You have updated you Name", ConsoleColor.Green);
    }

    public void ChangePassword(int userId, string oldPassword, string newPassword)
    {
        var user = db.GetUserById(userId);
        if (user.Password == oldPassword && oldPassword != newPassword)
        {
            if (!Validators.ValidatePassword(newPassword))
            {

                StringHelpers.ColorChanger("Passworr must be longer 6 characters and should contain at least on capital letter " +
                                        "and at least one number", ConsoleColor.Red);
                Thread.Sleep(3000);
                return;
            }
        }
        else
        {
            StringHelpers.ColorChanger("Your password cannot be the same as the previous!", ConsoleColor.Red);
            Thread.Sleep(3000);
            return;
        }
        user.Password = newPassword;
        db.UpdateUser(user);
        StringHelpers.ColorChanger("Your password is changed!!", ConsoleColor.Green);
    }


    public bool DeactivateAccount(User user)
    {
        Console.WriteLine("Do you want to deactivete your account ? Y/N");
        string choice = Console.ReadLine();
        if (choice == "y")
        {
            user.IsActive = false;
            StringHelpers.ColorChanger("Your have deacivated your account", ConsoleColor.Green);
            return true;
        }
        return false;
    }

    public User LogIn(string username, string password)
    {
        int maxAttempts = 3;
        int loginCount = 0;
        User user = null;

        do
        {
            user = db.GetAll().FirstOrDefault(x => x.Username == username && x.Password == password);
            if (user != null)
            {
                if (user.IsActive == false)
                {
                    Console.WriteLine("Your account is deactivated! Do you want to activate it? y/n");
                    string choice = Console.ReadLine();
                    if (choice == "y")
                    {
                        user.IsActive = true;
                        db.UpdateUser(user);
                        StringHelpers.ColorChanger("Your account is now active!", ConsoleColor.Green);
                        StringHelpers.ColorChanger("You successfully logged in!", ConsoleColor.Green);
                        return user;
                    }
                    else
                    {
                        StringHelpers.ColorChanger("Your account is still deactivated!", ConsoleColor.Red);
                        return null;
                    }
                }
                else
                {
                    StringHelpers.ColorChanger("Login successful", ConsoleColor.Green);
                    return user;
                }
            }
            else
            {
                loginCount++;
                StringHelpers.ColorChanger("Invalid username or password", ConsoleColor.Red);
                if (loginCount < maxAttempts)
                {
                    Console.WriteLine($"You have {maxAttempts - loginCount} attempts left.");
                    Console.WriteLine("Enter Username");
                    username = Console.ReadLine();
                    Console.WriteLine("Enter Password");
                    password = Console.ReadLine();
                }
            }
        } while (loginCount < maxAttempts);

        StringHelpers.ColorChanger("Too many attempts. Application is closing.", ConsoleColor.Red);
        Environment.Exit(0);

        return null;
    }





    public User Register(T user)
    {
        if (!Validators.ValidateUser(user.FirstName, user.LastName, user.Age) || !Validators.ValidateUserCredentials(user.Username, user.Password))
        {
            StringHelpers.ColorChanger("You have entered something wrong!", ConsoleColor.Red);
            Console.ReadLine();
            return null;
        }
        int id = db.Insert(user);
        Console.Clear();
        return db.GetUserById(id);
    }

    public void SeeStatistics(User user, int choice)
    {
        switch (choice)
        {
            case 1: //Reading
                activityServices.ReadingStatistics(user);
                break;
            case 2: //Working
                activityServices.WorkingStatistics(user);
                break;
            case 3: // Exercising
                activityServices.ExercisingStatistics(user);
                break;
            case 4: // Other hobbies
                activityServices.OtherHobbiesStatistics(user);
                break;
            case 5: // General
                activityServices.GeneralStatistics(user);
                break;
            default:
                break;
        }
    }
}

