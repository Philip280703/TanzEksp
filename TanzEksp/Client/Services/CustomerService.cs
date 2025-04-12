using System.Net.Http.Json;
using TanzEksp.Client.Services.Interfaces;
using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CustomerDTO>> GetAllCustomersAsync()
        {
            var customer = await _httpClient.GetFromJsonAsync<List<CustomerDTO>>("api/customer");
            if (customer == null)
            {
                throw new Exception("Failed to load customers");
            }
            return customer;
        }

        public async Task<CustomerDTO> GetCustomerByIdAsync(int id)
        {
            var customer = await _httpClient.GetFromJsonAsync<CustomerDTO>($"api/customer/{id}");
            if (customer == null)
            {
                throw new Exception($"Failed to load customer with ID {id}");
            }
            return customer;
        }

        public async Task<int> AddCustomerAsync(CustomerDTO customer)
        {
            var answer = await _httpClient.PostAsJsonAsync("api/customer", customer);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        public async Task<int> UpdateCustomerAsync(CustomerDTO customer)
        {
            var answer = await _httpClient.PutAsJsonAsync($"api/customer/{customer.Id}", customer);
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            var answer = await _httpClient.DeleteAsync($"api/customer/{id}");
            var answerCode = (int)answer.StatusCode;
            return answerCode;
        }
    }
    
    
}
