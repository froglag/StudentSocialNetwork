using ApplicationDbContext;
using ApplicationDbContext.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Create;
/// <summary>
/// This class provides functionality to add a new chat entry to the database.
/// </summary>
public class AddChatToDb
{
    private ReservoomDbContext _context;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddChatToDb"/> class.
    /// </summary>
    /// <param name="context">The database context used for data operations.</param>
    public AddChatToDb(ReservoomDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adds a new chat entry to the database based on the provided request.
    /// </summary>
    /// <param name="request">The request containing information about the chat.</param>
    public void Do(Request request)
    {
        _context.Chat.Add(new ChatModel
        {
            FirstStudentId = request.FirstStudentId,
            SecondStudentId = request.SecondStudentId
        });

        // Save changes to the database
        _context.SaveChanges();
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