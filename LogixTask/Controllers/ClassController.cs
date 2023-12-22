using LogixTask.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LogixTask.Controllers
{
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }

        [HttpGet("GetClasses")]
        public async Task<IActionResult> GetClasses()
        {
            return Ok(await _classService.GetClasses());
        }
    }
}
