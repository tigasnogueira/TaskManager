using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Dtos;
using TaskManager.Api.Interfaces;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : Controller
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById(Guid id)
    {
        var user = await _userService.GetById(id);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByEmail(string email)
    {
        var user = await _userService.GetByEmail(email);
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserByEmailAndPassword(string email, string password)
    {
        var user = await _userService.GetByEmailAndPassword(email, password);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var users = await _userService.GetAll();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> AddUser([FromBody] UserDto user)
    {
        var createdUser = await _userService.Add(user);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto user)
    {
        if (id != user.Id)
        {
            return BadRequest();
        }
        var updatedUser = await _userService.Update(user);
        return Ok(updatedUser);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveUser(Guid id)
    {
        var user = await _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        await _userService.Remove(user);
        return NoContent();
    }
}
