using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationDbContext.Models
{
    public class NewsModel
    {
        [Key]
        public int NewsId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }

        public int AuthorId { get; set; }
    }
}
