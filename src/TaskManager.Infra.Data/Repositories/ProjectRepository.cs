using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Infra.Data.Repositories;

public class ProjectRepository : IProjectRepository
{
    private readonly TaskManagerContext _context;

    public ProjectRepository(TaskManagerContext context)
    {
        _context = context;
    }

    public async Task<Project> GetById(Guid id)
    {
        return await _context.Projects.FindAsync(id);
    }

    public async Task<Project> GetByName(string name)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Nome == name);
    }

    public async Task<Project> GetByNameAndUserId(string name, Guid userId)
    {
        return await _context.Projects.FirstOrDefaultAsync(p => p.Nome == name && p.UsuarioId == userId);
    }

    public async Task<IEnumerable<Project>> GetByUserId(Guid userId)
    {
        return await _context.Projects.Where(p => p.UsuarioId == userId).ToListAsync();
    }

    public async Task<IEnumerable<Project>> GetByDescricao(string descricao)
    {
        return await _context.Projects.Where(p => p.Descricao.Contains(descricao)).ToListAsync();
    }

    public async Task<IEnumerable<Project>> GetByTarefa(UserTask tarefa)
    {
        return await _context.Projects.Where(p => p.Tarefas.Contains(tarefa)).ToListAsync();
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _context.Projects.ToListAsync();
    }

    public async Task<Project> Add(Project project)
    {
        await _context.Projects.AddAsync(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> Update(Project project)
    {
        _context.Projects.Update(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<Project> Remove(Project project)
    {
        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }
}
