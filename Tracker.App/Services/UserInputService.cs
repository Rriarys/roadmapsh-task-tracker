namespace Tracker.App.Services;
public static class UserInputService
{
    public static string GetUserInput()
    {
        while (true)
        {
            const int MaxUserInputLength = 200;

            Console.Write("Enter your command > ");
            string? userInputCommand = Console.ReadLine()?.Trim().ToLower();

            // Normalize and validate the user input
            if (string.IsNullOrEmpty(userInputCommand))
            {
                Console.WriteLine("Command cannot be empty. Please try again.");
                continue;
            }

            if (userInputCommand.Length > MaxUserInputLength)
            {
                Console.WriteLine($"Command cannot exceed {MaxUserInputLength} characters. Please try again.");
                continue;
            }

            if (userInputCommand == "exit")
            {
                Console.WriteLine("Exiting the application...");
                return "exit";
            }
            else if (userInputCommand == "help")
            {
                Console.WriteLine("Available commands:");
                Console.WriteLine("`add` -> Add a new task");
                Console.WriteLine("`list` -> List all tasks");
                Console.WriteLine("`update` -> Update an existing task");
                Console.WriteLine("`delete` -> Delete a task");
                Console.WriteLine("`mark-in-progress` -> Mark a task as in progress");
                Console.WriteLine("`mark-done` -> Mark a task as done");
                Console.WriteLine("`list-done` -> Shows only completed tasks");
                Console.WriteLine("`list-todo` -> Shows only pending tasks");
                Console.WriteLine("`list-in-progress` -> Shows only tasks in progress");
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
