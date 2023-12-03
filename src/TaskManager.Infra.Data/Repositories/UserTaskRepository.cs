using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;

namespace TaskManager.Infra.Data.Repositories;

public class UserTaskRepository
{
    private readonly TaskManagerContext _context;

    public UserTaskRepository(TaskManagerContext context)
    {
        _context = context;
    }

    public async Task<UserTask> GetById(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<UserTask> GetByName(string name)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Nome == name);
    }

    public async Task<UserTask> GetByDescricao(string descricao)
    {
        return await _context.Tasks.FirstOrDefaultAsync(t => t.Descricao == descricao);
    }

    public async Task<IEnumerable<UserTask>> GetByProjectId(Guid projectId)
    {
        return await _context.Tasks.Where(t => t.ProjetoId == projectId).ToListAsync();
    }

    public async Task<IEnumerable<UserTask>> GetByProjectName(string projectName)
    {
        return await _context.Tasks.Where(t => t.Projeto.Nome == projectName).ToListAsync();
    }

    public async Task<IEnumerable<UserTask>> GetByProject(Project project)
    {
        return await _context.Tasks.Where(t => t.Projeto == project).ToListAsync();
    }

    public async Task<IEnumerable<UserTask>> GetAll()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<UserTask> Add(UserTask userTask)
    {
        await _context.Tasks.AddAsync(userTask);
        await _context.SaveChangesAsync();
        return userTask;
    }

    public async Task<UserTask> Update(UserTask userTask)
    {
        _context.Tasks.Update(userTask);
        await _context.SaveChangesAsync();
        return userTask;
    }

    public async Task<UserTask> Remove(UserTask userTask)
    {
        _context.Tasks.Remove(userTask);
        await _context.SaveChangesAsync();
        return userTask;
    }
}
