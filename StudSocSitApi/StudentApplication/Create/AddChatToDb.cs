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
        var firstStudent = await _context.Student.FirstOrDefaultAsync(s => s.StudentId == request.FirstStudentId);
        var secondStudent = await _context.Student.FirstOrDefaultAsync(s => s.StudentId == request.SecondStudentId);

        var chatExists = await _context.StudentChat
        .AnyAsync(sc => (sc.StudentId == request.FirstStudentId || sc.StudentId == request.SecondStudentId) && sc.ChatId == _context.StudentChat
            .Where(innerSc => innerSc.StudentId == request.FirstStudentId || innerSc.StudentId == request.SecondStudentId)
            .Select(innerSc => innerSc.ChatId)
            .FirstOrDefault());

        if (chatExists)
        {
            _logger.LogError("Chat already exists.");
            return Results.BadRequest("Chat already exists.");
        }

        if (firstStudent == null || secondStudent == null)
        {
            _logger.LogError("Invalid student identifiers.");
            return Results.BadRequest("Invalid student identifiers.");
        }

        ChatModel chat = new();

        StudentChatModel firstStudentChat = new()
        {
            StudentId = request.FirstStudentId,
            ChatId = chat.ChatId,
        };

        StudentChatModel secondStudentChat = new()
        {
            StudentId = request.SecondStudentId,
            ChatId = chat.ChatId,
        };

        await using var transaction = _context.Database.BeginTransaction();
        try
        {
            await _context.Chat.AddAsync(chat);
            await _context.StudentChat.AddAsync(firstStudentChat);
            await _context.StudentChat.AddAsync(secondStudentChat);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            _logger.LogInformation("Chat successfully created.");
            return Results.Created("Chat successfully created.", new { chat, firstStudentChat, secondStudentChat });
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
        /// Gets or sets the identifier of the first student participating in the chat.
        /// </summary>
        public int FirstStudentId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the second student participating in the chat.
        /// </summary>
        public int SecondStudentId { get; set; }
    }
}