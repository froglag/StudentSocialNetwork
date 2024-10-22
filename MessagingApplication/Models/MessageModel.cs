using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagingApplication.Models;
public class MessageModel
{
    public int Id { get; set; }
    public int ChatId { get; set; }
    public int StudentId { get; set; }
    public string Content { get; set; }
    public DateTime SentAt { get; set; }
}
