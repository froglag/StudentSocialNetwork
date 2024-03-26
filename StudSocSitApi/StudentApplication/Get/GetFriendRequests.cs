using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace StudentApplication.Get;

/// <summary>
/// Represents a service for retrieving friend requests for a given student ID.
/// </summary>
public class GetFriendRequests
{
    private ReservoomDbContext _context;
    private ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the GetFriendRequests class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger.</param>
    public GetFriendRequests(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves friend requests for the specified student ID.
    /// </summary>
    /// <param name="id">The ID of the student.</param>
    /// <returns>An asynchronous task that returns the result of the operation.</returns>
    public async Task<IResult> Do(int id)
    {
        // Retrieve friend requests for the specified student ID
        var friendRequest = _context.FriendRequest.Where(f => f.ReceiverId == id).Select(f => f).ToList();

        // If no friend requests found, log error and return not found result
        if (friendRequest == null)
        {
            _logger.LogError("FriendRequest not found.");
            return Results.NotFound("FriendRequest not found.");
        }

        var listResponse = new List<Response>();

        friendRequest.ForEach(request =>
        {
            var student = _context.Student.FirstOrDefault(s => s.StudentId == request.SenderId);
            listResponse.Add(new Response
            {
                SenderId = request.SenderId,
                Firstname = student.FirstName, 
                Lastname = student.LastName,
                Text = request.Text,
            });
        });

        // Return OK result with the retrieved friend requests
        return Results.Ok(listResponse);
    }
    class Response
    {
        public int SenderId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Text { get; set; }
    }
}
