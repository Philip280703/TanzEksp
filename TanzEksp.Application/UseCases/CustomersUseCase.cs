using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanzEksp.Application.UseCases
{
    public class CustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomersUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public List<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
