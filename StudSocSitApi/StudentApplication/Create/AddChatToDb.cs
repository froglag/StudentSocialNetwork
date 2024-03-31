using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace StudentApplication.Create;
/// <summary>
/// This class provides functionality to add a new chat entry to the database.
/// </summary>
public class AddChatToDb
{
    private readonly ReservoomDbContext _context;
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddChatToDb"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    /// <param name="logger"></param>
    public AddChatToDb(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Adds a new chat entry to the database based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information about the chat.</param>
    public async Task<IResult> Do(Request request)
    {
        var firstStudent = await _context.Student.AnyAsync(s => s.StudentId == request.FirstStudentId);
        var secondStudent = await _context.Student.AnyAsync(s => s.StudentId == request.SecondStudentId);

        if (!firstStudent || !secondStudent)
        {
            _logger.LogError("Invalid student identifiers.");
            return Results.BadRequest("Invalid student identifiers.");
        }


        var firstStudentChat = _context.StudentChat.Where(sc => sc.StudentId == request.FirstStudentId).Select(sc => sc.ChatId);
        
        var secondStudentChat = _context.StudentChat.Where(sc => sc.StudentId == request.SecondStudentId).Select(sc => sc.ChatId);

        var chatExists = await firstStudentChat.AnyAsync(f => secondStudentChat.Any(s => s == f));

        if (chatExists)
        {
            _logger.LogError("Chat already exists.");
            return Results.BadRequest("Chat already exists.");
        }



        ChatModel chat = new();

        try
        {
            await _context.Chat.AddAsync(chat);
            await _context.SaveChangesAsync();
        }catch(Exception ex)
        {
            _logger.LogError("Failed to save chat to database:"+ ex.Message);
            return Results.Problem(detail: ex.Message);
        }
        

        StudentChatModel addFirstStudentChat = new()
        {
            StudentId = request.FirstStudentId,
            ChatId = chat.ChatId,
        };

        StudentChatModel addSecondStudentChat = new()
        {
            StudentId = request.SecondStudentId,
            ChatId = chat.ChatId,
        };

        await using var transaction = _context.Database.BeginTransaction();
        try
        {
            await _context.StudentChat.AddAsync(addFirstStudentChat);
            await _context.StudentChat.AddAsync(addSecondStudentChat);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            _logger.LogInformation("Chat successfully created.");
            return Results.Created("Chat successfully created.", new { chat, addFirstStudentChat, addSecondStudentChat });
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            _logger.LogError("Failed to create chat: " + ex.Message);
            return Results.Problem(detail: ex.Message);
        }

    }

    /// <summary>
    /// Represents the request format for adding a new chat entry.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the identifier of the addFirstStudentChat student participating in the chat.
        /// </summary>
        public int FirstStudentId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the addSecondStudentChat student participating in the chat.
        /// </summary>
        public int SecondStudentId { get; set; }
    }
}