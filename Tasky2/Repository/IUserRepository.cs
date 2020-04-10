using System.Threading.Tasks;
using Tasky2.Entities;
using Tasky2.Models;

namespace Tasky2.Repository
{
    public interface IUserRepository
    {
        Task<int> Create(RegistrationViewModel viewModel);

        Task<User> Authenticate(LoginViewModel viewModel);
    }
}
