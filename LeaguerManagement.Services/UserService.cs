using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LeaguerManagement.Entities.Entities;
using LeaguerManagement.Entities.Infrastructures;
using LeaguerManagement.Entities.Resources;
using LeaguerManagement.Entities.Utilities;
using LeaguerManagement.Entities.Utilities.Helper;
using LeaguerManagement.Entities.ViewModels;
using LeaguerManagement.Repositories;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NLog;

namespace LeaguerManagement.Services
{
    public class UserService : BaseService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        private IRepository<User> _userRepository;
        private IRepository<UserToken> _userTokenRepository;

        public UserService(ILogger logger, IMapper mapper,
            Func<IUnitOfWork> unitOfWorkFactory, IOptionsSnapshot<GlobalSettings> settings) : base(unitOfWorkFactory, settings)
        {
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AuthenticationUserModel> Login(LoginModel input)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _userRepository = unitOfWork.Repository<User>();

                var user = await _userRepository.FindUser(input.Username.Trim()) ??
                           throw new AppException(AppMessages.EmailOrPasswordIncorrect);
                // Compare Password
                var hashedPassword = PasswordHash.GetHash(string.Concat(input.Password, user.Salt));
                if (hashedPassword != user.Password)
                    throw new AppException(AppMessages.EmailOrPasswordIncorrect);

                var currentUser = await _userRepository.GetCurrentUser(user.Id) ??
                    throw new AppException(AppMessages.Unauthorized);

                return await CreateLoginResponse(currentUser, input.RememberMe, input.TimezoneOffset);
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> ChangePassword(ChangePasswordModel model)
        {
            try
            {
                using var unitOfWork = UnitOfWorkFactory();
                _userRepository = unitOfWork.Repository<User>();

                if (model.NewPass != model.ConfirmPass)
                    throw new AppException(AppMessages.PasswordIsNotSame);

                var user = await _userRepository.FindUser(model.Email) ??
                           throw new AppException(AppMessages.EmailOrPasswordIncorrect);
                // Check password
                var hashedPassword = PasswordHash.GetHash(string.Concat(model.CurrentPass, user.Salt));
                if (hashedPassword != user.Password)
                    throw new AppException(AppMessages.PasswordIsIncorrect);

                var salt = PasswordHash.GetSalt();
                user.Salt = salt;
                user.Password = PasswordHash.GetHash(model.NewPass, salt);

                await unitOfWork.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        public async Task<bool> IsEmailDuplicated(SingleFieldModel<string> input)
        {
            using var unitOfWork = UnitOfWorkFactory();
            return await unitOfWork.Repository<User>().IsUserEmailDuplicated(input.Id, input.Value);
        }

        public async Task<LoggedUserModel> CurrentUser()
        {
            using var unitOfWork = UnitOfWorkFactory();
            var user = await unitOfWork.Repository<User>().GetCurrentUser() ??
                       throw new AppException(AppMessages.Unauthorized);

            return user;
        }

        public void InitUserTokens()
        {
            using var unitOfWork = UnitOfWorkFactory();
            _userTokenRepository = unitOfWork.Repository<UserToken>();
            //
            // Remove Expired Tokens
            _userTokenRepository.RemoveExpiredTokens().Wait();
            //
            // Get Tokens from DB
            var userTokens = _userTokenRepository.GetTokens().Result;
            //
            // Convert to models
            var tokens = _mapper.Map<List<UserTokenModel>>(userTokens);
            UserTokenHelper.InitUserTokens(tokens);
        }

        public async Task RevokeToken(string accessToken)
        {
            using var unitOfWork = UnitOfWorkFactory();
            var token = UserTokenHelper.GetUserToken(accessToken, TokenType.AccessToken);
            if (token == null)
            {
                return;
            }
            //
            // Mark as revoked and update to the DB
            token.IsRevoked = true;
            //
            // Update to DB
            await unitOfWork.Repository<UserToken>().RevokeToken(token.Id);
        }

        #region Private Method

        private async Task<AuthenticationUserModel> CreateLoginResponse(LoggedUserModel user, bool isKeepSignedIn, double timeZoneOffset)
        {
            try
            {
                var result = new AuthenticationUserModel { User = user };
                //
                // Init token configurations
                var expireInHours = isKeepSignedIn ? Settings.Token.LongExpires : Settings.Token.Expires;
                var key = Encoding.ASCII.GetBytes(Settings.Token.TokenSecretKey);

                var claims = new List<Claim>
                {
                    new(AppClaimType.UserId, user.Id.ToString()),
                    new(AppClaimType.Username, user.Email),
                    new(AppClaimType.FullName, user.Name),
                    new(AppClaimType.RoleId, user.RoleId.ToString()),
                    new(AppClaimType.TimezoneOffset, timeZoneOffset.ToString(CultureInfo.CurrentCulture)),
                };
                if(user.UnitId != null) claims.Add(new Claim(AppClaimType.UnitId, user.UnitId.ToString()));

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(expireInHours),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                //
                // Generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                //
                // Set token expired day is max time if the device token is not null
                result.AccessToken = tokenHandler.WriteToken(securityToken);
                result.ImageToken = Guid.NewGuid().ToString();
                result.Exp = tokenDescriptor.Expires.Value.GetMiliSecond();
                //
                // Store token
                var userToken = new UserToken
                {
                    Id = 0,
                    ExpireAt = result.Exp.Value.ToDateTime(),
                    Token = result.AccessToken,
                    ImageToken = result.ImageToken,
                    UserId = user.Id,
                    IsRevoked = false
                };
                await AddUserToken(userToken);

                return result;
            }
            catch (Exception e)
            {
                _logger.Error(e, e.Message);
                throw new AppException(e.Message);
            }
        }

        private async Task AddUserToken(UserToken userToken)
        {
            using var unitOfWork = UnitOfWorkFactory();
            await unitOfWork.Repository<UserToken>().InsertAsync(userToken);

            UserTokenHelper.AddToken(_mapper.Map<UserTokenModel>(userToken));
        }

        #endregion
    }
}
