namespace Tracker.App.Models;

internal class TaskItem
{
    public static int Id { get; set; }
    public static string Description { get; set; } = null!;
    public static TaskStatus Status { get; set; }
    public static DateTime CreatedAt { get; set; }
    public static DateTime UpdatedAt { get; set; }
}
