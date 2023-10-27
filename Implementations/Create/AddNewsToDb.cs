using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;

namespace Model.Create
{
    public class AddNewsToDb
    {
        private ReservoomDbContext _context;

        public AddNewsToDb(ReservoomDbContext context)
        {
            _context = context;
        }

        public void Do(Request request)
        {
            NewsModel newsModel = new NewsModel
            {
                Title = request.Title,
                Content = request.Content,
                PublishDate = DateTime.Now,
                AuthorId = request.AuthorId,
            };
            _context.News.Add(newsModel);
            _context.SaveChanges();
        }

        public class Request
        {
            public string Title { get; set; }
            public string Content { get; set; }
            public int AuthorId { get; set; }
        }
    }
}
