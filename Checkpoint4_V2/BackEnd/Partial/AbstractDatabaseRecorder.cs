using System;

namespace Checkpoint4_V2
{
    public class AbstractDatabaseRecorder
    {
        public void RecordInDb()
        {
            using (var context = new CircusContext())
            {
                context.Update(this);
                context.SaveChanges();
            }
        }
    }
}
