using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FIAP.Library.Tests.Domain.Entities
{
    [TestFixture]
    public class CustomerTests
    {
        [Test]
        public void TesteCustomerkNotNull()
        {
            var customer = new Customer();

            Assert.IsNotNull(customer);
        }

        [Test]
        public void TesteCustomerDocumentRG()
        {
            var customer = new Customer();

            customer.document = EDocument.RG;

            Assert.That(customer.document, Is.EqualTo(EDocument.RG));
        }

        [Test]
        public void TesteCustomerDocumentCPF()
        {
            var customer = new Customer();

            customer.document = EDocument.CPF;

            Assert.That(customer.document, Is.EqualTo(EDocument.CPF));
        }

        [Test]
        public void TesteCustomerDocumentCNH()
        {
            var customer = new Customer();

            customer.document = EDocument.CNH;

            Assert.That(customer.document, Is.EqualTo(EDocument.CNH));
        }

        [Test]
        public void TesteCustomerDocumentPASSPORT()
        {
            var customer = new Customer();

            customer.document = EDocument.PASSPORT;

            Assert.That(customer.document, Is.EqualTo(EDocument.PASSPORT));
        }
    }
}
