using Domain.Interfaces.Repositories;
using Domain.Models;
using Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Infrastructure.Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        private readonly IMongoCollection<Room> _rooms;
        
        public RoomRepository(IOptions<HomeSalesDatabaseSettings> homeSalesDatabaseSettings)
            : base(homeSalesDatabaseSettings) =>
            _rooms = _db.GetCollection<Room>(_homeSalesDatabaseSettings.Value.RoomCollectionName);

        public async Task AddAsync(Room item) =>
            await _rooms.InsertOneAsync(item);

        public async Task<ICollection<Room>> GetAsync() =>
            await _rooms.Find(Builders<Room>.Filter.Empty).ToListAsync();

        public async Task<Room> GetByIdAsync(string id) =>
            await _rooms.Find(p => p.Id.Equals(id)).FirstOrDefaultAsync();

        public async Task UpdateAsync(Room item) =>
            await _rooms.FindOneAndReplaceAsync(
                Builders<Room>.Filter.Eq(p => p.Id, item.Id),
                item,
                new FindOneAndReplaceOptions<Room> { ReturnDocument = ReturnDocument.After });
    }
}