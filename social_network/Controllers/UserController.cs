using Microsoft.AspNetCore.Mvc;
using social_network.Models;
using social_network.Services;

namespace social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var userData = await _userRepository.GetAllAsync();
            return Ok(userData);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(int id)
        {
            var userData = await _userRepository.GetByIdAsync(id);
            if (userData == null)
            {
                return NotFound();
            }
            return Ok(userData);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> Post(User user)
        {
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.UpdateAsync(user);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userFirstOfDefault = await _userRepository.GetByIdAsync(id);
            if (userFirstOfDefault == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
