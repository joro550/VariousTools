using VariousTools;
using Spectre.Console.Cli;
using VariousTools.Config;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

var configuration = new ConfigurationBuilder()
    .AddEnvironmentVariables()
    .AddUserSecrets<Program>()
    .Build();

var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton(configuration);
serviceCollection.Configure<TwitterConfig>(configuration.GetSection(nameof(TwitterConfig)));
serviceCollection.AddTransient<TwitterFactory>();

var app = new CommandApp(new MyTypeRegister(serviceCollection));
app.Configure(config =>
{
    config.AddCommand<HelloCommand>("hello")
        .WithAlias("hola")
        .WithDescription("Say hello")
        .WithExample(new []{"hello", "Phil"})
        .WithExample(new []{"hello", "Phil", "--count", "4"});

    config.AddCommand<GetTwitterUser>("get-user");
});
await app.RunAsync(args);