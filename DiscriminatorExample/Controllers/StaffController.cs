using DiscriminatorExample.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiscriminatorExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly StaffService _staff;
        public StaffController(StaffService staff)
        {
                _staff = staff;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var stff=_staff.GetStaff();
            return Ok(stff);
        }
        [HttpPost]
        public IActionResult Save()
        {
            _staff.AddStaff();
            return Ok();
        }
    }
}
