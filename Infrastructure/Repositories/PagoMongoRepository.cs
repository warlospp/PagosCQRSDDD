using MongoDB.Driver;
using PagosCQRSDDD.Domain.Entities;
using PagosCQRSDDD.Domain.Interfaces;
using Microsoft.Extensions.Configuration;

namespace PagosCQRSDDD.Infrastructure.Repositories
{
    public class PagoMongoRepository : IPagoMongoRepository
    {
        private readonly IMongoCollection<Pago> _collection;

        public PagoMongoRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoConnection"));
            var database = client.GetDatabase("bddprodserv");
            _collection = database.GetCollection<Pago>("Pagos");
        }

        public async Task<Pago?> ObtenerPagoPorIdAsync(int id)
        {
            var filter = Builders<Pago>.Filter.Eq(p => p.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}