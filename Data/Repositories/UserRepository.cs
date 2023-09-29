using Microsoft.EntityFrameworkCore;
using CDNFM.Models;

namespace CDNFM.Data.Repositories;

public class UserRepository : IRepository<User>
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Add(User entity)
    {
        await _context.Users.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(User entity)
    {
        _context.Users.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(User entity)
    {
        _context.Users.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
