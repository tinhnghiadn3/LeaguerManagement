using System;
using System.Threading.Tasks;
using AutoMapper;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
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

        public async Task<LoadResult> GetCurrentLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var source = await _leaguerRepository.GetCurrentLeaguers();
            return LoadCustom(source, loadOptions);
        }

        public async Task<LoadResult> GetAllLeaguers(DataSourceLoadOptionsBase loadOptions)
        {
            using var unitOfWork = UnitOfWorkFactory.Invoke();
            _leaguerRepository = unitOfWork.Repository<Leaguer>();

            var source = await _leaguerRepository.GetAllLeaguers();
            return LoadCustom(source, loadOptions);
        }

        public async Task<int> AddLeaguer(LeaguerModel input)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory.Invoke();
                _leaguerRepository = unitOfWork.Repository<Leaguer>();

                // check exist with card number
                if (await _leaguerRepository.IsExistingLeaguer(input.Name, input.CardNumber))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đảng viên"));
                //
                // adding
                var model = _mapper.Map<LeaguerModel, Leaguer>(input);
                model.StatusId = AppLeaguerStatus.Preliminary.ToInt();
                await _leaguerRepository.InsertAsync(model);

                return model.Id;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> UpdateLeaguer(LeaguerModel input)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory.Invoke();
                _leaguerRepository = unitOfWork.Repository<Leaguer>();

                // check exist with card number (except current)
                if (await _leaguerRepository.IsExistingLeaguer(input.Name, input.CardNumber, input.Id))
                    throw new AppException(string.Format(AppMessages.ThisObjectIsExist, "Đảng viên"));

                // check exist leaguer
                var leaguer = await GetOrThrow(_leaguerRepository, input.Id,
                    string.Format(AppMessages.ThisObjectNotFound, "Đảng viên"));

                // updating
                _mapper.Map(input, leaguer);
                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }
    }
}
