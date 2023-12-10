using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Dtos;
using TaskManager.Api.Interfaces;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserTaskController : Controller
{
    private readonly IUserTaskService _userTaskService;

    public UserTaskController(IUserTaskService userTaskService)
    {
        _userTaskService = userTaskService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserTaskById(Guid id)
    {
        var userTask = await _userTaskService.GetById(id);
        return Ok(userTask);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetUserTaskByName(string name)
    {
        var userTask = await _userTaskService.GetByName(name);
        return Ok(userTask);
    }

    [HttpGet("{projectId}")]
    public async Task<IActionResult> GetUserTaskByProjectId(Guid projectId)
    {
        var userTask = await _userTaskService.GetByProjectId(projectId);
        return Ok(userTask);
    }

    [HttpGet("{projectName}")]
    public async Task<IActionResult> GetUserTaskByProjectName(string projectName)
    {
        var userTask = await _userTaskService.GetByProjectName(projectName);
        return Ok(userTask);
    }

    [HttpGet("user-tasks/")]
    public async Task<IActionResult> GetAllUserTasks()
    {
        var userTasks = await _userTaskService.GetAll();
        return Ok(userTasks);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserTask([FromBody] UserTaskDto userTask)
    {
        var createdUserTask = await _userTaskService.Add(userTask);
        return CreatedAtAction(nameof(GetUserTaskById), new { id = createdUserTask.Id }, createdUserTask);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUserTask(Guid id, [FromBody] UserTaskDto userTask)
    {
        if (id != userTask.Id)
        {
            return BadRequest();
        }
        var updatedUserTask = await _userTaskService.Update(userTask);
        return Ok(updatedUserTask);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveUserTask(Guid id)
    {
        var userTask = await _userTaskService.GetById(id);
        if (userTask == null)
        {
            return NotFound();
        }
        await _userTaskService.Remove(userTask);
        return NoContent();
    }
}
