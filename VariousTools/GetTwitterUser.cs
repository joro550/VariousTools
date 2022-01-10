using Spectre.Console;
using Spectre.Console.Cli;
using TwitterSharp.Client;

namespace VariousTools;

public class GetTwitterUser : AsyncCommand<GetTwitterUser.Settings>
{
    public class Settings : CommandSettings
    {
        [CommandArgument(0, "[Name]")]
        public string Name { get; set; }
    }

    private readonly TwitterClient _client;

    public GetTwitterUser(TwitterFactory factory) 
        => _client = factory.GetClient();

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        var user = await _client.GetUserAsync(settings.Name);
        
        // Create a table
        var table = new Table()
            .AddColumn("Username")
            .AddColumn(new TableColumn("Id").Centered());

        // Add some rows
        table.AddRow(user.Name, user.Id);

        // Render the table to the console
        AnsiConsole.Write(table);
        return 0;
    }
}