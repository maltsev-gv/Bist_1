using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Telephony;
using Android.Util;
using Bist_1.ExtensionMethods;
using Bist_1.Services;
using Xamarin.Forms;

namespace Bist_1.Droid.Services
{
    [BroadcastReceiver(DirectBootAware = true, Enabled = true, Exported = true, Permission = "android.permission.BROADCAST_SMS")]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" }, Priority = int.MaxValue)/*(int)IntentFilterPriority.HighPriority)*/]
    public class SmsReceiver : BroadcastReceiver
    {
        private const string _intentAction = "android.provider.Telephony.SMS_RECEIVED";

        public static Action<string, string> SmsReceivedInner;

        public override void OnReceive(Context context, Intent intent)
        {
            Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver), $"- OnReceive: Started sms handler. SmsReceiver.Hash = {GetHashCode()}");
            try
            {
                if (intent.Action != _intentAction)
                {
                    return;
                }
                var bundle = intent.Extras;
                if (bundle == null)
                {
                    return;
                }

                try
                {
                    var smsArray = (Java.Lang.Object[])bundle.Get("pdus");

                    var dict = new Dictionary<string, string>();
                    foreach (var item in smsArray)
                    {
                        string format = bundle.GetString("format");
                        var sms = SmsMessage.CreateFromPdu((byte[])item, format);
                        Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver), 
                            $"---- OnReceive: sms {sms.MessageBody}");
                        if (!dict.ContainsKey(sms.OriginatingAddress))
                        {
                            dict[sms.OriginatingAddress] = sms.MessageBody;
                        }
                        else
                        {
                            dict[sms.OriginatingAddress] += sms.MessageBody;
                        }

                    }

                    if (SmsReceivedInner == null)
                    {
                        Task.Run(() =>
                        {
                            Forms.Init(context, bundle);
                            Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver), $"---- OnReceive: Forms.Init");
                            var dataStore = DependencyService.Get<IDataStore>();
                            Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver),
                                $"---- OnReceive: DataStore = {dataStore.GetHashCode()}");
                            dataStore.LoadConfig();
                            Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver), $"---- OnReceive: LoadConfig");

                            //if (!dataStore.SenderSettings.IsBackgroundSender)
                            //{
                            //    return;
                            //}

                            var receiverAndSender = DependencyService.Get<IReceiverAndSender>();
                            Log.WriteLine(LogPriority.Warn, nameof(SmsReceiver),
                                $"---- OnReceive: IReceiverAndSender created");
                            dict.ForEach(kvp =>
                            {
                                receiverAndSender.OnSmsReceived(kvp.Key, kvp.Value);
                            });

                        });
                    }
                    else
                    {
                        dict.ForEach(kvp =>
                        {
                            SmsReceivedInner.BeginInvoke(kvp.Key, kvp.Value,null, null);
                        });
                    }
                }
                catch (Exception ex)
                {
                    Log.WriteLine(LogPriority.Error, nameof(SmsReceiver), $"---- OnReceive: exception {ex}");
                }
            }
            catch (Exception ex)
            {
                Log.Debug(nameof(SmsReceiver), ex.Message);
            }
        }
    }
}
