using TaskManager.Core.Models;

namespace TaskManager.Core.Tests.Models;

public class ProjectTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues_WhenCalled()
    {
        // Act
        var project = new Project();

        // Assert
        Assert.NotNull(project.Id);
        Assert.Null(project.Nome);
        Assert.Null(project.Descricao);
        Assert.Equal(default(DateTime), project.DataCriacao);
        Assert.Null(project.DataUltimaAtualizacao);
        Assert.False(project.Ativo);
        Assert.False(project.Excluido);
        Assert.Equal(Guid.Empty, project.UsuarioId);
        Assert.Null(project.Usuario);
        Assert.Null(project.Tarefas);
    }

    [Fact]
    public void SetProperties_ShouldAssignCorrectValues_WhenCalled()
    {
        // Arrange
        var project = new Project();
        var nome = "Projeto Teste";
        var descricao = "Descrição do projeto";
        var dataCriacao = DateTime.UtcNow;
        var usuarioId = Guid.NewGuid();
        var tarefas = new List<UserTask>();

        // Act
        project.Nome = nome;
        project.Descricao = descricao;
        project.DataCriacao = dataCriacao;
        project.UsuarioId = usuarioId;
        project.Tarefas = tarefas;

        // Assert
        Assert.Equal(nome, project.Nome);
        Assert.Equal(descricao, project.Descricao);
        Assert.Equal(dataCriacao, project.DataCriacao);
        Assert.Equal(usuarioId, project.UsuarioId);
        Assert.Same(tarefas, project.Tarefas);
    }
}
