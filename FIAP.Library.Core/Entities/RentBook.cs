using FIAP.Library.Core.Enums;

namespace FIAP.Library.Core.Entities
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
