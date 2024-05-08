using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.Entities
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
