using Tracker.App.Models;

namespace Tracker.App.Services;

public static class TaskManagementService
{
    public static void AddTask(string taskName)
    {
        if (string.IsNullOrWhiteSpace(taskName))
        {
            throw new ArgumentException("Task name cannot be empty.", nameof(taskName));
        }

        var tasks = TasksRepo.LoadTasksFromFile();

        int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1; // id = max existing id + 1, or 1 if no tasks exist

        var now = DateTime.UtcNow;
        var newTask = new TaskItem
        {
            Id = newId,
            Description = taskName.Trim(),
            Status = TaskItemStatus.Todo,
            CreatedAt = now,
            UpdatedAt = now
        };

        tasks.Add(newTask);
        TasksRepo.SaveTasksToFile(tasks);

        Console.WriteLine($"Task added: {newTask.Id} - {newTask.Description}");
    }

    public static void UpdateTask(int taskId, string newTaskName)

    {
        Console.WriteLine("moq UpdateTask: " + taskId + " -> " + newTaskName);
    }

    public static void RemoveTask(int taskId)
    {
        Console.WriteLine("moq RemoveTask: " + taskId);
    }

    public static void MarkTaskInProgress(int taskId)
    {
        Console.WriteLine("moq MarkTaskInProgress: " + taskId);
    }

    public static void MarkTaskTodo(int taskId)
    {
        Console.WriteLine("moq MarkTaskTodo: " + taskId);
    }

    public static void MarkTaskDone(int taskId)
    {
        Console.WriteLine("moq MarkTaskDone: " + taskId);
    }

    public static void ListTasks()
    {
        var tasks = TasksRepo.LoadTasksFromFile();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} - {task.Description} [{task.Status}] {{CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}}}");
        }
    }

    public static void ListDoneTasks()
    {
        Console.WriteLine("moq ListDoneTasks");
    }

    public static void ListTodoTasks()
    {
        Console.WriteLine("moq ListTodoTasks");
    }

    public static void ListInProgressTasks()
    {
        Console.WriteLine("moq ListInProgressTasks");
    }
}
