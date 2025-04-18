using TanzEksp.Shared.DTO;

namespace TanzEksp.Client.Services.Interfaces
{
    public interface IUserAccountService
    {
        Task<List<UserAccountDto>> GetAllUserAccountsAsync();
        Task<UserAccountDto?> GetUserAccountByIdAsync(int id);
        Task<int> AddUserAccountAsync(UserAccountDto user);
        Task<int> UpdateUserAccountAsync(UserAccountDto user);
        Task<int> DeleteUserAccountAsync(int id);
    }
}
