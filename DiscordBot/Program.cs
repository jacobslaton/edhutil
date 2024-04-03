using Discord;
using Discord.WebSocket;

namespace edhutil.discord
{
    public class Program
    {
        private static DiscordSocketClient client = new();

        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            client.Log += Log;
            string token = File.ReadAllText("config/token.txt");
            await client.LoginAsync(TokenType.Bot, token);
            await client.StartAsync();
            await Task.Delay(-1);
        }

        private static Task Log(LogMessage msg)
        {
            Console.WriteLine(msg.ToString());
            return Task.CompletedTask;
        }
    }
}

