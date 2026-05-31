using Tracker.App.Models;

namespace Tracker.App.Services;

// TODO: methods for work with JSON: EnsureFileExists(if no - create it), LoadTasksFromFile(read json), SaveTasksToFile(write json)
public static class TasksRepo
{
    private const string FileName = "tasks.json";

    public static string GetFilePath()
    {
        string currentDir = Directory.GetCurrentDirectory();
        return Path.Combine(currentDir, FileName);
    }

    public static void EnsureFileExists()
    {
        string filePath = GetFilePath();

        if (File.Exists(filePath))
        {
            return;
        }

        try
        {
            File.WriteAllText(filePath, "[]");
            Console.WriteLine("Tasks list file created successfully at: " + filePath);
            return;
        }
        catch (Exception ex)
        {
            throw new IOException($"Failed to create tasks list file at '{filePath}'.", ex);
        }
    }

    public static List<TaskItem> LoadTasksFromFile()
    {
        string filePath = GetFilePath();
        EnsureFileExists();
        Console.WriteLine($"Tasks file path: {filePath}");

        try
        {
            string jsonContent = File.ReadAllText(filePath);

            if (string.IsNullOrWhiteSpace(jsonContent)) 
                return new List<TaskItem>();

            return System.Text.Json.JsonSerializer.Deserialize<List<TaskItem>>(jsonContent) ?? new List<TaskItem>();
        }
        catch (Exception ex)
        {
            throw new IOException($"Failed to load tasks from list file at '{filePath}'.", ex);
        }
    }

    public static void SaveTasksToFile(List<TaskItem> tasks)
    {
        string filePath = GetFilePath();
        EnsureFileExists();
        try
        {
            string jsonContent = System.Text.Json.JsonSerializer.Serialize(tasks, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonContent);
        }
        catch (Exception ex)
        {
            throw new IOException($"Failed to save tasks to list file at '{filePath}'.", ex);
        }
    }
}
