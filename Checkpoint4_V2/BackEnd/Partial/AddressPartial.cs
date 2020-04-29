﻿using System.Linq;

namespace Checkpoint4_V2
{
    public partial class Address : AbstractDatabaseRecorder
    {
        public static bool IsInDb(short streetNumber, string streetName, City city)
        {
            bool isInDb = true;
            using (var context = new CircusContext())
            {
                isInDb = (from a in context.Addresses
                          where a.City == city && a.StreetName == streetName && a.StreetNumber == streetNumber
                          select a).Any();
            }
            return isInDb;
        }
    }
}
