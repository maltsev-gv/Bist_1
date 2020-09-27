using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Bist_1.Annotations;
using Rcn.Common;

namespace Bist_1.ViewModels
{
    public class MainViewModel : ObservableObject
    {
        public MainViewModel()
        {
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

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
