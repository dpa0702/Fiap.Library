using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.DTOs
{
    public class NewReservationDto
    {
        public int bookId { get; set; }
        public int customerId { get; set; }
        public EReservation status { get; set; }
    }
}
