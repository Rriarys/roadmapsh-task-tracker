namespace Tracker.App.Models;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public TaskItemStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
