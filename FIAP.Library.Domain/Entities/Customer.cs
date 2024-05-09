using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public EDocument document { get; set; }

        public virtual ICollection<RentBook> rentBooks { get; set; }
        public virtual ICollection<Reservation> reservations { get; set; }
    }
}
