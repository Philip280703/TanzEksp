using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Infrastructure.Persistence.EFContext;
using TanzEksp.Application.Interfaces;
using TanzEksp.Infrastructure.Persistence.Repositories;
using TanzEksp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TanzEksp.Infrastructure.Persistence.Repositories
{
    public class CustomerRepositorySQL : ICustomerRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public CustomerRepositorySQL(AppDbContext db, IUnitOfWork unitOfWork)
        {
            _db = db;
            _unitOfWork = unitOfWork;

        }

        //private static readonly List<Customer> _customerList;

        public async Task<List<Customer>> GetAll()
        {
            var result = await _db.CustomerEF.ToListAsync();
            return result;
        }

        public async Task<Customer> GetById(Guid id)
        {
            var result = await _db.CustomerEF.SingleOrDefaultAsync(c => c.Id == id);
            return result;
        }


        public async Task Add(Customer customer)
        {
            await _db.CustomerEF.AddAsync(customer);
            await _db.SaveChangesAsync();
        }


        public async Task Update(Customer customer)
        {
            var existingCustomer = await GetById(customer.Id); // Vent på asynkrone metode
            _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                if (existingCustomer != null)
                {
                    existingCustomer.FirstName = customer.FirstName;
                    existingCustomer.LastName = customer.LastName;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.PhoneNumber = customer.PhoneNumber;
                    existingCustomer.RowVersion = customer.RowVersion; // Opdater RowVersion for at undgå concurrency problemer

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


        public async Task Delete(Guid id)
        {
            var customer = await GetById(id); // Vent på asynkrone metode
            if (customer != null)
            {
                _db.CustomerEF.Remove(customer);
                await _db.SaveChangesAsync(); // Brug asynkrone version
            }
        }

        //static CustomerRepositorySQL()
        //{
        //    _customerList = new List<Customer>();
        //    _customerList.Clear();
        //}
    }
}
