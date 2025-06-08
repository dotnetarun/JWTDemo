using System.Threading.Tasks;
using TaskManagementApi.Data;
using TaskManagementApi.Models;

public class SqlTaskRepository : ITaskRepository
{
    private readonly TaskContext _context;
    public SqlTaskRepository(TaskContext context)
    {
        _context = context;
    }

    public async Task<List<ToDo>> GetAllAsync(int userId)
    {
        return await Task.FromResult(_context.Tasks.Where(t => t.UserId == userId).ToList());
    }

    public async Task<ToDo?> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<ToDo> CreateAsync(ToDo task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<ToDo?> UpdateAsync(int id, ToDo task)
    {
        var existingTask = await _context.Tasks.FindAsync(id);
        if (existingTask == null) return null;
        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.DueDate = task.DueDate;
        await _context.SaveChangesAsync();
        return existingTask;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;
        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}