namespace Tracker.App.Services;

public static class CommandRoutingService
{
    public static void RouteCommand(string userInputCommand)
    {
        var args = CommandSplitterService.Split(userInputCommand); // Split can return Null or List<string>

        if (args == null || args.Count == 0)
        {
            Console.WriteLine("Unknown command. Please try again.");
            return;
        }

        if (args.Count == 1)
        {
            switch (args[0])
            {
                case "list":
                    TaskManagementService.ListTasks();
                    break;
                case "list-done":
                    TaskManagementService.ListDoneTasks();
                    break;
                case "list-todo":
                    TaskManagementService.ListTodoTasks();
                    break;
                case "list-in-progress":
                    TaskManagementService.ListInProgressTasks();
                    break;
                default:
                    Console.WriteLine("Unknown command or missing arguments. Please try again.");
                    break;
            }
        }
        else if (args.Count == 2)
        {
            switch (args[0])
            {
                case "add":
                    if (int.TryParse(args[1], out _))
                    {
                        Console.WriteLine("Error: Task description cannot be just a number.");
                        break;
                    }
                    TaskManagementService.AddTask(args[1]);
                    break;

                // Handles successful ID parsing for two-argument commands
                case "delete" when int.TryParse(args[1], out int id):
                    TaskManagementService.RemoveTask(id);
                    break;
                case "mark-todo" when int.TryParse(args[1], out int id):
                    TaskManagementService.MarkTaskTodo(id);
                    break;
                case "mark-in-progress" when int.TryParse(args[1], out int id):
                    TaskManagementService.MarkTaskInProgress(id);
                    break;
                case "mark-done" when int.TryParse(args[1], out int id):
                    TaskManagementService.MarkTaskDone(id);
                    break;

                // Catches valid commands with non-numeric IDs
                case "delete":
                case "mark-todo":
                case "mark-in-progress":
                case "mark-done":
                    Console.WriteLine("Error: Task ID must be a valid number.");
                    break;

                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }
        }
        else if (args.Count == 3)
        {
            switch (args[0])
            {
                // Handles successful ID parsing for update command
                case "update" when int.TryParse(args[1], out int id):
                    if (int.TryParse(args[2], out _))
                    {
                        Console.WriteLine("Error: Task description cannot be just a number.");
                        break;
                    }
                    TaskManagementService.UpdateTask(id, args[2]);
                    break;

                // Catches update command with non-numeric ID
                case "update":
                    Console.WriteLine("Error: Task ID must be a valid number.");
                    break;

                default:
                    Console.WriteLine("Unknown command. Please try again.");
                    break;
            }
        }
        else
        {
            Console.WriteLine("Too many arguments. Please try again.");
        }
    }
}