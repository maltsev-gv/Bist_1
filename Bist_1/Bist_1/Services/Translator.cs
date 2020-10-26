using System.Collections.Generic;
using Bist_1.Models;
using Xamarin.Forms;

namespace Bist_1.Services
{
    public class Translator : BindableObject
    {
        private static Languages _language = Languages.English;
        public static Languages Language
        {
            get => _language;
            set
            {
                foreach (var keyValuePair in _translations)
                {
                    switch (keyValuePair.Key.GetType().Name)
                    {
                        case nameof(Label):
                            ((Label) keyValuePair.Key).Text = value == Languages.Russian
                                ? keyValuePair.Value.Russian
                                : keyValuePair.Value.English;
                            break;
                        case nameof(Entry):
                            ((Entry)keyValuePair.Key).Text = value == Languages.Russian
                                ? keyValuePair.Value.Russian
                                : keyValuePair.Value.English;
                            break;
                    }
                }
            }
        }

        private static readonly Dictionary<BindableObject, Translation> _translations = new Dictionary<BindableObject, Translation>();

        public static BindableProperty RussianProperty = BindableProperty.CreateAttached("Russian",
            typeof(string), typeof(Translator), null,
            propertyChanged: OnRussianPropertyChanged);

        private static void OnRussianPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!_translations.ContainsKey(bindable))
            {
                _translations[bindable] = new Translation();
            }

            _translations[bindable].Russian = newvalue as string;
        }

        public static void SetRussian(BindableObject bindable, string value)
        {
            bindable.SetValue(RussianProperty, value);
        }

        public static string GetRussian(BindableObject bindable)
        {
            return (string)bindable.GetValue(RussianProperty);
        }

        public static BindableProperty EnglishProperty = BindableProperty.CreateAttached("English",
            typeof(string), typeof(Translator), null,
            propertyChanged: OnEnglishPropertyChanged);

        private static void OnEnglishPropertyChanged(BindableObject bindable, object oldvalue, object newvalue)
        {
            if (!_translations.ContainsKey(bindable))
            {
                _translations[bindable] = new Translation();
            }

            _translations[bindable].English = newvalue as string;
        }

        public static void SetEnglish(BindableObject bindable, string value)
        {
            bindable.SetValue(EnglishProperty, value);
        }

        public static string GetEnglish(BindableObject bindable)
        {
            return (string)bindable.GetValue(EnglishProperty);
        }

        private class Translation
        {
            public string Russian { get; set; }
            public string English { get; set; }
        }
    }
}
