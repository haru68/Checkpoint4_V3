using System.Linq;

namespace Checkpoint4_V2
{
    public partial class User : AbstractDatabaseRecorder
    {
        public static bool IsInDb(string login, string password)
        {
            bool isInDb = true;
            using (var context = new CircusContext())
            {
                isInDb = (from u in context.Users
                          where u.Login == login && u.Password == password
                          select u).Any();
            }
            return isInDb;
        }
    }
}
