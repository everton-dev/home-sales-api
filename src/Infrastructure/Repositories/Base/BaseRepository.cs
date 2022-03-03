using Domain.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System.Security.Authentication;

namespace Infrastructure.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _db;
        protected readonly IOptions<HomeSalesDatabaseSettings> _homeSalesDatabaseSettings;

        public BaseRepository(IOptions<HomeSalesDatabaseSettings> homeSalesDatabaseSettings)
        {
            _homeSalesDatabaseSettings = homeSalesDatabaseSettings;
            
            var settings = MongoClientSettings.FromUrl(new MongoUrl(_homeSalesDatabaseSettings.Value.ConnectionString));

            settings.SslSettings =
              new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            _client = new MongoClient(settings);
            _db = _client.GetDatabase(_homeSalesDatabaseSettings.Value.DatabaseName);
        }

        public MongoClient GetClient() => _client;
    }
}