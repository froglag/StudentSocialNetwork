using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class FriendModel
    {
        [Key]
        public int FriendId { get; set; }
        public int StudentId { get; set; }
    }
}
