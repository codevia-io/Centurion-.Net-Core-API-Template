using Enums;
using Microsoft.AspNetCore.Mvc;
using Models.Forms;
using Services;
using Session;

namespace API.Controllers
{
    [ApiController]
    public class LoginController : ControllerBase
    {
        private LoginServices _service;

        public LoginController()
        {
            _service = new LoginServices();
        }

        [HttpPost]
        [Route("login")]
        public ActionResult LogIn(Login login)
        {
            return ApiResponse.Try(() =>
                    _service.Login(login),
                    Request.Headers,
                    UserPermission.Visitor
                );
        }

        [HttpPost]
        [Route("logout")]
        public ActionResult LogOut()
        {
            return ApiResponse.Try(() =>
                    _service.LogOut(TokenManagement.Get(Request.Headers)),
                    Request.Headers,
                    UserPermission.User
                );
        }
    }
}

