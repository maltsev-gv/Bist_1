using System;

namespace Bist_1.Services
{
    public interface ISmsService
    {
        Action<string, string> SmsReceived { get; set; }
    }
}
