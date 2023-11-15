using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class FriendRequestModel
    {
        [Key]
        public int RequestId { get; set; }
        public int? StudentId { get; set; }
        public int? FriendId { get; set; }
    }
}
