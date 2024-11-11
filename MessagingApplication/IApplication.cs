using MessagingApplication.Models;

namespace MessagingApplication;
public interface IApplication
{
    Task ChatDelete(int id);
    Task<ChatModel?> ChatGet(int id);
    Task<IEnumerable<ChatModel>> ChatGetAllByStudentId(int studentId);
    Task ChatInsert(ChatModel chat);
    Task ChatUpdate(ChatModel chat);
    Task MessageDelete(int id);
    Task<IEnumerable<MessageModel>> MessageGetAllByChatId(int chatId, int offset);
    Task MessageInsert(MessageModel message);
    Task MessageUpdate(MessageModel message);
}