using FIAP.Library.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Library.Core.DTOs
{
    public class ChangeBookGenreDto
    {
        public int BookId { get; set; }
        public EGenre genre { get; set; }
    }
}
