using System.Threading.Tasks;
using Api.ViewModels;

namespace Api.Services
{
    public interface IAccountService
    {
         Task RegisterUserAsync(UserViewModel model);
         Task Login(UserViewModel model);
         Task LogoutAsync();
    }
}