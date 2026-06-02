using Tracker.App.Models;

namespace Tracker.App.Services;

public static class TaskManagementService
{
    public static List<TaskItem> TaskLoader(bool hideNotfoundMsg = false)
    {
        var tasks = TasksRepo.LoadTasksFromFile();

        // if no tasks, print a message and return
        if (!tasks.Any())
        {
            if (!hideNotfoundMsg) // hide this msg for non-listing operations like add, update, remove, mark, etc. to avoid confusion
                Console.WriteLine("No tasks found.");

            return new List<TaskItem>();
        }

        return tasks;
    }

    public static void AddTask(string taskName)
    {
        if (string.IsNullOrWhiteSpace(taskName))
        {
            throw new ArgumentException("Task name cannot be empty.", nameof(taskName));
        }

        var tasks = TaskLoader(true);

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
        // to check if task exists, we can load all tasks and find the one with the given id, change its description and save the list back to the file, update the UpdatedAt field to the current time, and dont touch status and CreatedAt fields
        var tasks = TaskLoader(true);
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
            return;
        }

        task.Description = newTaskName.Trim();
        task.UpdatedAt = DateTime.UtcNow;
        TasksRepo.SaveTasksToFile(tasks);
        Console.WriteLine($"Task updated: {task.Id} - {task.Description}");
    }

    public static void RemoveTask(int taskId)
    {
        // to check if task exists, we can load all tasks and find the one with the given id, remove it from the list and save the list back to the file
        var tasks = TaskLoader(true);
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
            return;
        }

        tasks.Remove(task);
        TasksRepo.SaveTasksToFile(tasks);
        Console.WriteLine($"Task removed: {task.Id} - {task.Description}");
    }

    public static void MarkTaskInProgress(int taskId)
    {
        // th change only Status to InProgress, and update UpdatedAt field to the current time, and dont touch description and CreatedAt fields
        var tasks = TaskLoader(true);
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
            return;
        }

        task.Status = TaskItemStatus.InProgress;
        task.UpdatedAt = DateTime.UtcNow;
        TasksRepo.SaveTasksToFile(tasks);
        Console.WriteLine($"Task marked as InProgress: {task.Id} - {task.Description}");
    }

    public static void MarkTaskTodo(int taskId)
    {
        var tasks = TaskLoader(true);
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
            return;
        }

        task.Status = TaskItemStatus.Todo;
        task.UpdatedAt = DateTime.UtcNow;
        TasksRepo.SaveTasksToFile(tasks);
        Console.WriteLine($"Task marked as Todo: {task.Id} - {task.Description}");
    }

    public static void MarkTaskDone(int taskId)
    {
        var tasks = TaskLoader(true);
        var task = tasks.FirstOrDefault(t => t.Id == taskId);
        if (task == null)
        {
            Console.WriteLine($"Task with ID {taskId} not found.");
            return;
        }

        task.Status = TaskItemStatus.Done;
        task.UpdatedAt = DateTime.UtcNow;
        TasksRepo.SaveTasksToFile(tasks);
        Console.WriteLine($"Task marked as Done: {task.Id} - {task.Description}");
    }

    public static void ListTasks()
    {
        var tasks = TaskLoader();

        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} - {task.Description} [{task.Status}] {{CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}}}");
        }
    }

    public static void ListDoneTasks()
    {
        var tasks = TaskLoader().Where(t => t.Status == TaskItemStatus.Done).ToList();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} - {task.Description} [{task.Status}] {{CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}}}");
        }
    }

    public static void ListTodoTasks()
    {
        var tasks = TaskLoader().Where(t => t.Status == TaskItemStatus.Todo).ToList();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} - {task.Description} [{task.Status}] {{CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}}}");
        }
    }

    public static void ListInProgressTasks()
    {
        var tasks = TaskLoader().Where(t => t.Status == TaskItemStatus.InProgress).ToList();
        foreach (var task in tasks)
        {
            Console.WriteLine($"{task.Id} - {task.Description} [{task.Status}] {{CreatedAt: {task.CreatedAt}, UpdatedAt: {task.UpdatedAt}}}");
        }
    }
}
