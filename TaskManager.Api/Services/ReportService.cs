using TaskManager.Api.Interfaces;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class ReportService : IReportService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUserTaskRepository _userTaskRepository;

    public ReportService(IProjectRepository projectRepository, IUserTaskRepository userTaskRepository)
    {
        _projectRepository = projectRepository;
        _userTaskRepository = userTaskRepository;
    }

    public async Task<double> CalculateAverageCompletedTasksPerUser(Guid userId)
    {
        var dataInicial = DateTime.Now.AddDays(-30);
        var tarefasConcluidas = await _userTaskRepository.GetTasksFinishedByUser(userId, dataInicial);

        return tarefasConcluidas.Count() / 30.0; // Média diária nos últimos 30 dias
    }

    public async Task<double> CalculateAverageCompletedProjectsPerUser(Guid userId)
    {
        var dataInicial = DateTime.Now.AddDays(-30);
        var projetosConcluidos = await _projectRepository.GetProjectsFinishedByUser(userId, dataInicial);

        return projetosConcluidos.Count() / 30.0; // Média diária nos últimos 30 dias
    }

    public async Task<double> CalculateAverageCompletedTasksPerProject(Guid projectId)
    {
        var dataInicial = DateTime.Now.AddDays(-30);
        var tarefasConcluidas = await _userTaskRepository.GetTasksFinishedByProject(projectId, dataInicial);

        return tarefasConcluidas.Count() / 30.0; // Média diária nos últimos 30 dias
    }
}
