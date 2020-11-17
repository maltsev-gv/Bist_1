using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Android.Content;
using Android.Database;
using Android.Provider;
using Android.Util;
using Bist_1.Droid.Services;
using Bist_1.Services;
using Xamarin.Essentials;
using Xamarin.Forms;
using Application = Android.App.Application;

[assembly: Dependency(typeof(ContactsService))]
namespace Bist_1.Droid.Services
{
    public class ContactsService : IContactService
    {
        public bool IsLoading { get; private set; }

        public event EventHandler<Contact> ContactLoaded;
        public event EventHandler<IList<Contact>> AllContactsLoaded;

        public async Task<IList<Contact>> LoadContactsAsync()
        {
            var uri = ContactsContract.Contacts.ContentUri;
            var ctx = Application.Context;

            Log.WriteLine(LogPriority.Warn, nameof(ContactsService), 
                $"---- OnReceive: LoadContactsAsync. ctx = {ctx}. ApplicationContext = {ctx?.ApplicationContext}. Uri = {uri}");

            try
            {
                IList<Contact> contacts = new List<Contact>();
                if (Platform.CurrentActivity != null) // Запустились не из фона, попробуем запросить права
                {
                    var hasPermission = await DependencyService.Get<IPermissionService>().RequestPermissionsAsync();
                    if (!hasPermission)
                    {
                        return null;
                    }
                }

                await Task.Run(() =>
                {
                    IsLoading = true;
                    var cursor = ctx.ApplicationContext.ContentResolver.Query(uri, new[]
                    {
                        ContactsContract.Contacts.InterfaceConsts.Id,
                        ContactsContract.Contacts.InterfaceConsts.DisplayName,
                        ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri
                    }, null, null, $"{ContactsContract.Contacts.InterfaceConsts.DisplayName} ASC");
                    if (cursor.Count > 0)
                    {
                        while (cursor.MoveToNext())
                        {
                            var contact = CreateContact(cursor, ctx);

                            if (string.IsNullOrWhiteSpace(contact.Name)) continue;

                            ContactLoaded?.Invoke(this, contact);
                            contacts.Add(contact);
                        }
                    }

                    IsLoading = false;
                    AllContactsLoaded?.Invoke(this, contacts);
                });

                return contacts;
            }
            catch (Exception exception)
            {
                Log.WriteLine(LogPriority.Error, nameof(ContactsService), $"---- OnReceive: LoadContactsAsync: {exception}");
                return null;
            }
        }

        Contact CreateContact(ICursor cursor, Context ctx)
        {
            var contactId = GetString(cursor, ContactsContract.Contacts.InterfaceConsts.Id);

            var numbers = GetNumbers(ctx, contactId);
            //var emails = GetEmails(ctx, contactId);

            //var uri = GetString(cursor, ContactsContract.Contacts.InterfaceConsts.PhotoThumbnailUri);
           
            var contact = new Contact
            {
                Name = GetString(cursor, ContactsContract.Contacts.InterfaceConsts.DisplayName),
                //Emails = emails,
                PhoneNumbers = numbers,
            };

            return contact;
        }


        string[] GetNumbers(Context ctx, string contactId)
        {
            var key = ContactsContract.CommonDataKinds.Phone.Number;

            var cursor = ctx.ApplicationContext.ContentResolver.Query(
                ContactsContract.CommonDataKinds.Phone.ContentUri,
                null,
                ContactsContract.CommonDataKinds.Phone.InterfaceConsts.ContactId + " = ?",
                new[] { contactId },
                null
            );

            return ReadCursorItems(cursor, key)?.ToArray();
        }

        string[] GetEmails(Context ctx, string contactId)
        {
            var key = ContactsContract.CommonDataKinds.Email.InterfaceConsts.Data;

            var cursor = ctx.ApplicationContext.ContentResolver.Query(
                ContactsContract.CommonDataKinds.Email.ContentUri,
                null,
                ContactsContract.CommonDataKinds.Email.InterfaceConsts.ContactId + " = ?",
                new[] { contactId },
                null);

            return ReadCursorItems(cursor, key)?.ToArray();
        }

        IEnumerable<string> ReadCursorItems(ICursor cursor, string key)
        {
            while (cursor.MoveToNext())
            {
                var value = GetString(cursor, key);
                yield return value;
            }

            cursor.Close();
        }

        string GetString(ICursor cursor, string key)
        {
            return cursor.GetString(cursor.GetColumnIndex(key));
        }
    }
}