using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using MessagingApplication;

namespace MessagingService.Services;

public class ChatGrpcApplication : Chat.ChatBase
{
    private readonly ILogger<ChatGrpcApplication> _logger;
    private IApplication _application;

    public ChatGrpcApplication(ILogger<ChatGrpcApplication> logger, IApplication application)
    {
        _logger = logger;
        _application = application;
    }

    public override async Task<Empty> ChatInsert(ChatModel request, ServerCallContext context)
    {
        await _application.ChatInsert(new MessagingApplication.Models.ChatModel() { Name = request.Name });
        return new Empty();
    }

    public override async Task<ChatModel> ChatGet(GetChatRequest request, ServerCallContext context)
    {
        var response = await _application.ChatGet(request.Id);
        return new ChatModel() { Id = response.Id, Name = response.Name, CreatedAt = Timestamp.FromDateTime(DateTime.SpecifyKind(response.CreatedAt, DateTimeKind.Utc))};
    }

    public override async Task ChatGetAll(GetAllChatRequest request, IServerStreamWriter<ChatModel> responseStream, ServerCallContext context)
    {
        var chats = await _application.ChatGetAllByStudentId(request.StudentId);
        foreach (var chat in chats)
        {
            await responseStream.WriteAsync(new ChatModel() { Id = chat.Id, Name = chat.Name, CreatedAt = Timestamp.FromDateTime(DateTime.SpecifyKind(chat.CreatedAt, DateTimeKind.Utc)) });
        }
    }

    public override async Task<Empty> ChatUpdate(ChatModel request, ServerCallContext context)
    {
        await _application.ChatUpdate(new MessagingApplication.Models.ChatModel() { Id = request.Id, Name = request.Name });
        return new Empty();
    }

    public override async Task<Empty> ChatDelete(DeleteChatRequest request, ServerCallContext context)
    {
        await _application.ChatDelete(request.Id);
        return new Empty();
    }
}
