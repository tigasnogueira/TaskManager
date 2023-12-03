using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IProjectRepository
{
    Task<IEnumerable<Project>> GetAll();
    Task<Project> GetById(Guid id);
    Task<Project> GetByName(string name);
    Task<Project> GetByNameAndUserId(string name, Guid userId);
    Task<IEnumerable<Project>> GetByUserId(Guid userId);
    Task<IEnumerable<Project>> GetByDescricao(string descricao);
    Task<IEnumerable<Project>> GetByTarefa(UserTask tarefa);
    Task<Project> Add(Project project);
    Task<Project> Update(Project project);
    Task<Project> Remove(Project project);
}
