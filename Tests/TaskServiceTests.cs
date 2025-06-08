using Moq;
using TaskManagementApi.Interfaces;
using TaskManagementApi.Models;
using TaskManagementApi.Services;
using Microsoft.Extensions.Logging;
using Xunit;

namespace TaskManagementApi.Tests;
public class TaskServiceTests
{
    private readonly Mock<ITaskRepository> _mockRepo;
    private readonly Mock<ILogger<TaskService>> _mockLogger;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly Mock<ITaskRepositoryFactory> _mockFactory;
    private readonly TaskService _service;

    public TaskServiceTests()
    {
        _mockRepo = new Mock<ITaskRepository>();
        _mockLogger = new Mock<ILogger<TaskService>>();
        _mockConfig = new Mock<IConfiguration>();
        _mockFactory = new Mock<ITaskRepositoryFactory>();
        _mockConfig.Setup(c => c["RepositoryType"]).Returns("sql");
        _mockFactory.Setup(f => f.CreateRepository("sql")).Returns(_mockRepo.Object);
        _service = new TaskService(_mockFactory.Object, _mockLogger.Object, _mockConfig.Object);
    }

    [Fact]
    public async Task GetAllTasksAsync_ReturnsUserTasks()
    {
        var userId = 1;
        var tasks = new List<ToDo> { new ToDo { Id = 1, Title = "Test Task", UserId = userId } };
        _mockRepo.Setup(repo => repo.GetAllAsync(userId)).ReturnsAsync(tasks);

        var result = await _service.GetAllTasksAsync(userId);

        Assert.Equal(tasks, result);
    }
}