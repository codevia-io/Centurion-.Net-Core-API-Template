using API;
using Microsoft.AspNetCore.Mvc;
using Models;
using Forms = Models.Forms;
using Services;

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
        return ApiResponse.Try(() => _services.Created(model));
    }

    [HttpGet]
    public ActionResult List()
    {
        return ApiResponse.Try(() => _services.List());
    }

    [HttpGet]
    [Route("find")]
    public ActionResult Find(int Id)
    {
        return ApiResponse.Try(() => _services.Find(Id));
    }
}

