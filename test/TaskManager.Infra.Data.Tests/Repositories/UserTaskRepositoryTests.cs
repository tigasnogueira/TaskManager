using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.Data.Tests.Repositories;

public class UserTaskRepositoryTests
{
    private TaskManagerContext GetDatabaseContext()
    {
        var options = new DbContextOptionsBuilder<TaskManagerContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var databaseContext = new TaskManagerContext(options);
        databaseContext.Database.EnsureCreated();

        return databaseContext;
    }

    [Fact]
    public async Task AddUserTask_ShouldAddTask()
    {
        using var context = GetDatabaseContext();
        var repository = new UserTaskRepository(context);

        var userTask = new UserTask { Nome = "Test Task", Descricao = "Test Description" };
        var addedTask = await repository.Add(userTask);

        Assert.NotNull(addedTask);
        Assert.Equal("Test Task", addedTask.Nome);
        Assert.Equal("Test Description", addedTask.Descricao);
    }

    [Fact]
    public async Task GetUserTaskByName_ShouldReturnCorrectTask()
    {
        using var context = GetDatabaseContext();
        var repository = new UserTaskRepository(context);

        var userTask = new UserTask { Nome = "Test Task", Descricao = "Test Description" };
        await context.Tasks.AddAsync(userTask);
        await context.SaveChangesAsync();

        var foundTask = await repository.GetByName("Test Task");

        Assert.NotNull(foundTask);
        Assert.Equal("Test Task", foundTask.Nome);
    }

    [Fact]
    public async Task UpdateUserTask_ShouldUpdateTask()
    {
        using var context = GetDatabaseContext();
        var repository = new UserTaskRepository(context);

        var userTask = new UserTask { Nome = "Original Name", Descricao = "Original Description" };
        await context.Tasks.AddAsync(userTask);
        await context.SaveChangesAsync();

        userTask.Nome = "Updated Name";
        var updatedTask = await repository.Update(userTask);

        Assert.NotNull(updatedTask);
        Assert.Equal("Updated Name", updatedTask.Nome);
    }
}
