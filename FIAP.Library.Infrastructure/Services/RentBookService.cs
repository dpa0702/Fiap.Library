using FIAP.Library.Domain.Entities;
using FIAP.Library.Domain.Enums;
using FIAP.Library.Infrastructure.Repositories;
using FIAP.Library.Infrastructure.Repositories.Interfaces;
using FIAP.Library.Infrastructure.Services.Interfaces;

namespace FIAP.Library.Infrastructure.Services
{
    public class RentBookService : IRentBookService
    {
        private readonly IRentBookRepository _rentBookRepository;

        public RentBookService(IRentBookRepository rentBookRepository)
        {
            _rentBookRepository = rentBookRepository;
        }
        public async Task<IList<RentBook>> GetAll(CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            return await _rentBookRepository.GetAll(ct);
        }

        public async Task<RentBook> GetById(int id, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var RentBook = await _rentBookRepository.GetById(id, ct);

            return RentBook ?? throw new BadHttpRequestException("Locação não encontrada");
        }

        public async Task Add(RentBook RentBook, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            await _rentBookRepository.Insert(RentBook, ct);
        }

        public async Task UpdateStatus(RentBook dto, CancellationToken ct = default)
        {
            ct.ThrowIfCancellationRequested();

            var RentBook = await GetById(dto.Id, ct);

            if (!Enum.IsDefined(typeof(ERentalStatus), dto.status)) throw new BadHttpRequestException("Status Inválido");

            RentBook.status = dto.status;

            await _rentBookRepository.Update(RentBook, ct);
        }
    }
}
