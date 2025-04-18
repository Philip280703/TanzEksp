using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
    public interface IUserAccountRepository
    {
        Task<List<UserAccount>> GetAll();
        Task<UserAccount> GetById(int id);
        Task Add(UserAccount user);
        Task Update(UserAccount user);
        Task Delete(int id);
    }
}
