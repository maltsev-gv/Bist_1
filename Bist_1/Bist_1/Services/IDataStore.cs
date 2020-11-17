using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bist_1.Services
{
    public interface IDataStore
    {
        //ObservableCollection<SmsInfo> SmsInfos { get; }
        //ObservableCollection<AddressInfo> AddressInfos { get; }
        //ObservableCollection<MessageInfo> MessageInfos { get; }
        //SenderSettingsInfo SenderSettings { get; }
        //List<Contact> Contacts { get; }
        //Action ActiveAddressesChanged { get; set; }

        //IList GetCollection<T>() where T : BaseModel;
        void LoadConfig();
        void DeleteMessagesFromSmsIds(int[] deletingSmsIds);
        void StoreConfig();
    }
}
