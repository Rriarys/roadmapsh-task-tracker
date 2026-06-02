namespace Tracker.App.Services;

public static class CommandRoutingService
{
    private const string UnknownCommandMessage = "Unknown command. Type help to see available commands.";
    private const string MissingUpdateIdMessage = "Missing task ID. Type help to see the command format.";
    private const string MissingDescriptionMessage = "Missing task description. Type help to see the command format.";
    private const string EmptyDescriptionMessage = "Task description cannot be empty. Type help to see the command format.";
    private const string InvalidIdMessage = "Task ID must be a number. Type help to see the command format.";
    private const string OnlyNumbersDescriptionMessage = "Task description cannot be only numbers. Type help to see the command format.";

    public static void RouteCommand(string userInputCommand)
    {
        var args = CommandSplitterService.Split(userInputCommand); // Split can return Null or List<string>

        if (args == null || args.Count == 0)
        {
            Console.WriteLine(UnknownCommandMessage);
            return;
        }

        Console.WriteLine(string.Join(", ", args));
        Console.WriteLine(args.Count);

        if (args.Count == 1)
        {
            switch (args[0])
            {
                case "add":
                    Console.WriteLine(MissingDescriptionMessage);
                    break;
                case "list":
                    TaskManagementService.ListTasks();
                    break;
                case "update":
                case "delete":
                case "mark-todo":
                case "mark-in-progress":
                case "mark-done":
                    Console.WriteLine(MissingUpdateIdMessage);
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
                    Console.WriteLine(UnknownCommandMessage);
                    break;
            }
        }
        else if (args.Count == 2)
        {
            switch (args[0])
            {
                case "add":
                    if (string.IsNullOrWhiteSpace(args[1]))
                    {
                        Console.WriteLine(MissingDescriptionMessage);
                        break;
                    }
                    // cant be only nums
                    else if (int.TryParse(args[1], out _))
                    {
                        Console.WriteLine(OnlyNumbersDescriptionMessage);
                        break;
                    }
                    TaskManagementService.AddTask(args[1]);
                    break;

                case "update" when int.TryParse(args[1], out _):
                    Console.WriteLine(MissingDescriptionMessage);
                    break;
                case "update":
                    Console.WriteLine(MissingUpdateIdMessage);
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
                    Console.WriteLine(InvalidIdMessage);
                    break;

                default:
                    Console.WriteLine(UnknownCommandMessage);
                    break;
            }
        }
        else if (args.Count == 3)
        {
            switch (args[0])
            {
                // Handles successful ID parsing for update command
                case "update" when int.TryParse(args[1], out int id):
                    if (string.IsNullOrWhiteSpace(args[2]))
                    {
                        Console.WriteLine(EmptyDescriptionMessage);
                        break;
                    }
                    else if (int.TryParse(args[2], out _))
                    {
                        Console.WriteLine(OnlyNumbersDescriptionMessage);
                        break;
                    }
                    TaskManagementService.UpdateTask(id, args[2]);
                    break;

                // Catches update command with non-numeric ID
                case "update":
                    Console.WriteLine(InvalidIdMessage);
                    break;

                default:
                    Console.WriteLine(UnknownCommandMessage);
                    break;
            }
        }
        else
        {
            Console.WriteLine(UnknownCommandMessage);
        }
    }
}