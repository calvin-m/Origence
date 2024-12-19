namespace IdentityApi.Servies;
using IdentityApi.Models;
using IdentityApi.DAL;
public class UserService : IUserService
{
    private IUserRepository _userRepository;
    private ILogger _logger;
    public UserService(IUserRepository userRepository, ILogger logger)
    {
        _userRepository = userRepository;
        _logger = logger;
    }
    public void CreateUser(UserModel newUser, string password)
    {
        try{
            _userRepository.CreateUser(newUser, password);
        }
        catch(Exception ex)
        {
            _logger.LogError("User creation failed: " + newUser.UserName);
        }
    }

    public UserModel? Login(string userName, string password)
    {
        try
        {
            return _userRepository.Login(userName, password);
        }
        catch(Exception ex)
        {
            _logger.LogInformation(userName + " login failed");
            return null;
        }
    }
}
