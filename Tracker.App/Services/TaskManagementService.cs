namespace Tracker.App.Services;

public static class TaskManagementService
{
    public static void AddTask(string taskName)
    {
        Console.WriteLine("moq AddTask: " + taskName);
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
        Console.WriteLine("moq ListTasks");
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
