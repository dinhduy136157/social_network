using Microsoft.AspNetCore.Mvc;
using social_network.Models;
using social_network.Services;

namespace social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupFollowerController : Controller
    {
        private readonly IGroupFollowerRepository _groupFollowerRepository;
        public GroupFollowerController(IGroupFollowerRepository groupFollowerRepository)
        {
            _groupFollowerRepository = groupFollowerRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupFollower>>> Get()
        {
            var groupData = await _groupFollowerRepository.GetAllAsync();
            return Ok(groupData);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GroupFollower>> GetById(int id)
        {
            var groupData = await _groupFollowerRepository.GetByIdAsync(id);
            if (groupData == null)
            {
                return NotFound();
            }
            return Ok(groupData);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<GroupFollower>> Post(GroupFollower groupFollower)
        {
            await _groupFollowerRepository.AddAsync(groupFollower);
            return CreatedAtAction(nameof(GetById), new { id = groupFollower.Id }, groupFollower);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, GroupFollower groupFollower)
        {
            if (id != groupFollower.Id)
            {
                return BadRequest();
            }

            await _groupFollowerRepository.UpdateAsync(groupFollower);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var groupFirstOfDefault = await _groupFollowerRepository.GetByIdAsync(id);
            if (groupFirstOfDefault == null)
            {
                return NotFound();
            }

            await _groupFollowerRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
