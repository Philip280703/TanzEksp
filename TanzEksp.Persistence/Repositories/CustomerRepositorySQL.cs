using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Persistence.EFContext;
using TanzEksp.Server.RepositoryInterfaces;
using TanzEksp.Shared.Domain;

namespace TanzEksp.Persistence.Repositories
{
    public class CustomerRepositorySQL : ICustomerRepository
    {
        private AppDbContext _db;
        private IUnitOfWork _unitOfWork;

        public CustomerRepositorySQL()
        {
            _db = new AppDbContext();
            _unitOfWork = new UnitOfWork(_db);

        }

        private static readonly List<Customer> _customerList;

        public List<Customer> GetAll()
        {
            var result = _db.CustomerEF.ToList();
            return result;
        }

        public Customer GetById(int id)
        {
            var result = _db.CustomerEF.Single(c => c.Id == id);
            return result;
        }

        public  void Add(Customer customer)
        {
            _db.CustomerEF.Add(customer);
            _db.SaveChanges();
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            _unitOfWork.BeginTransaction(System.Data.IsolationLevel.Serializable);
            try
            {
                if (existingCustomer != null)
                {
                    existingCustomer.FirstName = customer.FirstName;
                    existingCustomer.Email = customer.Email;
                    existingCustomer.PhoneNumber = customer.PhoneNumber;
                    existingCustomer.Address = customer.Address;
                    existingCustomer.Zipcode = customer.Zipcode;
                    existingCustomer.HouseNumber = customer.HouseNumber;
                }
                _unitOfWork.Commit();
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                throw new Exception("Error updating customer", ex);
            }

        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _db.CustomerEF.Remove(customer);
                _db.SaveChanges();
            }
        }

        static CustomerRepositorySQL()
        {
            _customerList = new List<Customer>();
            _customerList.Clear();
        }
    }
}
