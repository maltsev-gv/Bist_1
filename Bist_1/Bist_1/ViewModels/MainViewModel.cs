using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Bist_1.Annotations;
using Bist_1.ExtensionMethods;
using Bist_1.Models;
using Bist_1.Services;
using Rcn.Common;
using Xamarin.Forms;

namespace Bist_1.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private DataManager _dataManager;

        public ObservableCollection<UserInfo> Users { get; } 

        public MainViewModel()
        {
            _dataManager = new DataManager();
            Users = new ObservableCollection<UserInfo>(_dataManager.GetUsers());
            Users.CollectionChanged += Users_CollectionChanged;
            ChangeRadiusCommand = new Command(obj => ChangeRadiusMethod(obj, true));
            //object obj = new object();

            //double x = 5.56e12;
            //var t = x.ToString();
            ////obj = Radius;
            //Radius = 2;
            //MyMethod();

        }

        private void Users_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine(nameof(Users_CollectionChanged));
        }

        private void ChangeRadiusMethod(object obj, bool isEnabled)
        {
            Users.CollectionChanged -= Users_CollectionChanged2;
            Users.CollectionChanged += Users_CollectionChanged2;
            var rad = Radius;
            Radius = rad.IsDoubleEqual(30)
                ? 100
                : rad.IsDoubleEqual(100)
                    ? 50
                    : 30;
            ColorName = ColorName == "Aqua" ? "Magenta" : "Aqua";
            Users.Add(new UserInfo("Джон Смит", 45, ""));
            //RaisePropertyChanged(nameof(Users));
        }

        private void Users_CollectionChanged2(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine(nameof(Users_CollectionChanged2));
        }

        public ICommand ChangeRadiusCommand { get; } 

        [InitialValue("LightGreen")]
        public string ColorName
        {
            get => GetVal<string>();
            set => SetVal(value);
        }


        public static int BasicRadius => 10;

        public double Radius
        {
            get
            {
                SetInitialVal((double)BasicRadius);
                return GetVal<double>();
            }
            set
            {
                SetVal(value);
                var classString = this.ToString();
            }
        }

        public string Login
        {
            get => GetVal<string>();
            set => SetVal(value);
        }

        //public string Login
        //{
        //    get => GetVal<string>();
        //    set => SetVal(value, () => IsButtonEnabled = !string.IsNullOrEmpty(value));
        //}

        //public bool IsButtonEnabled
        //{
        //    get => GetVal<bool>();
        //    set => SetVal(value);
        //}

        public void MyMethod()
        {
            RaisePropertyChanged();
        }

        //private double _radius = 30;
        //public double Radius
        //{
        //    get => _radius;
        //    set
        //    {
        //        _radius = value;
        //        OnPropertyChanged(nameof(Radius));
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //[NotifyPropertyChangedInvocator]
        //protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }
}
