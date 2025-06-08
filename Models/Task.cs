namespace TaskManagementApi.Models;
public class ToDo
{
    public int Id { get; set; }
    public string Title {get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
public string Status { get; set; } = "Pending";
public DateTime? DueDate { get; set; }
public int UserId { get; set; } // Foreign key
public User? User { get; set; } // Navigation property
}