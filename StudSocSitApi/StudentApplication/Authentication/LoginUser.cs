using ApplicationDbContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Identity;
using ApplicationDbContext.Models;

namespace StudentApplication.Authentication;

/// <summary>
/// Handles user login and generates a JWT token for authentication.
/// </summary>
public class LoginUser
{
    private readonly UserManager<UserModel> _userManager;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUser"/> class.
    /// </summary>
    /// <param name="userManager">The user manager for authentication.</param>
    public LoginUser(UserManager<UserModel> userManager)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Attempts to authenticate a user based on the provided credentials and generates a JWT token upon successful authentication.
    /// </summary>
    /// <param name="request">The request containing user login information.</param>
    /// <returns>An <see cref="IResult"/> containing the authentication result.</returns>
    public async Task<IResult> Do(Request request)
    {
        // Attempt to find the user by username
        var user = await _userManager.FindByNameAsync(request.UserName);

        // Check if the user exists and the password is correct
        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
        {
            return Results.Unauthorized();
        }

        // Create claims for the user's role
        var claims = new List<Claim> { new(ClaimTypes.Role, user.Role) };

        // Generate a JWT token with the user's claims
        var jwt = new JwtSecurityToken(
            issuer: AuthOptions.ISSUER,
            audience: AuthOptions.AUDIENCE,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromDays(1)),
            signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

        // Encode the JWT token
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        // Prepare the result containing the access token and username
        var result = new
        {
            access_token = encodedJwt,
            username = request.UserName
        };

        // Return the result as JSON
        return Results.Json(result);
    }

    /// <summary>
    /// Represents the request object for user login.
    /// </summary>
    public class Request
    {
        /// <summary>
        /// Gets or sets the user name for login.
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Gets or sets the user password for login.
        /// </summary>
        public string Password { get; set; } = null!;
    }
}

