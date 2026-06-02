using System.Text.RegularExpressions;

namespace Tracker.App.Services;

// May be: add "Go to gym", or update 1 "Go to gym at 10am"
public static class CommandSplitterService
{
    private readonly static List<string> validCommands =
    [
        "add", "list", "update", "delete", "mark-todo", "mark-in-progress", "mark-done",
        "list-done", "list-todo", "list-in-progress"
    ];

    public static List<string>? Split(string userInputCommand)
    {
        var matches = Regex.Matches(userInputCommand, @"\""([^""]*)\""|(\S+)"); // Match quoted strings or individual words

        List<string> splittedCommand = [];

        foreach (Match match in matches)
        {
            // Group[1] - text inside quotes
            if (match.Groups[1].Success)
            {
                splittedCommand.Add(match.Groups[1].Value);
            }
            // Group[2] - individual words
            else if (match.Groups[2].Success)
            {
                splittedCommand.Add(match.Groups[2].Value);
            }
            // Group[0] - whole match (fallback)
        }

        if (splittedCommand.Count != 0 && !validCommands.Contains(splittedCommand[0]))
        {
            return null;
        }

        return splittedCommand;
    }
}
