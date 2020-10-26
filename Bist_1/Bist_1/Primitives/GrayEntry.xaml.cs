using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bist_1.Primitives
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrayEntry : ContentView
    {
        public GrayEntry()
        {
            InitializeComponent();
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(GrayEntry), null, BindingMode.TwoWay, propertyChanged: OnTextChanged);

        private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var grayEntry = (GrayEntry)bindable;
            grayEntry.frame.BorderColor = grayEntry.Text?.Length > 5 ? Color.Crimson : Color.Gray;
            //grayEntry.Text != null && grayEntry.Text.Length > 5 ? Color.Crimson : Color.Gray;
        }

        public string Prompt
        {
            get => (string)GetValue(PromptProperty);
            set => SetValue(PromptProperty, value);
        }

        public static readonly BindableProperty PromptProperty =
            BindableProperty.Create(nameof(Prompt), typeof(string), typeof(GrayEntry));

        public bool IsPassword
        {
            get => (bool)GetValue(IsPasswordProperty);
            set => SetValue(IsPasswordProperty, value);
        }

        public static readonly BindableProperty IsPasswordProperty =
            BindableProperty.Create(nameof(IsPassword), typeof(bool), typeof(GrayEntry));

        public Keyboard Keyboard
        {
            get => (Keyboard)GetValue(KeyboardProperty);
            set => SetValue(KeyboardProperty, value);
        }

        public static readonly BindableProperty KeyboardProperty =
            BindableProperty.Create(nameof(Keyboard), typeof(Keyboard), typeof(GrayEntry), Keyboard.Text, BindingMode.TwoWay, propertyChanged: OnKeyboardChanged);

        private static void OnKeyboardChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var grayEntry = (GrayEntry) bindable;
            if (grayEntry.Keyboard == Keyboard.Numeric)
            { 
            }
        }

        private void ImageButton_OnPressed(object sender, EventArgs e)
        {
            var pos = entry.CursorPosition;
            entry.IsPassword = false;
            entry.CursorPosition = pos;
        }

        private void ImageButton_OnReleased(object sender, EventArgs e)
        {
            var pos = entry.CursorPosition;
            entry.IsPassword = true;
            entry.CursorPosition = pos;
        }
    }
}
