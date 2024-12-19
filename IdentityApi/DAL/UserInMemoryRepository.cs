using IdentityApi.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Internal;
using IdentityApi.DAL;
namespace IdentityApi.DAL;

public class UserInMemoryRepository : IUserRepository
{
    private static ICollection<UserEntity> USER_REPO = new List<UserEntity>(); 
    // Maybe Dictionary for quick lookup

    private Microsoft.AspNetCore.Authentication.ISystemClock _systemClock;
    
    public UserInMemoryRepository(Microsoft.AspNetCore.Authentication.ISystemClock systemClock)
    {
        _systemClock = systemClock;
    }
    public void CreateUser(UserModel newUser, string password)
    {
        // Validation - check if username already exist

        string passwordHash =  HashPassword(password); // ARGON hashing 
        var userEntity = new UserEntity(){
            UserName = newUser.UserName,
            Email = newUser.Email,
            PasswordHash = passwordHash,
            CreatedDate = _systemClock.UtcNow
        };

        USER_REPO.Add(userEntity);
    }

    public UserModel? Login(string userName, string password)
    {
        // Input validation - make sure password is not NullOrEmpty
        var user = USER_REPO.Where( u => u.UserName.Equals(userName)).FirstOrDefault();
        if(user != null)
        {
            string passwordHash = HashPassword(password);
            if(passwordHash.Equals(user.PasswordHash, StringComparison.OrdinalIgnoreCase))
            {
                return new UserModel(){
                    UserId = user.UserId,
                    UserName = user.UserName,
                    Email = user.Email,
                    CreatedDate = user.CreatedDate
                };
            }
        }    
        return null;
    }

    private string HashPassword(string plainTextPassword){
        return plainTextPassword; // for demo sake
    }
}
