using Discord.Interactions;
using Discord.WebSocket;
using System.Reflection;

namespace Edhutil.Discord
{
    public class CommandHandler
    {
        public ulong? BotOwnerId = null;
        public bool Shutdown = false;
        private readonly DiscordSocketClient _client;
        private readonly InteractionService _commands;
        private readonly IServiceProvider _services;

        public CommandHandler
        (
            DiscordSocketClient client,
            InteractionService commands,
            IServiceProvider services
        )
        {
            _client = client;
            _commands = commands;
            _services = services;
        }

        public async Task InitAsync(ulong? ownerId)
        {
            await _commands.AddModulesAsync
            (
                assembly: Assembly.GetEntryAssembly(),
                services: _services 
            );
            _client.InteractionCreated += HandleCommandAsync;
            BotOwnerId = ownerId;
        }

        public async Task HandleCommandAsync(SocketInteraction interaction)
        {
            try
            {
                SocketInteractionContext context = new(_client, interaction);
                await _commands.ExecuteCommandAsync(context, _services);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

