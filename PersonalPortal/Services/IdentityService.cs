﻿using System.Threading.Tasks;
using DBRepository.Repositories;
using Models;

namespace PersonalPortal.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly IIdentityRepository _identityRepository;

        public IdentityService(IIdentityRepository identityRepository)
        {
            _identityRepository = identityRepository;
        }

        public async Task<User> GetUser(string userName)
        {
            return await _identityRepository.GetUser(userName);
        }
    }
}