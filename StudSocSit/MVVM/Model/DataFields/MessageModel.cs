
using System;

namespace MVVM.Model.DataFields;

public class MessageModel
{
    public string Text { get; set; }
    public DateTime Timestamp { get; set; }
    public int ChatId { get; set; }
    public int AuthorId { get; set; }
}
