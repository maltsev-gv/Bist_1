using System;
using Bist_1.Droid.Services;
using Bist_1.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(SmsService))]
namespace Bist_1.Droid.Services
{
    public class SmsService : ISmsService
    {
        private Action<string, string> _smsReceived;

        public Action<string, string> SmsReceived
        {
            get => _smsReceived;
            set
            {
                _smsReceived = value;
                SmsReceiver.SmsReceivedInner = value;
            }
        }
    }
}