using PagosCQRSDDD.Domain.Entities;
using PagosCQRSDDD.Infrastructure.Repositories;
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
            var monto = Monto.Crear(command.Monto);
            var metodoPago = MetodoPago.Crear(command.MetodoPago);
            var pago = new Pago(command.ClienteId, monto, metodoPago);
            var id = await _repository.AgregarAsync(pago);
            await _mongoService.InsertarPagoAsync(pago);
            return id;
        }
    }
}