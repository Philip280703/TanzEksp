using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.UseCases
{
    public class UserAccountUseCase
    {
        private readonly IUserAccountRepository _userAccountRepository;

        public UserAccountUseCase(IUserAccountRepository userAccountRepository)
        {
            _userAccountRepository = userAccountRepository;
        }

        public async Task<List<UserAccount>> GetAll()
        {
            return await _userAccountRepository.GetAll();
        }

        public async Task<UserAccount> GetById(int id)
        {
            return await _userAccountRepository.GetById(id);
        }

        public async Task Add(UserAccount user)
        {
            await _userAccountRepository.Add(user);
        }

        public async Task Update(UserAccount user)
        {
            await _userAccountRepository.Update(user);
        }

        public async Task Delete(int id)
        {
            await _userAccountRepository.Delete(id);
        }
    }
}
