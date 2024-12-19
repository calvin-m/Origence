namespace IdentityApi.Models;

public class UserModel
{
    public int UserId {get; set;}
    public string UserName {get; set;}
    public string Email {get; set;}

    public DateTimeOffset CreatedDate{get; set;}
}
