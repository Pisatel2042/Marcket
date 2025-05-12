using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using static Telegram.Bot.TelegramBotClient;

internal class Program
{

    private static ReceiverOptions _receiverOptions;
   
    private static void Main(string[] args)
    {
        Start();
        Console.ReadLine();
    }
    public static async Task Start()
    {
        CancellationTokenSource cts = new();
        _receiverOptions = new();
        var Botclient = new TelegramBotClient("7225775703:AAGg7XN0g5b4lpiM56DMCqLv8J9_T3VH4EE");
        Botclient.StartReceiving(
     updateHandler: UpdateHandler,
     errorHandler: ErrorHandler,
     receiverOptions: _receiverOptions,
     cancellationToken: cts.Token);
    }
    private static Task ErrorHandler(ITelegramBotClient botClient, Exception arg2, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
    {
        //await ButotonUp(botClient,update,cancellationToken);
      await MessageHadler(botClient, update, cancellationToken).ConfigureAwait(false);


    }
    async static Task MessageHadler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
    {
        var message = update.Message;

        if (message != null && message.Text != null)
        {
            if (message.Text == "/start")
            {
                await botClient.SendMessage(message.Chat.Id, "Прветветвую тебя в боте по авторизации курьера, для продолжения работы Пожалуйста, поделитесь контактом  ");
                
                return;
                //await InlineButtonMainMenu(botClient,update.Message.Chat.Id, cancellationToken);
            }
        }

        return;

    }

}