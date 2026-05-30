using Tracker.App.Services;

namespace Tracker.App.Engine;
public static class TrackerEngine
{
    public static void Run()
    {
        Console.WriteLine("Welcome to the Task Tracker App!");
        Console.WriteLine("Type 'help' to see available commands or 'exit' to quit.");
        while (true)
        {
            string userInputCommand = Services.UserInputService.GetUserInput();
            if (userInputCommand == "exit")
            {
                break;
            }
            CommandRoutingService.RouteCommand(userInputCommand);
        }
        Console.WriteLine("Thank you for using the Task Tracker App. Goodbye!");
    }
}

