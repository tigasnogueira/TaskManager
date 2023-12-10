using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;

namespace TaskManager.Infra.Data.Tests.Context;

public class TaskManagerContextTests
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
    public async Task Context_ShouldSaveUser()
    {
        using var context = GetDatabaseContext();
        var user = new User { Nome = "Test User", Email = "test@test.com" };
        context.Users.Add(user);
        await context.SaveChangesAsync();

        var users = context.Users.ToList();
        Assert.Single(users);
        Assert.Equal("Test User", users.First().Nome);
    }

    [Fact]
    public async Task Context_ShouldSaveProject()
    {
        using var context = GetDatabaseContext();
        var project = new Project { Nome = "Test Project" };
        context.Projects.Add(project);
        await context.SaveChangesAsync();

        var projects = context.Projects.ToList();
        Assert.Single(projects);
        Assert.Equal("Test Project", projects.First().Nome);
    }

    [Fact]
    public async Task Context_ShouldSaveUserTask()
    {
        using var context = GetDatabaseContext();
        var userTask = new UserTask { Nome = "Test Task", Descricao = "Test Description" };
        context.Tasks.Add(userTask);
        await context.SaveChangesAsync();

        var tasks = context.Tasks.ToList();
        Assert.Single(tasks);
        Assert.Equal("Test Task", tasks.First().Nome);
    }

    [Fact]
    public async Task Context_ShouldSaveUserTaskHistory()
    {
        using var context = GetDatabaseContext();
        var history = new UserTaskHistory { PropertyName = "Nome", OldValue = "Old", NewValue = "New" };
        context.TaskHistories.Add(history);
        await context.SaveChangesAsync();

        var histories = context.TaskHistories.ToList();
        Assert.Single(histories);
        Assert.Equal("Nome", histories.First().PropertyName);
    }
}
