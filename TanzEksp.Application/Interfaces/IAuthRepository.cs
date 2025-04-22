using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanzEksp.Application.Auth;

namespace TanzEksp.Application.Interfaces
{
    public interface IAuthRepository
    {
        Task<LoginResult?> LoginAsync(LoginCommand command);
    }
}
