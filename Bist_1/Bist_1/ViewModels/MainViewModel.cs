using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Bist_1.Annotations;
using Bist_1.Models;
using Bist_1.Services;
using Rcn.Common;

namespace Bist_1.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        private DataManager _dataManager;

        public List<UserInfo> Users { get; private set; }

        public MainViewModel()
        {
            _dataManager = new DataManager();
            Users = _dataManager.GetUsers();
            //object obj = new object();

            //double x = 5.56e12;
            //var t = x.ToString();
            ////obj = Radius;
            //Radius = 2;
            //MyMethod();

        }

        [InitialValue("LightGreen")]
        public string ColorName
        {
            get => GetVal<string>();
            set => SetVal(value);
        }


        public int BasicRadius => 10;

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
