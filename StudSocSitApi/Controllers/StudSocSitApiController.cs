using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentApplication.Create;
using ApplicationDbContext;
using StudentApplication.Get;
using ApplicationDbContext.Models;
using StudentApplication.Delete;
using StudentApplication.Update;
using StudentApplication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace StudSocSitApi.Controllers;

/// <summary>
/// API controller for Student Social Network operations.
/// </summary>
[Route("[controller]")]
[ApiController]
public class StudSocSitApiController : ControllerBase
{
    private readonly ReservoomDbContext _context;
    private readonly ILogger _logger;
    private readonly UserManager<UserModel> _userManager;
    private readonly AddStudentInfo _addStudentInfo;
    private readonly AddChatToDb _addChatToDb;
    private readonly AddFriendRequestToDb _addFriendRequestToDb;
    private readonly AddFriendToDb _addFriendToDb;
    private readonly AddMessageToDb _addMessageToDb;
    private readonly GetStudentInfoById _getStudentInfoById;
    private readonly GetChatMessages _getChatMessages;
    private readonly UpdateStudentInfo _updateStudentInfo;
    private readonly DeleteFriendRequest _deleteFriendRequest;

    /// <summary>
    /// Initializes a new instance of the <see cref="StudSocSitApiController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="userManager">The user manager.</param>
    /// <param name="logger">The logger.</param>
    public StudSocSitApiController(ReservoomDbContext context, UserManager<UserModel> userManager, ILogger logger)
    {
        _context = context;
        _logger = logger;
        _userManager = userManager;

        _addStudentInfo = new AddStudentInfo(_context, _logger);
        _addChatToDb = new AddChatToDb(_context, _logger);
        _addFriendRequestToDb = new AddFriendRequestToDb(_context, _logger);
        _addFriendToDb = new AddFriendToDb(_context, _logger);
        _addMessageToDb = new AddMessageToDb(_context);

        _getStudentInfoById = new GetStudentInfoById(_context, _logger);
        _getChatMessages = new GetChatMessages(_context, _logger);

        _updateStudentInfo = new UpdateStudentInfo(_context, _logger);

        _deleteFriendRequest = new DeleteFriendRequest(_context, _logger);
    }

    /// <summary>
    /// Adds a student to the database.
    /// </summary>
    /// <param name="request">The request containing student information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addstudent")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> AddStudentToDb([FromBody] AddStudentInfo.Request request) => Ok(await _addStudentInfo.Do(request));

    /// <summary>
    /// Adds a chat to the database.
    /// </summary>
    /// <param name="request">The request containing chat information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addchat")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> AddChatToDb([FromBody] AddChatToDb.Request request) => Ok(await _addChatToDb.Do(request));

    /// <summary>
    /// Adds a friend request to the database.
    /// </summary>
    /// <param name="request">The request containing friend request information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addfriendrequest")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> AddFriendRequestToDb([FromBody] AddFriendRequestToDb.Request request) => Ok(await _addFriendRequestToDb.Do(request));

    /// <summary>
    /// Adds a friend to the database.
    /// </summary>
    /// <param name="request">The request containing friend information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addfriend")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> AddFriendToDb([FromBody] AddFriendToDb.Request request) => Ok(await _addFriendToDb.Do(request));

    /// <summary>
    /// Adds a message to the database.
    /// </summary>
    /// <param name="request">The request containing message information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addmessage")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> AddMessageToDb([FromBody] AddMessageToDb.Request request) => Ok(await _addMessageToDb.Do(request));

    /// <summary>
    /// Authenticates a user based on the provided login information.
    /// </summary>
    /// <param name="request">The request containing login information.</param>
    /// <returns>The result of the authentication operation.</returns>
    [HttpPost("login")]
    public IActionResult AuthenticateUser([FromBody] LoginUser.Request request) => Ok(new LoginUser(_userManager).Do(request));

    /// <summary>
    /// Handles the registration of a new user and returns the result as an <see cref="IActionResult"/>.
    /// </summary>
    /// <param name="request">The request containing user registration information.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the user registration.</returns>
    [HttpPost("signin")]
    public async Task<IActionResult> SigninUser([FromBody] SighinUser.Request request) => Ok(await new SighinUser(_userManager).Do(request));


    /// <summary>
    /// Gets information about a student by their identifier.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("student/{id}")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> GetStudentInfoById(int id) 
    {
        var user = User;  // Retrieve the current user principal

        if (user == null)
        {
            return Unauthorized(); // User is not authenticated
        }

        var authenticatedUser = await _userManager.GetUserAsync(user);

        if (authenticatedUser == null || authenticatedUser.Student == null)
        {
            return NotFound(); // User or associated student not found
        }

        var isFriend = await _context.Friendship
            .AnyAsync(fs => fs.StudentId == authenticatedUser.Student.StudentId && fs.FriendId == id);

        if (!isFriend)
        {
            return Forbid();
        }
        return Ok(await _getStudentInfoById.Do(id));
    }

    /// <summary>
    /// Gets chat messages based on the provided chat identifier.
    /// </summary>
    /// <param name="id">The chat identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("chat/{id}")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> GetChatMessages(int id) => Ok(await _getChatMessages.Do(id));

    /// <summary>
    /// Updates student information based on the provided request.
    /// </summary>
    /// <param name="request">The request containing updated student information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPut]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> UpdateStudentInfo([FromBody] UpdateStudentInfo.Request request) => Ok(await _updateStudentInfo.Do(request));

    /// <summary>
    /// Deletes a friend request from the database.
    /// </summary>
    /// <param name="request">The request containing friend request information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpDelete("frequest")]
    [Authorize(Roles = "student")]
    public async Task<IActionResult> DeleteFriendRequest([FromBody] DeleteFriendRequest.Request request) => Ok(await _deleteFriendRequest.Do(request));
}

