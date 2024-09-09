using GetRzdTicketBot.Models;
using RzdApi.Services.Implementations.GetTrainsDirectionsService;
using RzdApi.Services.Implementations.GetTrainsDirectionsService.Models;
using System;
using System.Text.Json;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;


class Program
{
    private static Dictionary<long, SearchCitiesDTO> _userRequestData = new Dictionary<long, SearchCitiesDTO>();
    private static void RemoveFromUserRequestData(long key)
    {
        if (_userRequestData.TryGetValue(key, out _))
        {
            _userRequestData.Remove(key);
        }
    }

    private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
    {
        // Обязательно ставим блок try-catch, чтобы наш бот не "падал" в случае каких-либо ошибок
        try
        {
            // Сразу же ставим конструкцию switch, чтобы обрабатывать приходящие Update
            switch (update.Type)
            {
                case UpdateType.Message:
                    {
                        // эта переменная будет содержать в себе все связанное с сообщениями
                        var message = update.Message;

                        // From - это от кого пришло сообщение
                        var user = message.From;

                        // Выводим на экран то, что пишут нашему боту, а также небольшую информацию об отправителе
                        Console.WriteLine($"{user.FirstName} ({user.Id}) написал сообщение: {message.Text}");

                        // Chat - содержит всю информацию о чате
                        var chat = message.Chat;

                        // Добавляем проверку на тип Message
                        switch (message.Type)
                        {
                            // Тут понятно, текстовый тип
                            case MessageType.Text:
                                {
                                    // тут обрабатываем команду /start, остальные аналогично
                                    if (message.Text == "/start")
                                    {
                                        RemoveFromUserRequestData(chat.Id);
                                        await botClient.SendTextMessageAsync(
                                            chat.Id,
                                            "Напишите, откуда вы собираетесь отправиться");
                                        return;
                                    }

                                    List<InlineKeyboardButton[]> cities = new List<InlineKeyboardButton[]>();
                                    if (!_userRequestData.ContainsKey(chat.Id))
                                    {
                                        _userRequestData.Add(chat.Id, new SearchCitiesDTO());
                                    }
                                    if (_userRequestData.TryGetValue(chat.Id, out SearchCitiesDTO data) &&
                                        String.IsNullOrWhiteSpace(data.FromCode))
                                    {
                                        var client = new GetTrainsDirectionsService();
                                        var response = await client.GetData(new GetTrainsDirectionsRequest(message.Text));

                                        if (!response.City.Any())
                                        {
                                            var responseMessage = "Направление не найдено. Попробуйте задать написать по-другому";
                                            await botClient.SendTextMessageAsync(
                                                    chat.Id,
                                                    "Напишите, откуда вы собираетесь отправиться");
                                            return;
                                        }
                                        cities = response.City.Select(z =>
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData(z.name, JsonSerializer
                                            .Serialize(new SearchCitiesCodesDTO(){ FromCode = z.expressCode }))
                                        }).ToList();
                                    }
                                    else
                                    {
                                        var client = new GetTrainsDirectionsService();
                                        var response = await client.GetData(new GetTrainsDirectionsRequest(message.Text));

                                        if (!response.City.Any())
                                        {
                                            var responseMessage = "Направление не найдено. Попробуйте задать написать по-другому";
                                            await botClient.SendTextMessageAsync(
                                                    chat.Id,
                                                    "Напишите, куда вы собираетесь отправиться");
                                            return;
                                        }
                                        cities = response.City.Select(z =>
                                        new InlineKeyboardButton[]
                                        {
                                            InlineKeyboardButton.WithCallbackData(z.name, JsonSerializer
                                            .Serialize(new SearchCitiesCodesDTO(){ ToCode = z.expressCode }))
                                        }).ToList();
                                    }
                                    var inlineKeyboard = new InlineKeyboardMarkup(cities);
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Выберите направление из предложенных",
                                        replyMarkup: inlineKeyboard);

                                    return;
                                }

                            // Добавил default , чтобы показать вам разницу типов Message
                            default:
                                {
                                    await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Используй только текст!");
                                    return;
                                }
                        }
                    }
                case UpdateType.CallbackQuery:
                    {
                        // Переменная, которая будет содержать в себе всю информацию о кнопке, которую нажали
                        var callbackQuery = update.CallbackQuery;

                        // Аналогично и с Message мы можем получить информацию о чате, о пользователе и т.д.
                        var user = callbackQuery.From;

                        // Выводим на экран нажатие кнопки
                        Console.WriteLine($"{user.FirstName} ({user.Id}) нажал на кнопку: {callbackQuery.Data}");

                        // Вот тут нужно уже быть немножко внимательным и не путаться!
                        // Мы пишем не callbackQuery.Chat , а callbackQuery.Message.Chat , так как
                        // кнопка привязана к сообщению, то мы берем информацию от сообщения.
                        var chat = callbackQuery.Message.Chat;
                        var dataModel = JsonSerializer.Deserialize<SearchCitiesCodesDTO>(callbackQuery.Data);
                        if (!_userRequestData.ContainsKey(chat.Id))
                        {
                            _userRequestData.Add(chat.Id, new SearchCitiesDTO());
                        }

                        _userRequestData.TryGetValue(chat.Id, out SearchCitiesDTO data);
                        if (!String.IsNullOrWhiteSpace(dataModel.ToCode))
                        {
                            data.ToCode = dataModel.ToCode;
                        }
                        else if (!String.IsNullOrWhiteSpace(dataModel.FromCode))
                        {
                            data.FromCode = dataModel.FromCode;
                        }

                        await botClient.AnswerCallbackQueryAsync(callbackQuery.Id);

                        if (!String.IsNullOrWhiteSpace(data.FromCode) && !String.IsNullOrWhiteSpace(data.ToCode))
                        {
                            await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        $"Вы отправляетесь из {data.FromCode} в {data.ToCode}");
                        }
                        else
                        {
                            await botClient.SendTextMessageAsync(
                                        chat.Id,
                                        "Теперь напишите, куда вы собираетесь отправиться");
                        }

                        return;
                    }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }

    private static Task ErrorHandler(ITelegramBotClient botClient, Exception error, CancellationToken cancellationToken)
    {
        // Тут создадим переменную, в которую поместим код ошибки и её сообщение 
        var ErrorMessage = error switch
        {
            ApiRequestException apiRequestException
                => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
            _ => error.ToString()
        };

        Console.WriteLine(ErrorMessage);
        return Task.CompletedTask;
    }

    // Это клиент для работы с Telegram Bot API, который позволяет отправлять сообщения, управлять ботом, подписываться на обновления и многое другое.
    private static ITelegramBotClient _botClient;
    // Это объект с настройками работы бота. Здесь мы будем указывать, какие типы Update мы будем получать, Timeout бота и так далее.
    private static ReceiverOptions _receiverOptions;

    static async Task Main()
    {

        _botClient = new TelegramBotClient("_");
        _receiverOptions = new ReceiverOptions // Также присваем значение настройкам бота
        {
            AllowedUpdates = new[] // Тут указываем типы получаемых Update`ов, о них подробнее расказано тут https://core.telegram.org/bots/api#update
            {
                UpdateType.Message, // Сообщения (текст, фото/видео, голосовые/видео сообщения и т.д.)
                UpdateType.CallbackQuery
            },
            // Параметр, отвечающий за обработку сообщений, пришедших за то время, когда ваш бот был оффлайн
            // True - не обрабатывать, False (стоит по умолчанию) - обрабатывать
            ThrowPendingUpdates = true,
        };

        using var cts = new CancellationTokenSource();

        // UpdateHander - обработчик приходящих Update`ов
        // ErrorHandler - обработчик ошибок, связанных с Bot API
        _botClient.StartReceiving(UpdateHandler, ErrorHandler, _receiverOptions, cts.Token); // Запускаем бота

        var me = await _botClient.GetMeAsync(); // Создаем переменную, в которую помещаем информацию о нашем боте.
        Console.WriteLine($"{me.FirstName} запущен!");

        await Task.Delay(-1);
    }
}