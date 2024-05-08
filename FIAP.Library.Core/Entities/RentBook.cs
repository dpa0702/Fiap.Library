using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.Entities
{
    public class RentBook
    {
        public int Id { get; set; }
        public int bookId { get; set; }
        public int customerId { get; set; }
        public DateTime datePossibleLocation { get; set; }
        public ERentalStatus status { get; set; }

        public virtual Customer customers { get; set; }
        public virtual Book books { get; set; }
    }
}
