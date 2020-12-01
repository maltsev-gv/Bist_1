using System.Collections.ObjectModel;
using Bist_1.Services;
using Xamarin.Forms;

namespace Bist_1.ViewModels
{
    public abstract class BaseViewModel<T> : ObservableObject where T: class
    {
        public ObservableCollection<T> Items { get; protected set; }
        public IDataManager DataManager { get; } = DependencyService.Get<IDataManager>();

        public abstract void Refresh();

        public bool IsBusy
        {
            get => GetVal<bool>();
            set => SetVal(value);
        }

    }
}