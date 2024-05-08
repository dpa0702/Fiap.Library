using FIAP.Library.Domain.Entities;
using FIAP.Library.Infrastructure.Controllers;
using FIAP.Library.Infrastructure.Services.Interfaces;

namespace FIAP.Library.Tests.Infrastructure.Controllers
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _controller;
        private IBookService _service;

        [Test]
        public void BookControllerTestNotNull()
        {
            _controller = new BookController(_service);
            Assert.IsNotNull(_controller);
        }
    }
}
