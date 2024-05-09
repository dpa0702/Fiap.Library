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
        public void TesteBookGenreFantasy()
        {
            var book = new Book();

            book.genre = EGenre.Fantasy;

            Assert.That(book.genre, Is.EqualTo(EGenre.Fantasy));
        }

        [Test]
        public void TesteBookGenreSelfhelpr()
        {
            var book = new Book();

            book.genre = EGenre.Selfhelp;

            Assert.That(book.genre, Is.EqualTo(EGenre.Selfhelp));
        }

        [Test]
        public void TesteBookGenreHorror()
        {
            var book = new Book();

            book.genre = EGenre.Horror;

            Assert.That(book.genre, Is.EqualTo(EGenre.Horror));
        }

        [Test]
        public void TesteBookGenreTrip()
        {
            var book = new Book();

            book.genre = EGenre.Trip;

            Assert.That(book.genre, Is.EqualTo(EGenre.Trip));
        }

        [Test]
        public void TesteBookGenreRomance()
        {
            var book = new Book();

            book.genre = EGenre.Romance;

            Assert.That(book.genre, Is.EqualTo(EGenre.Romance));
        }
    }
}
