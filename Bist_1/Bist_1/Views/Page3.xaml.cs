using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bist_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page3 : ContentPage
    {
        public Page3()
        {
            InitializeComponent();
        }

        private void Button_ToRootPage_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopToRootAsync();
        }

        private void Button_ToPrevPage_OnClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}