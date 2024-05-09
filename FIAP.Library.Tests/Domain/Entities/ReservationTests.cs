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
    public class ReservationTests
    {
        [Test]
        public void TesteReservationNotNull()
        {
            var reservation = new Reservation();

            Assert.IsNotNull(reservation);
        }

        [Test]
        public void TesteReservationReserved()
        {
            var reservation = new Reservation();

            reservation.status = EReservation.Reserved;

            Assert.That(reservation.status, Is.EqualTo(EReservation.Reserved));
        }

        [Test]
        public void TesteReservationBorrowed()
        {
            var reservation = new Reservation();

            reservation.status = EReservation.Borrowed;

            Assert.That(reservation.status, Is.EqualTo(EReservation.Borrowed));
        }

        [Test]
        public void TesteReservationCanceled()
        {
            var reservation = new Reservation();

            reservation.status = EReservation.Canceled;

            Assert.That(reservation.status, Is.EqualTo(EReservation.Canceled));
        }
    }
}
