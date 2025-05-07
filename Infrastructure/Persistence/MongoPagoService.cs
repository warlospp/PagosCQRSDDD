using MongoDB.Driver;
using PagosCQRSDDD.Domain.Entities;
using Microsoft.Extensions.Options;

namespace PagosCQRSDDD.Infrastructure.Persistence
{
    public class MongoPagoService
    {
        private readonly IMongoCollection<Pago> _pagosCollection;

        public MongoPagoService(IOptions<MongoDbSettings> mongoSettings)
        {
            var client = new MongoClient(mongoSettings.Value.ConnectionString);
            var database = client.GetDatabase(mongoSettings.Value.DatabaseName);
            _pagosCollection = database.GetCollection<Pago>(mongoSettings.Value.CollectionName);
        }

        public async Task InsertarPagoAsync(Pago pago)
        {
            await _pagosCollection.InsertOneAsync(pago);
        }
    }
}
