using Grpc.Core;
using Grpc.Net.Client;
using MessagingService;
using System;

namespace ApiGateway.PagesInfo;

public class ChatMessages
{
    private readonly IConfiguration _configuration;

    public ChatMessages(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<IResult> GetChatMessages(int chatId, int offset)
    {
        try
        {
            var messageServiceUrl = _configuration.GetValue<string>("RequestStrings:Developer:MessageService");
            if (string.IsNullOrWhiteSpace(messageServiceUrl))
            {
                return Results.Problem("Message service URL is missing in configuration.", statusCode: 500);
            }

            using var channel = GrpcChannel.ForAddress(messageServiceUrl);
            var client = new Message.MessageClient(channel);

            var messages = new List<MessageModel>();
            using var call = client.MessageGet(new GetMessageRequest { ChatId = chatId, Offset = offset});
            await foreach (var message in call.ResponseStream.ReadAllAsync())
            {
                messages.Add(message);
            }

            return Results.Ok(messages);
        }catch (Exception ex)
        {
            return Results.Problem(ex.Message, statusCode: 500);
        }

    }
}
