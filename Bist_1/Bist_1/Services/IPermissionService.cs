using System.Threading.Tasks;

namespace Bist_1.Services
{
    public interface IPermissionService
    {
        Task<bool> RequestPermissionsAsync();

    }
}
