namespace IdentityApi.Controllers;
using System.Web.Http;
using IdentityApi.Models;
using IdentityApi.Servies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

public class UserController : ApiController
{
    private IUserService _userService;
    private ILogger _logger;
    public UserController(IUserService userService, ILogger logger)
    {
        _userService = userService;
        _logger = logger;
    }

    // [EnableRateLimiting ]
    //POST "api/user"
    public void CreateUser([System.Web.Http.FromBody]UserModel newUser, [System.Web.Http.FromBody]string password)
    {
        // User input validation/sanitization

        _userService.CreateUser(newUser, password);
    }

    // [EnableRateLimiting ]
    //POST "api/user/login"
    public string Login([System.Web.Http.FromBody]string userName, [System.Web.Http.FromBody]string password)
    {
        var user = _userService.Login(userName, password);

        if(null == user)
        {
            throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
        }
  
        string jwt = ToJwt(user);

        return jwt;
    }

    private string ToJwt(UserModel user)
    {
        return "Jwt";
    }
}
