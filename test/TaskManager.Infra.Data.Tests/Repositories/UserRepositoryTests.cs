using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.Data.Tests.Repositories;

public class UserRepositoryTests
{
    private readonly TaskManagerContext _context;
    private readonly UserRepository _userRepository;

    public UserRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<TaskManagerContext>()
            .UseInMemoryDatabase(databaseName: "TaskManagerTestDb")
            .Options;

        _context = new TaskManagerContext(options);
        _userRepository = new UserRepository(_context);
    }

    [Fact]
    public async Task AddUser_ShouldAddUser_WhenUserIsValid()
    {
        // Arrange
        var user = new User
        {
            Nome = "Test User",
            Email = "test@example.com",
            Senha = "password123"
        };

        // Act
        var result = await _userRepository.Add(user);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Test User", result.Nome);
        Assert.Equal("test@example.com", result.Email);
    }

    [Fact]
    public async Task GetByEmail_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var user = new User
        {
            Nome = "Existing User",
            Email = "existing@example.com",
            Senha = "password123"
        };
        await _userRepository.Add(user);

        // Act
        var result = await _userRepository.GetByEmail("existing@example.com");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Existing User", result.Nome);
    }

    [Fact]
    public async Task GetByEmailAndPassword_ShouldReturnUser_WhenCredentialsAreCorrect()
    {
        // Arrange
        var user = new User
        {
            Nome = "Credential User",
            Email = "credential@example.com",
            Senha = "password123"
        };
        await _userRepository.Add(user);

        // Act
        var result = await _userRepository.GetByEmailAndPassword("credential@example.com", "password123");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Credential User", result.Nome);
    }

    [Fact]
    public async Task GetByName_ShouldReturnUser_WhenUserExists()
    {
        // Arrange
        var user = new User
        {
            Nome = "Name User",
            Email = "name@example.com",
            Senha = "password123"
        };
        await _userRepository.Add(user);

        // Act
        var result = await _userRepository.GetByName("Name User");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("name@example.com", result.Email);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
