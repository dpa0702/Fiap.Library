using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Domain.DTOs
{
    public class ChangeBookGenreDto
    {
        public int BookId { get; set; }
        public EGenre genre { get; set; }
    }
}
