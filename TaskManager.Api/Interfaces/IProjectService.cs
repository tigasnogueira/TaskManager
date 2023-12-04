using TaskManager.Api.Dtos;

namespace TaskManager.Api.Interfaces;

public interface IProjectService
{
    Task<ProjectDto> GetById(Guid id);
    Task<ProjectDto> GetByName(string name);
    Task<ProjectDto> GetByNameAndUserId(string name, Guid userId);
    Task<IEnumerable<ProjectDto>> GetByUserId(Guid userId);
    Task<IEnumerable<ProjectDto>> GetByUserName(string userName);
    Task<IEnumerable<ProjectDto>> GetByDescricao(string descricao);
    Task<IEnumerable<ProjectDto>> GetByTarefa(UserTaskDto tarefa);
    Task<IEnumerable<ProjectDto>> GetAll();
    Task<ProjectDto> Add(ProjectDto project);
    Task<ProjectDto> Update(ProjectDto project);
    Task<ProjectDto> Remove(ProjectDto project);
}
