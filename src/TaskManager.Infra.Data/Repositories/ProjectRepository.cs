﻿using Microsoft.EntityFrameworkCore;
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

    public async Task<IEnumerable<Project>> GetByUserName(string userName)
    {
        return await _context.Projects.Where(p => p.Usuario.Nome == userName).ToListAsync();
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
        if (!await CanRemoveProject(project.Id))
            throw new Exception("Não é possível remover um projeto com tarefas não concluídas.");

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();
        return project;
    }

    public async Task<bool> CanRemoveProject(Guid id)
    {
        var project = await _context.Projects.Include(p => p.Tarefas).FirstOrDefaultAsync(p => p.Id == id);
        return project != null && project.Tarefas.All(t => t.Concluida);
    }

    public async Task<IEnumerable<Project>> GetProjectsFinishedByUser(Guid userId, DateTime dataInicial)
    {
        return await _context.Projects
            .Include(p => p.Tarefas)
            .Where(p => p.UsuarioId == userId && p.Tarefas.Any(t => t.DataConclusao >= dataInicial && t.Concluida))
            .ToListAsync();
    }
}
