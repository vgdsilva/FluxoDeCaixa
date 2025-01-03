using FluxoDeCaixa.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDeCaixa.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUserById")]
    public ActionResult<User> GetUserById(string id)
    {
        return Ok();
    }

    [HttpPost(Name = "CreateUser")]
    public ActionResult<string> CreateUser()
    {
        return Created();
    }
}