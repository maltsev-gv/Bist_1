using System.Collections.Generic;
using System.Threading.Tasks;
using Bist_1.Helpers;
using Bist_1.Models;
using Bist_1.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(DataManager))]
namespace Bist_1.Services
{
    /// <summary>
    /// Основные типы коллекций:
    /// Array - неизменяемый массив
    /// List - изменяемый список
    /// Dictionary - словарь ключ-значение
    /// ObservableCollection - изменяемый список, обновляет привязки при изменении числа элементов
    /// HashSet - список уникальных значений
    /// Stack - коллекция, работающая по принципу LIFO (Last In - First Out)
    /// </summary>
    public partial class DataManager : IDataManager
    {
        /// <summary>
        /// Возвращает список пользователей
        /// </summary>
        /// <returns></returns>
        public List<UserInfo> GetUsers()
        {
            return new List<UserInfo>()
            {
                new UserInfo() { Name = "Абрамов", Age = 32 },
                new UserInfo("Сидоров", 18, "sidorov.png") { Category = UserCategories.Admin },
                new UserInfo() { Name = "Селезнёв", Age = 25, Photo = "seleznyov.png" },
            };
        }

        private readonly Dictionary<string, string> _headers = new Dictionary<string, string>()
        {
            ["User-Id"] = "15"
        };


        private List<NewsBlockInfo> _newsBlocks;

        public async Task<List<NewsBlockInfo>> GetNewsBlocks(bool force = false)
        {
            if (_newsBlocks == null || force)
            {
                var response = await RequestHelper.Get(Resources.DefaultHost + "Test/News", _headers);
                var news = JsonHelper.GetObjectFromString<List<NewsBlockInfo>>(response.Content);
                _newsBlocks = new List<NewsBlockInfo>(news);
            }
            return _newsBlocks;
        }

        public async void SetNewEntity(int entityId)
        {
            var response = await RequestHelper.Post(Resources.DefaultHost + "PostTestEntity",
                new EntityIdentifier() { EntityId = entityId, EntityType = "MobileType" });
        }


    }
}
