using TaskManager.Core.Models;

namespace TaskManager.Core.Tests.Models;

public class UserTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues_WhenCalled()
    {
        // Act
        var user = new User();

        // Assert
        Assert.NotNull(user.Id);
        Assert.Null(user.Nome);
        Assert.Null(user.Email);
        Assert.Null(user.Senha);
        Assert.Equal(default(DateTime), user.DataCriacao);
        Assert.Null(user.DataUltimaAtualizacao);
        Assert.Null(user.DataUltimoLogin);
        Assert.False(user.Ativo);
        Assert.False(user.Excluido);
        Assert.Null(user.Projetos);
    }

    [Fact]
    public void SetProperties_ShouldAssignCorrectValues_WhenCalled()
    {
        // Arrange
        var user = new User();
        var nome = "Teste Nome";
        var email = "teste@example.com";
        var senha = "123456";
        var dataCriacao = DateTime.UtcNow;
        var projetos = new List<Project>();

        // Act
        user.Nome = nome;
        user.Email = email;
        user.Senha = senha;
        user.DataCriacao = dataCriacao;
        user.Projetos = projetos;

        // Assert
        Assert.Equal(nome, user.Nome);
        Assert.Equal(email, user.Email);
        Assert.Equal(senha, user.Senha);
        Assert.Equal(dataCriacao, user.DataCriacao);
        Assert.Same(projetos, user.Projetos);
    }
}
