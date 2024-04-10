using Discord.Interactions;

namespace Edhutil.Discord.Modules
{
    [DontAutoRegister]
    public class AdminCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService? Commands { get; set; } = null;
        private Services.CommandHandler _handler;

        public AdminCommands(Services.CommandHandler handler)
        {
            _handler = handler;
        }

        [RequireOwner]
        [SlashCommand("shutdown", "Shutdown the bot.")]
        public async Task Shutdown()
        {
            _handler.Shutdown = true;
            await RespondAsync
            (
                $"Goodbye, {Context.User.Username}!",
                ephemeral: true
            );
        }
    }
}

