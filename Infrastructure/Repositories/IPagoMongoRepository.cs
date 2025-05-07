using PagosCQRSDDD.Domain.Entities;
using System.Threading.Tasks;

namespace PagosCQRSDDD.Infrastructure.Repositories
{
    public interface IPagoMongoRepository
    {
        Task<Pago?> ObtenerPagoPorIdAsync(int id);
    }
}