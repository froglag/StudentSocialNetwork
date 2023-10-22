using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public int ChatId { get; set; }
        public ChatModel Chat { get; set; }

        public int AuthorId { get; set; }
        public StudentModel Author { get; set; }
    }
}
