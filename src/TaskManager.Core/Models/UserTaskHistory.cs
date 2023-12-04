namespace TaskManager.Core.Models;

public class UserTaskHistory : Entity
{

    public UserTaskHistory()
    {
    }

    public Guid UserTaskId { get; set; }
    public string PropertyName { get; set; }
    public string OldValue { get; set; }
    public string NewValue { get; set; }
    public DateTime ChangeDate { get; set; }

    public UserTaskHistory(string property, string oldValue, string newValue, Guid userTaskId)
    {
        Id = Guid.NewGuid();
        UserTaskId = userTaskId;
        PropertyName = property;
        OldValue = oldValue;
        NewValue = newValue;
        ChangeDate = DateTime.Now;
    }
}
