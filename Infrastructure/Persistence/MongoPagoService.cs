using MongoDB.Driver;
using PagosCQRSDDD.Domain.Entities;
using Microsoft.Extensions.Options;

namespace PagosCQRSDDD.Infrastructure.Persistence
{
    public class MongoPagoService
    {
        private readonly IMongoCollection<PagoMongoDto> _pagosCollection;

        public MongoPagoService(IOptions<MongoDbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _pagosCollection = database.GetCollection<PagoMongoDto>(mongoSettings.Value.CollectionName);
        }

        public async Task InsertarPagoAsync(Pago pago)
        {
            var dto = new PagoMongoDto
            {
                Id = pago.Id,
                ClienteId = pago.ClienteId,
                Monto = (double)pago.Monto.Valor,
                FechaPago = pago.FechaPago,
                MetodoPago = pago.MetodoPago.Valor,
                Estado = pago.Estado
            };
            await _pagosCollection.InsertOneAsync(dto);
        }
    }
}
