using IdentityApi.Models;

namespace IdentityApi;

public class UserEntity : UserModel
{
    public string PasswordHash {get; set;}
}
