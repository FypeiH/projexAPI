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
    public class PersonController : Controller
    {
        private readonly DapperContext _context;

        public PersonController(DapperContext context)
        {
            _context = context;
        }

        [HttpPost("signup")]
        [ProducesResponseType(typeof(PersonModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Signup([FromBody] SignUpModel signUp)
        {
            try
            {
                using (var connection = _context.CreateConnection())
                {
                    // Check if the email or username is already in use
                    var existingUser = await connection.QueryFirstOrDefaultAsync<PersonModel>(
                        "SELECT * FROM person WHERE email = @email OR username = @username",
                        new { signUp.email, signUp.username });

                    if (existingUser != null)
                    {
                        // Return 400 Bad Request if email or username is already in use
                        return BadRequest("Email or username is already in use.");
                    }
                    else
                    {
                        // Hash the password before storing it in the database
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword(signUp.password);

                        // Insert the new user into the database
                        var newUser = await connection.QueryFirstOrDefaultAsync<PersonModel>(
                            "INSERT INTO person (name, username, email, password) OUTPUT inserted.* VALUES (@name, @username, @email, @password)",
                            new { signUp.name, signUp.username, signUp.email, password = hashedPassword });

                        // Clear the password before returning the user
                        newUser!.password = String.Empty;

                        return Ok(newUser);
                    }                 
                }
            }
            catch (Exception ex)
            {
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
