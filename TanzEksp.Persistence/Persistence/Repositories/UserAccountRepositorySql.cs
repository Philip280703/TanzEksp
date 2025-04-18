using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;
using TanzEksp.Infrastructure.Persistence.EFContext;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
    public class UserAccountRepositorySql : IUserAccountRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public UserAccountRepositorySql(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserAccount>> GetAll()
        {
            var result = await _db.UserAccountEF.ToListAsync();
            return result;
        }

        public async Task<UserAccount> GetById(int id)
        {
            var result = await _db.UserAccountEF.SingleOrDefaultAsync(c => c.Id == id);
            return result;
        }


        public async Task Add(UserAccount user)
        {
            await _db.UserAccountEF.AddAsync(user);
            await _db.SaveChangesAsync();
        }


        public async Task Update(UserAccount user)
        {
            var existingUser = await GetById(user.Id); // Vent på asynkrone metode
            _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                if (existingUser != null)
                {
                    existingUser.Email = user.Email;
                    existingUser.Password = user.Password;
                }
                _unitOfWork.Commit();
                await _db.SaveChangesAsync(); // Brug asynkrone version
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error updating customer", ex);
            }
        }


        public async Task Delete(int id)
        {
            var user = await GetById(id); // Vent på asynkrone metode
            if (user != null)
            {
                _db.UserAccountEF.Remove(user);
                await _db.SaveChangesAsync(); // Brug asynkrone version
            }
        }
      
    }
}
