using System.Linq;
using Bist_1.Models;
using Bist_1.Services;
using Bist_1.ViewModels;
using Xamarin.Forms;

namespace Bist_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Translator.Language = Languages.English;
        }

        //private void Button_OnClicked(object sender, EventArgs e)
        //{
        //    var context = ((Button) sender).BindingContext;
        //    var viewModel = context as MainViewModel;
        //    var rad = viewModel?.Radius;
        //    if (viewModel != null)
        //    {
        //        viewModel.Radius = rad == 30
        //            ? 100
        //            : rad == 100
        //                ? 50
        //                : 30;
        //        viewModel.ColorName = viewModel.ColorName == "Aqua" ? "Magenta" : "Aqua";
        //    }
        //}

        private void ListView_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var res1 = mainPage.Resources["labelUnderlinedStyle"];
            var resources = mainPage.Resources.ToList();
            var styles = mainPage.Resources.Values.OfType<Style>().ToList();


            var userInfo = e.Item as UserInfo;

            var context = mainPage.BindingContext;
            var viewModel = context as MainViewModel;
            viewModel.Login = userInfo.Name;
        }
    }
}
