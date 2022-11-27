using _02.AriBilgi.Blog.Model.UserDtos;
using _04.AriBilgi.Blog.Service;
using _05.AriBilgi.Blog.API.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _05.AriBilgi.Blog.API.Controllers
{
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public LoginDto Login([FromBody] LoginInputDto loginInputDto)
        {
            UserManager userManager = new();
            Shared shared = new();
            UserDto userDto = userManager.LoginCheck(loginInputDto.Username, loginInputDto.Password);

            if (userDto != null)
            {
                return new LoginDto()
                {
                    WebToken = shared.GenerateToken(userDto),
                };
            }

            return new LoginDto();
        }
    }
}
