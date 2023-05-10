using TimeTrackingAppDomain.Entities;

namespace TimeTrackingAppUI.Interfaces;

public interface IUserService<T> where T : User
{
    void ChangePassword(int userId, string oldPassword, string newPassword);
    void ChangeInfo(int userId, string firstName, string lastName);
    bool DeactivateAccount(User user);
    User LogIn(string username, string password);
    User Register(T user);
    void SeeStatistics(User user, int choice);
    bool AccountSettings(int id, int choice, User user);
    void AddActivity<T>(User user, T activity, List<T> list) where T : BaseActivity;
}
