using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCare.Services
{
    public interface IAuthenticationService
    {
        Task<bool> Login();
        Task<string> GetCurrentToken(IUser user);
        bool Logout();
        Task<bool> CurrentLogged();
        Task<bool> LoginSilent(IUser user);
    }
}
