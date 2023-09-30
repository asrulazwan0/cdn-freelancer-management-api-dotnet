using Microsoft.AspNetCore.Mvc;
using CDNFM.Dtos;
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
        public async Task<IActionResult> PutUser(int id, UserDto userDto)
        {
            User user = await userService.GetById(id);
            if (user == null)
            {
                return NotFound();
            }

            UpdateUserProperties(user, userDto);

            bool updateResult = await userService.UpdateUser(user);
            return updateResult ? NoContent() : StatusCode(500);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserDto userDto)
        {
            try
            {
                var user = await userService.CreateUser(userDto);
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            catch (System.Exception)
            {
                
                return Problem("Failed to create user.");
            }
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
    
        private void UpdateUserProperties(User user, UserDto userDto)
        {
            user.Username = userDto.Username;
            user.Email = userDto.Email;
            user.PhoneNumber = userDto.PhoneNumber;
            user.Skillsets = userDto.Skillsets;
            user.Hobby = userDto.Hobby;
        }
    }
}
