using TwitterSharp.Client;
using Microsoft.Extensions.Options;
using Spectre.Console;

namespace VariousTools;

public class TwitterFactory
{
    private readonly IOptions<TwitterConfig> _config;

    public TwitterFactory(IOptions<TwitterConfig> config) 
        => _config = config;

    public TwitterClient GetClient()
    {
        var valueBearerToken = _config.Value.BearerToken;
        AnsiConsole.WriteLine($"[red]{valueBearerToken}[/]");
        return new TwitterClient(valueBearerToken);
    }
}