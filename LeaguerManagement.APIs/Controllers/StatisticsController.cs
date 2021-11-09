using System.Threading.Tasks;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticsController : BaseController
    {
        private readonly StatisticsService _statisticsService;
        public StatisticsController(StatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("5btc/{year:int}")]
        public async Task<IActionResult> Export5BTC(int year)
        {
            var stream = await _statisticsService.Export5BTC(year);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        [HttpGet("4tw/{year:int}")]
        public async Task<IActionResult> Export4TW(int year)
        {
            var stream = await _statisticsService.Export4TW(year);
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

    }
}
