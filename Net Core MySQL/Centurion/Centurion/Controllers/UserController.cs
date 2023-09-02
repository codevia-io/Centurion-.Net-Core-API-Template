using API;
using Microsoft.AspNetCore.Mvc;
using Enums;
using Forms = Models.Forms;
using Services;
using Session;

namespace Centurion.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private UserServices _services;
    public UserController()
    {
        _services = new UserServices();
    }

    [HttpPost]
    [Route("")]
    public ActionResult Create(Forms.Sigin model)
    {
        return ApiResponse.Try(
                () => _services.Created(model),
                Request.Headers,
                UserPermission.Admin
            );
    }

    [HttpGet]
    public ActionResult List()
    {
        return ApiResponse.Try(
                () => _services.List(),
                Request.Headers,
                UserPermission.Admin
            );
    }

    [HttpGet]
    [Route("find/{Id}")]
    public ActionResult Find(int Id)
    {
        return ApiResponse.Try(
                () => _services.Find(Id),
                Request.Headers,
                UserPermission.User
            );
    }
}

