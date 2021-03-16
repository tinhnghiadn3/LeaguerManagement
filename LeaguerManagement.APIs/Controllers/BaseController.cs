using LeaguerManagement.Entities.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected int UserId => HttpContext.UserId();
    }
}
