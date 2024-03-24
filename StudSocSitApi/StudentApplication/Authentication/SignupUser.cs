using ApplicationDbContext;
using ApplicationDbContext.Authentication;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace StudentApplication.Authentication;

/// <summary>
/// Handles the creation of a new user and user registration.
/// </summary>
public class SignupUser
{
    private UserManager<UserModel> _userManager;
    private RoleManager<IdentityRole> _roleManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="SignupUser"/> class.
    /// </summary>
    /// <param name="userManager">The user manager for creating and managing users.</param>
    public SignupUser(UserManager<UserModel> userManager, RoleManager<IdentityRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }

    /// <summary>
    /// Creates a new user and registers them with the specified credentials.
    /// </summary>
    /// <param name="request">The request containing user information.</param>
    /// <returns>An <see cref="IResult"/> indicating the result of the operation.</returns>
    public async Task<IResult> Do(Request request)
    {
        var userExists = await _userManager.FindByNameAsync(request.Username);
        if (userExists != null)
            return Results.BadRequest("User already exists!");

        UserModel user = new UserModel()
        {
            Email = request.Email,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = request.Username
        };
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
            return Results.Problem("User creation failed! Please check user details and try again.");

        if (!await _roleManager.RoleExistsAsync(UserRoles.Admin))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        if (!await _roleManager.RoleExistsAsync(UserRoles.User))
            await _roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        if (await _roleManager.RoleExistsAsync(UserRoles.User))
        {
            await _userManager.AddToRoleAsync(user, UserRoles.User);
        }

        return Results.Created("User created successfully!", result);
    }

    /// <summary>
    /// Represents the request object for user registration.
    /// </summary>
    public class Request
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        public string Firstname { get; set; }
    }
}
