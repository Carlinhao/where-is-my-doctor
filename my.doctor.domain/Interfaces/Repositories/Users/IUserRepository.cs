using System.Threading.Tasks;
using my.doctor.domain.Models;
using System.Security.Cryptography;

namespace my.doctor.domain.Interfaces.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserRequest> CanDoLogin(UserRequest request);
        Task RegisterUser(UserRequest request);
        Task<string> ComputeHash(string input, SHA256CryptoServiceProvider algorithm);
    }
}
