using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class ChatModel
    {
        public int ChatId { get; set; }

        public ICollection<MessageModel> Messages { get; set; }

        public ICollection<StudentModel> Participants { get; set; }
    }
}
