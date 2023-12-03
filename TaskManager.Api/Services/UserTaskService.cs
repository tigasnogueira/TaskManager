using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _userTaskRepository;

    public UserTaskService(IUserTaskRepository userTaskRepository)
    {
        _userTaskRepository = userTaskRepository;
    }

    public async Task<UserTask> GetById(Guid id)
    {
        return await _userTaskRepository.GetById(id);
    }

    public async Task<UserTask> GetByName(string name)
    {
        return await _userTaskRepository.GetByName(name);
    }

    public async Task<UserTask> GetByDescricao(string descricao)
    {
        return await _userTaskRepository.GetByDescricao(descricao);
    }

    public async Task<IEnumerable<UserTask>> GetByProjectId(Guid projectId)
    {
        return await _userTaskRepository.GetByProjectId(projectId);
    }

    public async Task<IEnumerable<UserTask>> GetByProjectName(string projectName)
    {
        return await _userTaskRepository.GetByProjectName(projectName);
    }

    public async Task<IEnumerable<UserTask>> GetByProject(Project project)
    {
        return await _userTaskRepository.GetByProject(project);
    }

    public async Task<IEnumerable<UserTask>> GetAll()
    {
        return await _userTaskRepository.GetAll();
    }

    public async Task<UserTask> Add(UserTask userTask)
    {
        return await _userTaskRepository.Add(userTask);
    }

    public async Task<UserTask> Update(UserTask userTask)
    {
        return await _userTaskRepository.Update(userTask);
    }

    public async Task<UserTask> Remove(UserTask userTask)
    {
        return await _userTaskRepository.Remove(userTask);
    }
}
