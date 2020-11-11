using System;
using System.Windows.Input;
using Bist_1.Primitives;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bist_1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page2 : ContentPage
    {
        public Page2()
        {
            InitializeComponent();
            BackCommand = new Command(BackMethod);
        }

        private void BackMethod(object obj)
        {
            Navigation.PopAsync();
        }

        public ICommand BackCommand
        {
            get => (ICommand)GetValue(BackCommandProperty);
            set => SetValue(BackCommandProperty, value);
        }

        public static readonly BindableProperty BackCommandProperty =
            BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(Page2), null, BindingMode.OneTime);

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {

            base.OnDisappearing();
        }

        protected override bool OnBackButtonPressed()
        {
            //   return base.OnBackButtonPressed();
            return true;
        }

        private void Button_Page3_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Page3() { Title = "New page 3" });
        }

        private void Button_ModalPage_OnClicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NavigationPage(new ModalPage1() { Title = "Modal page" }));
            //Navigation.PushModalAsync(new ModalPage1());
        }
    }
}