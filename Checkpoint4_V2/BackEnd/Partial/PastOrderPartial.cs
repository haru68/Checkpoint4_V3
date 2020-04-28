
namespace Checkpoint4_V2
{
    public partial class PastOrder
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
