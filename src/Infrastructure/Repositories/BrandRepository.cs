using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class BrandRepository : BaseRepository, IBrandRepository
    {
        private readonly IMongoCollection<Brand> _brands;

        public BrandRepository(IOptions<HomeSalesDatabaseSettings> homeSalesDatabaseSettings)
            : base(homeSalesDatabaseSettings) =>
            _brands = _db.GetCollection<Brand>(_homeSalesDatabaseSettings.Value.BrandCollectionName);

        public async Task AddAsync(Brand item) =>
            await _brands.InsertOneAsync(item);

        public async Task<ICollection<Brand>> GetAsync() =>
            await _brands.Find(Builders<Brand>.Filter.Empty).ToListAsync();

        public async Task<Brand> GetByIdAsync(string id) =>
            await _brands.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task UpdateAsync(Brand item) =>
            await _brands.FindOneAndReplaceAsync(
                Builders<Brand>.Filter.Eq(p => p.Id, item.Id),
                item,
                new FindOneAndReplaceOptions<Brand> { ReturnDocument = ReturnDocument.After });
    }
}