using System;
using Bist_1.Models;
using Xamarin.Forms;

namespace Bist_1.Converters
{
    public class UserCategorySelector : DataTemplateSelector
    {
        public DataTemplate AdminTemplate { get; set; }
        public DataTemplate CommonTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is UserInfo userInfo)
            {
                return userInfo.Category == UserCategories.Admin
                    ? AdminTemplate
                    : CommonTemplate;
            }
            throw new ArgumentException($"{nameof(UserCategorySelector)}: item is not {nameof(UserInfo)}");
        }
    }
}
