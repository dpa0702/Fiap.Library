using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public EGenre genre { get; set; }

        public virtual ICollection<RentBook> rentBooks { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
    }
}
