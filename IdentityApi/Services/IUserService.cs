namespace IdentityApi.Servies;
using IdentityApi.Models;

public interface IUserService
{
    // password should be salted-hashed in DB
    void CreateUser(UserModel newUser, string password);
    UserModel Login(string userName, string password);
}
