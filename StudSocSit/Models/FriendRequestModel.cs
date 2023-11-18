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
        public int RequestId { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }
    }
}
