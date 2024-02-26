using ApplicationDbContext;
using ApplicationDbContext.Models;
using Microsoft.AspNetCore.Identity;

namespace StudentApplication.Authentication;

/// <summary>
/// Handles the creation of a new user and user registration.
/// </summary>
public class SighinUser
{
    private UserManager<UserModel> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="SighinUser"/> class.
    /// </summary>
    /// <param name="userManager">The user manager for creating and managing users.</param>
    public SighinUser(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Creates a new user and registers them with the specified credentials.
    /// </summary>
    /// <param name="request">The request containing user information.</param>
    /// <returns>An <see cref="IResult"/> indicating the result of the operation.</returns>
    public async Task<IResult> Do(Request request)
    {
        // Create a new user with the provided information
        var user = new UserModel
        {
            UserName = request.UserName,
            Role = request.Role,
        };

        // Attempt to create the user using the user manager
        var result = await _userManager.CreateAsync(user, request.Password);

        // Check if the user creation was successful
        if (result.Succeeded)
        {
            return Results.Ok();
        }

        // Return a BadRequest result with the error description if user creation fails
        return Results.BadRequest("Request error: " + result.Errors.FirstOrDefault()?.Description);
    }

    /// <summary>
    /// Represents the request object for user registration.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user password.
        /// </summary>
        public string Password { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user role.
        /// </summary>
        public string Role { get; set; } = null!;
    }
}
