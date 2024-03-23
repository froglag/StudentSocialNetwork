using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Get;

public class GetAllFriendsInfo
{
    private ReservoomDbContext _context;
    private ILogger _logger;

    public GetAllFriendsInfo(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IResult> Do(int studentId)
    {
         var friendship = _context.Student.Where(s => s.StudentId == studentId).Select(s => s.Friendships);
        if (friendship == null)
        {
            _logger.LogError("No friendship found");
            return Results.NotFound("No friendship found");
        }

        var friendsInfo = _context.Student.Where(s => friendship.Any(f => f.Any(fs => fs.FriendId == s.StudentId))).Select(s => s);

        var listFriends = new List<Response>();

        await friendsInfo.ForEachAsync(friend =>
        {
            listFriends.Add(new Response 
            { 
                FriendId = friend.StudentId,
                FirstName = friend.FirstName,
                LastName = friend.LastName,
                Email = friend.Email,
                FacultyName = friend.FacultyName,
                Specialization = friend.Specialization
            });
        });

        return Results.Ok(listFriends);
    }

    class Response
    {
        public int FriendId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }

        public string? FacultyName { get; set; }
        public string? Specialization { get; set; }
    }
}
