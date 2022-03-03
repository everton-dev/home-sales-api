using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class ProductRepository : BaseRepository, IProductRepository
    {
        private readonly IMongoCollection<Product> _products;

        public ProductRepository(IOptions<HomeSalesDatabaseSettings> homeSalesDatabaseSettings)
            :base(homeSalesDatabaseSettings) =>
            _products = _db.GetCollection<Product>(_homeSalesDatabaseSettings.Value.ProductCollectionName);

        public async Task AddAsync(Product item) =>
            await _products.InsertOneAsync(item);

        public async Task<ICollection<Product>> GetAsync() =>
            await _products.Find(Builders<Product>.Filter.Empty).ToListAsync();

        public async Task<Product> GetByIdAsync(string id) =>
            await _products.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task UpdateAsync(Product item) =>
            await _products.FindOneAndReplaceAsync(
                Builders<Product>.Filter.Eq(p => p.Id, item.Id),
                item,
                new FindOneAndReplaceOptions<Product> { ReturnDocument = ReturnDocument.After });
    }
}