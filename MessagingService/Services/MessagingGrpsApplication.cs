using Grpc.Core;
using MessagingApplication;
using Google.Protobuf.WellKnownTypes;

namespace MessagingService.Services;

public class MessagingGrpsApplication : Message.MessageBase
{
    private readonly ILogger<MessagingGrpsApplication> _logger;
    private readonly IApplication _application;

    public MessagingGrpsApplication(ILogger<MessagingGrpsApplication> logger, IApplication application)
    {
        _logger = logger;
        _application = application;
    }

    public override async Task<Empty> MessageInsert(MessageModel request, ServerCallContext context)
    {
         await _application.MessageInsert(new MessagingApplication.Models.MessageModel() { ChatId = request.ChatId, Content = request.Content, StudentId = request.StudentId });
        return new Empty();
    }

    public override async Task MessageGet(GetMessageRequest request, IServerStreamWriter<MessageModel> responseStream, ServerCallContext context)
    {
        var messages = await _application.MessageGetAllByChatId(request.ChatId, request.Offset);

        foreach (var message in messages)
        {
            await responseStream.WriteAsync(new MessageModel() { Id = message.Id, ChatId = message.ChatId, Content = message.Content, SendAt =  Timestamp.FromDateTime(DateTime.SpecifyKind(message.SentAt, DateTimeKind.Utc)), StudentId = message.StudentId});
        }
    }

    public override async Task<Empty> MessageUpdate(UpdateMessageRequest request, ServerCallContext context)
    {
        await _application.MessageUpdate(new MessagingApplication.Models.MessageModel() { Id = request.Id, Content = request.Content });
        return new Empty();
    }

    public override async Task<Empty> MessageDelete(DeleteMessageRequest request, ServerCallContext context)
    {
        await _application.MessageDelete(request.Id);
        return new Empty();
    }

}
