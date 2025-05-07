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
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _collection = database.GetCollection<Pago>(configuration["MongoDbSettings:CollectionName"]);
        }

        public async Task<Pago?> ObtenerPagoPorIdAsync(int id)
        {
            var filter = Builders<Pago>.Filter.Eq(p => p.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}