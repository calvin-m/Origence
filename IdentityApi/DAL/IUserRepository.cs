namespace IdentityApi.DAL;
using IdentityApi.Models;
public interface IUserRepository
{
    void CreateUser(UserModel newUser, string password);
    UserModel Login(string userName, string password);
}
