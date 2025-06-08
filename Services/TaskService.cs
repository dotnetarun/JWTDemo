using TaskManagementApi.Models;
using TaskManagementApi.Interfaces;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _repository;
    private readonly ILogger<TaskService> _logger;

    public TaskService(ITaskRepositoryFactory factory, ILogger<TaskService> logger, IConfiguration configuration)
    {
        _repository = factory.CreateRepository(configuration["RepositoryType"] ?? "sql");
        _logger = logger;
    }

    public async Task<List<ToDo>> GetAllTasksAsync(int userId)
    {
        return await _repository.GetAllAsync(userId);
    }

    public async Task<ToDo?> GetTaskByIdAsync(int id, int userId)
    {
        var task = await _repository.GetByIdAsync(id);
        return task?.UserId == userId ? task : null;
    }

    public async Task<ToDo> CreateTaskAsync(ToDo task)
    {
        return await _repository.CreateAsync(task);
    }

    public async Task<ToDo?> UpdateTaskAsync(int id, ToDo task, int userId)
    {
        var existingTask = await _repository.GetByIdAsync(id);
        if (existingTask == null || existingTask.UserId != userId) return null;
        existingTask.Title = task.Title;
        existingTask.Description = task.Description;
        existingTask.Status = task.Status;
        existingTask.DueDate = task.DueDate;
        return await _repository.UpdateAsync(id, existingTask);
    }

    public async Task<bool> DeleteTaskAsync(int id, int userId)
    {
        var task = await _repository.GetByIdAsync(id);
        if (task == null || task.UserId != userId) return false;
        return await _repository.DeleteAsync(id);
    }
}