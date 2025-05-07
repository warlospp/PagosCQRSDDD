using PagosCQRSDDD.Domain.Entities;
using PagosCQRSDDD.Domain.Interfaces;
using PagosCQRSDDD.Infrastructure.Persistence;

namespace PagosCQRSDDD.Application.Commands
{
    public class PagarCommandHandler
    {
        private readonly IPagoRepository _repository;
        private readonly MongoPagoService _mongoService;
        

        public PagarCommandHandler(IPagoRepository repository, MongoPagoService mongoService)
        {
            _repository = repository;
            _mongoService = mongoService;
        }

        public async Task<int> HandleAsync(PagarCommand command)
        {
            var pago = new Pago(command.ClienteId, command.Monto, command.MetodoPago);
            var id = await _repository.AgregarAsync(pago);
            await _mongoService.InsertarPagoAsync(pago);
            return id;

        }
    }
}