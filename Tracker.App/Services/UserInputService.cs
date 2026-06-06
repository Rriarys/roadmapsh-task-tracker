namespace Tracker.App.Services;
public static class UserInputService
{
    public static string GetUserInput()
    {
        while (true)
        {
            const int MaxUserInputLength = 200;

            Console.Write("\nEnter your command > ");
            string? userInputCommand = Console.ReadLine()?.Trim().ToLower();

            // Normalize and validate the user input
            if (string.IsNullOrEmpty(userInputCommand))
            {
                Console.WriteLine("Command cannot be empty. Type help to see available commands.");
                continue;
            }

            if (userInputCommand.Length > MaxUserInputLength)
            {
                Console.WriteLine($"Command cannot exceed {MaxUserInputLength} characters. Type help to see available commands.");
                continue;
            }

            if (userInputCommand == "exit")
            {
                Console.WriteLine("Exiting application.");
                return "exit";
            }
            else if (userInputCommand == "help")
            {
                Console.WriteLine("Available commands:");

                Console.WriteLine($"  {"Command",-30} | {"Description"}");
                Console.WriteLine(new string('-', 65));

                Console.WriteLine($"  {"add <description>",-30} | Add a new task");
                Console.WriteLine($"  {"list",-30} | Show all tasks");
                Console.WriteLine($"  {"update <id> <description>",-30} | Update a task description");
                Console.WriteLine($"  {"delete <id>",-30} | Delete a task");
                Console.WriteLine($"  {"mark-todo <id>",-30} | Mark a task as todo");
                Console.WriteLine($"  {"mark-in-progress <id>",-30} | Mark a task as in progress");
                Console.WriteLine($"  {"mark-done <id>",-30} | Mark a task as done");
                Console.WriteLine($"  {"list-done",-30} | Show completed tasks");
                Console.WriteLine($"  {"list-todo",-30} | Show pending tasks");
                Console.WriteLine($"  {"list-in-progress",-30} | Show tasks in progress");
                continue;
            }
            else
            {
                //Console.WriteLine($"You entered: {userInputCommand}"); // TODO: Remove this debug line after testing
                return userInputCommand;
            }
        }
    }
}
