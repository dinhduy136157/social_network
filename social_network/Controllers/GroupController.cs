using Microsoft.AspNetCore.Mvc;
using social_network.Models;
using social_network.Services;

namespace social_network.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        public GroupController(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Group>>> Get()
        {
            var groupData = await _groupRepository.GetAllAsync();
            return Ok(groupData);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Group>> GetById(int id)
        {
            var groupData = await _groupRepository.GetByIdAsync(id);
            if (groupData == null)
            {
                return NotFound();
            }
            return Ok(groupData);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Group>> Post(Group group)
        {
            await _groupRepository.AddAsync(group);
            return CreatedAtAction(nameof(GetById), new { id = group.Id }, group);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Group group)
        {
            if (id != group.Id)
            {
                return BadRequest();
            }

            await _groupRepository.UpdateAsync(group);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var groupFirstOfDefault = await _groupRepository.GetByIdAsync(id);
            if (groupFirstOfDefault == null)
            {
                return NotFound();
            }

            await _groupRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
