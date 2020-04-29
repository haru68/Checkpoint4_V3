

namespace Checkpoint4_V2
{
    public partial class Tour : AbstractDatabaseRecorder
    {
        public void BookSeats(int numberOfSeats)
        {
            this.AvailableSeats = this.AvailableSeats - numberOfSeats;
            RecordInDb();
        }

        public void DeBookSeats(int numberOfSeats)
        {
            this.AvailableSeats = this.AvailableSeats + numberOfSeats;
            RecordInDb();
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
