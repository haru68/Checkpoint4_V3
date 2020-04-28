using System;
using System.Linq;

namespace Checkpoint4_V2
{
    public class Authentification : IAuthentification
    {
        public User LoginUsers(string login, string password)
        {
            String encryptedPassword = Password.Encrypt(password.ToString());

            using (var context = new CircusContext())
            {
                return context.Users.Where(x => x.Login.Equals(login) && x.Password.Equals(encryptedPassword)).SingleOrDefault();
            }
        }

    }
}
