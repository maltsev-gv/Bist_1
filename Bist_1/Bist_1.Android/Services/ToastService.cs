using Android.OS;
using Android.Widget;
using Bist_1.Droid.Services;
using Bist_1.Services;
using Application = Android.App.Application;

[assembly: Xamarin.Forms.Dependency(typeof(ToastService))]
namespace Bist_1.Droid.Services
{
    public class ToastService: IToastService
    {
        public void LongAlert(string message)
        {
            ShowToast(message, false);
        }

        public void ShortAlert(string message)
        {
            ShowToast(message, true);
        }

        private static void ShowToast(string message, bool isShort)
        {
            Handler mainHandler = new Handler(Looper.MainLooper);
            Java.Lang.Runnable runnableToast = new Java.Lang.Runnable(() =>
            {
                var duration = isShort ? ToastLength.Short : ToastLength.Long;
                Toast.MakeText(Application.Context, message, duration).Show();
            });

            mainHandler.Post(runnableToast);
        }
    }
}