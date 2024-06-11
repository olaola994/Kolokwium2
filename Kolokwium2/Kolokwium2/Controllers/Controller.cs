using Kolokwium2.DTOs;
using Kolokwium2.Services;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[ApiController]
[Route("api/characters")]
public class Controller : ControllerBase
{
    private readonly Service _services;

    public Controller(Service service)
    {
        _services = service;
    }
    [HttpGet]
    public async Task<IActionResult> GetItems()
    {
        var orders = await _services.GetItemsAsync();
        return Ok(orders);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCharacter(int id)
    {
        var character = await _services.GetCharacter(id);
        if (character == null)
        {
            return NotFound("No character found");
        }

        return Ok(character);
    }

    
    [HttpPost("{id}/backpacks")]
    public async Task<IActionResult> AddItemsBackpack(int id, int[] items)

    {
        try
        {
            var response = await _services.AddItemsToBackpack(id, items);
            return Ok(response);
        }
        catch (Exception e)
        {
            return BadRequest(e.StackTrace);
        }
    }
    
}