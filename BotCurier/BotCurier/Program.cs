using BotCurier.DBContext;
using System;
using System.Collections.ObjectModel;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using static Telegram.Bot.TelegramBotClient;

internal class Program
{
    private static ReceiverOptions _receiverOptions;

    private static async Task Main(string[] args)
    {
        await Start();
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
    private static Task ErrorHandler(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ApiRequestException apiRequestException) // For Telegram API errors
        {
            Console.WriteLine($"Telegram API error code: {apiRequestException.ErrorCode}");
            Console.WriteLine($"Telegram API description: {apiRequestException.Message}");

            // You can take specific actions based on the error code
            if (apiRequestException.ErrorCode == 400) // Bad Request - например, неверный ID чата
            {
                // Handle Bad Request (e.g., notify user about invalid chat ID)
            }
        }
        else if (exception is TaskCanceledException) // Если задача была отменена (например, из-за таймаута)
        {
            // Handle task cancellation (e.g., retry the operation)
            Console.WriteLine("Task was canceled.");
        }
        else
        {
            // Handle other exceptions (general error handling)
            Console.WriteLine("Unhandled exception type.");

        }
        return Task.CompletedTask;
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
    {
        //await ButotonUp(botClient,update,cancellationToken);
        await MessageHadler(botClient, update, cancellationToken).ConfigureAwait(false);


    }
 
    async static Task MessageHadler(ITelegramBotClient botClient, Telegram.Bot.Types.Update update, CancellationToken cancellationToken)
    {
        UserDBContext userDBContext= new UserDBContext();

        var message = update.Message;
        var user = message.From;
        Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

        if (message != null)
        {
            if (message.Text == "/start")
            {
                var replyMarkupS = new ReplyKeyboardMarkup(new[]
                {
            new KeyboardButton("Поделиться контактом") { RequestContact = true }
        })
                {
                    ResizeKeyboard = true
                };

                await botClient.SendMessage(message.Chat.Id, "Приветствую тебя в боте по авторизации курьера. Для продолжения работы, пожалуйста, поделитесь контактом.", replyMarkup: replyMarkupS);
            }
            else if (message.Contact != null)
            {

                var contact = message.Contact;
                string name = $"{contact.FirstName} {contact.LastName}".Trim();
                string phone = contact.PhoneNumber;




                if (string.IsNullOrEmpty(name))
                {
                    name = "Имя не указано";
                }
                int userExists = userDBContext.FindUserByPhone(phone);
                if (userExists == 1)
                {
                    Console.WriteLine("Пользователь с таким номером телефона существует.");
                }
                else
                {
                    Console.WriteLine("Пользователь с таким номером телефона не существует.");
                }


                await botClient.SendMessage(message.Chat.Id, $"Спасибо! Ваш контакт: {name}, телефон: {phone}");
            }
        }
    }

}