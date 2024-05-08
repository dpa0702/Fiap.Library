using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;

namespace FIAP.Library.Tests.Domain.Entities
{
    [TestFixture]
    public class BookTests
    {
        [Test]
        public void TesteBookNotNull()
        {
            var book = new Book();

            Assert.IsNotNull(book);
        }

        [Test]
        public void TesteBookGenreHorror()
        {
            var book = new Book();

            book.genre = EGenre.Horror;

            Assert.That(EGenre.Horror, Is.EqualTo(book.genre));
        }
    }
}
