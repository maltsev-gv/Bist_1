using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Bist_1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace Bist_1.Services
{
    public class Translator : BindableObject
    {
        public string LanguageStr { get; set; }

        private static Languages _language = Languages.English;
        public static Languages Language
        {
            get => _language;
            set
            {
                var translatorType = typeof(Translator);
                var translatorProps = translatorType.GetProperties();
                translatorProps = translatorType.GetProperties(BindingFlags.Instance | BindingFlags.Public);

                foreach (var keyValuePair in _translations)
                {
                    var elemType = keyValuePair.Key.GetType();
                    var props = elemType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    var piText = props.FirstOrDefault<PropertyInfo>(pi => pi.Name == "Text" && pi.CanWrite);

                    //var propsForReadOnly = props.Where(pi => !pi.CanWrite).ToList();
                    //var pi2 = propsForReadOnly.Find(pi => pi.Name == "Text");

                    if (piText != null)
                    {
                        var text = piText.GetValue(keyValuePair.Key);

                        var z = default(BindingFlags);
                        piText.SetValue(keyValuePair.Key, 
                            value == Languages.Russian
                                    ? keyValuePair.Value.Russian
                                    : keyValuePair.Value.English);

                        text = piText.GetValue(keyValuePair.Key);
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
