using TaskManagementApi.Models;
public interface ITaskService

{
    Task<List<ToDo>> GetAllTasksAsync(int userId);
    Task<ToDo?> GetTaskByIdAsync(int id, int userId);
    Task<ToDo> CreateTaskAsync(ToDo task);
    Task<ToDo?> UpdateTaskAsync(int id, ToDo task, int userId);
    Task<bool> DeleteTaskAsync(int id, int userId);
}