namespace TaskManagementApi.Interfaces;
public interface ITaskRepositoryFactory
{
    ITaskRepository CreateRepository(string repositoryType);
}