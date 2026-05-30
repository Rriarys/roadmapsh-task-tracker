Console.WriteLine("Tracker App is running!");

const int MaxLength = 200;

while (true)
{
    Console.Write("Enter your command > ");
    string? userInputCommand = Console.ReadLine();

    // Normalize and validate the user input
    if (string.IsNullOrEmpty(userInputCommand))
    {
        Console.WriteLine("Command cannot be empty. Please try again.");
        continue;
    }
    else if (userInputCommand == "exit")
    {
        Console.WriteLine("Exiting the application...");
        break;
    }
    else
    {
        userInputCommand = userInputCommand.Trim().ToLower();

        if (userInputCommand.Length > MaxLength)
        {
            Console.WriteLine($"Command cannot exceed {MaxLength} characters. Please try again.");
            continue;
        }
    }

    Console.WriteLine($"You entered: {userInputCommand}");
}