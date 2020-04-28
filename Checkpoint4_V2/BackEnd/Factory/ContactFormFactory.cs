using System;

namespace Checkpoint4_V2
{
    public static class ContactFormFactory
    {
        public static ContactForm Create(string mail, string firstName, string name, string telephon, string text)
        {
            ContactForm contact = new ContactForm();
            contact.Email = mail;
            contact.FirstName = firstName;
            contact.Name = name;
            contact.TelephonNumber = telephon;
            contact.Text = text;
            return contact;
        }
    }
}
