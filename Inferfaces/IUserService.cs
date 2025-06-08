using TaskManagementApi.Models;

namespace TaskManagementApi.Interfaces;
public interface IUserService
{
    Task<User?> RegisterAsync(string username, string password);
    Task<string?> LoginAsync(string username, string password);
}