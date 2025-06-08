using TaskManagementApi.Interfaces;
using TaskManagementApi.Models;

namespace TaskManagementApi.Data;
public class InMemoryTaskRepository : ITaskRepository
{
    private readonly List<ToDo> _tasks = new();
    public async Task<List<ToDo>> GetAllAsync(int userId)
    {
        return await Task.FromResult(_tasks.Where(t => t.UserId == userId).ToList());
    }

    public async Task<ToDo?> GetByIdAsync(int id)
    {
        return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == id));
    }

    public async Task<ToDo> CreateAsync(ToDo task)
    {
        task.Id = _tasks.Count + 1;
        _tasks.Add(task);
        return await Task.FromResult(task);
    }

    public async Task<ToDo?> UpdateAsync(int id, ToDo task)
    {
        var existing = _tasks.FirstOrDefault(t => t.Id == id);
        if (existing == null) return null;
        existing.Title = task.Title;
        existing.Description = task.Description;
        existing.Status = task.Status;
        existing.DueDate = task.DueDate;
        return await Task.FromResult(existing);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var task = _tasks.FirstOrDefault(t => t.Id == id);
        if (task == null) return false;
        _tasks.Remove(task);
        return true;
    }
}