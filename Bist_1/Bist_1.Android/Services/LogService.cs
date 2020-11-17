using Android.Util;
using Bist_1.Droid.Services;
using Bist_1.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(LogService))]
namespace Bist_1.Droid.Services
{
    public class LogService : ILogService
    {
        public void WriteLine(LogTypes logType, string tag, string message)
        {

            var priority = logType == LogTypes.Debug
                ? LogPriority.Debug
                : logType == LogTypes.Error
                    ? LogPriority.Error
                    : logType == LogTypes.Warn
                        ? LogPriority.Warn
                        : LogPriority.Info;
            Log.WriteLine(priority, tag, message);
        }
    }
}