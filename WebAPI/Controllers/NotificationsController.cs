
using Business.Abstracts;
using Business.Dtos.Notification.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : Controller
    {
        INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] Guid Id)
        {
            var result = await _notificationService.Get(Id);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _notificationService.GetList(pageRequest);
            return Ok(result);

        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateNotificationRequest createnotificationRequest)
        {
            var result = await _notificationService.Add(createnotificationRequest);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] UpdateNotificationRequest updatenotificationRequest)
        {
            var result = await _notificationService.Update(updatenotificationRequest);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteNotificationRequest deletenotificationRequest)
        {
            var result = await _notificationService.Delete(deletenotificationRequest);
            return Ok(result);
        }
    }
}
