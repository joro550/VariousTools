using Spectre.Console;
using Spectre.Console.Cli;

namespace VariousTools;

public class HelloCommand : AsyncCommand<HelloCommand.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[Name]")]
        public string Name { get; set; }
    }

    public override Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        AnsiConsole.WriteLine($"Hello {settings.Name}");
        return Task.FromResult(0);
    }
}