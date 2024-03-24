using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace StudentApplication.Get;

public class GetMyFriendRequests
{
    private ReservoomDbContext _context;
    private ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the GetFriendRequests class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="logger">The logger.</param>
    public GetMyFriendRequests(ReservoomDbContext context, ILogger logger)
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
        var friendRequest = _context.FriendRequest.Where(f => f.SenderId == id).Select(f => f).ToList();

        // If no friend requests found, log error and return not found result
        if (friendRequest == null)
        {
            _logger.LogError("FriendRequest not found.");
            return Results.NotFound("FriendRequest not found.");
        }

        var listResponse = new List<Response>();

        friendRequest.ForEach(request =>
        {
            listResponse.Add(new Response
            {
                ReceiverId = request.ReceiverId,
                Text = request.Text,
            });
        });

        // Return OK result with the retrieved friend requests
        return Results.Ok(listResponse);
    }
    class Response
    {
        public int ReceiverId { get; set; }
        public string? Text { get; set; }
    }
}
