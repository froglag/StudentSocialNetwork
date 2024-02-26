using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class FriendRequestModel
    {
        [Key]
        public int FriendRequestId { get; set; }

        public string? Text { get; set; }

        public int SenderId { get; set; }
        public StudentModel Sender { get; set; } = null!;

        public int ReceiverId { get; set; }
        public StudentModel Receiver { get; set; } = null!;
    }
}
