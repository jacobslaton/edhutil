using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Edhutil.Discord
{
    public class Program
    {
        private DiscordSocketClient? _client = null;
        private InteractionService? _commands = null;
        private readonly IConfiguration _config;
        private Services.CommandHandler? _handler = null;

        public Program()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile(path: Path.Join("config", "config.json"))
                .Build();
        }

        public static Task Main(string[] args) => new Program().MainAsync(args);

        public async Task MainAsync(string[] args)
        {
            using (ServiceProvider services = ConfigureServices())
            {
                _client = services.GetRequiredService<DiscordSocketClient>();
                _commands = services.GetRequiredService<InteractionService>();
                _handler = services
                    .GetRequiredService<Services.CommandHandler>();

                _client.Log += LogAsync;
                _commands.Log += LogAsync;
                _client.Ready += ReadyAsync;

                await _client.LoginAsync(TokenType.Bot, _config["token"]);
                await _client.StartAsync();
                await _handler.InitAsync
                (
                    ulong.Parse(_config["bot_owner_id"] ?? string.Empty)
                );

                while (!_handler.Shutdown);
            }
        }

        private ServiceProvider ConfigureServices()
        {
            return new ServiceCollection()
                .AddSingleton<DiscordSocketClient>
                (
                    service =>
                    {
                        DiscordSocketConfig config = new()
                        {
                            GatewayIntents =
                                GatewayIntents.DirectMessages |
                                GatewayIntents.GuildMessages
                        };
                        return new DiscordSocketClient(config);
                    }
                )
                .AddSingleton
                (
                    service =>
                    {
                        return new InteractionService
                        (
                            service.GetRequiredService<DiscordSocketClient>()
                        );
                    }
                )
                .AddSingleton<Services.CommandHandler>()
                .AddSingleton
                (
                    service =>
                    {
                        return new Services.EdhutilApiClient
                        (
                            url: _config[$"edhutil_api_url"] ?? string.Empty
                        );
                    }
                )
                .BuildServiceProvider();
        }
        
        private Task LogAsync(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }

        private async Task ReadyAsync()
        {
            if (_commands is null)
            {
                throw new NullReferenceException
                (
                    "The commands service was not properly set."
                );
            }
            await _commands.AddModulesToGuildAsync
            (
                guildId: ulong.Parse(_config["test_guild_id"] ?? string.Empty),
                deleteMissing: false,
                modules: _commands.GetModuleInfo<Modules.AdminCommands>()
            );
            await _commands.RegisterCommandsGloballyAsync();
        }
    }
}

