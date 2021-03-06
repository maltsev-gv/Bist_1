﻿using System;
using System.Globalization;
using Bist_1.ExtensionMethods;
using Bist_1.ViewModels;
using Xamarin.Forms;

namespace Bist_1.Converters
{
    public class EmptyStringToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //return value is MainViewModel mainViewModel && !string.IsNullOrEmpty(mainViewModel.Login);

            //if (value is MainViewModel mainViewModel)
            //{
            //    return !string.IsNullOrEmpty(mainViewModel.Login);
            //}

            var result = value is string strValue && !strValue.IsNullOrEmpty();
            if (parameter is string strParam && strParam.ToLower().StartsWith("r"))
            {
                return !result;
            }

            return result;

            //if (value is string strValue)
            //{
            //    return !string.IsNullOrEmpty(strValue);
            //}

            //return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
