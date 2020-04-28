using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4_V2
{
    public partial class PastOrder
    {
        public void Record()
        {
            using (var context = new CircusContext())
            {
                context.Update(this);
                context.SaveChanges();
            }
        }
    }
}
