using PagosCQRSDDD.Domain.Entities;
using PagosCQRSDDD.Domain.Interfaces;

namespace PagosCQRSDDD.Application.Commands
{
    public class PagarCommandHandler
    {
        private readonly IPagoRepository _repository;

        public PagarCommandHandler(IPagoRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> HandleAsync(PagarCommand command)
        {
            var pago = new Pago(command.ClienteId, command.Monto, command.MetodoPago);
            return await _repository.AgregarAsync(pago);
        }
    }
}