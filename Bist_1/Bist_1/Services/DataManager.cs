using System;
using System.Collections.Generic;
using System.Text;
using Bist_1.Models;

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
    public class DataManager
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
    }
}
