using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Bist_1.Models;

namespace Bist_1.Services
{
    public interface IDataManager
    {
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        List<UserInfo> GetUsers();

        Task<List<NewsBlockInfo>> GetNewsBlocks(bool force = false);
        void SetNewEntity(int entityId);
    }
}