using System;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Repositories;
using Microsoft.Extensions.Options;
using NLog;

namespace LeaguerManagement.Services
{
    public class LeaguerService : BaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private IRepository<Leaguer> _leaguerRepository;


        public LeaguerService(Func<IUnitOfWork> unitOfWorkFactory, IMapper mapper,
            ILogger logger, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {

            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var source = await _leaguerRepository.GetAllLeaguers();
            return LoadCustom(source, loadOptions);
        }
    }
}
