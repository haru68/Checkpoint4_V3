

namespace Checkpoint4_V2
{
    public class ContactForm
    {
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Text { get; set; }

        public bool SendForm()
        {
            try
            {
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
