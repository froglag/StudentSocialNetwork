using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDbContext.Models
{
    public class FriendsModel
    {
        [Key]
        public int Id { get; set; }
        
        public int? StudentId { get; set; }
        public int? FriendId { get; set;}
    }
}
