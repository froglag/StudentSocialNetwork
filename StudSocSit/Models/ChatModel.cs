using System;
using System.Collections.Generic;
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
        public int FirstStudentId { get; set; }
        public int SecondStudentId { get; set; }
    }
}
