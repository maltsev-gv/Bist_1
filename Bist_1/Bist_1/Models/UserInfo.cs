using Bist_1.Services;
using Bist_1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Bist_1.Models
{
    public class UserInfo : ObservableObject
    {
        public UserInfo() : this("Нет имени", 100, "NoPhoto")
        {
        }

        public UserInfo(string name, int age, string photo) 
        {
            Name = name;
            Age = age;
            Photo = photo;
        }

        public string Name
        {
            get => GetVal<string>();
            set => SetVal(value, () => DependencyService.Get<IToastService>().LongAlert("Привет, " + value));
        }

        public int Age
        {
            get => GetVal<int>();
            set => SetVal(value);
        }

        public string Photo
        {
            get => GetVal<string>();
            set => SetVal(value);
        }

        public UserCategories Category
        {
            get => GetVal<UserCategories>();
            set => SetVal(value);
        }
    }
}
