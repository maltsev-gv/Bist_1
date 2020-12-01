using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Bist_1.Models;
using Xamarin.Forms;

namespace Bist_1.ViewModels
{
    public class NewsViewModel : BaseViewModel<NewsBlockInfo>
    {
        public NewsViewModel()
        {
            Task.Run(async () =>
            {
                await Task.Delay(1000);
                Refresh();
            });
        }

        public ICommand RefreshCommand => new Command(Refresh);
        private int _count = 1;

        public override async void Refresh()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;
                var itemsList = await DataManager.GetNewsBlocks(true);
                Items = new ObservableCollection<NewsBlockInfo>(itemsList);
                RaisePropertyChanged(nameof(Items));

                DataManager.SetNewEntity(_count++);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
