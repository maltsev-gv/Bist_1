using System.Threading.Tasks;
using Android;
using Android.Content.PM;
using Android.Support.V4.App;
using Bist_1.Droid.Services;
using Bist_1.Services;
using Xamarin.Essentials;

[assembly: Xamarin.Forms.Dependency(typeof(PermissionService))]

namespace Bist_1.Droid.Services
{
    public class PermissionService : IPermissionService
    {
        private const int _requestContacts = 1239;
        private const int _requestReadSms = 3004;

        private static readonly string[] _permissions =
        {
            Manifest.Permission.ReadContacts,
            Manifest.Permission.ReadSms,
            Manifest.Permission.BroadcastSms,
            Manifest.Permission.ReceiveSms,
            Manifest.Permission.WriteSms,
            Manifest.Permission.ReceiveBootCompleted,
        };

        void RequestPermissions()
        {
            if (!ActivityCompat.ShouldShowRequestPermissionRationale(Platform.CurrentActivity, Manifest.Permission.ReadContacts))
            {

                // Contact permissions have not been granted yet. Request them directly.
                ActivityCompat.RequestPermissions(Platform.CurrentActivity, _permissions, _requestReadSms);
                //ActivityCompat.RequestPermissions(Platform.CurrentActivity, _permissions, _requestContacts);
            }
        }

        public async Task<bool> RequestPermissionsAsync()
        {
            // Verify that all required contact permissions have been granted.

            if (Android.Support.V4.Content.ContextCompat.CheckSelfPermission(Platform.CurrentActivity, Manifest.Permission.ReadContacts) != (int)Permission.Granted
                || Android.Support.V4.Content.ContextCompat.CheckSelfPermission(Platform.CurrentActivity, Manifest.Permission.ReadSms) != (int)Permission.Granted
                || Android.Support.V4.Content.ContextCompat.CheckSelfPermission(Platform.CurrentActivity, Manifest.Permission.ReceiveBootCompleted) != (int)Permission.Granted)
            {
                // Contacts permissions have not been granted.
                RequestPermissions();
            }
            else
            {
                // Contact permissions have been granted. 
                return await Task.FromResult(true);
            }

            return await Task.FromResult(false);
        }
    }
}