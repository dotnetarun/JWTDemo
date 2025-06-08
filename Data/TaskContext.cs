using Microsoft.EntityFrameworkCore;
using TaskManagementApi.Models;

namespace TaskManagementApi.Data;
public class TaskContext : DbContext
{
    public TaskContext(DbContextOptions<TaskContext> options) : base(options) { }
    public DbSet<ToDo> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
}