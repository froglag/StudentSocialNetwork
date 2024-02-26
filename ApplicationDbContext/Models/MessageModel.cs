using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public required string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public int ChatId { get; set; }
        public ChatModel Chat { get; set; } = null!;

        public int AuthorId { get; set; }
    }
}
