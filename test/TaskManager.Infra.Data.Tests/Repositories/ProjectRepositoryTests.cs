using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Repositories;

namespace TaskManager.Infra.Data.Tests.Repositories;

public class ProjectRepositoryTests
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
    public async Task AddProject_ShouldAddProject()
    {
        using var context = GetDatabaseContext();
        var repository = new ProjectRepository(context);

        var project = new Project { Nome = "Test Project", Descricao = "Test Description" };
        var addedProject = await repository.Add(project);

        Assert.NotNull(addedProject);
        Assert.Equal("Test Project", addedProject.Nome);
        Assert.Equal("Test Description", addedProject.Descricao);
    }

    [Fact]
    public async Task GetProjectByName_ShouldReturnCorrectProject()
    {
        using var context = GetDatabaseContext();
        var repository = new ProjectRepository(context);

        var project = new Project { Nome = "Test Project", Descricao = "Test Description" };
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();

        var foundProject = await repository.GetByName("Test Project");

        Assert.NotNull(foundProject);
        Assert.Equal("Test Project", foundProject.Nome);
    }

    [Fact]
    public async Task RemoveProject_ShouldRemoveProject()
    {
        using var context = GetDatabaseContext();
        var repository = new ProjectRepository(context);

        var project = new Project { Nome = "Test Project", Descricao = "Test Description" };
        await context.Projects.AddAsync(project);
        await context.SaveChangesAsync();

        var addedProject = await repository.GetById(project.Id);
        Assert.NotNull(addedProject);

        await repository.Remove(addedProject);
        var deletedProject = await repository.GetById(project.Id);

        Assert.Null(deletedProject);
    }
}
