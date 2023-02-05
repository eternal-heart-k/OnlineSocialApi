using Microsoft.AspNetCore.Mvc;
using OnlineSocial.Application.Interface;
using OnlineSocial.Foundation;
using OnlineSocial.User.Model;

namespace OnlineSocial.WebApi.Controllers
{
    public class TestController : ApiBaseController
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("userinfo")]
        public Task<UserInfo> GetFirstUserInfo() => _userService.GetFirstUserInfoAsync();
    }
}