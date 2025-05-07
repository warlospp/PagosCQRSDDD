using MongoDB.Driver;
using PagosCQRSDDD.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace PagosCQRSDDD.Infrastructure.Repositories
{
    public class PagoMongoRepository : IPagoMongoRepository
    {
        private readonly IMongoCollection<PagoMongoDto> _collection;

        public PagoMongoRepository(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["MongoDbSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["MongoDbSettings:DatabaseName"]);
            _collection = database.GetCollection<PagoMongoDto>(configuration["MongoDbSettings:CollectionName"]);
        }

        public async Task<PagoMongoDto?> ObtenerPagoPorIdAsync(int id)
        {
            var filter = Builders<PagoMongoDto>.Filter.Eq(p => p.Id, id);
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }
    }
}