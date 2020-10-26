using System.Windows.Input;
using Xamarin.Forms;

namespace Bist_1.Primitives
{
    public partial class ContentButton : ContentView
    {
        private readonly TapGestureRecognizer _tapGestureRecognizer;

        public ContentButton()
        {
            _tapGestureRecognizer = new TapGestureRecognizer();
            GestureRecognizers.Add(_tapGestureRecognizer);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand),
            typeof(ContentButton), null, BindingMode.Default, null, CommandPropertyChanged);

        private static void CommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            //var command1 = (ICommand) newValue;
            //var contentButton1 = (ContentButton) bindable;
            //contentButton1._tapGestureRecognizer.Command = command1;

            if (newValue is ICommand command && bindable is ContentButton contentButton)
            {
                contentButton._tapGestureRecognizer.Command = command;
            }
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object),
            typeof(ContentButton), null, BindingMode.Default, null, CommandParameterPropertyChanged);

        private static void CommandParameterPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is ContentButton contentButton)
            {
                contentButton._tapGestureRecognizer.CommandParameter = newValue;
            }
        }
    }
}