using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bist_1.ViewModels;
using Xamarin.Forms;

namespace Bist_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            var context = ((Button) sender).BindingContext;
            var viewModel = context as MainViewModel;
            var rad = viewModel?.Radius;
            if (viewModel != null)
            {
                viewModel.Radius = rad == 30
                    ? 100
                    : rad == 100
                        ? 50
                        : 30;
                viewModel.ColorName = viewModel.ColorName == "Aqua" ? "Magenta" : "Aqua";
            }
        }
    }
}
