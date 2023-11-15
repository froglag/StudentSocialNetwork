using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class ChatModel
    {
        [Key]
        public int ChatId { get; set; }

        public IEnumerable<MessageModel>? Messages { get; set; }

        public ICollection<StudentModel>? Participants { get; set; }
    }
}
