using AutoMapper;
using TaskManager.Api.Dtos;
using TaskManager.Api.Interfaces;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Api.Services;

public class UserTaskService : IUserTaskService
{
    private readonly IUserTaskRepository _userTaskRepository;
    private readonly IMapper _mapper;

    public UserTaskService(IUserTaskRepository userTaskRepository, IMapper mapper)
    {
        _userTaskRepository = userTaskRepository;
        _mapper = mapper;
    }

    public async Task<UserTaskDto> GetById(Guid id)
    {
        var userTask = await _userTaskRepository.GetById(id);
        return _mapper.Map<UserTaskDto>(userTask);
    }

    public async Task<UserTaskDto> GetByName(string name)
    {
        var userTask = await _userTaskRepository.GetByName(name);
        return _mapper.Map<UserTaskDto>(userTask);
    }

    public async Task<UserTaskDto> GetByDescricao(string descricao)
    {
        var userTask = await _userTaskRepository.GetByDescricao(descricao);
        return _mapper.Map<UserTaskDto>(userTask);
    }

    public async Task<IEnumerable<UserTaskDto>> GetByProjectId(Guid projectId)
    {
        var userTask = await _userTaskRepository.GetByProjectId(projectId);
        return _mapper.Map<IEnumerable<UserTaskDto>>(userTask);
    }

    public async Task<IEnumerable<UserTaskDto>> GetByProjectName(string projectName)
    {
        var userTask = await _userTaskRepository.GetByProjectName(projectName);
        return _mapper.Map<IEnumerable<UserTaskDto>>(userTask);
    }

    public async Task<IEnumerable<UserTaskDto>> GetByProject(ProjectDto projectDto)
    {
        var project = _mapper.Map<Project>(projectDto);
        var userTask = _mapper.Map<UserTask>(project);
        return _mapper.Map<IEnumerable<UserTaskDto>>(userTask);
    }

    public async Task<IEnumerable<UserTaskDto>> GetAll()
    {
        var userTask = await _userTaskRepository.GetAll();
        return _mapper.Map<IEnumerable<UserTaskDto>>(userTask);
    }

    public async Task<UserTaskDto> Add(UserTaskDto userTaskDto)
    {
        var userTask = _mapper.Map<UserTask>(userTaskDto);
        var resultado = await _userTaskRepository.Add(userTask);
        return _mapper.Map<UserTaskDto>(resultado);
    }

    public async Task<UserTaskDto> Update(UserTaskDto userTaskDto)
    {
        var CurrentUserTask = await _userTaskRepository.GetById(userTaskDto.Id);
        if (CurrentUserTask == null)
        {
            return null;
        }
        var userTask = _mapper.Map<UserTask>(userTaskDto);
        var resultado = await _userTaskRepository.Update(userTask);
        return _mapper.Map<UserTaskDto>(resultado);
    }

    public async Task<UserTaskDto> Remove(UserTaskDto userTaskDto)
    {
        var userTask = _mapper.Map<UserTask>(userTaskDto);
        var resultado = await _userTaskRepository.Remove(userTask);
        return _mapper.Map<UserTaskDto>(resultado);
    }
}
