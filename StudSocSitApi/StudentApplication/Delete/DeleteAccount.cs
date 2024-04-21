using ApplicationDbContext;
using ApplicationDbContext.Authentication;
using Microsoft.AspNetCore.Identity;

namespace StudentApplication.Delete;

public class DeleteAccount
{
    private ReservoomDbContext _context;
    private UserManager<UserModel> _userManager;

    public DeleteAccount(ReservoomDbContext context, UserManager<UserModel> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    public async Task<IResult> Do(UserModel user)
    {
        _userManager.DeleteAsync(user);
        return Results.Ok();
    }
}
