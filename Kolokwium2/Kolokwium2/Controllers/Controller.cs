using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
// [Route("api/")]
public class Controller : ControllerBase
{
    private readonly Service _services;

    public Controller(Service service)
    {
        _services = service;
    }
}