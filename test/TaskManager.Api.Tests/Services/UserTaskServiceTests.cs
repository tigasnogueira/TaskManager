using AutoMapper;
using Moq;
using TaskManager.Api.Dtos;
using TaskManager.Api.Services;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Tests.Services;

public class UserTaskServiceTests
{
    private readonly Mock<IUserTaskRepository> _mockUserTaskRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserTaskService _userTaskService;

    public UserTaskServiceTests()
    {
        _mockUserTaskRepository = new Mock<IUserTaskRepository>();
        _mockMapper = new Mock<IMapper>();
        _userTaskService = new UserTaskService(_mockUserTaskRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetById_ShouldReturnUserTaskDto_WhenUserTaskExists()
    {
        // Arrange
        var userTaskId = Guid.NewGuid();
        var userTask = new UserTask { Id = userTaskId, Nome = "Test Task" };
        var userTaskDto = new UserTaskDto { Id = userTaskId, Nome = "Test Task" };

        _mockUserTaskRepository.Setup(repo => repo.GetById(userTaskId)).ReturnsAsync(userTask);
        _mockMapper.Setup(mapper => mapper.Map<UserTaskDto>(It.IsAny<UserTask>())).Returns(userTaskDto);

        // Act
        var result = await _userTaskService.GetById(userTaskId);

        // Assert
        Assert.Equal(userTaskDto, result);
    }

    // Similar tests for GetByName, GetByDescricao, GetByProjectId, GetByProjectName, GetByProject, GetAll

    [Fact]
    public async Task Add_ShouldReturnAddedUserTaskDto_WhenUserTaskIsAdded()
    {
        // Arrange
        var userTaskDto = new UserTaskDto { Nome = "New Task" };
        var userTask = new UserTask { Nome = "New Task" };

        _mockMapper.Setup(mapper => mapper.Map<UserTask>(It.IsAny<UserTaskDto>())).Returns(userTask);
        _mockUserTaskRepository.Setup(repo => repo.Add(It.IsAny<UserTask>())).ReturnsAsync(userTask);
        _mockMapper.Setup(mapper => mapper.Map<UserTaskDto>(It.IsAny<UserTask>())).Returns(userTaskDto);

        // Act
        var result = await _userTaskService.Add(userTaskDto);

        // Assert
        Assert.Equal(userTaskDto, result);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedUserTaskDto_WhenUserTaskIsUpdated()
    {
        // Arrange
        var userTaskId = Guid.NewGuid();
        var userTaskDto = new UserTaskDto { Id = userTaskId, Nome = "Updated Task" };
        var userTask = new UserTask { Id = userTaskId, Nome = "Updated Task" };

        _mockUserTaskRepository.Setup(repo => repo.GetById(userTaskId)).ReturnsAsync(userTask);
        _mockMapper.Setup(mapper => mapper.Map<UserTask>(It.IsAny<UserTaskDto>())).Returns(userTask);
        _mockUserTaskRepository.Setup(repo => repo.Update(It.IsAny<UserTask>())).ReturnsAsync(userTask);
        _mockMapper.Setup(mapper => mapper.Map<UserTaskDto>(It.IsAny<UserTask>())).Returns(userTaskDto);

        // Act
        var result = await _userTaskService.Update(userTaskDto);

        // Assert
        Assert.Equal(userTaskDto, result);
    }

    [Fact]
    public async Task Remove_ShouldReturnRemovedUserTaskDto_WhenUserTaskIsRemoved()
    {
        // Arrange
        var userTaskId = Guid.NewGuid();
        var userTaskDto = new UserTaskDto { Id = userTaskId };
        var userTask = new UserTask { Id = userTaskId };

        _mockMapper.Setup(mapper => mapper.Map<UserTask>(It.IsAny<UserTaskDto>())).Returns(userTask);
        _mockUserTaskRepository.Setup(repo => repo.Remove(It.IsAny<UserTask>())).ReturnsAsync(userTask);
        _mockMapper.Setup(mapper => mapper.Map<UserTaskDto>(It.IsAny<UserTask>())).Returns(userTaskDto);

        // Act
        var result = await _userTaskService.Remove(userTaskDto);

        // Assert
        Assert.Equal(userTaskDto, result);
    }
}
