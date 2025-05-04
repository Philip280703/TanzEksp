using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerDTO>> GetAllCustomersAsync();
        Task<CustomerDTO?> GetCustomerByIdAsync(Guid id);
        Task<int> AddCustomerAsync(CustomerDTO customer);
        Task<int> UpdateCustomerAsync(CustomerDTO customer);
        Task<int> DeleteCustomerAsync(Guid id);
    }
}
