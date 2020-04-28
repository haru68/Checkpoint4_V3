using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Checkpoint4_V2
{
    public class ContactForm
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string TelephonNumber { get; set; }
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
