using LogixTask.Domain.Enums;
using LogixTask.Domain.Models;
using LogixTask.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogixTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminOperations _operations;

        public AdminController(IAdminOperations operations)
        {
            _operations = operations;
        }

#if DEBUG
        [AllowAnonymous]
#endif
        [Attributes.Authorize(UserTypeEnum.Admin)]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await _operations.GetUsers());
        }

#if DEBUG
        [AllowAnonymous]
#endif
        [Attributes.Authorize(UserTypeEnum.Admin)]
        [HttpPost("AddUser")]
        public void AddUser(AddUser user)
        {
            _operations.AddUser(user);
        }

#if DEBUG
        [AllowAnonymous]
#endif
        [Attributes.Authorize(UserTypeEnum.Admin)]
        [HttpPost("EditUser")]
        public void EditUser(EditUser user, int userId)
        {
            _operations.EditUser(user, userId);
        }

#if DEBUG
        [AllowAnonymous]
#endif
        [Attributes.Authorize(UserTypeEnum.Admin)]
        [HttpDelete("DeleteUser")]
        public void DeleteUser(int id)
        {
            _operations.DeleteUser(id);
        }
    }
}
