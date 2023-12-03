using TaskManager.Core.Models;

namespace TaskManager.Api.Interfaces;

public interface IUserTaskService
{
    Task<UserTask> GetById(Guid id);
    Task<UserTask> GetByName(string name);
    Task<UserTask> GetByDescricao(string descricao);
    Task<IEnumerable<UserTask>> GetByProjectId(Guid projectId);
    Task<IEnumerable<UserTask>> GetByProjectName(string projectName);
    Task<IEnumerable<UserTask>> GetByProject(Project project);
    Task<IEnumerable<UserTask>> GetAll();
    Task<UserTask> Add(UserTask userTask);
    Task<UserTask> Update(UserTask userTask);
    Task<UserTask> Remove(UserTask userTask);
}
