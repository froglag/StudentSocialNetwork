using ApplicationDbContext;

namespace StudentApplication.Get;

public class GetStudentSearchInfo
{
    private ReservoomDbContext _context;
    private ILogger _logger;

    public GetStudentSearchInfo(ReservoomDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IResult> Do(int studentId)
    {
        var studentInfo = _context.Student.Where(s => s.StudentId != studentId).Select(s => s).ToList();

        if (studentInfo == null)
        {
            _logger.LogError("No student found");
            return Results.NotFound("No student found");
        }

        var listStudets = new List<Response>();

        studentInfo.ForEach(student =>
        {
            listStudets.Add(new Response
            {
                StudentId = student.StudentId,
                Firstname = student.FirstName,
                Lastname = student.LastName,
            });
        });

        return Results.Ok(listStudets);
    }

    public class Response
    {
        public int StudentId { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
    }
}

