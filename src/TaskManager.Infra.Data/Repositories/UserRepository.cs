using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Models;
using TaskManager.Infra.Data.Context;
using TaskManager.Infra.Data.Interfaces;

namespace TaskManager.Infra.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly TaskManagerContext _context;

    public UserRepository(TaskManagerContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(Guid id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetByEmailAndPassword(string email, string password)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Senha == password);
    }

    public async Task<User> GetByName(string name)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Nome == name);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> Add(User user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Update(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> Remove(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return user;
    }
}
