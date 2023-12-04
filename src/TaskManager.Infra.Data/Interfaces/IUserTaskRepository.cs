using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IUserTaskRepository : IRepository<UserTask>
{
    Task<UserTask?> GetByName(string name);
    Task<UserTask?> GetByDescricao(string descricao);
    Task<IEnumerable<UserTask?>> GetByProjectId(Guid projectId);
    Task<IEnumerable<UserTask?>> GetByProjectName(string projectName);
    Task<IEnumerable<UserTask?>> GetByProject(Project project);
    new Task<UserTask?> Add(UserTask userTask);
    new Task<UserTask?> Update(UserTask userTask);
    Task<IEnumerable<UserTask>> GetTasksFinishedByUser(Guid userId, DateTime dataInicial);
    Task<IEnumerable<UserTask>> GetTasksFinishedByProject(Guid projectId, DateTime dataInicial);
}
