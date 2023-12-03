using TaskManager.Core.Models;

namespace TaskManager.Api.Interfaces;

public interface IProjectService
{
    Task<Project> GetById(Guid id);
    Task<Project> GetByName(string name);
    Task<Project> GetByNameAndUserId(string name, Guid userId);
    Task<IEnumerable<Project>> GetByUserId(Guid userId);
    Task<IEnumerable<Project>> GetByDescricao(string descricao);
    Task<IEnumerable<Project>> GetByTarefa(UserTask tarefa);
    Task<IEnumerable<Project>> GetAll();
    Task<Project> Add(Project project);
    Task<Project> Update(Project project);
    Task<Project> Remove(Project project);
}
