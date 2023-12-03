using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;

namespace TaskManager.Api.Controllers;

public class ProjectController : Controller
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProjectById(Guid id)
    {
        var project = await _projectService.GetById(id);
        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectByName(string name)
    {
        var project = await _projectService.GetByName(name);
        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectByUserId(Guid userId)
    {
        var project = await _projectService.GetByUserId(userId);
        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetProjectByUserName(string userName)
    {
        var project = await _projectService.GetByUserName(userName);
        return Ok(project);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProjects()
    {
        var projects = await _projectService.GetAll();
        return Ok(projects);
    }

    [HttpPost]
    public async Task<IActionResult> AddProject([FromBody] Project project)
    {
        var createdProject = await _projectService.Add(project);
        return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProject(Guid id, [FromBody] Project project)
    {
        if (id != project.Id)
        {
            return BadRequest();
        }
        var updatedProject = await _projectService.Update(project);
        return Ok(updatedProject);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoveProject(Guid id)
    {
        var project = await _projectService.GetById(id);
        if (project == null)
        {
            return NotFound();
        }
        await _projectService.Remove(project);
        return NoContent();
    }
}
