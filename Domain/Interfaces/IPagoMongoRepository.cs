using PagosCQRSDDD.Domain.Entities;
using System.Threading.Tasks;

namespace PagosCQRSDDD.Domain.Interfaces
{
    public interface IPagoMongoRepository
    {
        Task<Pago?> ObtenerPorIdAsync(int id);
    }
}