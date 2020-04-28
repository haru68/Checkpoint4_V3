using System;

namespace Checkpoint4_V2
{
    public static class UserFactory
    {
        public static User Create(string login, string password, DateTime birthday, Address address)
        {
            User user = new User();
            user.Login = login;
            user.Password = password;
            user.Birthday = birthday;
            user.Address = address;
            user.RecordInDb();
            return user;
        }

    }
}
