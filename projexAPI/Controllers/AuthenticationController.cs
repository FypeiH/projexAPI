using Microsoft.AspNetCore.Mvc;
using Dapper;
using projexAPI.Context;
using projexAPI.Models;
using projexAPI.Services;

namespace projexAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AuthenticationController : Controller
    {
        private readonly DapperContext _context;
        private readonly ILogger<AuthenticationController> _logger;

        public AuthenticationController(DapperContext context, ILogger<AuthenticationController> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Logs in a user with the provided credentials.
        /// </summary>
        /// <param name="login">The login model containing the user's email/username and password.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the login operation.</returns>
        /// <response code="200">Returns the user and a JWT token.</response>
        /// <response code="400">If the login model is invalid.</response>
        /// <response code="401">If the user is not found or the password does not match.</response>
        /// <response code="500">If an error occurs while processing the request.</response>

        [HttpPost("login")]
        [ProducesResponseType(typeof(PersonModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    // Query the database for the user with the provided email
                    var user = await connection.QueryFirstOrDefaultAsync<PersonModel>(
                        "SELECT * FROM person WHERE email = @email OR username = @email",
                        new { email = login.emailUsername });

                    // If user is not found or password does not match, return 401 Unauthorized
                    if (user == null || !BCrypt.Net.BCrypt.Verify(login.password, user.password))
                    {
                        return Unauthorized();
                    }

                    // Clear the password before generating the token (for security reasons)
                    user.password = String.Empty;

                    // Generate JWT token
                    var token = TokenService.GenerateToken(user);

                    // Return the user and token in the response
                    return Ok(new { user, token });
                }
            }
            catch (Exception ex)
            {
                // Log the exception with detailed context information
                _logger.LogError(ex, "An error occurred while attempting to log in. Email/Username: {emailUsername}", login.emailUsername);

                // Return a generic error message to the client
                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Title = "An error occurred while processing your request.",
                    Detail = ex.Message // Include exception message for debugging
                };

                return StatusCode(problemDetails.Status.Value, problemDetails);
            }
        }
    }
}
