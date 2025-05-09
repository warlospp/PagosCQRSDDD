using PagosCQRSDDD.Domain.Entities;

namespace PagosCQRSDDD.Infrastructure.Repositories
{
    public interface IPagoRepository
    {
        Task<int> AgregarAsync(Pago pago);
        Task<IEnumerable<Pago>> ObtenerTodosAsync();
        Task<IEnumerable<Pago>> ObtenerPorClienteAsync(string clienteId);
    }
}