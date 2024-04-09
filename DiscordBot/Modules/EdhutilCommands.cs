using Discord.Interactions;

namespace Edhutil.Discord.Modules
{
    public class EdhutilCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService? Commands { get; set; } = null;
        private CommandHandler _handler;

        public EdhutilCommands(CommandHandler handler)
        {
            _handler = handler;
        }

        [SlashCommand("hello", "Test command.")]
        public async Task Hello()
        {
            await RespondAsync($"Hello {Context.User.Username} {Context.User.Id}!");
        }
    }
}

