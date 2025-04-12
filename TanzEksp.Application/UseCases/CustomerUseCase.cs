using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Interfaces;
using TanzEksp.Domain.Entities;

namespace TanzEksp.Application.UseCases
{
    public class CustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
