using TaskManagementApi.Models;

public interface ITaskRepository
{
    Task<List<ToDo>> GetAllAsync(int userId);
    Task<ToDo?> GetByIdAsync(int id);
    Task<ToDo> CreateAsync(ToDo task);
    Task<ToDo?> UpdateAsync(int id, ToDo task);
    Task<bool> DeleteAsync(int id);
}