using System;

namespace Bist_1.Services
{
    public interface IReceiverAndSender
    {
        //Action<SmsInfo> SmsCreated { get; set; }
        //Action<MessageInfo> MessageSent { get; set; }
        //void SendMessage(MessageInfo message);
        void OnSmsReceived(string sender, string messageBody);
    }
}