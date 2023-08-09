using Securities.API.Models;

namespace Securities.API.Repositories;

public interface IUserDataAccessLayer
{
    Task<IEnumerable<User>> GetAllUsers();
    void AddAUser(UserResponse user);
    void UpdateUser(User user);
    Task<User> GetUserData(int id);
    void DeleteAUser(int id);
}