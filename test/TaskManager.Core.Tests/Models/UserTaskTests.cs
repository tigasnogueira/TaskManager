using TaskManager.Core.Models;
using TaskManager.Core.Models.Enums;

namespace TaskManager.Core.Tests.Models;

public class UserTaskTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues_WhenCalledWithNoParameters()
    {
        // Act
        var userTask = new UserTask();

        // Assert
        Assert.NotNull(userTask.Id);
        Assert.Null(userTask.Nome);
        Assert.Null(userTask.Descricao);
        Assert.Null(userTask.Comentarios);
        // O restante das propriedades são verificadas aqui...
    }

    [Fact]
    public void Constructor_ShouldInitializeWithSpecifiedValues_WhenCalledWithParameters()
    {
        // Arrange
        var nome = "Tarefa de Teste";
        var descricao = "Descrição da tarefa";
        var prioridade = Priority.Medium;
        var projetoId = Guid.NewGuid();

        // Act
        var userTask = new UserTask(nome, descricao, prioridade, projetoId);

        // Assert
        Assert.Equal(nome, userTask.Nome);
        Assert.Equal(descricao, userTask.Descricao);
        Assert.Equal(prioridade, userTask.Prioridade);
        Assert.Equal(projetoId, userTask.ProjetoId);
        // O restante das propriedades são verificadas aqui...
    }

    [Fact]
    public void SetPrioridade_ShouldChangePriority_WhenCalledWithNewValue()
    {
        // Arrange
        var userTask = new UserTask("Tarefa", "Descrição", Priority.Low, Guid.NewGuid());

        // Act
        userTask.SetPrioridade(Priority.High);

        // Assert
        Assert.Equal(Priority.High, userTask.Prioridade);
    }
}
