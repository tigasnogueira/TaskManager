using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Interfaces;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ReportController : Controller
{
    private readonly IReportService _reportService;

    public ReportController(IReportService reportService)
    {
        _reportService = reportService;
    }

    [HttpGet("average-completed-tasks-per-user/{userId}")]
    public async Task<IActionResult> GetAverageCompletedTasksPerUser(Guid userId)
    {
        var average = await _reportService.CalculateAverageCompletedTasksPerUser(userId);

        return Ok(average);
    }

    [HttpGet("average-completed-projects-per-user/{userId}")]
    public async Task<IActionResult> GetAverageCompletedProjectsPerUser(Guid userId)
    {
        var average = await _reportService.CalculateAverageCompletedProjectsPerUser(userId);

        return Ok(average);
    }

    [HttpGet("average-completed-tasks-per-project/{projectId}")]
    public async Task<IActionResult> GetAverageCompletedTasksPerProject(Guid projectId)
    {
        var average = await _reportService.CalculateAverageCompletedTasksPerProject(projectId);

        return Ok(average);
    }
}
