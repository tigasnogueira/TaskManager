using TaskManager.Core.Models;

namespace TaskManager.Infra.Data.Interfaces;

public interface IProjectRepository : IRepository<Project>
{
    Task<Project?> GetByName(string name);
    Task<Project?> GetByNameAndUserId(string name, Guid userId);
    Task<IEnumerable<Project?>> GetByUserId(Guid userId);
    Task<IEnumerable<Project?>> GetByUserName(string userName);
    Task<IEnumerable<Project?>> GetByDescricao(string descricao);
    Task<IEnumerable<Project?>> GetByTarefa(UserTask tarefa);
    new Task<Project?> Remove(Project project);
    Task<IEnumerable<Project?>> GetProjectsFinishedByUser(Guid userId, DateTime dataInicial);
}
