using System;
using System.Collections.Generic;
using System.Text;

namespace Checkpoint4_V2
{
    public partial class Tour
    {
        public void BookSeats(int numberOfSeats)
        {
            this.AvailableSeats = this.AvailableSeats - numberOfSeats;
            using (var context = new CircusContext())
            {
                context.Update(this);
                context.SaveChanges();
            }
        }

        public void DeBookSeats(int numberOfSeats)
        {
            this.AvailableSeats = this.AvailableSeats + numberOfSeats;
            using (var context = new CircusContext())
            {
                context.Update(this);
                context.SaveChanges();
            }
        }

        public bool IsEnoughAvailableSeats(int wishedSeats)
        {
            if((this.AvailableSeats - wishedSeats) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
