using FIAP.Library.Core.Enums;

namespace FIAP.Library.Core.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int customerId { get; set; }
        public EReservation status { get; set; }

        public virtual Customer customers { get; set; }
        public virtual Book books { get; set; }
    }
}
