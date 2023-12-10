using TaskManager.Api.Dtos;

namespace TaskManager.Api.Interfaces;

public interface IUserTaskService
{
    Task<UserTaskDto> GetById(Guid id);
    Task<UserTaskDto> GetByName(string name);
    Task<UserTaskDto> GetByDescricao(string descricao);
    Task<IEnumerable<UserTaskDto>> GetByProjectId(Guid projectId);
    Task<IEnumerable<UserTaskDto>> GetByProjectName(string projectName);
    Task<IEnumerable<UserTaskDto>> GetByProject(ProjectDto project);
    Task<IEnumerable<UserTaskDto>> GetAll();
    Task<UserTaskDto> Add(UserTaskDto userTask);
    Task<UserTaskDto> Update(UserTaskDto userTask);
    Task<UserTaskDto> Remove(UserTaskDto userTask);
}
