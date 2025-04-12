using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.Interfaces
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        void Add(Customer customer);
        void Update(Customer customer);
        void Delete(int id);
    }
}
