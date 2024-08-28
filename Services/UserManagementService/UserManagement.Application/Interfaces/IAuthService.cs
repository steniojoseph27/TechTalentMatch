using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;

namespace UserManagement.Application.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(RegisterModel.InputModel registerModel);
        Task<string?> LoginAsync(LoginModel.InputModel loginModel);
    }
}
