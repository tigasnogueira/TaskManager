using AutoMapper;
using Moq;
using TaskManager.Api.Dtos;
using TaskManager.Api.Services;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Tests.Services;

public class UserServiceTests
{
    private readonly Mock<IUserRepository> _mockUserRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly UserService _userService;

    public UserServiceTests()
    {
        _mockUserRepository = new Mock<IUserRepository>();
        _mockMapper = new Mock<IMapper>();
        _userService = new UserService(_mockUserRepository.Object, _mockMapper.Object);
    }

    [Fact]
    public async Task GetById_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var userId = Guid.NewGuid();
        var user = new User { Id = userId, Nome = "Test User" };
        var userDto = new UserDto { Id = userId, Nome = "Test User" };

        _mockUserRepository.Setup(repo => repo.GetById(userId)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.GetById(userId);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task GetByEmail_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var email = "test@email.com";
        var user = new User { Email = email, Nome = "Test User" };
        var userDto = new UserDto { Email = email, Nome = "Test User" };

        _mockUserRepository.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.GetByEmail(email);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task GetByEmailAndPassword_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var email = "test@email.com";
        var password = "password";
        var user = new User { Email = email, Senha = password, Nome = "Test User" };
        var userDto = new UserDto { Email = email, Senha = password, Nome = "Test User" };

        _mockUserRepository.Setup(repo => repo.GetByEmailAndPassword(email, password)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.GetByEmailAndPassword(email, password);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task GetByName_ShouldReturnUserDto_WhenUserExists()
    {
        // Arrange
        var name = "Test User";
        var user = new User { Nome = name };
        var userDto = new UserDto { Nome = name };

        _mockUserRepository.Setup(repo => repo.GetByName(name)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.GetByName(name);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task GetAll_ShouldReturnUsersDto_WhenUsersExist()
    {
        // Arrange
        var users = new List<User>
        {
            new User { Nome = "Test User 1" },
            new User { Nome = "Test User 2" },
            new User { Nome = "Test User 3" }
        };
        var usersDto = new List<UserDto>
        {
            new UserDto { Nome = "Test User 1" },
            new UserDto { Nome = "Test User 2" },
            new UserDto { Nome = "Test User 3" }
        };

        _mockUserRepository.Setup(repo => repo.GetAll()).ReturnsAsync(users);
        _mockMapper.Setup(mapper => mapper.Map<IEnumerable<UserDto>>(It.IsAny<IEnumerable<User>>())).Returns(usersDto);

        // Act
        var result = await _userService.GetAll();

        // Assert
        Assert.Equal(usersDto, result);
    }

    [Fact]
    public async Task Add_ShouldReturnAddedUserDto_WhenUserIsAdded()
    {
        // Arrange
        var userDto = new UserDto { Nome = "New User" };
        var user = new User { Nome = "New User" };

        _mockMapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.Add(It.IsAny<User>())).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.Add(userDto);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task Update_ShouldReturnUpdatedUserDto_WhenUserIsUpdated()
    {
        // Arrange
        var userDto = new UserDto { Id = Guid.NewGuid(), Nome = "Updated User" };
        var user = new User { Id = userDto.Id, Nome = "Updated User" };

        _mockUserRepository.Setup(repo => repo.GetById(userDto.Id)).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.Update(It.IsAny<User>())).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.Update(userDto);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task Remove_ShouldReturnRemovedUserDto_WhenUserIsRemoved()
    {
        // Arrange
        var userDto = new UserDto { Id = Guid.NewGuid(), Nome = "Removed User" };
        var user = new User { Id = userDto.Id, Nome = "Removed User" };

        _mockMapper.Setup(mapper => mapper.Map<User>(It.IsAny<UserDto>())).Returns(user);
        _mockUserRepository.Setup(repo => repo.Remove(It.IsAny<User>())).ReturnsAsync(user);
        _mockMapper.Setup(mapper => mapper.Map<UserDto>(It.IsAny<User>())).Returns(userDto);

        // Act
        var result = await _userService.Remove(userDto);

        // Assert
        Assert.Equal(userDto, result);
    }

    [Fact]
    public async Task IsEmailAlreadyInUse_ShouldReturnTrue_WhenEmailIsInUse()
    {
        // Arrange
        var email = "test@example.com";
        var user = new User { Email = email };

        _mockUserRepository.Setup(repo => repo.GetByEmail(email)).ReturnsAsync(user);

        // Act
        var result = await _userService.IsEmailAlreadyInUse(email);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task IsNameAlreadyInUse_ShouldReturnTrue_WhenNameIsInUse()
    {
        // Arrange
        var name = "Test User";
        var user = new User { Nome = name };

        _mockUserRepository.Setup(repo => repo.GetByName(name)).ReturnsAsync(user);

        // Act
        var result = await _userService.IsNameAlreadyInUse(name);

        // Assert
        Assert.True(result);
    }
}
