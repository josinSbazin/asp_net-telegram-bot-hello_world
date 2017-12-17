using System.Collections.Generic;
using System.Threading.Tasks;
using Telegram.Bot;
using TelegramBot.Models.Commands;

namespace TelegramBot.Models
{
    public static class Bot
    {
        private static TelegramBotClient _client;
        private static List<Command> _commands;

        public static IReadOnlyList<Command> Commands => _commands.AsReadOnly();

        public static async Task<TelegramBotClient> Get()
        {
            if (_client != null) return _client;

            // commands init

            _commands = new List<Command>
            {
                new HelloCommand()
            };

            _client = new TelegramBotClient(AppSettings.Key);
            var hook = string.Format(AppSettings.Url, "api/message/update");
            await _client.SetWebhookAsync(hook);

            return _client;
        }
    }
}