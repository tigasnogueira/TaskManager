using AutoMapper;
using Moq;
using TaskManager.Api.Dtos;
using TaskManager.Api.Services;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Tests.Services;

public class ProjectServiceTests
{
    private readonly Mock<IProjectRepository> _mockProjectRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ProjectService _projectService;

    public ProjectServiceTests()
    {
        _mockProjectRepository = new Mock<IProjectRepository>();
        _mockMapper = new Mock<IMapper>();
        _projectService = new ProjectService(_mockProjectRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetById_ShouldReturnProjectDto_WhenProjectExists()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var project = new Project { Id = projectId, Nome = "Test Project" };
        var projectDto = new ProjectDto { Id = projectId, Nome = "Test Project" };

        _mockProjectRepository.Setup(repo => repo.GetById(projectId)).ReturnsAsync(project);
        _mockMapper.Setup(mapper => mapper.Map<ProjectDto>(It.IsAny<Project>())).Returns(projectDto);

        // Act
        var result = await _projectService.GetById(projectId);

        // Assert
        Assert.Equal(projectDto, result);
    }

    // Similar tests for GetByName, GetByNameAndUserId, GetByUserId, GetByUserName, GetByDescricao, GetByTarefa, and GetAll

    [Fact]
    public async Task Add_ShouldReturnAddedProjectDto_WhenProjectIsAdded()
    {
        // Arrange
        var projectDto = new ProjectDto { Nome = "New Project" };
        var project = new Project { Nome = "New Project" };

        _mockMapper.Setup(mapper => mapper.Map<Project>(It.IsAny<ProjectDto>())).Returns(project);
        _mockProjectRepository.Setup(repo => repo.Add(It.IsAny<Project>())).ReturnsAsync(project);
        _mockMapper.Setup(mapper => mapper.Map<ProjectDto>(It.IsAny<Project>())).Returns(projectDto);

        // Act
        var result = await _projectService.Add(projectDto);

        // Assert
        Assert.Equal(projectDto, result);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedProjectDto_WhenProjectIsUpdated()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var projectDto = new ProjectDto { Id = projectId, Nome = "Updated Project" };
        var project = new Project { Id = projectId, Nome = "Updated Project" };

        _mockProjectRepository.Setup(repo => repo.GetById(projectId)).ReturnsAsync(project);
        _mockMapper.Setup(mapper => mapper.Map<Project>(It.IsAny<ProjectDto>())).Returns(project);
        _mockProjectRepository.Setup(repo => repo.Update(It.IsAny<Project>())).ReturnsAsync(project);
        _mockMapper.Setup(mapper => mapper.Map<ProjectDto>(It.IsAny<Project>())).Returns(projectDto);

        // Act
        var result = await _projectService.Update(projectDto);

        // Assert
        Assert.Equal(projectDto, result);
    }

    [Fact]
    public async Task Remove_ShouldReturnRemovedProjectDto_WhenProjectIsRemoved()
    {
        // Arrange
        var projectId = Guid.NewGuid();
        var projectDto = new ProjectDto { Id = projectId };
        var project = new Project { Id = projectId };

        _mockMapper.Setup(mapper => mapper.Map<Project>(It.IsAny<ProjectDto>())).Returns(project);
        _mockProjectRepository.Setup(repo => repo.Remove(It.IsAny<Project>())).ReturnsAsync(project);
        _mockMapper.Setup(mapper => mapper.Map<ProjectDto>(It.IsAny<Project>())).Returns(projectDto);

        // Act
        var result = await _projectService.Remove(projectDto);

        // Assert
        Assert.Equal(projectDto, result);
    }

    // Additional tests for null checks, exceptional cases, and other scenarios
}
