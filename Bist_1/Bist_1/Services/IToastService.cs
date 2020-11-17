namespace Bist_1.Services
{
    public interface IToastService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}