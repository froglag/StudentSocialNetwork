using DataAccess.DbAccess;
using MessagingApplication.Models;

namespace MessagingApplication;

public class Application : IApplication
{
    private SqlAccess _access;

    public Application(SqlAccess access)
    {
        _access = access;
    }
    public async Task MessageInsert(MessageModel message)
    {
        await _access.SaveData<dynamic>("spMessage_Insert", new { message.StudentId, message.ChatId, message.Content });
    }

    public async Task<IEnumerable<MessageModel>> MessageGetAllByChatId(int chatId)
    {
        var result = await _access.LoadData<MessageModel, dynamic>("spMessage_GetAllByChatId", new { ChatId = chatId });
        return result;
    }

    public async Task MessageUpdate(MessageModel message)
    {
        await _access.SaveData<dynamic>("spMessage_Update", new { message.Id, message.Content });
    }

    public async Task MessageDelete(int id)
    {
        await _access.SaveData<dynamic>("spMessage_Delete", new { Id = id });
    }

    public async Task ChatInsert(ChatModel chat)
    {
        await _access.SaveData<dynamic>("spChat_Insert", new { chat.Name });
    }

    public async Task<ChatModel?> ChatGet(int id)
    {
        var result = await _access.LoadData<ChatModel, dynamic>("spChat_Get", new { Id = id });
        return result.FirstOrDefault();
    }

    public async Task<IEnumerable<ChatModel>> ChatGetAllByStudentId(int studentId)
    {
        var result = await _access.LoadData<ChatModel, dynamic>("spChat_GetAllByStudentId", new { StudentId = studentId });
        return result;
    }

    public async Task ChatUpdate(ChatModel chat)
    {
        await _access.SaveData<dynamic>("spChat_Update", new { chat.Id, chat.Name });
    }

    public async Task ChatDelete(int id)
    {
        await _access.SaveData<dynamic>("spChat_Delete", new { Id = id });
    }
}
