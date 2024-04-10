using Discord.Interactions;

namespace Edhutil.Discord.Modules
{
    public class EdhutilCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public InteractionService? Commands { get; set; } = null;
        private Services.CommandHandler _handler;
        private Services.EdhutilApiClient _client;

        public EdhutilCommands
        (
            Services.CommandHandler handler,
            Services.EdhutilApiClient client 
        )
        {
            _handler = handler;
            _client = client;
        }

        [SlashCommand("random-card", "Show a random magic card.")]
        public async Task RandomCard()
        {
            Models.Card card = await _client.GetRandomCard();
            string imageUrl = await _client.GetCardImageUrl(card.Uuid);
            await RespondAsync(imageUrl);
        }
    }
}

