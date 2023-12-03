using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;

    public ProjectService(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<Project> GetById(Guid id)
    {
        return await _projectRepository.GetById(id);
    }

    public async Task<Project> GetByName(string name)
    {
        return await _projectRepository.GetByName(name);
    }

    public async Task<Project> GetByNameAndUserId(string name, Guid userId)
    {
        return await _projectRepository.GetByNameAndUserId(name, userId);
    }

    public async Task<IEnumerable<Project>> GetByUserId(Guid userId)
    {
        return await _projectRepository.GetByUserId(userId);
    }

    public async Task<IEnumerable<Project>> GetByDescricao(string descricao)
    {
        return await _projectRepository.GetByDescricao(descricao);
    }

    public async Task<IEnumerable<Project>> GetByTarefa(UserTask tarefa)
    {
        return await _projectRepository.GetByTarefa(tarefa);
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _projectRepository.GetAll();
    }

    public async Task<Project> Add(Project project)
    {
        return await _projectRepository.Add(project);
    }

    public async Task<Project> Update(Project project)
    {
        return await _projectRepository.Update(project);
    }

    public async Task<Project> Remove(Project project)
    {
        return await _projectRepository.Remove(project);
    }
}
