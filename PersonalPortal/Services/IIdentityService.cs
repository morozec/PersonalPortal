using System.Threading.Tasks;
using Models;

namespace PersonalPortal.Services
{
    public interface IIdentityService
    {
        Task<User> GetUser(string userName);
    }
}