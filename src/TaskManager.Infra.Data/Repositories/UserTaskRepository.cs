using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Infra.Data.Repositories;

public class UserTaskRepository : IUserTaskRepository
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
        var existingTask = await _context.Tasks.FindAsync(userTask.Id);

        List<UserTaskHistory> changes = new List<UserTaskHistory>();

        if (existingTask.Nome != userTask.Nome)
        {
            changes.Add(new UserTaskHistory("Nome", existingTask.Nome, userTask.Nome, userTask.Id));
            existingTask.Nome = userTask.Nome;
        }

        if (existingTask.Descricao != userTask.Descricao)
        {
            changes.Add(new UserTaskHistory("Descricao", existingTask.Descricao, userTask.Descricao, userTask.Id));
            existingTask.Descricao = userTask.Descricao;
        }

        if (existingTask.Prioridade != userTask.Prioridade)
        {
            changes.Add(new UserTaskHistory("Prioridade", existingTask.Prioridade.ToString(), userTask.Prioridade.ToString(), userTask.Id));
            existingTask.SetPrioridade(userTask.Prioridade);
        }

        if (existingTask.DataConclusao != userTask.DataConclusao)
        {
            changes.Add(new UserTaskHistory("DataConclusao", existingTask.DataConclusao.ToString(), userTask.DataConclusao.ToString(), userTask.Id));
            existingTask.DataConclusao = userTask.DataConclusao;
        }

        if (existingTask.Concluida != userTask.Concluida)
        {
            changes.Add(new UserTaskHistory("Concluida", existingTask.Concluida.ToString(), userTask.Concluida.ToString(), userTask.Id));
            existingTask.Concluida = userTask.Concluida;
        }

        if (existingTask.Ativo != userTask.Ativo)
        {
            changes.Add(new UserTaskHistory("Ativo", existingTask.Ativo.ToString(), userTask.Ativo.ToString(), userTask.Id));
            existingTask.Ativo = userTask.Ativo;
        }

        if (existingTask.Excluido != userTask.Excluido)
        {
            changes.Add(new UserTaskHistory("Excluido", existingTask.Excluido.ToString(), userTask.Excluido.ToString(), userTask.Id));
            existingTask.Excluido = userTask.Excluido;
        }

        if (existingTask.ProjetoId != userTask.ProjetoId)
        {
            changes.Add(new UserTaskHistory("ProjetoId", existingTask.ProjetoId.ToString(), userTask.ProjetoId.ToString(), userTask.Id));
            existingTask.ProjetoId = userTask.ProjetoId;
        }

        _context.Tasks.Update(userTask);
        await _context.SaveChangesAsync();

        foreach (var change in changes)
        {
            await _context.TaskHistories.AddAsync(change);
        }

        return userTask;
    }

    public async Task<UserTask> Remove(UserTask userTask)
    {
        _context.Tasks.Remove(userTask);
        await _context.SaveChangesAsync();
        return userTask;
    }
}
