
namespace Checkpoint4_V2
{
    public static class ContactFormFactory
    {
        public static ContactForm Create(string mail, string firstName, string familyName, string phone, string text)
        {
            ContactForm contact = new ContactForm();
            contact.Email = mail;
            contact.FirstName = firstName;
            contact.FamilyName = familyName;
            contact.PhoneNumber = phone;
            contact.Text = text;
            return contact;
        }
    }
}
