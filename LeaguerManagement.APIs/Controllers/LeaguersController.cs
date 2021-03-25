using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Services;
using Microsoft.AspNetCore.Authorization;

namespace LeaguerManagement.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LeaguersController : BaseController
    {
        private readonly LeaguerService _leaguerService;

        public LeaguersController(LeaguerService leaguerService)
        {
            _leaguerService = leaguerService;
        }

        [HttpPost("search")]
        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _leaguerService.GetAllLeaguers(loadOptions);
        }
    }
}