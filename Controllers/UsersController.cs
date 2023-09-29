using Microsoft.AspNetCore.Mvc;
using CDNFM.Models;
using CDNFM.Services;

namespace CDNFM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            IEnumerable<User> users = await userService.GetAll();

            return users.ToList();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await userService.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            User userExists = await userService.GetById(id);
            if (userExists == null)
            {
                return NotFound();
            }

            bool updateResult = await userService.UpdateUser(user);
            if (updateResult)
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500);
            }
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            var success = await userService.CreateUser(user);

            if (!success)
            {
                return Problem("Failed to create user.");
            }

            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var success = await userService.DeleteUser(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
