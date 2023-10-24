using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class MessageModel
    {
        [Key]
        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public int ChatId { get; set; }

        public int AuthorId { get; set; }
    }
}
