using Microsoft.AspNetCore.Mvc;
using social_network.Models;
using social_network.Services;

namespace social_network.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        public NotificationController(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> Get()
        {
            var notiData = await _notificationRepository.GetAllAsync();
            return Ok(notiData);
        }
        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetById(int id)
        {
            var notiData = await _notificationRepository.GetByIdAsync(id);
            if (notiData == null)
            {
                return NotFound();
            }
            return Ok(notiData);
        }

        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<Notification>> Post(Notification noti)
        {
            await _notificationRepository.AddAsync(noti);
            return CreatedAtAction(nameof(GetById), new { id = noti.Id }, noti);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Notification noti)
        {
            if (id != noti.Id)
            {
                return BadRequest();
            }

            await _notificationRepository.UpdateAsync(noti);
            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var notiFirstOrDefault = await _notificationRepository.GetByIdAsync(id);
            if (notiFirstOrDefault == null)
            {
                return NotFound();
            }

            await _notificationRepository.DeleteAsync(id);
            return NoContent();
        }

    }
}
