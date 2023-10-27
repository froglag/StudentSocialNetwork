using ApplicationDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Get
{
    public class GetNewsInfo
    {
        private ReservoomDbContext _context;

        public GetNewsInfo(ReservoomDbContext context)
        {
            _context = context;
        }

        public Response? Do(int newsId)
        {
            return _context.News
                .Where(n => n.NewsId == newsId)
                .Select(n => new Response
                {
                    AuthorId = n.AuthorId,
                    Content = n.Content,
                    PublishDate = n.PublishDate,
                    Title = n.Title,
                })
                .First();
        }

        public class Response
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public DateTime PublishDate { get; set; }
            public int AuthorId { get; set; }
        }
    }
}
