namespace Bist_1.Services
{
    public interface ILogService
    {
        void WriteLine(LogTypes logType, string tag, string message);
    }

    public enum LogTypes
    {
        Info,
        Debug,
        Warn,
        Error,
    }
}
