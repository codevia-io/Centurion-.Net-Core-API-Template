using API;
using Microsoft.AspNetCore.Mvc;
using Models;
using Forms = Models.Forms;
using Services;
using _API = API.API;

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
        return _API.Post(() => _services.Created(model));
    }

    [HttpGet]
    public ActionResult List()
    {
        return _API.Get(() => _services.List());
    }

    [HttpGet]
    [Route("find")]
    public ActionResult Find(int Id)
    {
        return _API.Get(() => _services.Find(Id));
    }
}

