using TaskManagementApi.Interfaces;
using TaskManagementApi.Data;

namespace TaskManagementApi.Data;
public class TaskRepositoryFactory : ITaskRepositoryFactory
{
    private readonly IServiceProvider _serviceProvider;

    public TaskRepositoryFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ITaskRepository CreateRepository(string repositoryType)
    {
        return repositoryType.ToLower() switch
        {
            "sql" => _serviceProvider.GetService<SqlTaskRepository>()
                     ?? throw new InvalidOperationException("SqlTaskRepository not registered"),
            "inmemory" => _serviceProvider.GetService<InMemoryTaskRepository>()
                          ?? throw new InvalidOperationException("InMemoryTaskRepository not registered"),
            _ => throw new ArgumentException($"Invalid repository type: {repositoryType}")
        };
    }
}