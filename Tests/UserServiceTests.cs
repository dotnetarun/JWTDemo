using Moq;
using TaskManagementApi.Data;
using TaskManagementApi.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Xunit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TaskManagementApi.Models;

namespace TaskManagementApi.Tests;
public class UserServiceTests
{
    private readonly Mock<TaskContext> _mockContext;
    private readonly Mock<IConfiguration> _mockConfig;
    private readonly Mock<ILogger<UserService>> _mockLogger;
    private readonly UserService _service;

    public UserServiceTests()
    {
        _mockContext = new Mock<TaskContext>();
        _mockConfig = new Mock<IConfiguration>();
        _mockLogger = new Mock<ILogger<UserService>>();
        _mockConfig.Setup(c => c["Jwt:Key"]).Returns("YourSuperSecretKey1234567890");
        _mockConfig.Setup(c => c["Jwt:Issuer"]).Returns("TaskManagementApi");
        _mockConfig.Setup(c => c["Jwt:Audience"]).Returns("TaskManagementApi");
        _service = new UserService(_mockContext.Object, _mockConfig.Object, _mockLogger.Object);
    }

    [Fact]
    public async Task RegisterAsync_CreatesUser()
    {
        var username = "testuser";
        var password = "password123";
        var dbSetMock = new Mock<DbSet<User>>();
        _mockContext.Setup(c => c.Users).Returns(dbSetMock.Object);
        _mockContext.Setup(c => c.Users.Any(It.IsAny<Expression<Func<User, bool>>>())).Returns(false);

        var user = await _service.RegisterAsync(username, password);

        Assert.NotNull(user);
        Assert.Equal(username, user.Username);
    }
}