namespace TaskManager.Api.Interfaces;

public interface IReportService
{
    Task<double> CalculateAverageCompletedTasksPerUser(Guid userId);
    Task<double> CalculateAverageCompletedProjectsPerUser(Guid userId);
    Task<double> CalculateAverageCompletedTasksPerProject(Guid projectId);
}
