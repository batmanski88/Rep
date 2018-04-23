using System;
using System.Threading.Tasks;
using Api.Infrastructure.Extensions;
using Api.ViewModels;
using AutoMapper;
using Microsoft.Extensions.Caching.Memory;
using Repository;
using Repository.Models;

namespace Api.Services
{
    public class AccountService : IAccountService
    {
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;
        private readonly  IUserRepo _userRepo;
        private readonly IMemoryCache _cache;
        
        public AccountService(IMapper mapper, IEncrypter encrypter, IJwtHandler jwtHandler, IUserRepo userRepo, IMemoryCache cache)
        {
            _mapper = mapper;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
            _userRepo = userRepo;
            _cache = cache;
        }

        public async Task Login(UserViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);
            if(user == null)
            {
                throw new Exception("Użytkownik nie istnieje!");
            }

            var hash = _encrypter.GetHash(model.Password, user.Salt);
            var tokenTemp = _jwtHandler.CreateToken(user.UserId.ToString(), user.Roles);


            if(user.Password == hash)
            {
                _cache.SetJwt(model.UserId, tokenTemp);
            }
        }

        public async Task LogoutAsync()
        {
            
        }

        public async Task RegisterUserAsync(UserViewModel model)
        {
            var user = await _userRepo.GetUserByEmailAsync(model.Email);

            if(user != null)
            {
                throw new Exception("Użytkownik już istnieje w bazie");
            }
            
            var role = "user";

            var salt = _encrypter.GetSalt(model.Password);
            var hash = _encrypter.GetHash(model.Password, salt);

            user = new User(Guid.NewGuid(), model.Username, model.Email, hash, salt, role);
            await _userRepo.AddUserAsync(user);
        }
    }
}