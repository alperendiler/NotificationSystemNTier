using Business.Abstracts;
using Business.Dtos.UserInformation.Requests;
using Core.Business.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInformationsController : Controller
    {
        IUserInformationService _userInformationService;

        public UserInformationsController(IUserInformationService userInformationService)
        {
            _userInformationService = userInformationService;
        }

        [HttpGet("get")]
        public async Task<IActionResult> Get([FromQuery] Guid Id)
        {
            var result = await _userInformationService.Get(Id);
            return Ok(result);
        }
        [HttpGet("getlist")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            var result = await _userInformationService.GetList(pageRequest);
            return Ok(result);

        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateUserInformationRequest createUserInformationRequest)
        {
            var result = await _userInformationService.Add(createUserInformationRequest);
            return Ok(result);
        }
        [HttpPut("update")]
        public async Task<IActionResult> Update([FromQuery] UpdateUserInformationRequest updateUserInformationRequest)
        {
            var result = await _userInformationService.Update(updateUserInformationRequest);
            return Ok(result);
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserInformationRequest deleteUserInformationRequest)
        {
            var result = await _userInformationService.Delete(deleteUserInformationRequest);
            return Ok(result);
        }
    }
}
