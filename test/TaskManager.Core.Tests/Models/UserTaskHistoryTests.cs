using TaskManager.Core.Models;

namespace TaskManager.Core.Tests.Models;

public class UserTaskHistoryTests
{
    [Fact]
    public void Constructor_ShouldInitializeWithDefaultValues_WhenCalledWithNoParameters()
    {
        // Act
        var history = new UserTaskHistory();

        // Assert
        Assert.NotNull(history.Id);
        Assert.Equal(Guid.Empty, history.UserTaskId);
        Assert.Null(history.PropertyName);
        Assert.Null(history.OldValue);
        Assert.Null(history.NewValue);
        Assert.Equal(default(DateTime), history.ChangeDate);
    }

    [Fact]
    public void Constructor_ShouldInitializeWithSpecifiedValues_WhenCalledWithParameters()
    {
        // Arrange
        var userTaskId = Guid.NewGuid();
        var propertyName = "Nome";
        var oldValue = "Tarefa Antiga";
        var newValue = "Tarefa Nova";

        // Act
        var history = new UserTaskHistory(propertyName, oldValue, newValue, userTaskId);

        // Assert
        Assert.Equal(userTaskId, history.UserTaskId);
        Assert.Equal(propertyName, history.PropertyName);
        Assert.Equal(oldValue, history.OldValue);
        Assert.Equal(newValue, history.NewValue);
        Assert.True(history.ChangeDate <= DateTime.Now && history.ChangeDate > DateTime.Now.AddMinutes(-1));
    }
}
