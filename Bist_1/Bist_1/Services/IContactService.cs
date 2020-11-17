using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bist_1.Services
{
    public class Contact
    {
        public string Name { get; set; }
        public string[] PhoneNumbers { get; set; }

        public bool IsNumberEqual(string number)
        {
            return PhoneNumbers.Any(pn => Normalize(pn) == Normalize(number));
        }

        private string Normalize(string number)
        {
            return number.Replace("+", "").Replace("-", "").Replace(" ", "");
        }
    }

    public class ContactEventArgs : EventArgs
    {
        public Contact Contact { get; }
        public ContactEventArgs(Contact contact)
        {
            Contact = contact;
        }
    }

    public interface IContactService
    {
        bool IsLoading { get; }
        event EventHandler<Contact> ContactLoaded;
        event EventHandler<IList<Contact>> AllContactsLoaded;
        Task<IList<Contact>> LoadContactsAsync();
    }
}
