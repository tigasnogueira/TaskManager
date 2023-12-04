using AutoMapper;
using TaskManager.Api.Dtos;
using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectDto> GetById(Guid id)
    {
        var project = await _projectRepository.GetById(id);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> GetByName(string name)
    {
        var project = await _projectRepository.GetByName(name);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<ProjectDto> GetByNameAndUserId(string name, Guid userId)
    {
        var project = await _projectRepository.GetByNameAndUserId(name, userId);
        return _mapper.Map<ProjectDto>(project);
    }

    public async Task<IEnumerable<ProjectDto>> GetByUserId(Guid userId)
    {
        var projects = await _projectRepository.GetByUserId(userId);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<IEnumerable<ProjectDto>> GetByUserName(string userName)
    {
        var projects = await _projectRepository.GetByUserName(userName);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<IEnumerable<ProjectDto>> GetByDescricao(string descricao)
    {
        var projects = await _projectRepository.GetByDescricao(descricao);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<IEnumerable<ProjectDto>> GetByTarefa(UserTaskDto tarefaDto)
    {
        var tarefa = _mapper.Map<UserTask>(tarefaDto);
        var projects = await _projectRepository.GetByTarefa(tarefa);
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<IEnumerable<ProjectDto>> GetAll()
    {
        var projects = await _projectRepository.GetAll();
        return _mapper.Map<IEnumerable<ProjectDto>>(projects);
    }

    public async Task<ProjectDto> Add(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var resultado = await _projectRepository.Add(project);
        return _mapper.Map<ProjectDto>(resultado);
    }

    public async Task<ProjectDto> Update(ProjectDto projectDto)
    {
        var currentProject = await _projectRepository.GetById(projectDto.Id);
        if (currentProject != null)
        {
            return null;
        }
        var project = _mapper.Map<Project>(projectDto);
        var resultado = await _projectRepository.Add(project);
        return _mapper.Map<ProjectDto>(resultado);
    }

    public async Task<ProjectDto> Remove(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var resultado = await _projectRepository.Remove(project);
        return _mapper.Map<ProjectDto>(resultado);
    }
}
