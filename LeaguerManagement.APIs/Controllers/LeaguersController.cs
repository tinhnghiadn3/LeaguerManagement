using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.ViewModels;
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

        [HttpPost("current")]
        public async Task<LoadResult> GetCurrentLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _leaguerService.GetCurrentLeaguers(loadOptions);
        }

        [HttpPost("search")]
        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            return await _leaguerService.GetAllLeaguers(loadOptions);
        }

        [HttpPost]
        public async Task<int> AddLeaguer(LeaguerModel input)
        {
            return await _leaguerService.AddLeaguer(input);
        }

        [HttpPut]
        public async Task<bool> UpdateLeaguer(LeaguerModel input)
        {
            return await _leaguerService.UpdateLeaguer(input);
        }
    }
}