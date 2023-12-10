using Moq;
using TaskManager.Api.Services;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Tests.Services;
public class ReportServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepository;
    private readonly Mock<IUserTaskRepository> _mockUserTaskRepository;
    private readonly ReportService _reportService;

    public ReportServiceTests()
    {
        _mockProjectRepository = new Mock<IProjectRepository>();
        _mockUserTaskRepository = new Mock<IUserTaskRepository>();
        _reportService = new ReportService(_mockProjectRepository.Object, _mockUserTaskRepository.Object);
    }

    [Fact]
    public async Task CalculateAverageCompletedTasksPerUser_ShouldReturnCorrectAverage()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var dataInicial = DateTime.Now.AddDays(-30);
        var tarefasConcluidas = new List<UserTask>
        {
            new UserTask { Concluida = true },
        };

        _mockUserTaskRepository.Setup(repo => repo.GetTasksFinishedByUser(userId, dataInicial))
            .ReturnsAsync(tarefasConcluidas);

        // Act
        var average = await _reportService.CalculateAverageCompletedTasksPerUser(userId);

        // Assert
        var expectedAverage = tarefasConcluidas.Count / 30.0;
        Assert.Equal(expectedAverage, average);
    }

    [Fact]
    public async Task CalculateAverageCompletedProjectsPerUser_ShouldReturnCorrectAverage()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var dataInicial = DateTime.Now.AddDays(-30);
        var projetosConcluidos = new List<Project>
        {
            new Project { /* Configuração do projeto concluído */ },
        };

        _mockProjectRepository.Setup(repo => repo.GetProjectsFinishedByUser(userId, dataInicial))
            .ReturnsAsync(projetosConcluidos);

        // Act
        var average = await _reportService.CalculateAverageCompletedProjectsPerUser(userId);

        // Assert
        var expectedAverage = projetosConcluidos.Count / 30.0;
        Assert.Equal(expectedAverage, average);
    }

    [Fact]
    public async Task CalculateAverageCompletedTasksPerProject_ShouldReturnCorrectAverage()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var dataInicial = DateTime.Now.AddDays(-30);
        var tarefasConcluidas = new List<UserTask>
        {
            new UserTask { Concluida = true },
        };

        _mockUserTaskRepository.Setup(repo => repo.GetTasksFinishedByProject(projectId, dataInicial))
            .ReturnsAsync(tarefasConcluidas);

        // Act
        var average = await _reportService.CalculateAverageCompletedTasksPerProject(projectId);

        // Assert
        var expectedAverage = tarefasConcluidas.Count / 30.0;
        Assert.Equal(expectedAverage, average);
    }
}
