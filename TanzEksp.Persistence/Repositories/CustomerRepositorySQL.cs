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
        AppDbContext _db = new AppDbContext();

        public CustomerRepositorySQL()
        {
            
        }

        private static readonly List<Customer> _customerList;

        public List<Customer> GetAll()
        {
            return _customerList;
        }

        public Customer GetById(int id)
        {
            return _customerList.FirstOrDefault(c => c.Id == id);
        }

        public void Add(Customer customer)
        {
            _customerList.Add(customer);
        }

        public void Update(Customer customer)
        {
            var existingCustomer = GetById(customer.Id);
            if (existingCustomer != null)
            {
                existingCustomer.FirstName = customer.FirstName;
                existingCustomer.Email = customer.Email;
                existingCustomer.PhoneNumber = customer.PhoneNumber;
                existingCustomer.Address = customer.Address;
                existingCustomer.Zipcode = customer.Zipcode;
                existingCustomer.HouseNumber = customer.HouseNumber;
            }
        }

        public void Delete(int id)
        {
            var customer = GetById(id);
            if (customer != null)
            {
                _customerList.Remove(customer);
            }
        }

        static CustomerRepositorySQL()
        {
            _customerList = new List<Customer>();
            _customerList.Clear();
        }
    }
}
