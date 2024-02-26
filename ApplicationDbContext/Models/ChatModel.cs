using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class ChatModel
    {
        [Key]
        public int ChatId { get; set; }

        public ICollection<StudentChatModel> StudentChats { get; set; } = null!;

        public ICollection<MessageModel>? Messages { get; set; }
    }
}
