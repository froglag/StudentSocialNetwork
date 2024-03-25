using Microsoft.AspNetCore.Mvc;
using StudentApplication.Create;
using ApplicationDbContext;
using StudentApplication.Get;
using StudentApplication.Delete;
using StudentApplication.Update;
using StudentApplication.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ApplicationDbContext.Authentication;

namespace StudSocSitApi.Controllers;

/// <summary>
/// API controller for Student Social Network operations.
/// </summary>
[Route("[controller]")]
[ApiController]
public class StudentApiController : ControllerBase
{
    private readonly ReservoomDbContext _context;
    private readonly ILogger _logger;
    private readonly UserManager<UserModel> _userManager;
    private readonly IConfiguration _configuration;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly AddStudentInfo _addStudentInfo;
    private readonly AddChatToDb _addChatToDb;
    private readonly AddFriendRequestToDb _addFriendRequestToDb;
    private readonly AddFriendToDb _addFriendToDb;
    private readonly AddMessageToDb _addMessageToDb;
    private readonly GetStudentInfoById _getStudentInfoById;
    private readonly GetChatMessages _getChatMessages;
    private readonly GetFriendRequests _getFriendRequest;
    private readonly GetMyFriendRequests _getMyFriendRequest;
    private readonly GetAllFriendsInfo _getAllFriendsInfo;
    private readonly UpdateStudentInfo _updateStudentInfo;
    private readonly DeleteFriendRequest _deleteFriendRequest;


    /// <summary>
    /// Initializes a new instance of the <see cref="StudentApiController"/> class.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <param name="userManager">The user manager.</param>
    /// <param name="logger">The logger.</param>
    public StudentApiController(ReservoomDbContext context, UserManager<UserModel> userManager, ILogger<StudentApiController> logger, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _logger = logger;
        _userManager = userManager;
        _configuration = configuration;
        _roleManager = roleManager;

        _addStudentInfo = new AddStudentInfo(_context, _logger, _userManager);
        _addChatToDb = new AddChatToDb(_context, _logger);
        _addFriendRequestToDb = new AddFriendRequestToDb(_context, _logger);
        _addFriendToDb = new AddFriendToDb(_context, _logger);
        _addMessageToDb = new AddMessageToDb(_context);

        _getStudentInfoById = new GetStudentInfoById(_context, _logger);
        _getChatMessages = new GetChatMessages(_context, _logger);
        _getFriendRequest = new GetFriendRequests(_context, _logger);
        _getMyFriendRequest = new GetMyFriendRequests(_context, _logger);
        _getAllFriendsInfo = new GetAllFriendsInfo(_context, _logger);

        _updateStudentInfo = new UpdateStudentInfo(_context, _logger);

        _deleteFriendRequest = new DeleteFriendRequest(_context, _logger);
    }

    /// <summary>
    /// Adds a chat to the database.
    /// </summary>
    /// <param name="request">The request containing chat information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addchat")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> AddChatToDb([FromBody] AddChatToDb.Request request)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
        {
            return NotFound("User not found");
        }

        if(student.StudentId != request.FirstStudentId)
        {
            return BadRequest("You can't create chat through another student");
        }
        await _addChatToDb.Do(request);
        return Ok();
    }
        

    /// <summary>
    /// Adds a friend request to the database.
    /// </summary>
    /// <param name="request">The request containing friend request information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addfriendrequest")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> AddFriendRequestToDb([FromBody] AddFriendRequestToDb.Request request)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
        
        if (student == null)
        {
            return NotFound("User not found");
        }
        if (student.StudentId != request.SenderId)
        {
            return BadRequest("You can't send a request through another user");
        }
        await _addFriendRequestToDb.Do(request);
        return Ok();
    }
    

    /// <summary>
    /// Adds a friend to the database.
    /// </summary>
    /// <param name="request">The request containing friend information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addfriend")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> AddFriendToDb([FromBody] AddFriendToDb.Request request)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
        {
            return NotFound("User not found");
        }

        if (student.StudentId != request.StudentId)
        {
            return BadRequest("You can't add friend through another user");
        }
        await _addFriendToDb.Do(request);
        return Ok();
    }
        

    /// <summary>
    /// Adds a message to the database.
    /// </summary>
    /// <param name="text">The request containing message information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPost("addmessage")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> AddMessageToDb([FromBody] string text)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
        {
            return NotFound("User not found");
        }

        var chat = await _context.StudentChat.FirstOrDefaultAsync(sc => sc.StudentId == student.StudentId);

        if (chat == null)
        {
            return NotFound("Chat not found");
        }

        AddMessageToDb.Request request = new()
        {
            AuthorId = student.StudentId,
            ChatId = chat.ChatId,
            Text = text
        };

        await _addMessageToDb.Do(request);
        return Ok();
    }
        

    /// <summary>
    /// Authenticates a user based on the provided login information.
    /// </summary>
    /// <param name="request">The request containing login information.</param>
    /// <returns>The result of the authentication operation.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> AuthenticateUser([FromBody] LoginUser.Request request) => Ok(await new LoginUser(_userManager, _configuration).Do(request));

    /// <summary>
    /// Handles the registration of a new user and returns the result as an <see cref="IActionResult"/>.
    /// </summary>
    /// <param name="request">The request containing user registration information.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the user registration.</returns>
    [HttpPost("signup")]
    public async Task<IActionResult> SigninUser([FromBody] SignupUser.Request request)
    {
        try
        {
            await new SignupUser(_userManager, _roleManager).Do(request);
            await _addStudentInfo.Do(new AddStudentInfo.Request
            {
                FirstName = request.Firstname,
                UserName = request.Username
            });
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }  


    /// <summary>
    /// Gets information about a student by their identifier.
    /// </summary>
    /// <returns>The result of the operation.</returns>
    [HttpGet("userinfo")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetStudentInfoById()
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
        if (student == null)
        {
            return NotFound("User not found");
        }
        
        return Ok(await _getStudentInfoById.Do(student.StudentId));
    }

    /// <summary>
    /// Gets information about a student by their identifier.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("friendinfo/{id}")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetStudentInfoById(int id)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
        if (student == null)
        {
            return NotFound("User not found");
        }

        var friendExise = await _context.Student.Include(s => s.Friendships).AnyAsync(s => s.StudentId == student.StudentId && s.Friendships.Any(f => f.FriendId == id));
        
        if (!friendExise)
        {
            return NotFound("Friend not found");
        }

        return Ok(await _getStudentInfoById.Do(id));
    }

    /// <summary>
    /// Gets FriendRequest of student.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("friendrequest")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetFriendRequest()
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
        if (student == null)
        {
            return NotFound("User not found");
        }

        return Ok(await _getFriendRequest.Do(student.StudentId));
    }

    /// <summary>
    /// Gets FriendRequest of student.
    /// </summary>
    /// <param name="id">The student identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("myfriendrequest")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetMyFriendRequest()
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
        {
            return NotFound("User not found");
        }

        return Ok(await _getMyFriendRequest.Do(student.StudentId));
    }

    /// <summary>
    /// Gets All Friends of student.
    /// </summary>
    /// <returns>The result of the operation.</returns>
    [HttpGet("allfriendsinfo")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetAllFriends()
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);
        if (student == null)
        {
            return NotFound("User not found");
        }

        return Ok(await _getAllFriendsInfo.Do(student.StudentId));
    }

    /// <summary>
    /// Gets chat messages based on the provided chat identifier.
    /// </summary>
    /// <param name="id">The chat identifier.</param>
    /// <returns>The result of the operation.</returns>
    [HttpGet("chatmessages/{id}")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> GetChatMessages(int id)
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
            return BadRequest("User id not found");

        var chatId = await _context.Chat.Include(c => c.StudentChats).FirstOrDefaultAsync(c => c.StudentChats.Any(sc => sc.StudentId == student.StudentId && sc.StudentId == id));
        
        if (chatId == null)
        {
            return BadRequest("Chat not found");
        }

        return Ok(await _getChatMessages.Do(chatId.ChatId));
    }
        

    /// <summary>
    /// Updates student information based on the provided request.
    /// </summary>
    /// <param name="request">The request containing updated student information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpPut("studentinfo")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> UpdateStudentInfo([FromBody] UpdateStudentInfo.Request request) 
    {
        var student = await _context.Student.Include(s => s.User).FirstOrDefaultAsync(s => s.User.UserName == User.Identity.Name);

        if (student == null)
            return BadRequest("User id not found");

        return Ok(await _updateStudentInfo.Do(request, student.StudentId));
    }

    /// <summary>
    /// Deletes a friend request from the database.
    /// </summary>
    /// <param name="request">The request containing friend request information.</param>
    /// <returns>The result of the operation.</returns>
    [HttpDelete("frequest")]
    [Authorize(Roles = UserRoles.User)]
    public async Task<IActionResult> DeleteFriendRequest([FromBody] DeleteFriendRequest.Request request) => Ok(await _deleteFriendRequest.Do(request));
}

