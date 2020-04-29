using System.Linq;

namespace Checkpoint4_V2
{
    public partial class City : AbstractDatabaseRecorder
    {
        public static bool IsInDb(string cityName, string postalCode)
        {
            bool isInDb = true;
            using (var context = new CircusContext())
            {
                isInDb = (from c in context.Cities
                          where c.Name == cityName && c.PostalCode == postalCode
                          select c).Any();
            }
            return isInDb;
        }
    }
}
